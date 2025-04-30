using AiSeasonCreator.Data;
using AiSeasonCreator.Services;
using AiSeasonCreator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    public class SeasonPresenter : ISeasonPresenter
    {
        private ISeasonView _view;
        private ISeasonService _seasonService;
        private LoadedData _loadedData;

        public SeasonPresenter(ISeasonView view, ISeasonService seasonService, LoadedData loadedData)
        {
            _view = view;
            _seasonService = seasonService;
            _loadedData = loadedData;

            _view.ViewLoaded += OnViewLoaded;
            _view.SeriesIndexChanged += OnSeriesIndexChanged;
            _view.RosterClicked += OnRosterClicked;
            _view.QualiAloneChecked += OnQualiAloneChecked;
            _view.CreateSeasonClicked += OnCreateSeasonClicked;
        }

        public void OnViewLoaded(object sender, EventArgs e)
        {
            _seasonService.Initialize();
            _view.SeriesList = _seasonService.GetAvailableSeries();
            _view.RosterList = _seasonService.GetAvailableRosters();
            SetUserDefaultSettings();
        }

        public void OnSeriesIndexChanged(object sender, EventArgs e)
        {
            _seasonService.SetSelectedSeasonAndSeries(_view.SelectedSeries);
            _view.CarList = _seasonService.GetAvailableCars();
            _view.TrackList =_seasonService.GetAvailableTracks();
            _view.CarCount = _seasonService.GetDriverCount();
            _view.QualiLength = _seasonService.GetQualiLength(_view.QualiAlone);
            _view.RaceLength = _seasonService.GetRaceLength();
        }

        public void OnRosterClicked(object sender, EventArgs e)
        {
            _view.RosterList = _seasonService.GetAvailableRosters();
        }

        public void OnQualiAloneChecked(object sender, EventArgs e)
        {
            _view.QualiLength = _seasonService.GetQualiLength(_view.QualiAlone);
        }

        public void OnCreateSeasonClicked(object sender, EventArgs e)
        {
            _seasonService.CreateSeason(_view.SeasonName);
            var bp = 0;
        }

        private void SetUserDefaultSettings()
        {
            var ud = _loadedData.UserDefaultSettings;

            _view.AiMin = ud.TrackBarUserValues.AiMinSkill;
            _view.AiMax = ud.TrackBarUserValues.AiMaxSkill;

            _view.UseAdaptiveAi = ud.CheckBoxesUserValues.UseAdaptiveAi;
            _view.DisableDamage = ud.CheckBoxesUserValues.DisableCarDamage;
            _view.AiAvoids = ud.CheckBoxesUserValues.AiAvoidsPlayer;
            _view.StaticWeather = ud.CheckBoxesUserValues.StaticWeather;
            _view.AfternoonRaces = ud.CheckBoxesUserValues.AfternoonRaces;
            _view.NeverRain = ud.CheckBoxesUserValues.NeverRain;
            _view.QualiAlone = ud.CheckBoxesUserValues.QualifyAlone;
            _view.ShortParade = ud.CheckBoxesUserValues.ShortParade;

            _view.AdaptiveAiDifficulty = ud.ComboBoxesUserValues.AdaptiveAiSkillLevel;
        }
    }
}
