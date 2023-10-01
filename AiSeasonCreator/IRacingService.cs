using System;
using System.Text.Json;
using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.Roster;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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

            weather.TempUnits = ss.TempUnits;
            weather.Fog = ss.Fog;
            weather.WindUnits = ss.WindUnits;
            weather.Skies = ss.Skies;
            weather.SimulatedTimeMultiplier = ss.SimulatedTimeMultiplier;
            weather.SimulatedTimeOffsets = ss.SimulatedTimeOffsets.ToList();
            weather.Version = ss.Version;
            weather.WeatherVarInitial = ss.WeatherVarInitial;
            weather.WeatherVarOngoing = ss.WeatherVarOngoing;

            if (MainForm.ConsistentWeather)
            {
                weather.Type = 3;
                weather.TempValue = 78;
                weather.RelHumidity = 55;
                weather.WindDir = 0;
                weather.WindValue = 2;
            }
            else
            {
                weather.Type = ss.Type;
                weather.TempValue = ss.TempValue;
                weather.RelHumidity = ss.RelHumidity;
                weather.WindDir = ss.WindDir;
                weather.WindValue = ss.WindValue;
            }

            if (MainForm.AfternoonRaces)
            {
                weather.SimulatedStartTime = DateTime.Parse(ss.SimulatedStartTime.ToString("yyyy-MM-ddTHH:mm:ss").Substring(0, 11) + "14:00:00");
                weather.TimeOfDay = 0;
            }
            else
            {
                weather.SimulatedStartTime = ss.SimulatedStartTime;
                weather.TimeOfDay = ss.TimeOfDay;
            }

            return weather;
        }

        private static List<Events> CreateEvents(int i)
        {
            var events = new List<Events>();
            var notAllowedTracks = new List<int>();

            var ss = MainForm.FullSchedule[i];
            var tracks = MainForm.TrackDetails;

            for (var j = 0; j < tracks.Length; j++)
            {
                if (!tracks[j].AiEnabled)
                {
                    notAllowedTracks.Add(tracks[j].TrackId);
                }                
            }

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
                    loopEvent.ShortParadeLap = MainForm.ShortParade ? true : false;
                    
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
                    loopEvent.TimeOfDay = MainForm.AfternoonRaces ? 0 : ss.Schedules[j].Weather.TimeOfDay;

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

        private static Drivers DriverAttributes(Drivers d, Random rand)
        {
            var min = MainForm.AiMin.Value;
            var max = MainForm.AiMax.Value;
            var total = ((min + max) / 2) * 2;

            if (total < 50)
            {
                total = 50;
            }

            var a1 = 0;
            var a2 = 0;
            var a3 = 0;

            var balance = rand.Next(3, 6);

            for ( var i = 0; i < total; i++)
            {
                var choice = rand.Next(balance);

                if (choice < 1)
                {
                    a1++;
                }
                else if (choice < 2)
                {
                    a2++;
                }
                else
                {
                    if (a3 > 99)
                    {
                        if (a1 > 99)
                        {
                            a2++;
                            continue;
                        }
                        a1++;
                        continue;
                    }
                    a3++;
                }
            }

            var aos = new List<int>() { a1, a2, a3 };
            aos = aos.OrderBy(x => rand.Next()).ToList();

            d.DriverAggression = aos[0];
            d.DriverOptimism = aos[1];
            d.DriverSmoothness = aos[2];

            //set pit skills
            var psTotal = Convert.ToInt32(((min + max) / 2) * 1.33);
            if (psTotal < 40)
            {
                psTotal = 40;
            }
            else if (psTotal > 160)
            {
                psTotal = 160;
            }

            var psBalance = rand.Next(3, 5);
            var p1 = 0;
            var p2 = 0;

            for ( var i = 0; i < psTotal; i++)
            {
                var choice = rand.Next(balance);

                if (choice < 2)
                {
                    if (p1 > 99) { p2++; continue; }
                    p1++;
                }
                else
                {
                    if (p2 > 99) { p1++; continue; }
                    p2++; 
                }
            }

            var ps = new List<int>() { p1 , p2 };
            ps = ps.OrderBy(x => rand.Next()).ToList();

            d.PitCrewSkill = ps[0];
            d.StrategyRiskiness = ps[1];

            //set relative and age skills
            d.DriverSkill = rand.Next(1, 101);
            d.DriverAge = rand.Next(18, 70);

            return d;
        }

        private static Drivers AttributesFromRanges(Drivers d, Random rand)
        {
            d.DriverSkill = rand.Next(MainForm.RelateiveSkillMin, MainForm.RelativeSkillMax + 1);
            d.DriverAggression = rand.Next(MainForm.AggressionMin, MainForm.AggressionMax + 1);
            d.DriverOptimism = rand.Next(MainForm.OptimismMin, MainForm.OptimismMax + 1);
            d.DriverSmoothness = rand.Next(MainForm.SmoothnessMin, MainForm.SmoothnessMax + 1);
            d.DriverAge = rand.Next(MainForm.AgeMin, MainForm.AgaMax + 1);
            d.PitCrewSkill = rand.Next(MainForm.PitCrewMin, MainForm.PitCrewMax + 1);
            d.StrategyRiskiness = rand.Next(MainForm.PitStratMin, MainForm.PitStratMax + 1);

            return d;
        }

        public static void UpdateRoster(string rosterName)
        {
            var rand = new Random();
            var roster = JsonSerializer.Deserialize<DriverRoster>(File.ReadAllText(rosterName));
            var drivers = roster.Drivers;

            foreach (var d in drivers)
            {
                d.DriverSkill = MainForm.UseRelativeSkill ? rand.Next(MainForm.RelateiveSkillMin, MainForm.RelativeSkillMax + 1) : d.DriverSkill;
                d.DriverAggression = MainForm.UseAggression ? rand.Next(MainForm.AggressionMin, MainForm.AggressionMax + 1) : d.DriverAggression;
                d.DriverOptimism = MainForm.UseOptimism ? rand.Next(MainForm.OptimismMin, MainForm.OptimismMax + 1) : d.DriverOptimism;
                d.DriverSmoothness = MainForm.UseSmoothness ? rand.Next(MainForm.SmoothnessMin, MainForm.SmoothnessMax + 1) : d.DriverSmoothness;
                d.DriverAge = MainForm.UseAge ? rand.Next(MainForm.AgeMin, MainForm.AgaMax + 1) : d.DriverAge;
                d.PitCrewSkill = MainForm.UsePitCrew ? rand.Next(MainForm.PitCrewMin, MainForm.PitCrewMax + 1) : d.PitCrewSkill;
                d.StrategyRiskiness = MainForm.UsePitStrat ? rand.Next(MainForm.PitStratMin, MainForm.PitStratMax + 1) : d.StrategyRiskiness;
            }

            DriverRoster newRoster = new DriverRoster { Drivers = drivers };
            SaveRosterToJson(newRoster, rosterName); 
        }

        public static void CreateRoster(List<int> carClassIds, int maxDrivers, bool rosterButton)
        {   
            var names = new List<string>()
            {
                "Liam Johnson", "Noah Martinez", "Oliver Thompson", "Elijah Taylor", "William Anderson", "James White", "Benjamin Harris", "Lucas Clark",
                "Henry Lewis", "Alexander Walker", "Sebastian Hall", "Jack Allen", "Samuel Young", "Luke King", "Daniel Wright", "Gabriel Hill",
                "Anthony Scott", "Isaac Green", "Grayson Adams", "Joseph Baker", "Aiden Nelson", "Ethan Mitchell", "Leo Ramirez", "Carter Carter",
                "Mason Roberts", "Josiah Phillips", "Andrew Evans", "Thomas Torres", "Joshua Hughes", "Christopher Morris", "Ian Price", "Hudson Sanchez",
                "Nathan Perry", "Aaron Reed", "Julian Bryant", "Levi Cruz", "David Long", "Jaxon Foster", "Adam Ward", "Jonathan Howard",
                "Christian Grant", "Lincoln Cooper", "Jordan Rivera", "Ezra Hayes", "Xavier Simmons", "Brayden Griffin", "Micah West", "Brandon Brooks",
                "Miles Kelly", "Easton Spencer", "Harrison Alexander", "Wesley Hoffman", "Emmett Weaver", "Caleb Chapman", "Declan Gardner",
                "Colton Fisher", "Zachary Mason", "Olivia Holland", "Billy Sage", "Emma Luna", "Ava May", "Isabella Ray","Amelia Daniels",
                "Charlotte Harmon", "Harper George", "Evelyn Reid"
            };

            var designs = new List<string>()
            {
                "9A0000,35005D,BCBCBC", "447ac0,ffffff,ee3442", "111111,ffffff,5481fc", "391c83,111111,ccff00", "ffffff,013990,4bd3fd", "5e5e5e,135324,111111",
                "4bd3fd,013990,ffffff", "184252,111111,03bbbd", "111111,ffee47,0300c2", "981a9b,00f0e7,ffffff", "135324,5e5e5e,111111", "0300c2,111111,ffee47",
                "284a94,b82f37,111111", "f06e34,ffffff,111111", "28536B,FFD838,21EDE5", "111111,ffffff,f06e34", "111111,03bbbd,184252", "111111,391c83,ccff00",
                "135324,5e5e5e,111111", "5e5e5e,111111,135324", "ffffff,0ada00,111111", "b82f37,111111,284a94", "d7162d,efd600,111111", "ffee47,0300c2,111111",
                "0ada00,111111,ffffff", "F9D10F,031163,FFFFFF", "7de54c,1f2892,ffffff", "111111,ccff00,391c83", "FFFFFF,184B91,D82520", "4bd3fd,013990,ffffff",
                "1f2892,ffffff,7de54c", "dff000,1a4b9b,ffffff", "ffffff,4bd3fd,013990", "391c83,ccff00,111111", "d7162d,efd600,111111", "ccff00,111111,391c83",
                "ffffff,ee3442,447ac0", "f1732e,372a75,ffffff", "447ac0,ffffff,ee3442", "5e5e5e,135324,111111", "ffee47,111111,0300c2", "1f2892,7de54c,ffffff",
                "447ac0,ffffff,ee3442", "f26522,00aeef,0a0a0a", "f1732e,372a75,ffffff", "013990,ffffff,4bd3fd", "ffffff,447ac0,ee3442", "EBDA28,000000,000000",
                "5481fc,ffffff,111111", "ed1c24,111111,cccccc", "111111,d7162d,efd600", "000000,2A3795,2A3795", "111111,135324,5e5e5e", "000000,0090FF,E7F700",
                "5481fc,111111,ffffff", "111111,d7162d,efd600", "f06e34,ffffff,111111", "FFFFFF,FFFFFF,FFFFFF", "000000,000000,000000", "000000,FFFFFF,000000",
                "000000,FFFFFF,FFFFFF", "ffffff,111111,5481fc", "111111,ffffff,fc0706", "b82f37,111111,284a94", "d7162d,efd600,111111", "ffee47,0300c2,111111"
            };

            var cc = MainForm.CarClasses;
            var drivers = new List<Drivers>();
            var carNum = 0;

            var rand = new Random();
            var split = maxDrivers / carClassIds.Count;

            for (var i = 0; i < carClassIds.Count; i++)
            {
                for (var j = 0; j < split; j++)
                {   
                    var num = rand.Next(1, 20);
                    var randIndex = rand.Next(0, names.Count);
                    var d = new Drivers();

                    d.RowIndex = carNum;
                    carNum++;
                    d.DriverName = $"{names[randIndex]}";
                    var design = $"{num},{designs[randIndex]}";
                    names.RemoveAt(randIndex);
                    designs.RemoveAt(randIndex);
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
                                var pickOne = rand.Next(0, cc[k].CarsInClass.Length);
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
                    d.DisableCarDecals = false;

                    var s1 = rand.Next(2, 221);
                    var s2 = rand.Next(2, 221);

                    d.Sponsor1 = s1;
                    d.Sponsor2 = s2;

                    d = rosterButton || MainForm.UseRosterTabAtt ? AttributesFromRanges(d, rand) : DriverAttributes(d, rand);

                    drivers.Add(d);
                }
            }

            string seasonName = rosterButton ? MainForm.RosterName : MainForm.SeasonName;
            string newFolderPath = Path.Combine(MainForm.RosterFolderPath, seasonName);
            Directory.CreateDirectory(newFolderPath);

            string filePath = Path.Combine(newFolderPath, "roster.json");

            DriverRoster roster = new DriverRoster { Drivers = drivers };
            SaveRosterToJson(roster, filePath);
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
                s.UserCarClassId = c.CarClassIds[0];
            }
            else
            {
                s.AiCarClassId = null;
                s.AiCarClassIds = CarClassIds;

                for (var j = 0; j < carClasses.Length; j++)
                {
                    for (var k = 0; k < s.AiCarClassIds.Count; k++)
                    {
                        if (s.AiCarClassIds[k] == carClasses[j].CarClassId)
                        {
                            for (var n = 0; n < carClasses[j].CarsInClass.Length; n++)
                            {
                                if (carClasses[j].CarsInClass[n].CarId == s.CarId)
                                {
                                    s.UserCarClassId = carClasses[j].CarClassId;
                                }
                            }
                        }
                    }
                }
            }

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
                }
                s.CarSettings = CarSettingsList;
            }

            s.DamageModel = MainForm.DisableDamage ? 3 : 0;

            s.TrackState = CreateTrackState();
            s.TimeOfDay = 0;
            s.Weather = CreateWeather(i, 0);
            s.FullCourseCautions = c.Schedules[0].HasFullCourseCautions;
            s.GridPosition = 1;
            s.LuckyDog = c.LuckyDog;

            if (MainForm.CustCarCountSeason)
            {
                s.MaxDrivers = MainForm.CustCarCountValue;
            }
            else
            {
                for (var j = 0; j < seriesDetails.Length; j++)
                {
                    if (seriesDetails[j].SeriesShortName == MainForm.SeriesName)
                    {
                        s.MaxDrivers = seriesDetails[j].MaxStarters;
                        s.PointsSystemId = seriesDetails[j].CategoryId + 2;
                        break;
                    }
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

            if (MainForm.ExcludeRoster)
            {
                s.RosterName = null;
            }
            else if (MainForm.UseExistingRoster && MainForm.ExistingRosterName != "")
            {
                s.RosterName = MainForm.ExistingRosterName;
            }
            else
            {
                s.RosterName = MainForm.SeasonName;
                CreateRoster(CarClassIds, s.MaxDrivers, false);
            }

            s.ShortParadeLap = MainForm.ShortParade ? true : false;
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
 