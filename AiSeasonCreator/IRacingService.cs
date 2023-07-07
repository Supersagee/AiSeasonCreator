using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using AiSeasonCreator.ScheduleClasses;
using System.Reflection;
using System.Diagnostics;
using AiSeasonCreator.Roster;

namespace AiSeasonCreator
{
    public class IRacingService
    {

        public static List<CarSettings> CarSettingsList { get; set; } = new List<CarSettings>();
        public static List<int> CarClassIds { get; set; }
        public static List<int> CarIds { get; set; }


        public static List<string> GetAllSeries()
        {
            var seriesList = new List<string>();
            var schedules = MainForm.FullSchedule;
            var carClasses = MainForm.CarClasses;
            var carDetails = MainForm.CarDetails;

            foreach (var schedule in schedules)
            {
                var carIds = schedule.CarClassIds;
                var carsInSeries = carClasses
                    .Where(cc => carIds.Contains(cc.CarClassId))
                    .SelectMany(cc => cc.CarsInClass.Select(car => car.CarId))
                    .ToList();

                var aiCarsInSeries = carDetails
                    .Where(cd => carsInSeries.Contains(cd.CarId) && cd.AiEnabled)
                    .ToList();

                if (aiCarsInSeries.Any())
                {
                    seriesList.Add(schedule.Schedules[0].SeriesName);
                }
            }

            seriesList.Sort();
            return seriesList;
        }

        public static void CreateCarSettings()
        {
            var ss = MainForm.FullSchedule;
            var i = MainForm.SeasonSeriesIndex;
            var carIds = new List<int>();
            CarSettingsList.Clear();
          
            for (var j = 0; j < ss[i].Schedules[0].CarRestrictions.Count; j++)
            {
                carIds.Add(ss[i].Schedules[0].CarRestrictions[j].CarId);
                var carSettings = new CarSettings();
                carSettings.CarId = ss[i].Schedules[0].CarRestrictions[j].CarId;
                carSettings.MaxPctFuelFill = Convert.ToInt32(ss[i].Schedules[0].CarRestrictions[j].MaxPctFuelFill);
                carSettings.MaxDryTireSets = ss[i].Schedules[0].CarRestrictions[j].MaxDryTireSets;
                CarSettingsList.Add(carSettings);
            }
        }

        public static TrackState CreateTrackState()
        {
            var ts = new TrackState();

            ts.LeaveMarbles = false;
            ts.PracticeRubber = -1;
            ts.QualifyRubber = -1;
            ts.RaceRubber = -1;
            ts.WarmupRubber = -1;
                
            return ts;
        }

        private static Weather CreateWeather(int i, int j)
        {
            var weather = new Weather();
            var ss = MainForm.FullSchedule[i].Schedules[j].Weather;

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

            if (MainForm.ConsistentWeather)
            {
                weather.Type = 3;
                weather.TempValue = 78;
                weather.RelHumidity = 55;
                weather.WindDir = 0;
                weather.WindValue = 2;
            }

            return weather;
        }

        private static List<Events> CreateEvents(int i)
        {
            var events = new List<Events>();
            var notAllowedTracks = new List<int>();
            var tracks = MainForm.TrackDetails;

            for (var j = 0; j < tracks.Length; j++)
            {
                if (!tracks[j].AiEnabled)
                {
                    notAllowedTracks.Add(tracks[j].TrackId);
                }                
            }

            var ss = MainForm.FullSchedule[i];

            for (var j = 0; j < ss.Schedules.Count; j++)
            {   
                
                if (MainForm.UnselectedTracks != null && MainForm.UnselectedTracks.Contains(j))
                {
                    continue;
                }
                
                if (!notAllowedTracks.Contains(ss.Schedules[j].Track.TrackId))
                {
                    var loopEvent = new Events();
                    loopEvent.TrackId = ss.Schedules[j].Track.TrackId;
                    loopEvent.NumOptLaps = 0;
                    loopEvent.PaceCar = CreatePaceCar(j);
                    loopEvent.ShortParadeLap = false;
                    loopEvent.MustUseDiffTireTypesInRace = ss.MustUseDiffTireTypesInRace;

                    if (MainForm.QualiAlone)
                    {
                        loopEvent.Subsessions = new List<int> { 3, 4, 6 };
                    }
                    else
                    {
                        loopEvent.Subsessions = new List<int> { 3, 5, 6 };
                    }
                    
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

                    loopEvent.Weather = CreateWeather(i, j);
                    loopEvent.StartZone = ss.Schedules[j].HasStartZone;
                    loopEvent.FullCourseCautions = ss.Schedules[j].HasFullCourseCautions;
                    loopEvent.TimeOfDay = ss.Schedules[j].Weather.TimeOfDay;

                    if (ss.Schedules[j].Track.TrackName.Contains("Combined") || ss.Schedules[j].Track.TrackName.Contains("Nordschleife"))
                    {
                        loopEvent.QualifyLength = 20;
                    }
                    else if (ss.Schedules[j].Track.Category == "oval")
                    {
                        loopEvent.QualifyLength = 5;
                    }
                    else
                    {
                        loopEvent.QualifyLength = 8;
                    }

                    events.Add(loopEvent);
                }
                else
                {
                    MainForm.NotAvailableTracks.Add($"{ss.Schedules[j].Track.TrackName} - {ss.Schedules[j].Track.ConfigName}");
                }
            }

            MainForm.UnselectedTracks = new List<int> { };

            if (events.Count <= 0)
            {
                throw new Exception();
            }

            return events;
        }

