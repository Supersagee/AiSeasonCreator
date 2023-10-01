using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.DefaultUserSettings
{
    public class TrackBarUserValues
    {
        [JsonPropertyName("aiMinSkill")]
        public int AiMinSkill { get; set; }
        [JsonPropertyName("aiMaxSkill")]
        public int AiMaxSkill { get; set; }
        [JsonPropertyName("relativeMinSkill")]
        public int RelativeMinSkill { get; set; }
        [JsonPropertyName("relativeMaxSkill")]
        public int RelativeMaxSkill { get; set;}
        [JsonPropertyName("aggressionMinSkill")]
        public int AggressionMinSkill { get; set; }
        [JsonPropertyName("aggressionMaxSkill")]
        public int AggressionMaxSkill { get; set; }
        [JsonPropertyName("optimismMinSkill")]
        public int OptimismMinSkill { get; set; }
        [JsonPropertyName("optimismMaxSkill")]
        public int OptimismMaxSkill { get; set; }
        [JsonPropertyName("smoothnessMinSkill")]
        public int SmoothnessMinSkill { get; set; }
        [JsonPropertyName("smoothnessMaxSkill")]
        public int SmoothnessMaxSkill { get; set; }
        [JsonPropertyName("ageMinSkill")]
        public int AgeMinSkill { get; set; }
        [JsonPropertyName("ageMaxSkill")]
        public int AgeMaxSkill { get; set; }
        [JsonPropertyName("pitCrewMinSkill")]
        public int PitCrewMinSkill { get; set; }
        [JsonPropertyName("pitCrewMaxSkill")]
        public int PitCrewMaxSkill { get; set; }
        [JsonPropertyName("pitStratMinSkill")]
        public int PitStratMinSkill { get; set; }
        [JsonPropertyName("pitStratMaxSkill")]
        public int PitStratMaxSkill { get; set; }
    }
}
