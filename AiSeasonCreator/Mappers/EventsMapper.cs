using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;

namespace AiSeasonCreator.Mappers
{
    public class EventsMapper : IMapper<List<Events>>
    {
        private readonly IMapper<PaceCar> _paceCarMapper;
        private readonly IMapper<Weather> _weather;
        private readonly UserSelectedOptions _userSelectedOptions;
        public EventsMapper(IMapper<PaceCar> paceCarMapper, IMapper<Weather> weather, UserSelectedOptions userSelectedOptions)
        {
            _paceCarMapper = paceCarMapper;
            _weather = weather;
            _userSelectedOptions = userSelectedOptions;
        }
        public List<Events> Map(int eventIndex, string eventGuid)
        {
            var i = _userSelectedOptions.SeasonSeriesIndex;

            var events = new List<Events>();
            var notAllowedTracks = new List<int>();

            var ss = _userSelectedOptions.FullSchedule[i];
            var tracks = _userSelectedOptions.TrackDetails;

            for (var j = 0; j < tracks.Length; j++)
            {
                if (!tracks[j].AiEnabled)
                {
                    notAllowedTracks.Add(tracks[j].TrackId);
                }
            }

            for (var j = 0; j < ss.Schedules.Count; j++)
            {

                if (_userSelectedOptions.UnselectedTracks != null && _userSelectedOptions.UnselectedTracks.Contains(j))
                {
                    continue;
                }

                if (!notAllowedTracks.Contains(ss.Schedules[j].Track.TrackId))
                {
                    var loopEvent = new Events();
                    loopEvent.TrackId = ss.Schedules[j].Track.TrackId;
                    loopEvent.NumOptLaps = 0;
                    loopEvent.PaceCar = _paceCarMapper.Map(j, "");
                    loopEvent.ShortParadeLap = _userSelectedOptions.ShortParade ? true : false;

                    loopEvent.MustUseDiffTireTypesInRace = ss.MustUseDiffTireTypesInRace;

                    if (_userSelectedOptions.QualiAlone)
                    {
                        loopEvent.Subsessions = new List<int> { 3, 4, 6 };
                    }
                    else
                    {
                        loopEvent.Subsessions = new List<int> { 3, 5, 6 };
                    }

                    eventGuid = Guid.NewGuid().ToString();
                    loopEvent.EventId = eventGuid;

                    if (ss.Schedules[j].RaceLapLimit == null)
                    {
                        loopEvent.RaceLaps = 0;
                        loopEvent.RaceLength = ss.Schedules[j].RaceTimeLimit;
                        loopEvent.RaceLengthType = 2;
                    }
                    else
                    {
                        loopEvent.RaceLaps = ss.Schedules[j].RaceLapLimit;
                        loopEvent.RaceLength = 0;
                        loopEvent.RaceLengthType = 3;
                    }

                    loopEvent.Weather = _weather.Map(j, eventGuid);
                    loopEvent.StartZone = ss.Schedules[j].HasStartZone;
                    loopEvent.FullCourseCautions = ss.Schedules[j].HasFullCourseCautions;
                    loopEvent.TimeOfDay = _userSelectedOptions.AfternoonRaces ? 0 : ss.Schedules[j].Weather.TimeOfDay;

                    if (ss.Schedules[j].Track.TrackName.Contains("Combined") || ss.Schedules[j].Track.TrackName.Contains("Nordschleife"))
                    {
                        loopEvent.QualifyLength = 20;
                    }
                    else if (ss.Schedules[j].Track.Category == "oval")
                    {
                        loopEvent.QualifyLength = 5;
                    }
                    else
                    {
                        loopEvent.QualifyLength = 8;
                    }

                    events.Add(loopEvent);
                }
                else
                {
                    _userSelectedOptions.NotAvailableTracks.Add($"{ss.Schedules[j].Track.TrackName} - {ss.Schedules[j].Track.ConfigName}");
                }
            }
            _userSelectedOptions.UnselectedTracks = new List<int> { };

            if (events.Count <= 0)
            {
                throw new Exception();
            }

            return events;
        }
    }
}
