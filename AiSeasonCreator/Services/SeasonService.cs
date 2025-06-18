using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Helpers;
using AiSeasonCreator.JsonClasses.Assets;
using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using AiSeasonCreator.Mappers;
using AiSeasonCreator.Repos;
using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.Views;
using iRacingWeatherURLParser.WeatherSchedule;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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

            var carAssetsFilePath = Path.Combine(basePath, "JsonFiles", "CarAssets.json");
            _loadedData.CarAssets = _jsonRepo.Load<Dictionary<string, CarAssets>>(carAssetsFilePath);

            var seriesAssetsFilePath = Path.Combine(basePath, "JsonFiles", "SeriesAssets.json");
            _loadedData.SeriesAssets = _jsonRepo.Load<Dictionary<string, SeriesAssets>>(seriesAssetsFilePath);

            var trackAssetsFilePath = Path.Combine(basePath, "JsonFiles", "TrackAssets.json");
            _loadedData.TrackAssets = _jsonRepo.Load<Dictionary<string, TrackAssets>>(trackAssetsFilePath);
        }

        public void SetSelectedSeasonAndSeries(string seriesName)
        {
            var selectedSeries = _loadedData.FullSchedule.FirstOrDefault(s => s.Schedules[0].SeriesName == seriesName);
            _loadedData.SelectedSeries = selectedSeries;

            _loadedData.SelectedSeriesDetails = _loadedData.SeriesDetails.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);

            _loadedData.SelectedSeriesWeather = _loadedData.WeatherSchedule.Series.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);
        }

        public IEnumerable<NameAndAsset> GetAvailableSeries()
        {
            var availableSeries = new List<NameAndAsset>();
            var schedules = _loadedData.FullSchedule;
            var carClasses = _loadedData.CarClasses;
            var carDetails = _loadedData.CarDetails;

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var schedule in schedules)
            {
                var naa = new NameAndAsset();

                var carIds = schedule.CarClassIds;
                var carsInSeries = carClasses
                    .Where(cc => carIds.Contains(cc.CarClassId))
                    .SelectMany(cc => cc.CarsInClass.Select(car => car.CarId))
                    .ToList();

                var aiCarsInSeries = carDetails
                    .Where(cd => carsInSeries.Contains(cd.CarId) && cd.AiEnabled)
                    .ToList();

                var seriesAssets = _loadedData.SeriesAssets.FirstOrDefault(s => Convert.ToInt32(s.Key) == schedule.SeriesId).Value.Logo;
                seriesAssets = Path.Combine(basePath, "Assets", "SeriesAssets", seriesAssets);

                if (aiCarsInSeries.Any())
                {
                    naa.Name = schedule.Schedules[0].SeriesName;

                    if (File.Exists(seriesAssets))
                        naa.Asset = Image.FromFile(seriesAssets);

                    availableSeries.Add(naa);
                }
            }

            availableSeries.Sort((x, y) => x.Name.CompareTo(y.Name));
            return availableSeries;
        }

        public IEnumerable<NameAndAsset> GetAvailableCars()
        {
            var cars = new List<NameAndAsset>();
            var carIds = new List<int>();
            var carClasses = _loadedData.SelectedSeries.CarClassIds;

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var carClass in carClasses)
            {
                var ids = _loadedData.CarClasses.FirstOrDefault(c => c.CarClassId == carClass);

                foreach (var id in ids.CarsInClass)
                {
                    var naa = new NameAndAsset();

                    var car = _loadedData.CarDetails.FirstOrDefault(c => c.CarId == id.CarId);
                    var carAssets = _loadedData.CarAssets.FirstOrDefault(c => Convert.ToInt32(c.Key) == id.CarId).Value.Logo;
                    carAssets = Path.Combine(basePath, "Assets", "CarAssets", carAssets);

                    if (car.AiEnabled)
                    {
                        naa.Name = car.CarName;

                        if (File.Exists(carAssets))
                            naa.Asset = Image.FromFile(carAssets);

                        cars.Add(naa);
                    }
                }
            }

            return cars;
        }

        public IEnumerable<NameAndAsset> GetAvailableTracks()
        {
            var availableTracks = new List<NameAndAsset>();
            var ss = _loadedData.SelectedSeries;

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var evnt in ss.Schedules)
            {
                var naa = new NameAndAsset();
                var id = evnt.Track.TrackId;

                var trackDetail = _loadedData.TrackDetails.FirstOrDefault(t => t.TrackId == id);
                var trackAssets = _loadedData.TrackAssets.FirstOrDefault(c => Convert.ToInt32(c.Key) == evnt.Track.TrackId).Value.Logo;
                trackAssets = Path.Combine(basePath, "Assets", "TrackAssets", trackAssets);

                if (trackDetail.AiEnabled)
                {
                    naa.Name = trackDetail.TrackName;

                    if (File.Exists(trackAssets))
                        naa.Asset = Image.FromFile(trackAssets);

                    availableTracks.Add(naa);
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
            if (_loadedData.SelectedSeries != null)
            {
                var ss = _loadedData.SelectedSeries.Schedules[0];

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
                        var path = Path.Combine(roster, "roster.json");
                        if (File.Exists(path))
                            rosterNames.Add(Path.GetFileName(roster));
                    }
                }
            }
            return rosterNames;
        }

        public void CreateSeason(string seasonName)
        {
            (seasonName, var filePath) = IncrementFileName(seasonName);

            try
            {
                var sb = _seasonBuilder.BuildSeason(seasonName);
                _jsonRepo.Save(filePath, sb);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private (string SeasonName, string FilePath) IncrementFileName(string seasonName)
        {
            var filePath = Path.Combine(_appSettings.SeasonFolderPath, $"{seasonName}.json");

            var newSeasonName = seasonName;
            int fileCounter = 0;
            while (File.Exists(filePath))
            {
                fileCounter++;
                filePath = Path.Combine(_appSettings.SeasonFolderPath, $"{seasonName}({fileCounter}).json");
                newSeasonName = $"{seasonName}({fileCounter})";
            }

            return (newSeasonName, filePath);
        }
    }
}
