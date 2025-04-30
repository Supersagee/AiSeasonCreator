using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Views
{
    public interface ISettingsView
    {
        event EventHandler ViewLoaded;
        event EventHandler SeasonFolderClicked;
        event EventHandler RosterFolderClicked;

        string SeasonFolderPath { get; set; }
        string RosterFolderPath { get; set; }
        string SetFolderPathLabel { get; set; }
    }
}
