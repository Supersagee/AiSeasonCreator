using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace iRacingSeasonCreator.ScheduleClasses
{
    public class Weather
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("temp_units")]
        public int TempUnits { get; set; }
        [JsonPropertyName("temp_value")]
        public int TempValue { get; set; }
        [JsonPropertyName("rel_humidity")]
        public int RelHumidity { get; set; }
        [JsonPropertyName("fog")]
        public int Fog { get; set; }
        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }
        [JsonPropertyName("wind_units")]
        public int WindUnits { get; set; }
        [JsonPropertyName("wind_value")]
        public int WindValue { get; set; }
        [JsonPropertyName("skies")]
        public int Skies { get; set; }
        [JsonPropertyName("simulated_start_time")]
        public DateTime SimulatedStartTime { get; set; }
        [JsonPropertyName("simulated_time_multiplier")]
        public int SimulatedTimeMultiplier { get; set; }
        [JsonPropertyName("simulated_time_offsets")]
        public List<int> SimulatedTimeOffsets { get; set; }
        [JsonPropertyName("version")]
        public int Version { get; set; }
        [JsonPropertyName("weather_var_initial")]
        public int WeatherVarInitial { get; set; }
        [JsonPropertyName("weather_var_ongoing")]
        public int WeatherVarOngoing { get; set; }
        [JsonPropertyName("time_of_day")]
        public int TimeOfDay { get; set; }
    }
}
