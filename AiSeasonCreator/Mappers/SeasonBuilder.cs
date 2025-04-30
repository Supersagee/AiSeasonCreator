using AiSeasonCreator.ScheduleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Mappers
{
    public class SeasonBuilder<T>
    {
        private readonly IMapper<SeasonSchedule> _seasonScheduleMapper;

        public SeasonBuilder(IMapper<SeasonSchedule> seasonScheduleMapper)
        {
            _seasonScheduleMapper = seasonScheduleMapper;
        }

        public SeasonSchedule BuildSeason(string seasonName)
        {
            return _seasonScheduleMapper.Map(0, seasonName);
        }
    }
}
