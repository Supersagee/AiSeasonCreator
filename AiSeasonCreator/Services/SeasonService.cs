using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using AiSeasonCreator.Repos;
using iRacingWeatherURLParser.WeatherSchedule;
using System;
using System.Collections.Generic;
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

        public SeasonService(IJsonRepo jsonRepo, LoadedData loadedData)
        {
            _jsonRepo = jsonRepo;
            _loadedData = loadedData;
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
            _loadedData.CarClasses = _jsonRepo.Load<CarClasses[]>(carClassesFilePath);

            var carsFilePath = Path.Combine(basePath, "JsonFiles", "Cars.json");
            _loadedData.CarDetails = _jsonRepo.Load<CarDetails[]>(carsFilePath);

            var tracksFilePath = Path.Combine(basePath, "JsonFiles", "Tracks.json");
            _loadedData.TrackDetails = _jsonRepo.Load<TrackDetails[]>(tracksFilePath);
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

        public void SetSelectedSeasonAndSeries(string seriesName)
        {
            var selectedSeries = _loadedData.FullSchedule.FirstOrDefault(s => s.Schedules[0].SeriesName == seriesName);
            _loadedData.SelectedSeries = selectedSeries;

            _loadedData.SelectedSeriesDetails = _loadedData.SeriesDetails.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);
        }
    }
}
