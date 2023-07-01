using System;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class Schedules
    {
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }
        [JsonPropertyName("race_week_num")]
        public int RaceWeekIndex { get; set; }
        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        [JsonPropertyName("series_name")]
        public string SeriesName { get; set; } = default!;

        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; } = default!;

        [JsonPropertyName("schedule_name")]
        public string ScheduleName { get; set; } = default!;
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }
        [JsonPropertyName("simulated_time_multiplier")]
        public int SimulatedTimeMultiplier { get; set; }

        [JsonPropertyName("race_lap_limit")]
        public int? RaceLapLimit { get; set; }

        [JsonPropertyName("race_time_limit")]
        public int? RaceTimeLimit { get; set; }

        [JsonPropertyName("start_type")]
        public string StartType { get; set; } = default!;

        [JsonPropertyName("restart_type")]
        public string RestartType { get; set; } = default!;

        [JsonPropertyName("qual_attached")]
        public bool QualifyingIsAttached { get; set; }
        [JsonPropertyName("full_course_cautions")]
        public bool? HasFullCourseCautions { get; set; }

        [JsonPropertyName("special_event_type")]
        public int? SpecialEventType { get; set; }

        [JsonPropertyName("start_zone")]
        public bool? HasStartZone { get; set; }

        [JsonPropertyName("enable_pitlane_collisions")]
        public bool? PitlaneCollisionsEnabled { get; set; }

        [JsonPropertyName("short_parade_lap")]
        public bool? HasShortParadeLap { get; set; }

        [JsonPropertyName("track")]
        public Track Track { get; set; } = default!;
        [JsonPropertyName("weather")]
        public Weather Weather { get; set; } = default!;
        [JsonPropertyName("track_state")]
        public TrackState TrackState { get; set; } = default!;
        [JsonPropertyName("race_time_descriptors")]
        public List<RaceTimeDescriptors> RaceTimeDescriptors { get; set; }
        [JsonPropertyName("car_restrictions")]
        public List<CarRestrictions> CarRestrictions { get; set; }
    }
}
