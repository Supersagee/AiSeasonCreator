using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.Roster
{
    public class Drivers
    {
        [JsonPropertyName("driverName")]
        public string DriverName { get; set; }
        [JsonPropertyName("carNumber")]
        public string CarNumber { get; set; }
        [JsonPropertyName("carId")]
        public int CarId { get; set; }
        [JsonPropertyName("carClassId")]
        public int CarClassId { get; set; }
        [JsonPropertyName("carPath")]
        public string CarPath { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("carDesign")]
        public string CarDesign { get; set; }
        [JsonPropertyName("numberDesign")]
        public string NumberDesign { get; set; }
        [JsonPropertyName("helmetDesign")]
        public string HelmetDesign { get; set; }
        [JsonPropertyName("suitDesign")]
        public string SuitDesign { get; set; }
        [JsonPropertyName("disableCarDecals")]
        public bool DisableCarDecals { get; set;}
    }
}
