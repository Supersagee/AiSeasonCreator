using AiSeasonCreator.FormOptions;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using iRacingWeatherURLParser.WeatherSchedule;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.Interfaces;
using AiSeasonCreator.Roster;
using System.ComponentModel;

namespace AiSeasonCreator
{
    public class SeasonService
    {
        private readonly UserSelectedOptions _userSelectedOptions;
        private readonly IJsonRepo _jsonService;
        private readonly IMapper<DriverRoster> _driverRoster;

        public event PropertyChangedEventHandler? PropertyChanged;

        public SeasonService(UserSelectedOptions userSelectedOptions, IJsonRepo jsonService, IMapper<DriverRoster> driverRoster) 
        {
            _userSelectedOptions = userSelectedOptions;
            _jsonService = jsonService;
            _driverRoster = driverRoster;
        }

        public void ProgramLoad()
        {
            LoadSeasonAndSeriesFileNames();
            LoadJsonFiles(_userSelectedOptions.SeasonFileNames[0], _userSelectedOptions.SeriesFileNames[0], true);
        }

        public List<string> GetAllSeries()
        {
            var seriesList = new List<string>();
            var schedules = _userSelectedOptions.FullSchedule;
            var carClasses = _userSelectedOptions.CarClasses;
            var carDetails = _userSelectedOptions.CarDetails;

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

        public List<string> PopulateCarComboBox()
        {
            var schedules = _userSelectedOptions.FullSchedule;
            var carClasses = _userSelectedOptions.CarClasses;
            var carDetails = _userSelectedOptions.CarDetails;

            var carClassIds = new List<int>();
            var carIds = new List<int>();
            var carNames = new List<string>();

            var seriesSchedule = schedules.FirstOrDefault(ss => ss.Schedules[0].SeriesName == _userSelectedOptions.SeriesName);

            if (seriesSchedule != null)
            {
                carClassIds = seriesSchedule.CarClassIds;
                _userSelectedOptions.SeasonSeriesIndex = Array.IndexOf(schedules, seriesSchedule);
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

            return carNames;
        }

        public void LoadJsonFiles(string season, string series, bool isPageLoad)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (isPageLoad)
            {
                var rosterScheduleFilePath = Path.Combine(basePath, "JsonFiles", "Schedules", $"{season}.json");
                _userSelectedOptions.RosterFullSchedule = _jsonService.Load<FullSchedule[]>(rosterScheduleFilePath);

                var rosterSeriesFilePath = Path.Combine(basePath, "JsonFiles", "SeriesDetails", $"{series}.json");
                _userSelectedOptions.RosterSeriesDetails = _jsonService.Load<SeriesDetails[]>(rosterSeriesFilePath);

                var carClassesFilePath = Path.Combine(basePath, "JsonFiles", "carClassesJson.json");
                _userSelectedOptions.CarClasses = _jsonService.Load<CarClasses[]>(carClassesFilePath);

                var carsFilePath = Path.Combine(basePath, "JsonFiles", "carsJson.json");
                _userSelectedOptions.CarDetails = _jsonService.Load<CarDetails[]>(carsFilePath);

                var tracksFilePath = Path.Combine(basePath, "JsonFiles", "tracksJson.json");
                _userSelectedOptions.TrackDetails = _jsonService.Load<TrackDetails[]>(tracksFilePath);
            }

            var scheduleFilePath = Path.Combine(basePath, "JsonFiles", "Schedules", $"{season}.json");
            _userSelectedOptions.FullSchedule = _jsonService.Load<FullSchedule[]>(scheduleFilePath);

            var seriesFilePath = Path.Combine(basePath, "JsonFiles", "SeriesDetails", $"{series}.json");
            _userSelectedOptions.SeriesDetails = _jsonService.Load<SeriesDetails[]>(seriesFilePath);

            var weatherFilePath = Path.Combine(basePath, "JsonFiles", "WeatherSchedules", $"WeatherSchedule {season}.json");
            _userSelectedOptions.WeatherSchedule = _jsonService.Load<WeatherSchedule>(weatherFilePath);
        }

        public void LoadSeasonAndSeriesFileNames()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var seasonProp = Path.Combine(basePath, "JsonFiles", "Schedules");
            var seasonFiles = Directory.GetFiles(seasonProp);

            var seriesProp = Path.Combine(basePath, "JsonFiles", "SeriesDetails");
            var seriesFiles = Directory.GetFiles(seriesProp);

            for (int i = 0; i < seasonFiles.Length; i++)
            {
                _userSelectedOptions.SeasonFileNames.Add(Path.GetFileNameWithoutExtension(seasonFiles[i]));
                _userSelectedOptions.SeriesFileNames.Add(Path.GetFileNameWithoutExtension(seriesFiles[i]));
            }
            _userSelectedOptions.SeasonFileNames.Reverse();
            _userSelectedOptions.SeriesFileNames.Reverse();
        }

        public void CreateRoster(int isRosterButton, string rosterName)
        {
            var roster =_driverRoster.Map(isRosterButton, rosterName);
        }

