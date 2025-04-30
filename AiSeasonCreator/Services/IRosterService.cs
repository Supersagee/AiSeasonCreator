using AiSeasonCreator.Helpers;
using AiSeasonCreator.Roster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface IRosterService
    {
        void Initialize();
        void SetSelectedSeasonAndSeries(string seriesName);
        IEnumerable<string> GetAvailableSeries();
        void GetAvailableDrivers(string rosterName);
        IEnumerable<string> GetAvailableRosters();
        void UpdateDrivers(DataGridViewSelectedCellCollection selectedDrivers, AttributesInUse att, string rosterName, bool isAllDrivers, bool isMinusPlus);
        void SkillCellUpdated(string rosterName);
        int GetDriverCount();
        Drivers GetDriver(string driverName);
        void CreateRoster(string rosterName);
    }
}
