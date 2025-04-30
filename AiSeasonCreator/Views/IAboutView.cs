using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Views
{
    public interface IAboutView
    {
        event EventHandler ViewLoaded;
        event EventHandler ForumLinkClicked;
        string GeneralAboutSection { get; set; }
        string SeasonAboutSection { get; set; }
        string RosterAboutSection { get; set; }
    }
}
