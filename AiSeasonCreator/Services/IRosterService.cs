using AiSeasonCreator.Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface IRosterService
    {
        void Initialize();
        void SetSelectedSeasonAndSeries(string seriesName);
        IEnumerable<string> GetRosterSources();
        IEnumerable<string> GetAvailableSeriesOrRosters(string rosterSource);
        IEnumerable<string> GetAvailableDrivers(string rosterName);
        int GetDriverCount();
        Drivers GetDriver(string driverName);
        void CreateRoster();
    }
}
