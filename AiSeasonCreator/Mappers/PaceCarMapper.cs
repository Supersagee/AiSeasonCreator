using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Data;

namespace AiSeasonCreator.Mappers
{
    public class PaceCarMapper : IMapper<PaceCar>
    {
        private readonly LoadedData _loadedData;
        public PaceCarMapper(LoadedData loadeddata) 
        {
            _loadedData = loadeddata;
        }
        public PaceCar Map(int eventIndex, string eventGuid)
        {
            var paceCar = new PaceCar();
            var s = _loadedData.SelectedSeries;

            if (s.Schedules[eventIndex].Track.Category == "road")
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
