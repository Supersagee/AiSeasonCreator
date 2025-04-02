using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    public interface ISeasonPresenter
    {
        void OnViewLoaded(object sender, EventArgs e);
        void OnSeriesIndexChanged(object sender, EventArgs e);
        void OnRosterClicked(object sender, EventArgs e);
        void OnCreateSeasonClicked(object sender, EventArgs e);
    }
}
