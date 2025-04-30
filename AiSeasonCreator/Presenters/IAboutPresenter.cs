using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    public interface IAboutPresenter
    {
        void OnViewLoaded(object sender, EventArgs e);
        void OnForumLinkClicked(object sender, EventArgs e);
    }
}
