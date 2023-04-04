using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace iRacingSeasonCreator.JsonClasses.TrackDetails
{
    public class TrackTypes
    {
        [JsonPropertyName("track_type")]
        public string TrackType { get; set; } = default!;
    }
}
