using AiSeasonCreator.Interfaces;
using AiSeasonCreator.ScheduleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator
{
    public class SeasonBuilder<T>
    {
        private readonly IMapper<SeasonSchedule> _seasonScheduleMapper;

        public SeasonBuilder(IMapper<SeasonSchedule> seasonScheduleMapper)
        {
            _seasonScheduleMapper = seasonScheduleMapper;
        }

        public SeasonSchedule BuildSeason()
        {
            return _seasonScheduleMapper.Map(0, "");
        }
    }
}