        public void UpdateRoster(string rosterName)
        {
            var rand = new Random();
            var roster = JsonSerializer.Deserialize<DriverRoster>(File.ReadAllText(rosterName));
            var drivers = roster.Drivers;
            var uso = _userSelectedOptions;

            if (uso.DriversComboBoxName == "Update All Drivers")
            {
                foreach (var d in drivers)
                {
                    d.DriverSkill = uso.UseRelativeSkill ? rand.Next(uso.RelateiveSkillMin, uso.RelativeSkillMax + 1) : d.DriverSkill;
                    d.DriverAggression = uso.UseAggression ? rand.Next(uso.AggressionMin, uso.AggressionMax + 1) : d.DriverAggression;
                    d.DriverOptimism = uso.UseOptimism ? rand.Next(uso.OptimismMin, uso.OptimismMax + 1) : d.DriverOptimism;
                    d.DriverSmoothness = uso.UseSmoothness ? rand.Next(uso.SmoothnessMin, uso.SmoothnessMax + 1) : d.DriverSmoothness;
                    d.DriverAge = uso.UseAge ? rand.Next(uso.AgeMin, uso.AgeMax + 1) : d.DriverAge;
                    d.PitCrewSkill = uso.UsePitCrew ? rand.Next(uso.PitCrewMin, uso.PitCrewMax + 1) : d.PitCrewSkill;
                    d.StrategyRiskiness = uso.UsePitStrat ? rand.Next(uso.PitStratMin, uso.PitStratMax + 1) : d.StrategyRiskiness;
                }
            }
            else
            {
                foreach (var d in drivers)
                {
                    if (d.DriverName == uso.DriversComboBoxName)
                    {
                        d.DriverSkill = uso.UseRelativeSkill ? rand.Next(uso.RelateiveSkillMin, uso.RelativeSkillMax + 1) : d.DriverSkill;
                        d.DriverAggression = uso.UseAggression ? rand.Next(uso.AggressionMin, uso.AggressionMax + 1) : d.DriverAggression;
                        d.DriverOptimism = uso.UseOptimism ? rand.Next(uso.OptimismMin, uso.OptimismMax + 1) : d.DriverOptimism;
                        d.DriverSmoothness = uso.UseSmoothness ? rand.Next(uso.SmoothnessMin, uso.SmoothnessMax + 1) : d.DriverSmoothness;
                        d.DriverAge = uso.UseAge ? rand.Next(uso.AgeMin, uso.AgeMax + 1) : d.DriverAge;
                        d.PitCrewSkill = uso.UsePitCrew ? rand.Next(uso.PitCrewMin, uso.PitCrewMax + 1) : d.PitCrewSkill;
                        d.StrategyRiskiness = uso.UsePitStrat ? rand.Next(uso.PitStratMin, uso.PitStratMax + 1) : d.StrategyRiskiness;
                    }
                }
            }

            DriverRoster newRoster = new DriverRoster { Drivers = drivers };
            _jsonService.Save(rosterName, newRoster);
        }

        public string AboutDescription()
        {
            var builder = new StringBuilder();

            builder.AppendLine("The purpose of this program is to create AI seasons and rosters based on the iRacing multiplayer seasons, " +
                "along with editing existing user rosters with minimal effort.");

            builder.AppendLine("");
            builder.AppendLine("The AI seasons that are created will contain the proper tracks, cars, time/laps, etc. in order to match the multiplayer series. " +
                "All seasons will also automatically create a roster, except when the 'Exclude Roster' checkbox is checked.");

            builder.AppendLine("");
            builder.AppendLine("Individual AI rosters can also be created based on a series, and existing rosters can also be updated with different attributes. " +
                "The attribute sliders in the 'Roster' tab are min and max ranges for a particular attribute. " +
                "For example, if 'Aggression' is set to 25%-75%, all drivers in that roster will have their aggression set randomly between those percentages. " +
                "When updating a roster, unchecking an attribute will leave that particular attribute as is for all drivers.");

            builder.AppendLine("");
            builder.AppendLine("Keep in mind that some cars and tracks are not AI enabled.");

            return builder.ToString();
        }

        //Methods below for later use

        public void SetSelectedSeasonAndSeries(string seriesName)
        {
            var selectedSeries = _userSelectedOptions.FullSchedule.FirstOrDefault(s => s.Schedules[0].SeriesName == seriesName);
            _userSelectedOptions.SelectedSeason = selectedSeries;

            _userSelectedOptions.SelectedSeries = _userSelectedOptions.SeriesDetails.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);
        }

        public List<string> GetAvailableCars()
        {
            var cars = new List<string>();
            var carIds = new List<int>();
            var carClasses = _userSelectedOptions.SelectedSeason.CarClassIds;

            foreach (var carClass in carClasses)
            {
                var ids = _userSelectedOptions.CarClasses.FirstOrDefault(c => c.CarClassId == carClass);

                foreach (var id in ids.CarsInClass)
                {
                    var car = _userSelectedOptions.CarDetails.FirstOrDefault(c => c.CarId == id.CarId);

                    if (car.AiEnabled)
                    {
                        cars.Add(car.CarName);
                    }
                }
            }
            return cars;
        }
    }
}
