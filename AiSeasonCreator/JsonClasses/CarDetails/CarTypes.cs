using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.CarDetails
{
    public class CarTypes
    {
        [JsonPropertyName("car_type")]
        public string CarType { get; set; } = default!;
    }
}
