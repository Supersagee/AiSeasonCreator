using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class WebKeyframes
    {
        [JsonPropertyName("time_offset")]
        public int TimeOffset { get; set; }
        [JsonPropertyName("raw_air_temp")]
        public int RawAirTemp { get; set; }
        [JsonPropertyName("precip_chance")]
        public int PrecipChance { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("is_sun_up")]
        public bool IsSunUp { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }
        [JsonPropertyName("air_temp")]
        public int AirTemp { get; set; }
        [JsonPropertyName("valid_stats")]
        public bool ValidStats { get; set; }
        [JsonPropertyName("affects_session")]
        public bool AffectsSession { get; set; }
        [JsonPropertyName("cloud_cover")]
        public int CloudCover { get; set; }
        [JsonPropertyName("rel_humidity")]
        public int RelHumidity { get; set; }
        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }
        [JsonPropertyName("allow_precip")]
        public bool AllowPrecip { get; set; }
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("precip_amount")]
        public int PrecipAmount { get; set; }
    }
}
