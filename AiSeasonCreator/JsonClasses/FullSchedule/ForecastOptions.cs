using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class ForecastOptions
    {
        [JsonPropertyName("skies")]
        public int Skies { get; set; }
        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }
        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }
        [JsonPropertyName("stop_precip")]
        public int StopPrecip { get; set; }
        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }
        [JsonPropertyName("weather_seed")]
        public long WeatherSeed { get; set; }
        [JsonPropertyName("forecast_type")]
        public int ForecastType { get; set; }
        [JsonPropertyName("precipitation")]
        public int Precipitation { get; set; }
}
}
