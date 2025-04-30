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
        public bool UseAdaptiveAi { get; set; } = false;
        [JsonPropertyName("disableCarDamage")]
        public bool DisableCarDamage { get; set; } = false;
        [JsonPropertyName("aiAvoidsPlayer")]
        public bool AiAvoidsPlayer { get; set; } = false;
        [JsonPropertyName("consistentWeather")]
        public bool StaticWeather { get; set; } = false;
        [JsonPropertyName("afternoonRaces")]
        public bool AfternoonRaces { get; set; } = false;
        [JsonPropertyName("neverRain")]
        public bool NeverRain { get; set; } = false;
        [JsonPropertyName("qualifyAlone")]
        public bool QualifyAlone { get; set; } = true;
        [JsonPropertyName("shortParade")]
        public bool ShortParade { get; set; } = false;
        [JsonPropertyName("selectTracks")]
        public bool SelectTracks { get; set; } = false;
        [JsonPropertyName("excludeRoster")]
        public bool ExcludeRoster { get; set; } = false;
        [JsonPropertyName("useRosterTabAtt")]
        public bool UseRosterTabAtt { get; set; } = false;
    }
}
