using Aydsko.iRacingData.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacingSeasonCreator.JsonClasses.FullSchedule
{
    public class Schedules
    {
        public int season_id { get; set; }
        public int race_week_num { get; set; }
        public int series_id { get; set; }
        public string series_name { get; set; }
        public string season_name { get; set; }
        public string schedule_name { get; set; }
        public string start_date { get; set; }
        public int simulated_time_multiplier { get; set; }
        public int race_lap_limit { get; set; }
        public object race_time_limit { get; set; }
        public string start_type { get; set; }
        public string restart_type { get; set; }
        public bool qual_attached { get; set; }
        public bool full_course_cautions { get; set; }
        public object special_event_type { get; set; }
        public bool start_zone { get; set; }
        public bool enable_pitlane_collisions { get; set; }
        public bool short_parade_lap { get; set; }
        public Track track { get; set; }
        public Weather weather { get; set; }
        public TrackState track_state { get; set; }
        public List<RaceTimeDescriptors> race_time_descriptors { get; set; }
        public List<CarRestrictions> car_restrictions { get; set; }
    }
}
