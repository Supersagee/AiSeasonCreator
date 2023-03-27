using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace iRacingSeasonCreator.ScheduleClasses
{
    public class TrackState
    {
        [JsonPropertyName("leave_marbles")]
        public bool LeaveMarbles { get; set; }
        [JsonPropertyName("practice_rubber")]
        public int PracticeRubber { get; set; }
        [JsonPropertyName("qualify_rubber")]
        public int QualifyRubber { get; set; }
        [JsonPropertyName("race_rubber")]
        public int RaceRubber { get; set; }
        [JsonPropertyName("warmup_rubber")]
        public int WarmupRubber { get; set; }
    }
}
