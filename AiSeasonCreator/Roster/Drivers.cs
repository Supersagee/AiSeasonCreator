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
        [JsonPropertyName("carTgaName")]
        public string CarTgaName { get; set; }
        [JsonPropertyName("helmetTgaName")]
        public string HelmetTgaName { get; set; }
        [JsonPropertyName("suitTgaName")]
        public string SuitTgaName { get; set; }
        [JsonPropertyName("numberDesign")]
        public string NumberDesign { get; set; }
        [JsonPropertyName("helmetDesign")]
        public string HelmetDesign { get; set; }
        [JsonPropertyName("suitDesign")]
        public string SuitDesign { get; set; }
        [JsonPropertyName("disableCarDecals")]
        public bool DisableCarDecals { get; set;}
        [JsonPropertyName("sponsor1")]
        public int Sponsor1 { get; set; }
        [JsonPropertyName("sponsor2")]
        public int Sponsor2 { get; set; }
        [JsonPropertyName("rowIndex")]
        public int RowIndex { get; set; }
        [JsonPropertyName("driverSkill")]
        public int DriverSkill { get; set; }
        [JsonPropertyName("driverAggression")]
        public int DriverAggression { get; set; }
        [JsonPropertyName("driverOptimism")]
        public int DriverOptimism { get; set; }
        [JsonPropertyName("driverSmoothness")]
        public int DriverSmoothness { get; set; }
        [JsonPropertyName("pitCrewSkill")]
        public int PitCrewSkill { get; set; }
        [JsonPropertyName("strategyRiskiness")]
        public int StrategyRiskiness { get; set; }
        [JsonPropertyName("driverAge")]
        public int DriverAge { get; set; }
    }
}
