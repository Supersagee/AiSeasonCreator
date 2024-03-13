using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class RaceWeekCars
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }
        [JsonPropertyName("car_name")]
        public string CarName { get; set; }
        [JsonPropertyName("car_name_abbreviated")]
        public string CarNameAbbreviated { get; set; }
    }
}
