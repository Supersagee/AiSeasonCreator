using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Mappers;
using AiSeasonCreator.Repos;
using AiSeasonCreator.Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public class RosterService : IRosterService
    {
        private IJsonRepo _jsonRepo;
        private LoadedData _loadedData;
        private AppSettings _appSettings;
        private readonly IMapper<DriverRoster> _driverRoster;
        public RosterService(IJsonRepo jsonRepo, 
            LoadedData loadedData, 
            AppSettings appSettings, 
            IMapper<DriverRoster> driverRoster)
        {
            _jsonRepo = jsonRepo;
            _loadedData = loadedData;
            _appSettings = appSettings;
            _driverRoster = driverRoster;
        }
        public void Initialize()
        {

        }
        public void SetSelectedSeasonAndSeries(string seriesName)
        {
            var selectedSeries = _loadedData.FullSchedule.FirstOrDefault(s => s.Schedules[0].SeriesName == seriesName);
            _loadedData.RosterSelectedSeries = selectedSeries;

            _loadedData.RosterSelectedSeriesDetails = _loadedData.SeriesDetails.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);
        }

        public IEnumerable<string> GetRosterSources()
        {
            return new List<string>() { "Create from iRacing series", "Update from existing roster" };
        }

        public IEnumerable<string> GetAvailableSeriesOrRosters(string rosterSource)
        {
            if (rosterSource == "Create from iRacing series")
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
            else
            {
                var rosters = Directory.GetDirectories(_appSettings.RosterFolderPath);
                var rosterNames = new List<string>();

                foreach (var roster in rosters)
                {
                    rosterNames.Add(Path.GetFileName(roster));
                }

                return rosterNames;
            }
        }

        public IEnumerable<string> GetAvailableDrivers(string rosterName)
        {
            var path = Path.Combine(_appSettings.RosterFolderPath, rosterName, "roster.json");
            var roster = _jsonRepo.Load<DriverRoster>(path);

            _loadedData.SelectedRoster = roster;

            var drivers = roster.Drivers;

            var driverNames = new List<string>() { "Update All Drivers" };

            foreach (var driver in drivers)
            {
                driverNames.Add(driver.DriverName);
            }

            return driverNames;
        }

        public int GetDriverCount()
        {
            return _loadedData.RosterSelectedSeriesDetails.MaxStarters;
        }

        public Drivers GetDriver(string driverName)
        {
            var driver = _loadedData.SelectedRoster.Drivers.FirstOrDefault(d => d.DriverName == driverName);

            return driver;
        }

        public void CreateRoster()
        {
            _driverRoster.Map(1, "");
        }
    }
}
