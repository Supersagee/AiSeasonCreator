using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Helpers;
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
            _view.SeriesRosterIndexChanged += OnSeriesRosterIndexChanged;
            _view.RosterComboBoxClicked += OnRosterComboBoxClicked;
            _view.RosterComboBoxIndexChanged += OnRosterComboBoxIndexChanged;
            _view.UpdateSelectedDriversButtonClicked += OnUpdateSelectedDriversButtonClicked;
            _view.UpdateAllDriversButtonClicked += OnUpdateAllDriversButtonClicked;
            _view.SkillCellUpdated += OnSkillCellUpdated;
            _view.CreateUpdateRosterClicked += OnCreateUpdateRosterClicked;
        }

        public void OnViewLoaded(object sender, EventArgs e)
        {
            _view.SeriesList = _rosterService.GetAvailableSeries();
        }

        public void OnSeriesRosterIndexChanged(object sender, EventArgs e)
        {
            _rosterService.SetSelectedSeasonAndSeries(_view.SeriesName);
            _view.DriverCount = _rosterService.GetDriverCount();
        }

        public void OnRosterComboBoxClicked(object sender, EventArgs e)
        {
            _view.RosterList = _rosterService.GetAvailableRosters();
        }

        public void OnRosterComboBoxIndexChanged(object sender, EventArgs e)
        {
            _rosterService.GetAvailableDrivers(_view.ExistingRosterName);
        }

        public void OnUpdateAllDriversButtonClicked(object sender, EventArgs e)
        {
            var attributesInUse = new AttributesInUse()
            {
                RelativeSkillMin = _view.RelativeSkillMin,
                RelativeSkillMax = _view.RelativeSkillMax,
                AggressionMin = _view.AggressionMin,
                AggressionMax = _view.AggressionMax,
                OptimismMin = _view.OptimismMin,
                OptimismMax = _view.OptimismMax,
                SmoothnessMin = _view.SmoothnessMin,
                SmoothnessMax = _view.SmoothnessMax,
                AgeMin = _view.AgeMin,
                AgeMax = _view.AgeMax,
                PitCrewMin = _view.PitCrewMin,
                PitCrewMax = _view.PitCrewMax,
                PitStratMin = _view.PitStratMin,
                PitStratMax = _view.PitStratMax,
                UseRelativeSkill = _view.UseRelativeSkill,
                UseAggression = _view.UseAggression,
                UseOptimism = _view.UseOptimism,
                UseSmoothness = _view.UseSmoothness,
                UseAge = _view.UseAge,
                UsePitCrew = _view.UsePitCrew,
                UsePitStrat = _view.UsePitStrat
            };

            _rosterService.UpdateDrivers(_view.SelectedDrivers, attributesInUse, _view.ExistingRosterName, true, _view.MinusPlusRandomize);
        }

        public void OnUpdateSelectedDriversButtonClicked(object sender, EventArgs e)
        {
            var attributesInUse = new AttributesInUse()
            {
                RelativeSkillMin = _view.RelativeSkillMin,
                RelativeSkillMax = _view.RelativeSkillMax,
                AggressionMin = _view.AggressionMin,
                AggressionMax = _view.AggressionMax,
                OptimismMin = _view.OptimismMin,
                OptimismMax = _view.OptimismMax,
                SmoothnessMin = _view.SmoothnessMin,
                SmoothnessMax = _view.SmoothnessMax,
                AgeMin = _view.AgeMin,
                AgeMax = _view.AgeMax,
                PitCrewMin = _view.PitCrewMin,
                PitCrewMax = _view.PitCrewMax,
                PitStratMin = _view.PitStratMin,
                PitStratMax = _view.PitStratMax,
                UseRelativeSkill = _view.UseRelativeSkill,
                UseAggression = _view.UseAggression,
                UseOptimism = _view.UseOptimism,
                UseSmoothness = _view.UseSmoothness,
                UseAge = _view.UseAge,
                UsePitCrew = _view.UsePitCrew,
                UsePitStrat = _view.UsePitStrat
            };

            _rosterService.UpdateDrivers(_view.SelectedDrivers, attributesInUse, _view.ExistingRosterName, false, _view.MinusPlusRandomize);
        }

        public void OnSkillCellUpdated(object sender, EventArgs e)
        {
            _rosterService.SkillCellUpdated(_view.ExistingRosterName);
        }

        public void OnCreateUpdateRosterClicked(object sender, EventArgs e)
        {
            _rosterService.CreateRoster(_view.RosterName);
        }
    }
}
