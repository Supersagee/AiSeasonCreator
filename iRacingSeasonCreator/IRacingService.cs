using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aydsko.iRacingData;
using Aydsko.iRacingData.Series;
using iRacingSeasonCreator.ScheduleClasses;
using Microsoft.Extensions.DependencyInjection;

namespace iRacingSeasonCreator
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
        public Aydsko.iRacingData.Common.DataResponse<Aydsko.iRacingData.Cars.CarInfo[]> CarInfo { get; set; }
        public List<CarSettings> CarSettingsList { get; set; } = new List<CarSettings>();
        public static List<string> CurrentSeries { get; set; }

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
            SeasonSeries = await dataClient.GetSeasonsAsync(true, default);
        }

        public async Task SetCars()
        {
            CarInfo = await dataClient.GetCarsAsync();
        }

        public async Task<List<string>> GetAllSeries()
        {
            var seasonSchedule = SeasonSeries.Data;
            var list = new List<string>();

            foreach (var item in seasonSchedule)
            {
                list.Add(item.Schedules[0].SeriesName);
            }

            return list;
        }

        public async Task<List<string>> PopulateCarComboBox()
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

            var carsInfo = CarInfo.Data;
            var carNames = new List<string>();
            for (var i = 0; i < carIds.Count; i++)
            {
                for (var j = 0; j < carsInfo.Length; j++)
                {
                    if (carIds[i] == carsInfo[j].CarId)
                    {
                        carNames.Add(carsInfo[j].CarName);
                    }
                }
            }

            return carNames;
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

            for (var i = 0; i < SeasonSeries.Data.Length; i++)
            {
                var ss = SeasonSeries.Data[i];

                if (ss.Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    for (var j = 0; j < SeasonSeries.Data[i].Schedules.Length; j++)
                    {
                        var loopEvent = new Events();
                        loopEvent.TrackId = ss.Schedules[j].Track.TrackId;
                        loopEvent.NumOptLaps = 0;
                        loopEvent.PaceCar = await CreatePaceCar();
                        loopEvent.ShortParadeLap = false;
                        loopEvent.MustUseDiffTireTypesInRace = ss.MustUseDiffTireTypesInRace;
                        loopEvent.Subsessions = new List<int> { 3, 5, 6 };
                        loopEvent.EventId = Guid.NewGuid().ToString();
                        loopEvent.Weather = await CreateWeather();
                        loopEvent.TimeOfDay = ss.Schedules[j].Weather.TimeOfDay;

                        events.Add(loopEvent);
                    }
                }
            }

            return events;
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

        public async Task SeasonBuilder(string seasonName)
        {
            var s = new SeasonSchedule();
            var client = await dataClient.GetSeasonsAsync(true, default);
            var seriesDetails = await dataClient.GetSeriesAsync();
            var cars = await dataClient.GetCarsAsync();

            for (var i = 0; i < client.Data.Length; i++)
            {
                var c = client.Data[i];

                if (c.Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    s.AiCarClassId = c.CarClassIds[0];
                    
                    //get carID
                    for (var j = 0; j < cars.Data.Length; j++)
                    {
                        if (cars.Data[j].CarName == MainForm.CarName)
                        {
                            s.CarId = cars.Data[j].CarId;
                            break;
                        }
                    }

                    s.CarSettings = CarSettingsList;

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
                        if (seriesDetails.Data[j].SeriesShortName == MainForm.SeasonName)
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
                        s.RaceLength = c.Schedules[0].RaceLapLimit;
                        s.RaceLengthType = 2;
                    }
                    else
                    {
                        s.RaceLaps = c.Schedules[0].RaceLapLimit;
                        s.RaceLength = 0;
                        s.RaceLengthType = 3;
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

                    s.ShortParadeLap = c.Schedules[0].HasShortParadeLap;
                    s.NoLapperWaveArounds = false;
                    s.DoNotCountCautionLaps = c.CautionLapsDoNotCount;
                    s.Subsessions = new List<int> { 3, 5, 6 };
                    s.StartZone = 0;

                    s.Events = await CreateEvents();

                    s.Name = MainForm.SeasonName;
                    var nothing = 0;
                }
                
            }
        }

    }
}
