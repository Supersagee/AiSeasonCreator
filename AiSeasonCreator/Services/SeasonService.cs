using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using AiSeasonCreator.Repos;
using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.Views;
using iRacingWeatherURLParser.WeatherSchedule;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public class SeasonService : ISeasonService
    {
        private IJsonRepo _jsonRepo;
        private LoadedData _loadedData;
        private AppSettings _appSettings;
        private readonly SeasonBuilder<SeasonSchedule> _seasonBuilder;

        public SeasonService(IJsonRepo jsonRepo, LoadedData loadedData, AppSettings appSettings, SeasonBuilder<SeasonSchedule> seasonBuilder)
        {
            _jsonRepo = jsonRepo;
            _loadedData = loadedData;
            _appSettings = appSettings;
            _seasonBuilder = seasonBuilder;
        }

        public void Initialize()
        {
            LoadData();
        }

        private void LoadData()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var scheduleFilePath = Path.Combine(basePath, "JsonFiles", "SeasonSchedule.json");
            _loadedData.FullSchedule = _jsonRepo.Load<FullSchedule[]>(scheduleFilePath);

            var seriesFilePath = Path.Combine(basePath, "JsonFiles", "SeriesDetails.json");
            _loadedData.SeriesDetails = _jsonRepo.Load<SeriesDetails[]>(seriesFilePath);

            var weatherFilePath = Path.Combine(basePath, "JsonFiles", "WeatherSchedule.json");
            _loadedData.WeatherSchedule = _jsonRepo.Load<WeatherSchedule>(weatherFilePath);

            var carClassesFilePath = Path.Combine(basePath, "JsonFiles", "CarClasses.json");
            _loadedData.CarClasses = _jsonRepo.Load<JsonClasses.CarClasses.CarClasses[]>(carClassesFilePath);

            var carsFilePath = Path.Combine(basePath, "JsonFiles", "Cars.json");
            _loadedData.CarDetails = _jsonRepo.Load<CarDetails[]>(carsFilePath);

            var tracksFilePath = Path.Combine(basePath, "JsonFiles", "Tracks.json");
            _loadedData.TrackDetails = _jsonRepo.Load<TrackDetails[]>(tracksFilePath);
        }

        public void SetSelectedSeasonAndSeries(string seriesName)
        {
            var selectedSeries = _loadedData.FullSchedule.FirstOrDefault(s => s.Schedules[0].SeriesName == seriesName);
            _loadedData.SelectedSeries = selectedSeries;

            _loadedData.SelectedSeriesDetails = _loadedData.SeriesDetails.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);

            _loadedData.SelectedSeriesWeather = _loadedData.WeatherSchedule.Series.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);
        }

        public IEnumerable<string> GetAvailableSeries()
        {
            var availableSeries = new List<string>();
            var schedules = _loadedData.FullSchedule;
            var carClasses = _loadedData.CarClasses;
            var carDetails = _loadedData.CarDetails;

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
                    availableSeries.Add(schedule.Schedules[0].SeriesName);
                }
            }

            availableSeries.Sort();
            return availableSeries;
        }

        public IEnumerable<string> GetAvailableCars()
        {
            var cars = new List<string>();
            var carIds = new List<int>();
            var carClasses = _loadedData.SelectedSeries.CarClassIds;

            foreach (var carClass in carClasses)
            {
                var ids = _loadedData.CarClasses.FirstOrDefault(c => c.CarClassId == carClass);

                foreach (var id in ids.CarsInClass)
                {
                    var car = _loadedData.CarDetails.FirstOrDefault(c => c.CarId == id.CarId);

                    if (car.AiEnabled)
                    {
                        cars.Add(car.CarName);
                    }
                }
            }

            return cars;
        }

        public IEnumerable<string> GetAvailableTracks()
        {
            var availableTracks = new List<string>();
            var ss = _loadedData.SelectedSeries;

            foreach (var evnt in ss.Schedules)
            {
                var id = evnt.Track.TrackId;

                var trackDetail = _loadedData.TrackDetails.FirstOrDefault(t => t.TrackId == id);

                if (trackDetail.AiEnabled)
                {
                    availableTracks.Add(trackDetail.TrackName);
                }
            }

            return availableTracks;
        }

        public int GetDriverCount()
        {
            return _loadedData.SelectedSeriesDetails.MaxStarters;
        }

        public int GetPracticeLength()
        {
            return 3;
        }

        public int GetQualiLength(bool qualiAlone)
        {
            var ss = _loadedData.SelectedSeries.Schedules[0];

            if (_loadedData.SelectedSeries != null)
            {
                if (qualiAlone)
                    return ss.QualifyLaps > 5 ? 5 : ss.QualifyLaps;
                else
                    return ss.QualifyLength > 30 ? 30 :  ss.QualifyLength;
            }
            else
            {
                if (qualiAlone)
                    return 2;
                else
                    return 8;
            }
        }

        public int GetRaceLength()
        {
            var ss = _loadedData.SelectedSeries.Schedules[0];

            if (ss.RaceLapLimit == null)
            {
                return ss.RaceTimeLimit > 300 ? 300 : (int)ss.RaceTimeLimit;
            }

            return 100;
        }

        public IEnumerable<string> GetAvailableRosters()
        {
            var rosterNames = new List<string>() { "Generate Roster", "Exclude Roster"};
            var folerPath = _appSettings.RosterFolderPath;

            if (Directory.Exists(folerPath))
            {
                var rosters = Directory.GetDirectories(folerPath);

                if (rosters.Length > 0)
                {
                    foreach (var roster in rosters)
                    {
                        rosterNames.Add(Path.GetFileName(roster));
                    }
                }
            }
            return rosterNames;
        }

        public void CreateSeason(string seasonName)
        {
            var filePath = Path.Combine(_appSettings.SeasonFolderPath, $"{seasonName}.json");
            try
            {
                var sb = _seasonBuilder.BuildSeason();
                _jsonRepo.Save(filePath, sb);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
