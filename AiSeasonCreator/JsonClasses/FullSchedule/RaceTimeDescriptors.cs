using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class RaceTimeDescriptors
    {
        public bool repeating { get; set; }
        public bool super_session { get; set; }
        public int session_minutes { get; set; }
        public string start_date { get; set; }
        public List<int> day_offset { get; set; }
        public string first_session_time { get; set; }
        public int repeat_minutes { get; set; }
    }
}
