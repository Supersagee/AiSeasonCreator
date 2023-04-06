using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.JsonClasses.FullSchedule
{
    public class CarRestrictions
    {
        public int car_id { get; set; }
        public int race_setup_id { get; set; }
        public int qual_setup_id { get; set; }
        public int max_pct_fuel_fill { get; set; }
        public int weight_penalty_kg { get; set; }
        public int power_adjust_pct { get; set; }
        public int max_dry_tire_sets { get; set; }
    }
}
