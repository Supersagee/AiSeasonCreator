using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Data;
using AiSeasonCreator.Views;
using ReaLTaiizor.Extension;

namespace AiSeasonCreator.Mappers
{
    public class EventsMapper : IMapper<List<Events>>
    {
        private readonly IMapper<PaceCar> _paceCarMapper;
        private readonly IMapper<Weather> _weather;
        private readonly LoadedData _loadedData;
        private readonly ISeasonView _seasonView;
        public EventsMapper(IMapper<PaceCar> paceCarMapper, IMapper<Weather> weather, LoadedData loadedData, ISeasonView seasonView)
        {
            _paceCarMapper = paceCarMapper;
            _weather = weather;
            _loadedData = loadedData;
            _seasonView = seasonView;
        }
        public List<Events> Map(int eventIndex, string eventGuid)
        {
            var events = new List<Events>();
            var s = _loadedData.SelectedSeries;
            var tracks = _loadedData.TrackDetails;
            var selectedTracks = _seasonView.SelectedTracks;

            for (var i = 0; i < s.Schedules.Count; i++)
            {
                if ((selectedTracks.Contains(s.Schedules[i].Track.TrackName)))
                {
                    var loopEvent = new Events();
                    loopEvent.TrackId = s.Schedules[i].Track.TrackId;
                    loopEvent.NumOptLaps = 0;
                    loopEvent.PaceCar = _paceCarMapper.Map(i, "");
                    loopEvent.ShortParadeLap = _seasonView.ShortParade ? true : false;

                    loopEvent.MustUseDiffTireTypesInRace = s.MustUseDiffTireTypesInRace;

                    if (_seasonView.QualiAlone)
                    {
                        loopEvent.Subsessions = new List<int> { 3, 4, 6 };
                    }
                    else
                    {
                        loopEvent.Subsessions = new List<int> { 3, 5, 6 };
                    }

                    eventGuid = Guid.NewGuid().ToString();
                    loopEvent.EventId = eventGuid;

                    if (s.Schedules[i].RaceLapLimit == null)
                    {
                        loopEvent.RaceLaps = 0;
                        loopEvent.RaceLength = s.Schedules[i].RaceTimeLimit;
                        loopEvent.RaceLengthType = 2;
                    }
                    else
                    {
                        loopEvent.RaceLaps = s.Schedules[i].RaceLapLimit;
                        loopEvent.RaceLength = 0;
                        loopEvent.RaceLengthType = 3;
                    }

                    loopEvent.Weather = _weather.Map(i, eventGuid);
                    loopEvent.StartZone = s.Schedules[i].HasStartZone;
                    loopEvent.FullCourseCautions = s.Schedules[i].HasFullCourseCautions;
                    loopEvent.TimeOfDay = _seasonView.AfternoonRaces ? 0 : s.Schedules[i].Weather.TimeOfDay;

                    if (s.Schedules[i].Track.TrackName.Contains("Combined") || s.Schedules[i].Track.TrackName.Contains("Nordschleife"))
                    {
                        loopEvent.QualifyLength = 20;
                    }
                    else if (s.Schedules[i].Track.Category == "oval")
                    {
                        loopEvent.QualifyLength = 5;
                    }
                    else
                    {
                        loopEvent.QualifyLength = 8;
                    }

                    events.Add(loopEvent);
                }
            }

            if (events.Count <= 0)
            {
                throw new Exception("No tracks selected");
            }

            return events;
        }
    }
}
