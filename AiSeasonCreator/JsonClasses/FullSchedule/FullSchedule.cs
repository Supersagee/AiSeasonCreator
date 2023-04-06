using Aydsko.iRacingData.Common;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class FullSchedule
    {
        public bool active { get; set; }
        public object allowed_season_members { get; set; }
        public List<int> car_class_ids { get; set; }
        public List<CarTypes> car_types { get; set; }
        public bool caution_laps_do_not_count { get; set; }
        public bool complete { get; set; }
        public bool cross_license { get; set; }
        public int driver_change_rule { get; set; }
        public bool driver_changes { get; set; }
        public int drops { get; set; }
        public bool enable_pitlane_collisions { get; set; }
        public bool fixed_setup { get; set; }
        public int green_white_checkered_limit { get; set; }
        public bool grid_by_class { get; set; }
        public bool ignore_license_for_practice { get; set; }
        public int incident_limit { get; set; }
        public int incident_warn_mode { get; set; }
        public int incident_warn_param1 { get; set; }
        public int incident_warn_param2 { get; set; }
        public bool is_heat_racing { get; set; }
        public int license_group { get; set; }
        public List<LicenseGroupTypes> license_group_types { get; set; }
        public bool lucky_dog { get; set; }
        public int max_team_drivers { get; set; }
        public int max_weeks { get; set; }
        public int min_team_drivers { get; set; }
        public bool multiclass { get; set; }
        public bool must_use_diff_tire_types_in_race { get; set; }
        public object next_race_session { get; set; }
        public int num_opt_laps { get; set; }
        public bool official { get; set; }
        public int op_duration { get; set; }
        public int open_practice_session_type_id { get; set; }
        public bool qualifier_must_start_race { get; set; }
        public int race_week { get; set; }
        public int race_week_to_make_divisions { get; set; }
        public int reg_user_count { get; set; }
        public bool region_competition { get; set; }
        public bool restrict_by_member { get; set; }
        public bool restrict_to_car { get; set; }
        public bool restrict_viewing { get; set; }
        public string schedule_description { get; set; }
        public List<Schedules> schedules { get; set; }
        public int season_id { get; set; }
        public string season_name { get; set; }
        public int season_quarter { get; set; }
        public string season_short_name { get; set; }
        public int season_year { get; set; }
        public bool send_to_open_practice { get; set; }
        public int series_id { get; set; }
        public bool short_parade_lap { get; set; }
        public DateTime start_date { get; set; }
        public bool start_on_qual_tire { get; set; }
        public bool start_zone { get; set; }
        public List<TrackTypes> track_types { get; set; }
        public int unsport_conduct_rule_mode { get; set; }
    }
}
