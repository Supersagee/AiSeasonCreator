using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Helpers
{
    public class AttributesInUse
    {
        public int RelativeSkillMin { get; set; }
        public int RelativeSkillMax { get; set; }
        public int AggressionMin { get; set; }
        public int AggressionMax { get; set; }
        public int OptimismMin { get; set; }
        public int OptimismMax { get; set; }
        public int SmoothnessMin { get; set; }
        public int SmoothnessMax { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int PitCrewMin { get; set; }
        public int PitCrewMax { get; set; }
        public int PitStratMin { get; set; }
        public int PitStratMax { get; set; }
        public bool UseRelativeSkill { get; set; }
        public bool UseAggression { get; set; }
        public bool UseOptimism { get; set; }
        public bool UseSmoothness { get; set; }
        public bool UseAge { get; set; }
        public bool UsePitCrew { get; set; }

        public bool UsePitStrat { get; set; }
    }
}
