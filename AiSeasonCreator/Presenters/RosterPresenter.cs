using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Repos;
using AiSeasonCreator.Roster;
using AiSeasonCreator.Services;
using AiSeasonCreator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    public class RosterPresenter : IRosterPresenter
    {
        private IRosterView _view;
        private IRosterService _rosterService;
        private IJsonRepo _jsonRepo;
        private LoadedData _loadedData;
        private AppSettings _appSettings;

        public RosterPresenter(IRosterView view, 
            IRosterService rosterService, 
            IJsonRepo jsonRepo, 
            LoadedData loadedData,
            AppSettings appSettings)
        {
            _view = view;
            _rosterService = rosterService;
            _jsonRepo = jsonRepo;
            _loadedData = loadedData;
            _appSettings = appSettings;

            _view.ViewLoaded += OnViewLoaded;
            _view.RosterSourceIndexChanged += OnRosterSourceIndexChanged;
            _view.SeriesRosterIndexChanged += OnSeriesRosterIndexChanged;
            _view.DriversIndexChanged += OnDriversIndexChanged;
            _view.CreateUpdateRosterClicked += OnCreateUpdateRosterClicked;
        }

        public void OnViewLoaded(object sender, EventArgs e)
        {
            _view.RosterSourceList = _rosterService.GetRosterSources();
        }

        public void OnRosterSourceIndexChanged(object sender, EventArgs e)
        {
            _view.SeriesRosterList = _rosterService.GetAvailableSeriesOrRosters(_view.RosterSource);
        }

        public void OnSeriesRosterIndexChanged(object sender, EventArgs e)
        {
            if (_view.RosterSource == "Update from existing roster")
            {
                _view.DriversList = _rosterService.GetAvailableDrivers(_view.SeriesRosterName);
            }
            else
            {
                _rosterService.SetSelectedSeasonAndSeries(_view.SeriesRosterName);
            }

            _view.DriverCount = _rosterService.GetDriverCount();
        }

        public void OnDriversIndexChanged(object sender, EventArgs e)
        {
            var driver = _rosterService.GetDriver(_view.DriverName);

            if (driver != null)
            {
                _view.RelativeSkillMax = driver.DriverSkill;
                _view.AggressionMax = driver.DriverAggression;

                var colors = GetColors(driver.HelmetDesign);
                
                if (colors.Count == 3)
                {
                    _view.DriverColor1 = colors[0];
                    _view.DriverColor2 = colors[1];
                    _view.DriverColor3 = colors[2];
                }
                else
                {
                    _view.DriverColor1 = "#000000";
                    _view.DriverColor2 = "#000000";
                    _view.DriverColor3 = "#000000";
                }

                _view.DriverNumber = Convert.ToInt32(driver.CarNumber);
                _view.DriverCar = _loadedData.CarDetails.FirstOrDefault(c => c.CarId == driver.CarId).CarName;
            }
            
        }

        public void OnCreateUpdateRosterClicked(object sender, EventArgs e)
        {
            if (_view.RosterSource == "Create from iRacing series")
            {
                _rosterService.CreateRoster();
            }
            else
            {
                if (_view.DriverName == "Update All Drivers")
                {
                    UpdateRoster(true); 
                }
                else
                {
                    UpdateRoster(false);
                }
            }
            
        }

        private void UpdateRoster(bool updateAllDrivers)
        {
            var rand = new Random();
            var rosterFilePath = Path.Combine(_appSettings.RosterFolderPath, _view.SeriesRosterName, "roster.json");
            var roster = _jsonRepo.Load<DriverRoster>(rosterFilePath);
            var drivers = roster.Drivers;
            var v = _view;

            if (updateAllDrivers)
            {
                foreach (var d in drivers)
                {
                    d.DriverSkill = v.UseRelativeSkill ? rand.Next(v.RelativeSkillMin, v.RelativeSkillMax + 1) : d.DriverSkill;
                    d.DriverAggression = v.UseAggression ? rand.Next(v.AggressionMin, v.AggressionMax + 1) : d.DriverAggression;
                    d.DriverOptimism = v.UseOptimism ? rand.Next(v.OptimismMin, v.OptimismMax + 1) : d.DriverOptimism;
                    d.DriverSmoothness = v.UseSmoothness ? rand.Next(v.SmoothnessMin, v.SmoothnessMax + 1) : d.DriverSmoothness;
                    d.DriverAge = v.UseAge ? rand.Next(v.AgeMin, v.AgeMax + 1) : d.DriverAge;
                    d.PitCrewSkill = v.UsePitCrew ? rand.Next(v.PitCrewMin, v.PitCrewMax + 1) : d.PitCrewSkill;
                    d.StrategyRiskiness = v.UsePitStrat ? rand.Next(v.PitStratMin, v.PitStratMax + 1) : d.StrategyRiskiness;
                }
            }
            else
            {
                foreach (var d in drivers)
                {
                    if (d.DriverName == v.DriverName)
                    {
                        d.DriverSkill = v.UseRelativeSkill ? rand.Next(v.RelativeSkillMin, v.RelativeSkillMax + 1) : d.DriverSkill;
                        d.DriverAggression = v.UseAggression ? rand.Next(v.AggressionMin, v.AggressionMax + 1) : d.DriverAggression;
                        d.DriverOptimism = v.UseOptimism ? rand.Next(v.OptimismMin, v.OptimismMax + 1) : d.DriverOptimism;
                        d.DriverSmoothness = v.UseSmoothness ? rand.Next(v.SmoothnessMin, v.SmoothnessMax + 1) : d.DriverSmoothness;
                        d.DriverAge = v.UseAge ? rand.Next(v.AgeMin, v.AgeMax + 1) : d.DriverAge;
                        d.PitCrewSkill = v.UsePitCrew ? rand.Next(v.PitCrewMin, v.PitCrewMax + 1) : d.PitCrewSkill;
                        d.StrategyRiskiness = v.UsePitStrat ? rand.Next(v.PitStratMin, v.PitStratMax + 1) : d.StrategyRiskiness;
                    }
                }
            }
            DriverRoster newRoster = new DriverRoster { Drivers = drivers };
            _jsonRepo.Save(rosterFilePath, newRoster);
        }

        private List<string> GetColors(string colors)
        {
            List<string> colorList = colors.Split(',').ToList<string>();

            colorList.RemoveAt(0);
            var returnList = new List<string>();

            foreach (var color in colorList)
            {
                returnList.Add($"#{color}");
            }

            return returnList;
        }
    }
}
