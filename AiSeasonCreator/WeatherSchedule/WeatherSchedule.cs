using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacingWeatherURLParser.WeatherSchedule
{
    public class WeatherSchedule
    {
        public string SeasonName { get; set; }
        public int SeasonId { get; set; }
        public List<Series> Series { get; set;}
    }
}
