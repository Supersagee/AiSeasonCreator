using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace AiSeasonCreator.ScheduleClasses
{
    public class CarSettings
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }
        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPctFuelFill { get; set; }
        [JsonPropertyName("max_dry_tire_sets")]
        public int MaxDryTireSets { get; set; }
    }
}
