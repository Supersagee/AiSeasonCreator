using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Views
{
    public interface IRosterView
    {
        event EventHandler ViewLoaded;
        event EventHandler RosterSourceIndexChanged;
        event EventHandler SeriesRosterIndexChanged;
        event EventHandler DriversIndexChanged;
        event EventHandler CreateUpdateRosterClicked;

        IEnumerable<string> RosterSourceList { set; }
        IEnumerable<string> SeriesRosterList { set; }
        IEnumerable<string> DriversList { set; }

        string RosterName { get; }
        string RosterSource { get; }
        string SeriesRosterName { get; }
        string DriverName { get; }
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
        public int DriverNumber{ set; }
        public string DriverCar { set; }
        public string DriverColor1{ set; }
        public string DriverColor2{ set ; }
        public string DriverColor3{ set ; }
    }
}
