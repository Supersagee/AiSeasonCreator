using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Roster;
using AiSeasonCreator.Data;
using System.Runtime.CompilerServices;
using AiSeasonCreator.Views;

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
        private readonly ISeasonView _seasonView;
        private readonly LoadedData _loadedData;
        public SeasonScheduleMapper(
            IMapper<List<CarSettings>> carSettingsMapper,
            IMapper<List<Events>> eventsMapper,
            IMapper<GuidedParameters> guidedParametersMapper,
            IMapper<List<Keyframes>> keyframesMapper,
            IMapper<PaceCar> paceCarMapper,
            IMapper<TrackState> trackStateMapper,
            IMapper<Weather> weatherMapper,
            IMapper<DriverRoster> driverRoster,
            ISeasonView seasonView,
            LoadedData loadedData)
        {
            _carSettingsMapper = carSettingsMapper;
            _eventsMapper = eventsMapper;
            _guidedParametersMapper = guidedParametersMapper;
            _keyframesMapper = keyframesMapper;
            _paceCarMapper = paceCarMapper;
            _trackStateMapper = trackStateMapper;
            _weatherMapper = weatherMapper;
            _driverRoster = driverRoster;
            _seasonView = seasonView;
            _loadedData = loadedData;
        }
        public SeasonSchedule Map(int eventIndex, string seasonName)
        {
            var ss = new SeasonSchedule();
            var s = _loadedData.SelectedSeries;
            var sd = _loadedData.SelectedSeriesDetails;

            SetCarIdsAndClassIds(ss);

            ss.CarSettings = _carSettingsMapper.Map(0, "");
            ss.DamageModel = _seasonView.DisableDamage ? 3 : 0;
            ss.TrackState = _trackStateMapper.Map(0, "");
            ss.TimeOfDay = 0;
            ss.Weather = _weatherMapper.Map(0, "");
            ss.FullCourseCautions = s.Schedules[0].HasFullCourseCautions;
            ss.GridPosition = 1;
            ss.LuckyDog = s.LuckyDog;

            ss.MaxDrivers = _seasonView.CarCount;
            ss.PointsSystemId = sd.Category == "oval" ? 3 : 4;

            ss.NumFastTows = -1;
            ss.AvoidUser = _seasonView.AiAvoids;

            SetAiDifficulty(ss);

            ss.MustUseDiffTireTypesInRace = s.MustUseDiffTireTypesInRace;
            ss.StartOnQualTire = s.StartOnQualTire;
            ss.UnsportConductRuleMode = 0;
            ss.PracticeLength = _seasonView.PracticeLength;
            ss.QualifyLaps = _seasonView.QualiLength;
            ss.QualifyLength = _seasonView.QualiLength;

            //sets race by lap count or time limit
            if (s.Schedules[0].RaceLapLimit == null)
            {
                ss.RaceLaps = 0;
                ss.RaceLength = _seasonView.RaceLength;
                ss.RaceLengthType = 2;
            }
            else
            {
                ss.RaceLaps = (s.Schedules[0].RaceTimeLimit * _seasonView.RaceLength) / 100;
                ss.RaceLength = 0;
                ss.RaceLengthType = 3;
            }

            ss.Restarts = s.Schedules[0].RestartType == "Double-file Back" ? 2 : 0;
            ss.RollingStarts = s.Schedules[0].StartType == "Rolling" ? true : false;

            if (_seasonView.RosterName == "Generate Roster")
            {
                ss.RosterName = _seasonView.SeasonName;
                _driverRoster.Map(0, seasonName);
            }
            else if (_seasonView.RosterName == "Exclude Roster")
            {
                ss.RosterName = null;
            }
            else
            {
                ss.RosterName = _seasonView.RosterName;
            }

            ss.ShortParadeLap = _seasonView.ShortParade;
            ss.NoLapperWaveArounds = false;
            ss.DoNotCountCautionLaps = s.CautionLapsDoNotCount;
            ss.Subsessions = new List<int> { 3, 5, 6 };
            ss.StartZone = 0;

            ss.Events = _eventsMapper.Map(0, ""); 

            ss.Name = seasonName;

            return ss;
        }

        private void SetCarIdsAndClassIds(SeasonSchedule ss)
        {
            var s = _loadedData.SelectedSeries;
            var cd = _loadedData.CarDetails;
            var cc = _loadedData.CarClasses;

            ss.CarId = cd.FirstOrDefault(c => c.CarName == _seasonView.SelectedCar).CarId;

            if (s.CarClassIds.Count == 1)
            {
                ss.AiCarClassId = s.CarClassIds[0];
                ss.AiCarClassIds = new List<int>();
                ss.UserCarClassId = s.CarClassIds[0];
            }
            else
            {
                ss.AiCarClassId = null;
                ss.AiCarClassIds = s.CarClassIds;

                for (var j = 0; j < cc.Length; j++)
                {
                    for (var k = 0; k < ss.AiCarClassIds.Count; k++)
                    {
                        if (ss.AiCarClassIds[k] == cc[j].CarClassId)
                        {
                            for (var n = 0; n < cc[j].CarsInClass.Length; n++)
                            {
                                if (cc[j].CarsInClass[n].CarId == ss.CarId)
                                {
                                    ss.UserCarClassId = cc[j].CarClassId;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetAiDifficulty(SeasonSchedule ss)
        {
            if (_seasonView.UseAdaptiveAi)
            {
                ss.AdaptiveAiEnabled = true;

                switch (_seasonView.AdaptiveAiDifficulty)
                {
                    case "Low":
                        ss.AdaptiveAiDifficulty = 0;
                        break;
                    case "Medium":
                        ss.AdaptiveAiDifficulty = 1;
                        break;
                    case "Hard":
                        ss.AdaptiveAiDifficulty = 2;
                        break;
                    case "Extreme":
                        ss.AdaptiveAiDifficulty = 3;
                        break;
                    default:
                        ss.AdaptiveAiDifficulty = 1;
                        break;
                }
            }
            else
            {
                ss.AdaptiveAiEnabled = false;
                ss.AdaptiveAiDifficulty = 0;
            }

            ss.MinSkill = _seasonView.AiMin;
            ss.MaxSkill = _seasonView.AiMax;
        }
    }
}
