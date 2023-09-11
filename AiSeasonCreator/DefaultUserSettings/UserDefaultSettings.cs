using System;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.DefaultUserSettings
{
    public class UserDefaultSettings
    {
        [JsonPropertyName("settingsVersion")]
        public int SettingsVersion { get; set; }
        [JsonPropertyName("disableCarDamage")]
        public bool DisableCarDamage { get; set; }
        [JsonPropertyName("aiAvoidsPlayer")]
        public bool AiAvoidsPlayer { get; set; }
        [JsonPropertyName("consistentWeather")]
        public bool ConsistentWeather { get; set; }
        [JsonPropertyName("afternoonRaces")]
        public bool AfternoonRaces { get; set; }
        [JsonPropertyName("qualifyAlone")]
        public bool QualifyAlone { get; set; }
        [JsonPropertyName("shortParade")]
        public bool ShortParade { get; set; }
        [JsonPropertyName("selectTracks")]
        public bool SelectTracks { get; set; }
        [JsonPropertyName("aiMinSkill")]
        public int AiMinSkill { get; set; }
        [JsonPropertyName("aiMaxSkill")]
        public int AiMaxSkill { get; set; }
        [JsonPropertyName("windowLocation")]
        public WindowLocation WindowLocation { get; set; }
    }
}
