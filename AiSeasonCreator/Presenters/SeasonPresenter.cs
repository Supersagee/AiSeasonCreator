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

        public SeasonPresenter(ISeasonView view, ISeasonService seasonService)
        {
            _view = view;
            _seasonService = seasonService;

            _view.ViewLoaded += OnViewLoaded;
            _view.SeriesIndexChanged += OnSeriesIndexChanged;
            _view.CreateSeasonClicked += OnCreateSeasonClicked;
        }

        public void OnViewLoaded(object sender, EventArgs e)
        {
            _seasonService.Initialize();
            _view.SeriesList = _seasonService.GetAvailableSeries();
        }

        public void OnSeriesIndexChanged(object sender, EventArgs e)
        {
            _seasonService.SetSelectedSeasonAndSeries(_view.SeriesName);
        }

        public void OnCreateSeasonClicked(object sender, EventArgs e)
        {

        }
    }
}
