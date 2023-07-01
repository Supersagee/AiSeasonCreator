using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class CarRestrictions
    {
        [JsonPropertyName("car_id")]
        public int CarId { get; set; }
        [JsonPropertyName("race_setup_id")]
        public int RaceSetupId { get; set; }
        [JsonPropertyName("qual_setup_id")]
        public int QualSetupId { get; set; }
        [JsonPropertyName("max_pct_fuel_fill")]
        public int MaxPctFuelFill { get; set; }
        [JsonPropertyName("weight_penalty_kg")]
        public int WeightPenaltyKg { get; set; }
        [JsonPropertyName("power_adjust_pct")]
        public double PowerAdjustPct { get; set; }
        [JsonPropertyName("max_dry_tire_sets")]
        public int MaxDryTireSets { get; set; }
    }
}
