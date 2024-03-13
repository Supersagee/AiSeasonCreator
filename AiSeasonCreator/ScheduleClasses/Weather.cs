using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.ScheduleClasses
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
        [JsonPropertyName("track_water")]
        public int TrackWater { get; set; }
        [JsonPropertyName("weather_id")]
        public string WeatherId { get; set; }
        [JsonPropertyName("guided_parameters")]
        public GuidedParameters GuidedParameters { get; set; }
        [JsonPropertyName("allow_fog")]
        public bool AllowFog { get; set; }
        [JsonPropertyName("precip_option")]
        public int PrecipOption { get; set; }
        [JsonPropertyName("weather_seed")]
        public long? WeatherSeed { get; set; }
        [JsonPropertyName("event_id")]
        public string EventId { get; set; }
        [JsonPropertyName("loading")]
        public bool Loading { get; set; }
        [JsonPropertyName("keyframes")]
        public List<Keyframes> Keyframes { get; set; }
    }
}
