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
        void OnSeriesRosterIndexChanged(object sender, EventArgs e);
        void OnRosterComboBoxClicked(object sender, EventArgs e);
        void OnRosterComboBoxIndexChanged(object sender, EventArgs e);
        void OnUpdateSelectedDriversButtonClicked(object sender, EventArgs e);
        void OnSkillCellUpdated(object sender, EventArgs e);
        void OnCreateUpdateRosterClicked(object sender, EventArgs e);
    }
}
