using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;

namespace AiSeasonCreator.Mappers
{
    public class TrackStateMapper : IMapper<TrackState>
    {
        public TrackState Map(int eventIndex, string eventGuid)
        {
            var ts = new TrackState();

            ts.LeaveMarbles = false;
            ts.PracticeRubber = -1;
            ts.QualifyRubber = -1;
            ts.RaceRubber = -1;
            ts.WarmupRubber = -1;

            return ts;
        }
    }
}
