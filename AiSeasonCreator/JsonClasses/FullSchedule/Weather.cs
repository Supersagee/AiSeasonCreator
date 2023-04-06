using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class Weather
    {
        public int version { get; set; }
        public int type { get; set; }
        public int temp_units { get; set; }
        public int temp_value { get; set; }
        public int rel_humidity { get; set; }
        public int fog { get; set; }
        public int wind_dir { get; set; }
        public int wind_units { get; set; }
        public int wind_value { get; set; }
        public int skies { get; set; }
        public int weather_var_initial { get; set; }
        public int weather_var_ongoing { get; set; }
        public int time_of_day { get; set; }
        public DateTime simulated_start_time { get; set; }
        public List<int> simulated_time_offsets { get; set; }
        public int simulated_time_multiplier { get; set; }
        public DateTime simulated_start_utc_time { get; set; }
    }
}
