using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class Track
    {
        [JsonPropertyName("track_id")]
        public int TrackId { get; set; }
        [JsonPropertyName("track_name")]
        public string TrackName { get; set; }
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("config_name")]
        public string ConfigName { get; set; }
    }
}
