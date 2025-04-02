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
        string AboutSection { get; set; }
    }
}
