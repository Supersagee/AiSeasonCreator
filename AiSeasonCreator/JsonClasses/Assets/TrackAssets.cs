using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.Assets
{
    public class TrackAssets
    {
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }
}
