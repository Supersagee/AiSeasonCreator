using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.ScheduleClasses
{
    public class GuidedParameters
    {
        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }
        [JsonPropertyName("wind_dir")]
        public int WindDir { get; set; }
        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }
        [JsonPropertyName("skies")]
        public int Skies { get; set; }
        [JsonPropertyName("precipitation")]
        public int Precipitation { get; set; }
        [JsonPropertyName("stop_precip")]
        public int StopPrecip { get; set; }
        [JsonPropertyName("allow_fog")]
        public bool AllowFog { get; set; }
    }
}
