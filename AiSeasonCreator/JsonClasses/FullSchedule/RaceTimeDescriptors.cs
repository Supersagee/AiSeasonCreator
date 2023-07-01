using System;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class RaceTimeDescriptors
    {
        [JsonPropertyName("repeating")]
        public bool IsRepeating { get; set; }

        [JsonPropertyName("super_session")]
        public bool IsSuperSession { get; set; }

        [JsonPropertyName("session_minutes")]
        public int SessionMinutes { get; set; }
        [JsonPropertyName("session_times")]
        public DateTimeOffset[]? SessionTimes { get; set; }
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = default!;
        [JsonPropertyName("day_offset")]
        public int[]? DayOffset { get; set; }

        [JsonPropertyName("first_session_time")]
        public TimeSpan? FirstSessionTime { get; set; }

        [JsonPropertyName("repeat_minutes")]
        public int? RepeatMinutes { get; set; }
    }
}
