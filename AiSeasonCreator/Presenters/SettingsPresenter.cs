using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Services;
using AiSeasonCreator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    class SettingsPresenter : ISettingsPresenter
    {
        private ISettingsView _view;
        private ISettingsService _settingsService;
        private AppSettings _appSettings;
        public SettingsPresenter(ISettingsView view, ISettingsService settingsService, AppSettings appSettings)
        {
            _view = view;
            _settingsService = settingsService;
            _appSettings = appSettings;

            _view.ViewLoaded += OnViewLoaded;
            _view.SeasonFolderClicked += OnSeasonFolderClicked;
            _view.RosterFolderClicked += OnRosterFolderClicked;
        }

        public void OnViewLoaded(object sender, EventArgs e)
        {
            _settingsService.LoadUserDefaultSettings();

            _view.SeasonFolderPath = _settingsService.GetSeasonsFolderPathAuto("aiseasons");
            _appSettings.SeasonFolderPath = _view.SeasonFolderPath;

            _view.RosterFolderPath = _settingsService.GetRostersFolderPathAuto("airosters");
            _appSettings.RosterFolderPath = _view.RosterFolderPath;
        }

        public void OnSeasonFolderClicked(object sender, EventArgs e)
        {
            _view.SeasonFolderPath = _settingsService.GetSeasonsFolderPath("aiseasons");
            _appSettings.SeasonFolderPath = _view.SeasonFolderPath;
        }

        public void OnRosterFolderClicked(object sender, EventArgs e)
        {
            _view.RosterFolderPath = _settingsService.GetRostersFolderPath("airosters");
            _appSettings.RosterFolderPath = _view.RosterFolderPath;
        }
    }
}
