using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace iRacingSeasonCreator.JsonClasses.CarDetails
{
    public class PaintRules
    {
        [JsonPropertyName("RestrictCustomPaint")]
        public bool RestrictCustomPaint { get; set; }
    }
}
