using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    public interface IRosterPresenter
    {
        void OnViewLoaded(object sender, EventArgs e);
        void OnRosterSourceIndexChanged(object sender, EventArgs e);
        void OnSeriesRosterIndexChanged(object sender, EventArgs e);
        void OnDriversIndexChanged(object sender, EventArgs e);
        void OnCreateUpdateRosterClicked(object sender, EventArgs e);
    }
}
