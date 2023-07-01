using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class TrackState
    {
        [JsonPropertyName("leave_marbles")]
        public bool LeaveMarbles { get; set; }
    }
}