        public static List<string> PopulateCarComboBox()
        {
            var schedules = MainForm.FullSchedule;
            var carClasses = MainForm.CarClasses;
            var carDetails = MainForm.CarDetails;

            var carClassIds = new List<int>();
            var carIds = new List<int>();
            var carNames = new List<string>();

            var seriesSchedule = schedules.FirstOrDefault(ss => ss.Schedules[0].SeriesName == MainForm.SeriesName);

            if (seriesSchedule != null)
            {
                carClassIds = seriesSchedule.CarClassIds;
                MainForm.SeasonSeriesIndex = Array.IndexOf(schedules, seriesSchedule);
            }

            foreach (var carClass in carClasses)
            {
                if (carClassIds.Contains(carClass.CarClassId))
                {
                    carIds.AddRange(carClass.CarsInClass.Select(car => car.CarId));
                }
            }

            foreach (var car in carDetails)
            {
                if (carIds.Contains(car.CarId) && car.AiEnabled)
                {
                    carNames.Add(car.CarName);
                }
            }

            CarIds = carIds;
            CarClassIds = carClassIds;
            return carNames;
        }

        private static PaceCar CreatePaceCar(int j)
        {
            var ss = MainForm.FullSchedule;
            var i = MainForm.SeasonSeriesIndex;
            var paceCar = new PaceCar();

            if (ss[i].Schedules[j].Track.Category == "road")
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

            return paceCar;
        }

        public static void CreateRoster(List<int> carClassIds, int maxDrivers)
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

            var cc = MainForm.CarClasses;
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
                    for (var k = 0; k < cc.Length;  k++)
                    {
                        if (cc[k].CarClassId == carClassIds[i])
                        {
                            if (cc[k].CarsInClass.Length == 1)
                            {
                                d.CarId = cc[k].CarsInClass[0].CarId;
                                d.CarPath = cc[k].CarsInClass[0].CarDirpath;
                            }
                            else
                            {
                                var pickOne = new Random().Next(0, cc[k].CarsInClass.Length - 1);
                                d.CarId = cc[k].CarsInClass[pickOne].CarId;
                                d.CarPath = cc[k].CarsInClass[pickOne].CarDirpath;
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
            SaveRosterToJson(roster, filePath);
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

        public static SeasonSchedule SeasonBuilder()
        {
            var s = new SeasonSchedule();
            var seriesDetails = MainForm.SeriesDetails;
            var cars = MainForm.CarDetails;
            var carClasses = MainForm.CarClasses;
            var i = MainForm.SeasonSeriesIndex;

            var c = MainForm.FullSchedule[i];

            //get carID

            for (var j = 0; j < cars.Length; j++)
            {
                if (cars[j].CarName == MainForm.CarName)
                {
                    s.CarId = cars[j].CarId;
                    break;
                }
            }

            //get AiIds and UserClassId
            if (c.CarClassIds.Count == 1)
            {
                s.AiCarClassId = c.CarClassIds[0];
                s.AiCarClassIds = new List<int>();
                s.UserCarClassId = null;
            }
            else
            {
                s.AiCarClassId = null;
                s.AiCarClassIds = CarClassIds;

                var matchingCarClass = carClasses.FirstOrDefault(cc => s.AiCarClassIds.Contains(cc.CarClassId));
                if (matchingCarClass != null)
                {
                    var userCarInClass = matchingCarClass.CarsInClass.FirstOrDefault(car => car.CarId == s.CarId);
                    if (userCarInClass != null)
                    {
                        s.UserCarClassId = matchingCarClass.CarClassId;
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
                foreach (var id in CarIds)
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
            s.Weather = CreateWeather(i, 0);
            s.FullCourseCautions = c.Schedules[0].HasFullCourseCautions;
            s.GridPosition = 1;
            s.LuckyDog = c.LuckyDog;

            for (var j = 0; j < seriesDetails.Length; j++)
            {
                if (seriesDetails[j].SeriesShortName == MainForm.SeriesName)
                {
                    s.MaxDrivers = seriesDetails[j].MaxStarters;
                    s.PointsSystemId = seriesDetails[j].CategoryId + 2;
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
            s.QualifyLaps = 2;
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
                CreateRoster(s.AiCarClassIds, s.MaxDrivers);
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

            s.Events = CreateEvents(i);

            s.Name = MainForm.SeasonName;
                  
            return s;
        }

    }
}
 