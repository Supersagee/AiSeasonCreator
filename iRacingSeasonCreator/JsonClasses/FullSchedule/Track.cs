using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacingSeasonCreator.JsonClasses.FullSchedule
{
    public class Track
    {
        public int track_id { get; set; }
        public string track_name { get; set; }
        public int category_id { get; set; }
        public string category { get; set; }
        public string config_name { get; set; }
    }
}
