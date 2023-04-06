using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.CarClasses
{
    public class CarClasses
    {
        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        [JsonPropertyName("cars_in_class")]
        public CarsInClass[] CarsInClass { get; set; } = Array.Empty<CarsInClass>();

        [JsonPropertyName("cust_id")]
        public int? CustomerId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("relative_speed")]
        public int RelativeSpeed { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; } = default!;
    }
}
