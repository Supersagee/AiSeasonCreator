using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Aydsko.iRacingData.Series;

namespace iRacingSeasonCreator.ScheduleClasses
{
    public class SeasonSchedule
    {
        public SeasonSchedule() { }

        [JsonPropertyName("aiCarClassId")]
        public int? AiCarClassId { get; set; }
        [JsonPropertyName("aiCarClassIds")]
        public List<int> AiCarClassIds { get; set; }
        [JsonPropertyName("carId")]
        public int CarId { get; set; }
        [JsonPropertyName("carSettings")]
        public List<CarSettings>? CarSettings { get; set; }
        [JsonPropertyName("damage_model")]
        public int DamageModel { get; set; }
        [JsonPropertyName("track_state")]
        public TrackState? TrackState { get; set; }
        [JsonPropertyName("time_of_day")]
        public int TimeOfDay { get; set; }
        [JsonPropertyName("weather")]
        public Weather? Weather { get; set; }
        [JsonPropertyName("full_course_cautions")]
        public bool? FullCourseCautions { get; set; }
        [JsonPropertyName("gridPosition")]
        public int GridPosition { get; set; }
        [JsonPropertyName("lucky_dog")]
        public bool LuckyDog { get; set; }
        [JsonPropertyName("max_drivers")]
        public int MaxDrivers { get; set; }
        [JsonPropertyName("num_fast_tows")]
        public int NumFastTows { get; set; }
        [JsonPropertyName("avoidUser")]
        public bool AvoidUser { get; set; }
        [JsonPropertyName("minSkill")]
        public int MinSkill { get; set; }
        [JsonPropertyName("maxSkill")]
        public int MaxSkill { get; set; }
        [JsonPropertyName("must_use_diff_tire_types_in_race")]
        public bool MustUseDiffTireTypesInRace { get; set; }
        [JsonPropertyName("start_on_qual_tire")]
        public bool StartOnQualTire { get; set; }
        [JsonPropertyName("unsport_conduct_rule_mode")]
        public int UnsportConductRuleMode { get; set; }
        [JsonPropertyName("practice_length")]
        public int PracticeLength { get; set; }
        [JsonPropertyName("qualify_laps")]
        public int QualifyLaps { get; set; }
        [JsonPropertyName("qualify_length")]
        public int QualifyLength { get; set; }
        [JsonPropertyName("race_laps")]
        public int? RaceLaps { get; set; }
        [JsonPropertyName("race_length")]
        public int? RaceLength { get; set; }
        [JsonPropertyName("race_length_type")]
        public int RaceLengthType { get; set; }
        [JsonPropertyName("restarts")]
        public int Restarts { get; set; }
        [JsonPropertyName("rolling_starts")]
        public bool RollingStarts { get; set; }
        [JsonPropertyName("rosterName")]
        public string? RosterName { get; set; }
        [JsonPropertyName("short_parade_lap")]
        public bool? ShortParadeLap { get; set; }
        [JsonPropertyName("no_lapper_wave_arounds")]
        public bool NoLapperWaveArounds { get; set; }
        [JsonPropertyName("do_not_count_caution_laps")]
        public bool DoNotCountCautionLaps { get; set; }
        [JsonPropertyName("subsessions")]
        public List<int>? Subsessions { get; set; }
        [JsonPropertyName("startZone")]
        public int StartZone { get; set; }
        [JsonPropertyName("events")]
        public List<Events>? Events { get; set; }
        [JsonPropertyName("points_system_id")]
        public int PointsSystemId { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
