using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Diagnostics.Contracts;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class WeatherSummary
    {
        [JsonPropertyName("temp_low")]
        public double TempLow { get; set; }
        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }
        [JsonPropertyName("wind_low")]
        public double WindLow { get; set; }
        [JsonPropertyName("skies_low")]
        public int SkiesLow { get; set; }
        [JsonPropertyName("temp_high")]
        public double TempHigh { get; set; }
        [JsonPropertyName("wind_high")]
        public double WindHigh { get; set; }
        [JsonPropertyName("skies_high")]
        public int SkiesHigh { get; set; }
        [JsonPropertyName("temp_units")]
        public int TempUnits { get; set; }
        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }
        [JsonPropertyName("precip_chance")]
        public double PrecipChance { get; set; }
        [JsonPropertyName("max_precip_rate")]
        public double MaxPrecipRate { get; set; }
        [JsonPropertyName("max_precip_rate_desc")]
        public string MaxPrecipRateDesc { get; set; }
    }
}
