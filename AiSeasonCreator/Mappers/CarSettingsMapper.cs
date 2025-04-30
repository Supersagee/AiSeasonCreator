using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Data;

namespace AiSeasonCreator.Mappers
{
    public class CarSettingsMapper : IMapper<List<CarSettings>>
    {
        private readonly LoadedData _loadedData;
        public CarSettingsMapper(LoadedData loadedData)
        {
             _loadedData = loadedData;
        }
        public List<CarSettings> Map(int eventIndex, string eventGuid)
        {
            var s = _loadedData.SelectedSeries;
            
            var carSettingsList = new List<CarSettings>();

            for (var j = 0; j < s.Schedules[0].CarRestrictions.Count; j++)
            {
                var carSettings = new CarSettings();
                carSettings.CarId = s.Schedules[0].CarRestrictions[j].CarId;
                carSettings.MaxPctFuelFill = Convert.ToInt32(s.Schedules[0].CarRestrictions[j].MaxPctFuelFill);
                carSettings.MaxDryTireSets = s.Schedules[0].CarRestrictions[j].MaxDryTireSets;
                carSettingsList.Add(carSettings);
            }
            return carSettingsList;
        }
    }
}
