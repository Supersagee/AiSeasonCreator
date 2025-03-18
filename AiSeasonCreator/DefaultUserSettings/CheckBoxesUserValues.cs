using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.DefaultUserSettings
{
    public class CheckBoxesUserValues
    {
        [JsonPropertyName("useAdaptiveAi")]
        public bool UseAdaptiveAi { get; set; }
        [JsonPropertyName("disableCarDamage")]
        public bool DisableCarDamage { get; set; }
        [JsonPropertyName("aiAvoidsPlayer")]
        public bool AiAvoidsPlayer { get; set; }
        [JsonPropertyName("consistentWeather")]
        public bool ConsistentWeather { get; set; }
        [JsonPropertyName("afternoonRaces")]
        public bool AfternoonRaces { get; set; }
        [JsonPropertyName("neverRain")]
        public bool NeverRain { get; set; }
        [JsonPropertyName("qualifyAlone")]
        public bool QualifyAlone { get; set; }
        [JsonPropertyName("shortParade")]
        public bool ShortParade { get; set; }
        [JsonPropertyName("selectTracks")]
        public bool SelectTracks { get; set; }
        [JsonPropertyName("excludeRoster")]
        public bool ExcludeRoster { get; set; }
        [JsonPropertyName("useRosterTabAtt")]
        public bool UseRosterTabAtt { get; set; }
    }
}
