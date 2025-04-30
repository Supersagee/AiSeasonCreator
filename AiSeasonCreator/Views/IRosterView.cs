using AiSeasonCreator.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Views
{
    public interface IRosterView
    {
        event EventHandler ViewLoaded;
        event EventHandler SeriesRosterIndexChanged;
        event EventHandler RosterComboBoxClicked;
        event EventHandler RosterComboBoxIndexChanged;
        event EventHandler UpdateSelectedDriversButtonClicked;
        event EventHandler UpdateAllDriversButtonClicked;
        event EventHandler SkillCellUpdated;
        event EventHandler CreateUpdateRosterClicked;

        IEnumerable<string> SeriesList { set; }
        IEnumerable<string> RosterList { set; }
        DataGridViewSelectedCellCollection SelectedDrivers { get; }

        string RosterName { get; }
        string ExistingRosterName { get; }
        string SeriesName { get; }
        int DriverCount { get; set; }
        int RelativeSkillMin { get; set; }
        int RelativeSkillMax { get; set; }
        int AggressionMin { get; set; }
        int AggressionMax { get; set; }
        int OptimismMin { get; set; }
        int OptimismMax { get; set; }
        int SmoothnessMin { get; set; }
        int SmoothnessMax { get; set; }
        int AgeMin { get; set; }
        int AgeMax { get; set; }
        int PitCrewMin { get; set; }
        int PitCrewMax { get; set; }
        int PitStratMin { get; set; }
        int PitStratMax { get; set; }
        bool UseRelativeSkill { get; set; }
        bool UseAggression { get; set; }
        bool UseOptimism { get; set; }
        bool UseSmoothness { get; set; }
        bool UseAge { get; set; }
        bool UsePitCrew { get; set; }
        bool UsePitStrat { get; set; }
        bool MinusPlusRandomize { get; }
    }
}
