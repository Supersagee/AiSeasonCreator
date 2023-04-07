using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aydsko.iRacingData;
using Aydsko.iRacingData.Series;
using AiSeasonCreator.ScheduleClasses;
using Microsoft.Extensions.DependencyInjection;
using AiSeasonCreator.JsonClasses.TrackDetails;
using System.Reflection;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.CarDetails;
using System.Diagnostics;
using AiSeasonCreator.Roster;

namespace AiSeasonCreator
{
    public class IRacingService
    {
        private readonly IDataClient dataClient;
        public IRacingService(IDataClient dataClient)
        {
            this.dataClient = dataClient;
        }

        public static IRacingService IRacingServiceLogin { get; set; }
        public Task<IRacingService> GetCurrentSeason { get; set; }
        public Aydsko.iRacingData.Common.DataResponse<SeasonSeries[]> SeasonSeries { get; set; }
        public dynamic CarInfo { get; set; }
        public List<CarSettings> CarSettingsList { get; set; } = new List<CarSettings>();
        public static List<string> CurrentSeries { get; set; }
        public static List<int> CarClassIds { get; set; }
        public static List<int> CarIds { get; set; }

        public static async Task<bool> LoginWindow(string userName, string password)
        {
            var services = new ServiceCollection();
            services.AddIRacingDataApi(options =>
            {
                options.Username = userName;
                options.Password = password;
            });

            var provider = services.BuildServiceProvider();
            var appScope = provider.CreateScope();
            var iRacingClient = provider.GetRequiredService<IDataClient>();

            IRacingServiceLogin = new IRacingService(iRacingClient);

            try
            {
                var isLoggedIn = await IRacingServiceLogin.dataClient.GetMyInfoAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task SetCurrentSeason()
        {
            SeasonSeries = await dataClient.GetSeasonsAsync(true);
        }

        public async Task SetCars()
        {
            if (MainForm.OfflineMode)
            {
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var jsonFilePath = Path.Combine(basePath, "JsonFiles", "carsJson.json");
                CarInfo = JsonSerializer.Deserialize<List<CarDetails>>(File.ReadAllText(jsonFilePath)).ToArray();
            }
            else
            {
                CarInfo = await dataClient.GetCarsAsync();
                CarInfo = CarInfo.Data;
            }
        }

        public async Task<List<string>> GetAllSeries()
        {
            var list = new List<string>();
            //dynamic seriesCheck;
            var getSeriesNames = await dataClient.GetSeasonsAsync(true);

            //if (MainForm.OfflineMode)
            //{
            //    var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //    var jsonFilePath = Path.Combine(basePath, "JsonFiles", "seriesListJson.json");
            //    seriesCheck = JsonSerializer.Deserialize<List<SeriesDetails>>(File.ReadAllText(jsonFilePath)).ToArray();
            //}
            //else
            //{
            //    seriesCheck = await dataClient.GetSeriesAsync();
            //    seriesCheck = seriesCheck.Data;
            //}

            for (var i =  0; i < getSeriesNames.Data.Length; i++)
            {
                if (getSeriesNames.Data[i].Schedules[0].Track.Category == "oval" || getSeriesNames.Data[i].Schedules[0].Track.Category == "road")
                {
                    list.Add(getSeriesNames.Data[i].Schedules[0].SeriesName);
                }
            }

            list.Sort();
            return list;
        }

        public async Task CreateCarSettings()
        {
            var seasonSchedule = SeasonSeries.Data;
            var carIds = new List<int>();
            CarSettingsList.Clear();

            for (var i = 0; i < seasonSchedule.Length; i++)
            {
                if (seasonSchedule[i].Schedules[0].SeriesName == MainForm.SeriesName)
                {                  
                    for (var j = 0; j < seasonSchedule[i].Schedules[0].CarRestrictions.Length; j++)
                    {
                        carIds.Add(seasonSchedule[i].Schedules[0].CarRestrictions[j].CarId);
                        var carSettings = new CarSettings();
                        carSettings.CarId = seasonSchedule[i].Schedules[0].CarRestrictions[j].CarId;
                        carSettings.MaxPctFuelFill = Convert.ToInt32(seasonSchedule[i].Schedules[0].CarRestrictions[j].MaxPercentFuelFill);
                        carSettings.MaxDryTireSets = seasonSchedule[i].Schedules[0].CarRestrictions[j].MaxDryTireSets;
                        CarSettingsList.Add(carSettings);
                    }
                }
            }
        }

        public static ScheduleClasses.TrackState CreateTrackState()
        {
            var trackState = new ScheduleClasses.TrackState();

            trackState.LeaveMarbles = false;
            trackState.PracticeRubber = -1;
            trackState.QualifyRubber = -1;
            trackState.RaceRubber = -1;
            trackState.WarmupRubber = -1;
                
            return trackState;
        }

        public async Task<ScheduleClasses.Weather> CreateWeather()
        {
            var weather = new ScheduleClasses.Weather();

            for (var i = 0; i < SeasonSeries.Data.Length; i++)
            {
                var ss = SeasonSeries.Data[i].Schedules[0].Weather;

                if (SeasonSeries.Data[i].Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    weather.Type = ss.Type;
                    weather.TempUnits = ss.TempUnits;
                    weather.TempValue = ss.TempValue;
                    weather.RelHumidity = ss.RelHumidity;
                    weather.Fog = ss.Fog;
                    weather.WindDir = ss.WindDir;
                    weather.WindUnits = ss.WindUnits;
                    weather.WindValue = ss.WindValue;
                    weather.Skies = ss.Skies;
                    weather.SimulatedStartTime = ss.SimulatedStartTime;
                    weather.SimulatedTimeMultiplier = ss.SimulatedTimeMultiplier;
                    weather.SimulatedTimeOffsets = ss.SimulatedTimeOffsets.ToList();
                    weather.Version = ss.Version;
                    weather.WeatherVarInitial = ss.WeatherVarInitial;
                    weather.WeatherVarOngoing = ss.WeatherVarOngoing;
                    weather.TimeOfDay = ss.TimeOfDay;
                }
            }

            return weather;
        }

        public async Task<List<Events>> CreateEvents()
        {
            var events = new List<Events>();
            dynamic tracks;
            var notAllowedTracks = new List<int>();

            if (MainForm.OfflineMode)
            {
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var jsonFilePath = Path.Combine(basePath, "JsonFiles", "tracksJson.json");
                tracks = JsonSerializer.Deserialize<List<TrackDetails>>(File.ReadAllText(jsonFilePath)).ToArray();
            }
            else
            {
                tracks = await dataClient.GetTracksAsync();
                tracks = tracks.Data;
            }

            for (var i = 0; i < tracks.Length; i++)
            {
                if (!tracks[i].AiEnabled)
                {
                    notAllowedTracks.Add(tracks[i].TrackId);
                }                
            }

            for (var i = 0; i < SeasonSeries.Data.Length; i++)
            {
                var ss = SeasonSeries.Data[i];

                if (ss.Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    for (var j = 0; j < SeasonSeries.Data[i].Schedules.Length; j++)
                    {
                        if (!notAllowedTracks.Contains(SeasonSeries.Data[i].Schedules[j].Track.TrackId))
                        {
                            var loopEvent = new Events();
                            loopEvent.TrackId = ss.Schedules[j].Track.TrackId;
                            loopEvent.NumOptLaps = 0;
                            loopEvent.PaceCar = await CreatePaceCar();
                            loopEvent.ShortParadeLap = false;
                            loopEvent.MustUseDiffTireTypesInRace = ss.MustUseDiffTireTypesInRace;
                            loopEvent.Subsessions = new List<int> { 3, 5, 6 };
                            loopEvent.EventId = Guid.NewGuid().ToString();

                            if (ss.Schedules[j].RaceLapLimit == null)
                            {
                                loopEvent.RaceLaps = 0;
                                loopEvent.RaceLength = ss.Schedules[j].RaceTimeLimit;
                                loopEvent.RaceLengthType = 2;
                            }
                            else
                            {
                                loopEvent.RaceLaps = ss.Schedules[j].RaceLapLimit;
                                loopEvent.RaceLength = 0;
                                loopEvent.RaceLengthType = 3;
                            }

                            loopEvent.Weather = await CreateWeather();
                            loopEvent.TimeOfDay = ss.Schedules[j].Weather.TimeOfDay;

                            events.Add(loopEvent);
                        }
                        else
                        {
                            MainForm.NotAvailableTracks.Add($"{SeasonSeries.Data[i].Schedules[j].Track.TrackName} - {SeasonSeries.Data[i].Schedules[j].Track.ConfigName}");
                        }
                    }
                }
            }

            return events;
        }

        public async Task<List<string>> PopulateCarComboBox()
        {
            var cc = await dataClient.GetCarClassesAsync();
            var cars = await dataClient.GetCarsAsync();
            var ccd = cc.Data;
            var carClassIds = new List<int>();
            var carIds = new List<int>();
            var carNames = new List<string>();

            for (var i = 0; i < SeasonSeries.Data.Length; i++)
            {
                if (SeasonSeries.Data[i].Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    for (var j = 0; j < SeasonSeries.Data[i].CarClassIds.Length; j++)
                    {
                        carClassIds.Add(SeasonSeries.Data[i].CarClassIds[j]);
                    }
                }
            }
            var breakpoint = "";
            for (var i = 0; i < ccd.Length; i++)
            {
                for (var j = 0; j < carClassIds.Count; j++)
                {
                    if (ccd[i].CarClassId == carClassIds[j])
                    {
                        for (var k = 0; k < ccd[i].CarsInClass.Length; k++)
                        {
                            carIds.Add(ccd[i].CarsInClass[k].CarId);
                        }                        
                    }
                }
            }
            breakpoint = "";
            for (var i = 0; i < cars.Data.Length; i++)
            {
                for (var j = 0; j < carIds.Count; j++)
                {
                    if (cars.Data[i].CarId == carIds[j])
                    {
                        carNames.Add(cars.Data[i].CarName);
                    }
                }
            }

            IRacingService.CarIds = carIds;
            IRacingService.CarClassIds = carClassIds;
            return carNames;
        }

        public async Task<PaceCar> CreatePaceCar()
        {
            var paceCar = new PaceCar();

            for (var i = 0; i < SeasonSeries.Data.Length; i++)
            {
                if (SeasonSeries.Data[i].Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    if (SeasonSeries.Data[i].Schedules[0].Track.Category == "road")
                    {
                        paceCar.CategoryId = 2;
                        paceCar.CarId = 136;
                        paceCar.IsOval = false;
                        paceCar.IsDirt = false;
                        paceCar.CarName = "Pace Car - Sedan";
                        paceCar.CarClassId = 11;
                        paceCar.Order = 4;
                    }
                    else
                    {
                        paceCar.CategoryId = 1;
                        paceCar.CarId = 90;
                        paceCar.IsOval = true;
                        paceCar.IsDirt = false;
                        paceCar.CarName = "Pace Car - Truck";
                        paceCar.CarClassId = 11;
                        paceCar.Order = 3;
                    }
                }
            }

            return paceCar;
        }

        public async Task CreateRoster(List<int> carClassIds, int maxDrivers)
        {
            var names = new List<string>()
            {
                "Liam Johnson", "Noah Martinez", "Oliver Thompson", "Elijah Taylor", "William Anderson", "James White", "Benjamin Harris", "Lucas Clark",
                "Henry Lewis", "Alexander Walker", "Sebastian Hall", "Jack Allen", "Samuel Young", "Luke King", "Daniel Wright", "Gabriel Hill",
                "Anthony Scott", "Isaac Green", "Grayson Adams", "Joseph Baker", "Aiden Nelson", "Ethan Mitchell", "Leo Ramirez", "Carter Carter",
                "Mason Roberts", "Josiah Phillips", "Andrew Evans", "Thomas Torres", "Joshua Hughes", "Christopher Morris", "Ian Price", "Hudson Sanchez",
                "Nathan Perry", "Aaron Reed", "Julian Bryant", "Levi Cruz", "David Long", "Jaxon Foster", "Adam Ward", "Jonathan Howard",
                "Nolan Jenkins", "Elias Rogers", "Mateo Cook", "Nicholas Bailey", "Dominic Diaz", "Landon Richardson", "John Brooks",
                "Robert Watson", "Tyler Wood", "Gavin Gray", "Dylan James", "Jackson Bennett", "Maxwell Ramirez", "Connor Collins", "Cameron Ryan",
                "Christian Grant", "Lincoln Cooper", "Jordan Rivera", "Ezra Hayes", "Xavier Simmons", "Brayden Griffin", "Micah West", "Brandon Brooks",
                "Miles Kelly", "Easton Spencer", "Harrison Alexander", "Wesley Hoffman", "Emmett Weaver", "Caleb Chapman", "Declan Gardner",
                "Owen Kelley", "Charles Snyder", "Ayden Vasquez", "Caden Hawkins", "Blake Guerrero", "Cooper Silva", "Ryder Lawson",
                "Colton Fisher", "Zachary Mason", "Maddox Diaz", "Olivia Holland", "Sophia Warren", "Emma Luna", "Ava May", "Isabella Ray",
                "Amelia Daniels", "Mia Cummings", "Charlotte Harmon", "Harper George", "Evelyn Reid", "Abigail Armstrong", "Emily Ellis",
                "Avery Porter", "Scarlett Sanchez", "Lily Hunt", "Chloe Murphy", "Sophie Romero", "Layla Cole", "Riley Douglas", "Zoey Stone"
            };

            var cc = await dataClient.GetCarClassesAsync();
            var drivers = new List<Drivers>();
            var carNum = 0;

            var split = maxDrivers / carClassIds.Count;

            for (var i = 0; i < carClassIds.Count; i++)
            {
                for (var j = 0; j < split; j++)
                {   
                    var num = new Random().Next(1, 20);
                    var nameNum = new Random().Next(0, names.Count - 1);
                    var color1 = String.Format("{0:X6}", new Random().Next(0x1000000));
                    var color2 = String.Format("{0:X6}", new Random().Next(0x1000000));
                    var color3 = String.Format("{0:X6}", new Random().Next(0x1000000));
                    var design = $"{num},{color1},{color2},{color3}";

                    var d = new Drivers();

                    carNum++;
                    d.DriverName = $"{names[nameNum]}";
                    names.RemoveAt(nameNum);
                    d.CarNumber = carNum.ToString();

                    //asign random cars to proper classes
                    for (var k = 0; k < cc.Data.Length;  k++)
                    {
                        if (cc.Data[k].CarClassId == carClassIds[i])
                        {
                            if (cc.Data[k].CarsInClass.Length == 1)
                            {
                                d.CarId = cc.Data[k].CarsInClass[0].CarId;
                                d.CarPath = cc.Data[k].CarsInClass[0].CarDirpath;
                            }
                            else
                            {
                                var pickOne = new Random().Next(0, cc.Data[k].CarsInClass.Length - 1);
                                d.CarId = cc.Data[k].CarsInClass[pickOne].CarId;
                                d.CarPath = cc.Data[k].CarsInClass[pickOne].CarDirpath;
                            }
                        }
                    }
                    
                    d.CarClassId = carClassIds[i];

                    d.Id = Guid.NewGuid().ToString();

                    d.CarDesign = design;
                    d.HelmetDesign = design;
                    d.SuitDesign = design;
                    d.NumberDesign = "0,0,ffffff,AAAAAA,000000";
                    d.DisableCarDecals = true;

                    drivers.Add(d);
                }
            }

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string airostersPath = Path.Combine(documentsPath, "iRacing", "airosters");

            // Check if the default folder path exists
            if (!Directory.Exists(airostersPath))
            {
                MessageBox.Show($@"The default folder path for iRacing could not be found for saving the season roster. Please select the folder where the ""{MainForm.SeasonName}"" folder should be created.", "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Prompt the user to select a folder path if the default one doesn't exist
                string selectedFolderPath = GetFolderPathFromUser();
                if (selectedFolderPath != null)
                {
                    airostersPath = selectedFolderPath;
                }
                else
                {
                    return;
                }
            }

            Directory.CreateDirectory(airostersPath);

            string seasonName = MainForm.SeasonName;
            string newFolderPath = Path.Combine(airostersPath, seasonName);
            Directory.CreateDirectory(newFolderPath);

            string filePath = Path.Combine(newFolderPath, "roster.json");

            DriverRoster roster = new DriverRoster { Drivers = drivers };
            await SaveRosterToJson(roster, filePath);
        }

        public static string GetFolderPathFromUser()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    return folderBrowserDialog.SelectedPath;
                }
            }
            return null;
        }

