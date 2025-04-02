using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Data;
using AiSeasonCreator.Views;

namespace AiSeasonCreator.Mappers
{
    public class GuidedParametersMapper : IMapper<GuidedParameters>
    {
        private readonly LoadedData _loadedData;
        private readonly ISeasonView _seasonView;
        public GuidedParametersMapper(LoadedData loadedData, ISeasonView seasonView)
        {
            _loadedData = loadedData;
            _seasonView = seasonView;
        }
        public GuidedParameters Map(int eventIndex, string eventGuid)
        {
            var gp = new GuidedParameters();
            var s = _loadedData.SelectedSeries.Schedules[eventIndex];

            gp.Temperature = s.Weather.ForecastOptions.Temperature;
            gp.WindDir = s.Weather.ForecastOptions.WindDir;
            gp.WindSpeed = s.Weather.ForecastOptions.WindSpeed;
            gp.Skies = s.Weather.ForecastOptions.Skies;
            gp.Precipitation = _seasonView.NeverRain ? 1 : s.Weather.ForecastOptions.Precipitation;
            gp.StopPrecip = s.Weather.ForecastOptions.StopPrecip;
            gp.AllowFog = s.Weather.AllowFog;

            return gp;
        }
    }
}
