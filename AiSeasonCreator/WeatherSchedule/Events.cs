using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacingWeatherURLParser.WeatherSchedule
{
    public class Events
    {
        public int RaceWeekNum { get; set; }
        public List<Keyframes> Keyframes { get; set; }
    }
}
