using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.Assets
{
    public class CarAssets
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }
}
