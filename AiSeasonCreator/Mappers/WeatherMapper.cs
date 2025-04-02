using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Data;
using AiSeasonCreator.Views;

namespace AiSeasonCreator.Mappers
{
    public class WeatherMapper : IMapper<Weather>
    {
        private readonly IMapper<GuidedParameters> _guidedParametersMapper;
        private readonly IMapper<List<Keyframes>> _keyframesMapper;
        private readonly LoadedData _loadedData;
        private readonly ISeasonView _seasonView;
        public WeatherMapper(
            IMapper<GuidedParameters> guidedParametersMapper, 
            IMapper<List<Keyframes>> keyframesMapper, 
            LoadedData loadedData, 
            ISeasonView seasonView)
        {
            _guidedParametersMapper = guidedParametersMapper;
            _keyframesMapper = keyframesMapper;
            _loadedData = loadedData;
            _seasonView = seasonView;
        }
        public Weather Map(int eventIndex, string eventGuid)
        {
            var weather = new Weather();
            var s = _loadedData.SelectedSeries.Schedules[eventIndex].Weather;

            weather.TempUnits = s.TempUnits;
            weather.WindUnits = s.WindUnits;
            weather.SimulatedTimeMultiplier = s.SimulatedTimeMultiplier;
            weather.SimulatedTimeOffsets = s.SimulatedTimeOffsets.ToList();
            weather.WeatherVarInitial = s.WeatherVarInitial;
            weather.WeatherVarOngoing = s.WeatherVarOngoing;

            if (_seasonView.StaticWeather)
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
                weather.Version = s.Version;
                weather.Type = s.Type;
                weather.TempValue = s.TempValue;
                weather.RelHumidity = s.RelHumidity;
                weather.WindDir = s.WindDir;
                weather.WindValue = s.WindValue;
                weather.Skies = s.Skies;
                weather.Fog = s.Fog;
                weather.AllowFog = s.AllowFog;
            }

            if (_seasonView.AfternoonRaces)
            {
                weather.SimulatedStartTime = DateTime.Parse(s.SimulatedStartTime.ToString("yyyy-MM-ddTHH:mm:ss").Substring(0, 11) + "14:00:00");
                weather.TimeOfDay = 0;
            }
            else
            {
                weather.SimulatedStartTime = s.SimulatedStartTime;
                weather.TimeOfDay = s.TimeOfDay;
            }

            weather.TrackWater = 0;
            weather.WeatherId = "564678_" + Guid.NewGuid().ToString();
            weather.EventId = eventGuid;
            weather.Loading = false;

            if (s.ForecastOptions != null && !_seasonView.StaticWeather)
            {
                weather.GuidedParameters = _guidedParametersMapper.Map(eventIndex, eventGuid);
                weather.WeatherSeed = s.ForecastOptions.WeatherSeed;
                weather.PrecipOption = s.PrecipOption;
                weather.Keyframes = _keyframesMapper.Map(eventIndex, eventGuid);
            }

            return weather;
        }
    }
}
