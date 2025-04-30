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
        public int AiMinSkill { get; set; } = 25;
        [JsonPropertyName("aiMaxSkill")]
        public int AiMaxSkill { get; set; } = 75;
        [JsonPropertyName("relativeMinSkill")]
        public int RelativeMinSkill { get; set; } = 25;
        [JsonPropertyName("relativeMaxSkill")]
        public int RelativeMaxSkill { get; set; } = 75;
        [JsonPropertyName("aggressionMinSkill")]
        public int AggressionMinSkill { get; set; } = 25;
        [JsonPropertyName("aggressionMaxSkill")]
        public int AggressionMaxSkill { get; set; } = 75;
        [JsonPropertyName("optimismMinSkill")]
        public int OptimismMinSkill { get; set; } = 25;
        [JsonPropertyName("optimismMaxSkill")]
        public int OptimismMaxSkill { get; set; } = 75;
        [JsonPropertyName("smoothnessMinSkill")]
        public int SmoothnessMinSkill { get; set; } = 25;
        [JsonPropertyName("smoothnessMaxSkill")]
        public int SmoothnessMaxSkill { get; set; } = 75;
        [JsonPropertyName("ageMinSkill")]
        public int AgeMinSkill { get; set; } = 25;
        [JsonPropertyName("ageMaxSkill")]
        public int AgeMaxSkill { get; set; } = 75;
        [JsonPropertyName("pitCrewMinSkill")]
        public int PitCrewMinSkill { get; set; } = 25;
        [JsonPropertyName("pitCrewMaxSkill")]
        public int PitCrewMaxSkill { get; set; } = 75;
        [JsonPropertyName("pitStratMinSkill")]
        public int PitStratMinSkill { get; set; } = 25;
        [JsonPropertyName("pitStratMaxSkill")]
        public int PitStratMaxSkill { get; set; } = 75;
    }
}
