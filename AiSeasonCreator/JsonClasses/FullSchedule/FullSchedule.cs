using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class FullSchedule
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("allowed_season_members")]
        public object AllowedSeasonMembers { get; set; }
        [JsonPropertyName("car_class_ids")]
        public List<int> CarClassIds { get; set; }
        [JsonPropertyName("car_types")]
        public List<CarTypes> CarTypes { get; set; }
        [JsonPropertyName("caution_laps_do_not_count")]
        public bool CautionLapsDoNotCount { get; set; }
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }
        [JsonPropertyName("cross_license")]
        public bool CrossLicense { get; set; }
        [JsonPropertyName("driver_change_rule")]
        public int DriverChangeRule { get; set; }
        [JsonPropertyName("driver_changes")]
        public bool DriverChanges { get; set; }
        [JsonPropertyName("drops")]
        public int Drops { get; set; }
        [JsonPropertyName("enable_pitlane_collisions")]
        public bool EnablePitlaneCollisions { get; set; }
        [JsonPropertyName("fixed_setup")]
        public bool FixedSetup { get; set; }
        [JsonPropertyName("green_white_checkered_limit")]
        public int GreenWhiteCheckeredLimit { get; set; }
        [JsonPropertyName("grid_by_class")]
        public bool GridByClass { get; set; }
        [JsonPropertyName("hardcore_level")]
        public int HardcoreLevel { get; set; }
        [JsonPropertyName("heat_ses_info")]
        public HeatSessionInfo HeatSesInfo { get; set; } = default!;
        [JsonPropertyName("ignore_license_for_practice")]
        public bool IgnoreLicenseForPractice { get; set; }
        [JsonPropertyName("incident_limit")]
        public int IncidentLimit { get; set; }
        [JsonPropertyName("incident_warn_mode")]
        public int IncidentWarnMode { get; set; }
        [JsonPropertyName("incident_warn_param1")]
        public int IncidentWarnParam1 { get; set; }
        [JsonPropertyName("incident_warn_param2")]
        public int IncidentWarnParam2 { get; set; }
        [JsonPropertyName("is_heat_racing")]
        public bool IsHeatRacing { get; set; }
        [JsonPropertyName("license_group")]
        public int LicenseGroup { get; set; }
        [JsonPropertyName("license_group_types")]
        public List<LicenseGroupTypes> LicenseGroupTypes { get; set; }
        [JsonPropertyName("lucky_dog")]
        public bool LuckyDog { get; set; }
        [JsonPropertyName("max_team_drivers")]
        public int MaxTeamDrivers { get; set; }
        [JsonPropertyName("max_weeks")]
        public int MaxWeeks { get; set; }
        [JsonPropertyName("min_team_drivers")]
        public int MinTeamDrivers { get; set; }
        [JsonPropertyName("multiclass")]
        public bool Multiclass { get; set; }
        [JsonPropertyName("must_use_diff_tire_types_in_race")]
        public bool MustUseDiffTireTypesInRace { get; set; }
        [JsonPropertyName("next_race_session")]
        public object NextRaceSession { get; set; }
        [JsonPropertyName("num_opt_laps")]
        public int NumOptLaps { get; set; }
        [JsonPropertyName("official")]
        public bool Official { get; set; }
        [JsonPropertyName("op_duration")]
        public int OpDuration { get; set; }
        [JsonPropertyName("open_practice_session_type_id")]
        public int OpenPracticeSessionTypeId { get; set; }
        [JsonPropertyName("qualifier_must_start_race")]
        public bool QualifierMustStartRace { get; set; }
        [JsonPropertyName("race_week")]
        public int RaceWeek { get; set; }
        [JsonPropertyName("race_week_to_make_divisions")]
        public int RaceWeekToMakeDivisions { get; set; }
        [JsonPropertyName("reg_user_count")]
        public int RegUserCount { get; set; }
        [JsonPropertyName("region_competition")]
        public bool RegionCompetition { get; set; }
        [JsonPropertyName("restrict_by_member")]
        public bool RestrictByMember { get; set; }
        [JsonPropertyName("restrict_to_car")]
        public bool RestrictToCar { get; set; }
        [JsonPropertyName("restrict_viewing")]
        public bool RestrictViewing { get; set; }
        [JsonPropertyName("rookie_season")]
        public string RookieSeason { get; set; } = default!;
        [JsonPropertyName("schedule_description")]
        public string ScheduleDescription { get; set; }
        [JsonPropertyName("schedules")]
        public List<Schedules> Schedules { get; set; }
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }
        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; }
        [JsonPropertyName("season_quarter")]
        public int SeasonQuarter { get; set; }
        [JsonPropertyName("season_short_name")]
        public string SeasonShortName { get; set; }
        [JsonPropertyName("season_year")]
        public int SeasonYear { get; set; }
        [JsonPropertyName("send_to_open_practice")]
        public bool SendToOpenPractice { get; set; }
        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }
        [JsonPropertyName("short_parade_lap")]
        public bool ShortParadeLap { get; set; }
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }
        [JsonPropertyName("start_on_qual_tire")]
        public bool StartOnQualTire { get; set; }
        [JsonPropertyName("start_zone")]
        public bool StartZone { get; set; }
        [JsonPropertyName("track_types")]
        public List<TrackTypes> TrackTypes { get; set; }
        [JsonPropertyName("unsport_conduct_rule_mode")]
        public int UnsportConductRuleMode { get; set; }
    }
}