        public static async Task SaveRosterToJson(DriverRoster drivers, string filePath)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(drivers, jsonOptions);

            await File.WriteAllTextAsync(filePath, jsonString);
        }
        
        public static async Task SaveSeasonScheduleToJson(SeasonSchedule seasonSchedule, string filePath)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(seasonSchedule, jsonOptions);

            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public async Task<SeasonSchedule> SeasonBuilder()
        {
            var s = new SeasonSchedule();
            var client = await dataClient.GetSeasonsAsync(true, default);
            var seriesDetails = await dataClient.GetSeriesAsync();
            var cars = await dataClient.GetCarsAsync();
            var carClasses = await dataClient.GetCarClassesAsync();
            var tracks = await dataClient.GetTracksAsync();

            for (var i = 0; i < client.Data.Length; i++)
            {
                var c = client.Data[i];

                //get carID
                if (c.Schedules[0].SeriesName == MainForm.SeriesName)
                {

                    for (var j = 0; j < cars.Data.Length; j++)
                    {
                        if (cars.Data[j].CarName == MainForm.CarName)
                        {
                            s.CarId = cars.Data[j].CarId;
                            break;
                        }
                    }

                    //get AiIds and UserClassId
                    if (c.CarClassIds.Length == 1)
                    {
                        s.AiCarClassId = c.CarClassIds[0];
                        s.AiCarClassIds = new List<int> { };
                        s.UserCarClassId = null;
                    }
                    else
                    {
                        s.AiCarClassId = null;
                        s.AiCarClassIds = IRacingService.CarClassIds;
                        
                        for (var j = 0; j < carClasses.Data.Length; j++)
                        {
                            for (var k = 0; k < s.AiCarClassIds.Count; k++)
                            {
                                if (s.AiCarClassIds[k] == carClasses.Data[j].CarClassId)
                                {
                                    for (var l = 0; l  < carClasses.Data[j].CarsInClass.Length;  l++)
                                    {
                                        if (carClasses.Data[j].CarsInClass[l].CarId == s.CarId)
                                        {
                                            s.UserCarClassId = carClasses.Data[j].CarClassId;
                                        }
                                    }
                                }
                            }
                        }
                    }
      
                    var carIds = new List<int>();

                    if (CarSettingsList.Any())
                    {
                        s.CarSettings = CarSettingsList;
                    }
                    else
                    {
                        foreach (var id in IRacingService.CarIds)
                        {
                            var carSettings = new CarSettings();
                            carSettings.CarId = id;
                            carSettings.MaxPctFuelFill = 100;
                            carSettings.MaxDryTireSets = 0;
                            CarSettingsList.Add(carSettings);
                            carIds.Add(id);
                        }
                        s.CarSettings = CarSettingsList;
                    }
                    

                    if (MainForm.DisableDamage)
                    {
                        s.DamageModel = 3;
                    }
                    else
                    {
                        s.DamageModel = 0;
                    }

                    s.TrackState = CreateTrackState();
                    s.TimeOfDay = 0;
                    s.Weather = await CreateWeather();
                    s.FullCourseCautions = c.Schedules[0].HasFullCourseCautions;
                    s.GridPosition = 1;
                    s.LuckyDog = c.LuckyDog;

                    for (var j = 0; j < seriesDetails.Data.Length; j++)
                    {
                        if (seriesDetails.Data[j].SeriesShortName == MainForm.SeriesName)
                        {
                            s.MaxDrivers = seriesDetails.Data[j].MaxStarters;
                            s.PointsSystemId = seriesDetails.Data[j].CategoryId + 2;
                            break;
                        }
                    }

                    s.NumFastTows = -1;
                    s.AvoidUser = MainForm.AiAvoids;
                    s.MinSkill = MainForm.AiMin.Value;
                    s.MaxSkill = MainForm.AiMax.Value;
                    s.MustUseDiffTireTypesInRace = c.MustUseDiffTireTypesInRace;
                    s.StartOnQualTire = c.StartOnQualTire;
                    s.UnsportConductRuleMode = 0;
                    s.PracticeLength = 3;
                    s.QualifyLaps = 3;
                    s.QualifyLength = 8;

                    //sets race by by lap count or time limit
                    if (c.Schedules[0].RaceLapLimit == null)
                    {
                        s.RaceLaps = 0;
                        s.RaceLength = c.Schedules[0].RaceTimeLimit;
                        s.RaceLengthType = 2;
                    }
                    else
                    {
                        s.RaceLaps = c.Schedules[0].RaceLapLimit;
                        s.RaceLength = 0;
                        s.RaceLengthType = 3;
                    }
                    
                    //restart type
                    if (c.Schedules[0].RestartType == "Double-file Back")
                    {
                        s.Restarts = 2;
                    }
                    else
                    {
                        s.Restarts = 0;
                    }

                    //rolling or standing starts
                    if (c.Schedules[0].StartType == "Rolling")
                    {
                        s.RollingStarts = true;
                    }
                    else
                    {
                        s.RollingStarts = false;
                    }

                    if (s.AiCarClassIds.Any())
                    {
                        s.RosterName = MainForm.SeasonName;
                        await CreateRoster(s.AiCarClassIds, s.MaxDrivers);
                    }
                    else
                    {
                        s.RosterName = null;
                    }

                    s.ShortParadeLap = c.Schedules[0].HasShortParadeLap;
                    s.NoLapperWaveArounds = false;
                    s.DoNotCountCautionLaps = c.CautionLapsDoNotCount;
                    s.Subsessions = new List<int> { 3, 5, 6 };
                    s.StartZone = 0;

                    s.Events = await CreateEvents();

                    s.Name = MainForm.SeasonName;
                }  
            }
            return s;
        }

    }
}
