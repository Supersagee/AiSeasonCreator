using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiSeasonCreator.ScheduleClasses
{
    public class Events
    {
        [JsonPropertyName("trackId")]
        public int TrackId { get; set; }
        [JsonPropertyName("num_opt_laps")]
        public int NumOptLaps { get; set; }
        [JsonPropertyName("paceCar")]
        public PaceCar PaceCar { get; set; }
        [JsonPropertyName("short_parade_lap")]
        public bool ShortParadeLap { get; set; }
        [JsonPropertyName("must_use_diff_tire_types_in_race")]
        public bool MustUseDiffTireTypesInRace { get; set; }
        [JsonPropertyName("subsessions")]
        public List<int> Subsessions { get; set; }
        [JsonPropertyName("eventId")]
        public string EventId { get; set; }
        [JsonPropertyName("race_laps")]
        public int? RaceLaps { get; set; }
        [JsonPropertyName("race_length")]
        public int? RaceLength { get; set; }
        [JsonPropertyName("race_length_type")]
        public int RaceLengthType { get; set; }
        [JsonPropertyName("weather")]
        public Weather Weather { get; set; }
        [JsonPropertyName("startZone")]
        public bool StartZone { get; set; }
        [JsonPropertyName("full_course_cautions")]
        public bool FullCourseCautions { get; set;}
        [JsonPropertyName("time_of_day")]
        public int TimeOfDay { get; set; }
        [JsonPropertyName("qualify_length")]
        public int QualifyLength { get; set; }
    }
}
