using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;

namespace AiSeasonCreator.Mappers
{
    public class CarSettingsMapper : IMapper<List<CarSettings>>
    {
        private readonly UserSelectedOptions _userSelectedOptions;
        public CarSettingsMapper(UserSelectedOptions userSelectedOptions)
        {
            _userSelectedOptions = userSelectedOptions;
        }
        public List<CarSettings> Map(int eventIndex, string eventGuid)
        {
            var ss = _userSelectedOptions.FullSchedule;
            var i = _userSelectedOptions.SeasonSeriesIndex;
            
            var carSettingsList = new List<CarSettings>();

            for (var j = 0; j < ss[i].Schedules[0].CarRestrictions.Count; j++)
            {
                var carSettings = new CarSettings();
                carSettings.CarId = ss[i].Schedules[0].CarRestrictions[j].CarId;
                carSettings.MaxPctFuelFill = Convert.ToInt32(ss[i].Schedules[0].CarRestrictions[j].MaxPctFuelFill);
                carSettings.MaxDryTireSets = ss[i].Schedules[0].CarRestrictions[j].MaxDryTireSets;
                carSettingsList.Add(carSettings);
            }
            return carSettingsList;
        }
    }
}
