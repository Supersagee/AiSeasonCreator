using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;

namespace AiSeasonCreator.Mappers
{
    public class WeatherMapper : IMapper<Weather>
    {
        private readonly IMapper<GuidedParameters> _guidedParametersMapper;
        private readonly IMapper<List<Keyframes>> _keyframesMapper;
        private readonly UserSelectedOptions _userSelectedOptions;
        public WeatherMapper(IMapper<GuidedParameters> guidedParametersMapper, IMapper<List<Keyframes>> keyframesMapper, UserSelectedOptions userSelectedOptions)
        {
            _guidedParametersMapper = guidedParametersMapper;
            _keyframesMapper = keyframesMapper;
            _userSelectedOptions = userSelectedOptions;
        }
        public Weather Map(int eventIndex, string eventGuid)
        {
            var i = _userSelectedOptions.SeasonSeriesIndex;
            var j = eventIndex;

            var weather = new Weather();
            var ss = _userSelectedOptions.FullSchedule[i].Schedules[j].Weather;

            weather.TempUnits = ss.TempUnits;
            weather.WindUnits = ss.WindUnits;
            weather.SimulatedTimeMultiplier = ss.SimulatedTimeMultiplier;
            weather.SimulatedTimeOffsets = ss.SimulatedTimeOffsets.ToList();
            weather.WeatherVarInitial = ss.WeatherVarInitial;
            weather.WeatherVarOngoing = ss.WeatherVarOngoing;

            if (_userSelectedOptions.StaticWeather)
            {
                weather.Version = 2;
                weather.Type = 3;
                weather.TempValue = 78;
                weather.RelHumidity = 45;
                weather.WindDir = 0;
                weather.WindValue = 2;
                weather.Skies = 0;
                weather.Fog = 0;
                weather.AllowFog = false;
            }
            else
            {
                weather.Version = ss.Version;
                weather.Type = ss.Type;
                weather.TempValue = ss.TempValue;
                weather.RelHumidity = ss.RelHumidity;
                weather.WindDir = ss.WindDir;
                weather.WindValue = ss.WindValue;
                weather.Skies = ss.Skies;
                weather.Fog = ss.Fog;
                weather.AllowFog = ss.AllowFog;
            }

            if (_userSelectedOptions.AfternoonRaces)
            {
                weather.SimulatedStartTime = DateTime.Parse(ss.SimulatedStartTime.ToString("yyyy-MM-ddTHH:mm:ss").Substring(0, 11) + "14:00:00");
                weather.TimeOfDay = 0;
            }
            else
            {
                weather.SimulatedStartTime = ss.SimulatedStartTime;
                weather.TimeOfDay = ss.TimeOfDay;
            }

            weather.TrackWater = 0;
            weather.WeatherId = "564678_" + Guid.NewGuid().ToString();
            weather.EventId = eventGuid;
            weather.Loading = false;

            if (ss.ForecastOptions != null && !_userSelectedOptions.StaticWeather)
            {
                weather.GuidedParameters = _guidedParametersMapper.Map(j, eventGuid);
                weather.WeatherSeed = ss.ForecastOptions.WeatherSeed;
                weather.PrecipOption = ss.PrecipOption;
                weather.Keyframes = _keyframesMapper.Map(j, eventGuid);
            }

            return weather;
        }
    }
}
