using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using AiSeasonCreator.JsonClasses.Assets;
using AiSeasonCreator.Roster;
using iRacingWeatherURLParser.WeatherSchedule;

namespace AiSeasonCreator.Data
{
    public class LoadedData
    {
        public FullSchedule[] FullSchedule { get; set; }
        public SeriesDetails[] SeriesDetails { get; set; }
        public WeatherSchedule WeatherSchedule { get; set; }
        public CarClasses[] CarClasses { get; set; }
        public CarDetails[] CarDetails { get; set; }
        public TrackDetails[] TrackDetails { get; set; }
        public FullSchedule SelectedSeries { get; set; }
        public SeriesDetails SelectedSeriesDetails { get; set; }
        public Series SelectedSeriesWeather { get; set; }
        public FullSchedule RosterSelectedSeries { get; set; }
        public SeriesDetails RosterSelectedSeriesDetails { get; set; }
        public DriverRoster SelectedRoster { get; set; }
        public Dictionary<string, CarAssets> CarAssets { get; set; }
        public Dictionary<string, SeriesAssets> SeriesAssets { get; set; }
        public Dictionary<string, TrackAssets> TrackAssets { get; set; }
    }
}
