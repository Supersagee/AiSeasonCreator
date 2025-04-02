using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Views
{
    public interface ISeasonView
    {
        event EventHandler ViewLoaded;
        event EventHandler SeriesIndexChanged;
        event EventHandler RosterClicked;
        event EventHandler CreateSeasonClicked;

        IEnumerable<string> SeriesList { set; }
        IEnumerable<string> CarList { set; }
        IEnumerable<string> TrackList { set; }
        IEnumerable<string> SelectedTracks { get; }
        IEnumerable<string> RosterList { set; }

        string SeasonName { get; }
        string SeriesName { get; }
        string CarName { get; }
        bool UseAdaptiveAi { get; set; }
        string AdaptiveAiDifficulty { get; set; }
        int AiMin { get; set; }
        int AiMax { get; set; }
        bool DisableDamage { get; set; }
        bool AiAvoids { get; set; }
        bool StaticWeather { get; set; }
        bool AfternoonRaces { get; set; }
        bool NeverRain { get; set; }
        bool QualiAlone { get; set; }
        bool ShortParade { get; set; }
        string RosterName { get; set; }
        int CarCount { get; set; }
    }
}
