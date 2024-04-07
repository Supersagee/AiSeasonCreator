using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacingWeatherURLParser.WeatherSchedule
{
    public class Series
    {
        public string SeriesName { get; set; }
        public int SeriesId { get; set; }
        public List<Events> Events { get; set; }
    }
}
