using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface ISeasonService
    {
        void Initialize();
        void SetSelectedSeasonAndSeries(string seriesName);
        IEnumerable<string> GetAvailableSeries();
        IEnumerable<string> GetAvailableCars();
        IEnumerable<string> GetAvailableTracks();
        int GetDriverCount();
        IEnumerable<string> GetAvailableRosters();
        void CreateSeason(string seasonName);
    }
}
