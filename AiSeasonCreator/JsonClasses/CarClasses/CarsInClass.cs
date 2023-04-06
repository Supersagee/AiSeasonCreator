using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.CarClasses
{
    public class CarsInClass
    {
        [JsonPropertyName("car_dirpath")]
        public string CarDirpath { get; set; } = default!;

        [JsonPropertyName("car_id")]
        public int CarId { get; set; }

        [JsonPropertyName("retired")]
        public bool Retired { get; set; }
    }
}
