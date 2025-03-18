using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;

namespace AiSeasonCreator.Mappers
{
    public class GuidedParametersMapper : IMapper<GuidedParameters>
    {
        private readonly UserSelectedOptions _userSelectedOptions;
        public GuidedParametersMapper(UserSelectedOptions userSelectedOptions)
        {
            _userSelectedOptions = userSelectedOptions;
        }
        public GuidedParameters Map(int eventIndex, string eventGuid)
        {
            var ss = _userSelectedOptions.FullSchedule;
            var i = _userSelectedOptions.SeasonSeriesIndex;
            var j = eventIndex;
            var gp = new GuidedParameters();

            gp.Temperature = ss[i].Schedules[j].Weather.ForecastOptions.Temperature;
            gp.WindDir = ss[i].Schedules[j].Weather.ForecastOptions.WindDir;
            gp.WindSpeed = ss[i].Schedules[j].Weather.ForecastOptions.WindSpeed;
            gp.Skies = ss[i].Schedules[j].Weather.ForecastOptions.Skies;
            gp.Precipitation = _userSelectedOptions.NeverRain ? 1 : ss[i].Schedules[j].Weather.ForecastOptions.Precipitation;
            gp.StopPrecip = ss[i].Schedules[j].Weather.ForecastOptions.StopPrecip;
            gp.AllowFog = ss[i].Schedules[j].Weather.AllowFog;

            return gp;
        }
    }
}
