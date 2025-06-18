using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Data;
using AiSeasonCreator.Views;

namespace AiSeasonCreator.Mappers
{
    public class KeyframesMapper : IMapper<List<Keyframes>>
    {
        private readonly LoadedData _loadedData;
        private readonly ISeasonView _seasonView;
        public KeyframesMapper(LoadedData loadedData, ISeasonView seasonView)
        {
            _loadedData = loadedData;
            _seasonView = seasonView;
        }
        public List<Keyframes> Map(int eventIndex, string eventGuid)
        {
            var lkf = new List<Keyframes>();

            var weatherWeek = _loadedData.SelectedSeriesWeather.Events[eventIndex];
            var wkf = weatherWeek.Keyframes;
            long? ws = weatherWeek.Keyframes[0].WeatherSeed;

            var sst = _loadedData.SelectedSeries.Schedules[eventIndex].Weather.SimulatedStartTime;
            
            var index = 0;

            foreach (var f in wkf)
            {
                var kf = new Keyframes();
                kf.Index = index;
                kf.Timestamp = f.Timestamp;
                kf.TimeOffset = f.TimeOffset;
                kf.AllowPrecip = _seasonView.NeverRain ? false : f.AllowPrecip;
                kf.ValidStats = f.ValidStats;
                kf.AffectsSession = f.AffectsSession;
                kf.CloudCover = f.CloudCover;
                kf.AirTemp = f.AirTemp;
                kf.RelHumidity = f.RelHumidity;
                kf.Pressure = f.Pressure;
                kf.WindDir = f.WindDir;
                kf.WindSpeed = f.WindSpeed;
                kf.PrecipChance = _seasonView.NeverRain ? 0 : f.PrecipChance;
                kf.PrecipAmount = f.PrecipAmount;
                kf.RawAirTemp = f.RawAirTemp;
                kf.IsSunUp = f.IsSunUp;
                //kf.WeatherSeed = index == 0 ? ws : null;
                kf.WeatherSeed = null;
                kf.SimulatedStartTime = index == 0 ? sst.ToString("yyyy-MM-ddTHH:mm:ss") : null;
                lkf.Add(kf);
                index++;

                kf = new Keyframes();
                kf.Index = index;
                kf.Timestamp = f.Timestamp.AddMinutes(15);
                kf.TimeOffset = f.TimeOffset + 15;
                kf.AllowPrecip = _seasonView.NeverRain ? false : f.AllowPrecip;
                kf.ValidStats = f.ValidStats;
                kf.AffectsSession = f.AffectsSession;
                kf.CloudCover = f.CloudCover;
                kf.AirTemp = f.AirTemp;
                kf.RelHumidity = f.RelHumidity;
                kf.Pressure = f.Pressure;
                kf.WindDir = f.WindDir;
                kf.WindSpeed = f.WindSpeed;
                kf.PrecipChance = _seasonView.NeverRain ? 0 : f.PrecipChance;
                kf.PrecipAmount = f.PrecipAmount;
                kf.RawAirTemp = f.RawAirTemp;
                kf.IsSunUp = f.IsSunUp;
                kf.WeatherSeed = null;
                lkf.Add(kf);
                index++;

                kf = new Keyframes();
                kf.Index = index;
                kf.Timestamp = f.Timestamp.AddMinutes(30);
                kf.TimeOffset = f.TimeOffset + 30;
                kf.AllowPrecip = _seasonView.NeverRain ? false : f.AllowPrecip;
                kf.ValidStats = f.ValidStats;
                kf.AffectsSession = f.AffectsSession;
                kf.CloudCover = f.CloudCover;
                kf.AirTemp = f.AirTemp;
                kf.RelHumidity = f.RelHumidity;
                kf.Pressure = f.Pressure;
                kf.WindDir = f.WindDir;
                kf.WindSpeed = f.WindSpeed;
                kf.PrecipChance = _seasonView.NeverRain ? 0 : f.PrecipChance;
                kf.PrecipAmount = f.PrecipAmount;
                kf.RawAirTemp = f.RawAirTemp;
                kf.IsSunUp = f.IsSunUp;
                kf.WeatherSeed = null;
                lkf.Add(kf);
                index++;

                kf = new Keyframes();
                kf.Index = index;
                kf.Timestamp = f.Timestamp.AddMinutes(45);
                kf.TimeOffset = f.TimeOffset + 45;
                kf.AllowPrecip = _seasonView.NeverRain ? false : f.AllowPrecip;
                kf.ValidStats = f.ValidStats;
                kf.AffectsSession = f.AffectsSession;
                kf.CloudCover = f.CloudCover;
                kf.AirTemp = f.AirTemp;
                kf.RelHumidity = f.RelHumidity;
                kf.Pressure = f.Pressure;
                kf.WindDir = f.WindDir;
                kf.WindSpeed = f.WindSpeed;
                kf.PrecipChance = _seasonView.NeverRain ? 0 : f.PrecipChance;
                kf.PrecipAmount = f.PrecipAmount;
                kf.RawAirTemp = f.RawAirTemp;
                kf.IsSunUp = f.IsSunUp;
                kf.WeatherSeed = null;
                lkf.Add(kf);
                index++;
            }

            return lkf;
        }
    }
}