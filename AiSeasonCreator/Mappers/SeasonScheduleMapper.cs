using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;
using AiSeasonCreator.Roster;

namespace AiSeasonCreator.Mappers
{
    public class SeasonScheduleMapper : IMapper<SeasonSchedule>
    {
        private readonly IMapper<List<CarSettings>> _carSettingsMapper;
        private readonly IMapper<List<Events>> _eventsMapper;
        private readonly IMapper<GuidedParameters> _guidedParametersMapper;
        private readonly IMapper<List<Keyframes>> _keyframesMapper;
        private readonly IMapper<PaceCar> _paceCarMapper;
        private readonly IMapper<TrackState> _trackStateMapper;
        private readonly IMapper<Weather> _weatherMapper;
        private readonly IMapper<DriverRoster> _driverRoster;
        private readonly UserSelectedOptions _userSelectedOptions;
        public SeasonScheduleMapper(
            IMapper<List<CarSettings>> carSettingsMapper,
            IMapper<List<Events>> eventsMapper,
            IMapper<GuidedParameters> guidedParametersMapper,
            IMapper<List<Keyframes>> keyframesMapper,
            IMapper<PaceCar> paceCarMapper,
            IMapper<TrackState> trackStateMapper,
            IMapper<Weather> weatherMapper,
            IMapper<DriverRoster> driverRoster,
            UserSelectedOptions userSelectedOptions)
        {
            _carSettingsMapper = carSettingsMapper;
            _eventsMapper = eventsMapper;
            _guidedParametersMapper = guidedParametersMapper;
            _keyframesMapper = keyframesMapper;
            _paceCarMapper = paceCarMapper;
            _trackStateMapper = trackStateMapper;
            _weatherMapper = weatherMapper;
            _driverRoster = driverRoster;
            _userSelectedOptions = userSelectedOptions;
        }
        public SeasonSchedule Map(int eventIndex, string eventGuid)
        {
            var s = new SeasonSchedule();
            var seriesDetails = _userSelectedOptions.SeriesDetails;
            var cars = _userSelectedOptions.CarDetails;
            var carClasses = _userSelectedOptions.CarClasses;
            var carSettingsList = _carSettingsMapper.Map(0, "");
            var i = _userSelectedOptions.SeasonSeriesIndex;
            var c = _userSelectedOptions.FullSchedule[i];

            for (var j = 0; j < cars.Length; j++)
            {
                if (cars[j].CarName == _userSelectedOptions.CarName)
                {
                    s.CarId = cars[j].CarId;
                    break;
                }
            }

            //get AiIds and UserClassId
            if (c.CarClassIds.Count == 1)
            {
                s.AiCarClassId = c.CarClassIds[0];
                s.AiCarClassIds = new List<int>();
                s.UserCarClassId = c.CarClassIds[0];
            }
            else
            {
                s.AiCarClassId = null;
                s.AiCarClassIds = c.CarClassIds;

                for (var j = 0; j < carClasses.Length; j++)
                {
                    for (var k = 0; k < s.AiCarClassIds.Count; k++)
                    {
                        if (s.AiCarClassIds[k] == carClasses[j].CarClassId)
                        {
                            for (var n = 0; n < carClasses[j].CarsInClass.Length; n++)
                            {
                                if (carClasses[j].CarsInClass[n].CarId == s.CarId)
                                {
                                    s.UserCarClassId = carClasses[j].CarClassId;
                                }
                            }
                        }
                    }
                }
            }

            s.CarSettings = carSettingsList;
            s.DamageModel = _userSelectedOptions.DisableDamage ? 3 : 0;
            s.TrackState = _trackStateMapper.Map(0, "");
            s.TimeOfDay = 0;
            s.Weather = _weatherMapper.Map(0, "");
            s.FullCourseCautions = c.Schedules[0].HasFullCourseCautions;
            s.GridPosition = 1;
            s.LuckyDog = c.LuckyDog;
            
            var matchingSeries = seriesDetails.FirstOrDefault(sd => sd.SeriesId == c.SeriesId);
            if (matchingSeries != null)
            {
                if (_userSelectedOptions.CustCarCountSeason)
                {
                    s.MaxDrivers = _userSelectedOptions.CustCarSeasonCountValue;
                }
                else
                {
                    s.MaxDrivers = matchingSeries.MaxStarters;
                }
                s.PointsSystemId = matchingSeries.Category == "oval" ? 3 : 4;
            }

            s.NumFastTows = -1;
            s.AvoidUser = _userSelectedOptions.AiAvoids;

            //if (_userSelectedOptions.UseAdaptiveAi)
            //{
            //    //Adaptive Ai HERE
            //}
            //else
            //{
                s.MinSkill = _userSelectedOptions.AiMin;
                s.MaxSkill = _userSelectedOptions.AiMax;
            //}
            
            s.MustUseDiffTireTypesInRace = c.MustUseDiffTireTypesInRace;
            s.StartOnQualTire = c.StartOnQualTire;
            s.UnsportConductRuleMode = 0;
            s.PracticeLength = 3;
            s.QualifyLaps = 2;
            s.QualifyLength = 8;

            //sets race by lap count or time limit
            if (c.Schedules[0].RaceLapLimit == null)
            {
                s.RaceLaps = 0;
                s.RaceLength = c.Schedules[0].RaceTimeLimit;
                s.RaceLengthType = 2;
            }
            else
            {
                s.RaceLaps = c.Schedules[0].RaceLapLimit;
                s.RaceLength = 0;
                s.RaceLengthType = 3;
            }

            //restart type
            if (c.Schedules[0].RestartType == "Double-file Back")
            {
                s.Restarts = 2;
            }
            else
            {
                s.Restarts = 0;
            }

            //rolling or standing starts
            if (c.Schedules[0].StartType == "Rolling")
            {
                s.RollingStarts = true;
            }
            else
            {
                s.RollingStarts = false;
            }

            if (_userSelectedOptions.ExcludeRoster)
            {
                s.RosterName = null;
            }
            else if (_userSelectedOptions.UseExistingRoster && _userSelectedOptions.ExistingRosterName != "")
            {
                s.RosterName = _userSelectedOptions.ExistingRosterName;
            }
            else
            {
                s.RosterName = _userSelectedOptions.SeasonName;
                _driverRoster.Map(0, _userSelectedOptions.SeasonName);
            }

            s.ShortParadeLap = _userSelectedOptions.ShortParade;
            s.NoLapperWaveArounds = false;
            s.DoNotCountCautionLaps = c.CautionLapsDoNotCount;
            s.Subsessions = new List<int> { 3, 5, 6 };
            s.StartZone = 0;

            s.Events = _eventsMapper.Map(0, ""); 

            s.Name = _userSelectedOptions.SeasonName;

            return s;
        }
    }
}
