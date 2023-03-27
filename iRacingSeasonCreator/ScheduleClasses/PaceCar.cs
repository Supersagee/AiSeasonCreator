using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace iRacingSeasonCreator.ScheduleClasses
{
    public class PaceCar
    {
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }
        [JsonPropertyName("is_oval")]
        public bool IsOval { get; set; }
        [JsonPropertyName("is_dirt")]
        public bool IsDirt { get; set; }
        [JsonPropertyName("car_name")]
        public string CarName { get; set; }
        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }
        [JsonPropertyName("order")]
        public int Order { get; set; }
    }
}
