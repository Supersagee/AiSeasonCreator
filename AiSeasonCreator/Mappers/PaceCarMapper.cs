using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;

namespace AiSeasonCreator.Mappers
{
    public class PaceCarMapper : IMapper<PaceCar>
    { 
        private readonly UserSelectedOptions _userSelectedOptions;
        public PaceCarMapper(UserSelectedOptions userSelectedOptions) 
        {
            _userSelectedOptions = userSelectedOptions;
        }
        public PaceCar Map(int eventIndex, string eventGuid)
        {
            var ss = _userSelectedOptions.FullSchedule;
            var i = _userSelectedOptions.SeasonSeriesIndex;
            var j = eventIndex;
            var paceCar = new PaceCar();

            if (ss[i].Schedules[j].Track.Category == "road")
            {
                paceCar.CategoryId = 2;
                paceCar.CarId = 136;
                paceCar.IsOval = false;
                paceCar.IsDirt = false;
                paceCar.CarName = "Pace Car - Sedan";
                paceCar.CarClassId = 11;
                paceCar.Order = 4;
            }
            else
            {
                paceCar.CategoryId = 1;
                paceCar.CarId = 90;
                paceCar.IsOval = true;
                paceCar.IsDirt = false;
                paceCar.CarName = "Pace Car - Truck";
                paceCar.CarClassId = 11;
                paceCar.Order = 3;
            }

            return paceCar;
        }
    }
}
