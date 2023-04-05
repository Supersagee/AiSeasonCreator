using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace iRacingSeasonCreator.Roster
{
    public class DriverRoster
    {
        [JsonPropertyName("drivers")]
        public List<Drivers> Drivers { get; set; }
    }
}
