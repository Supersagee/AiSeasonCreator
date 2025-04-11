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
        int GetPracticeLength();
        int GetQualiLength(bool qualiAlone);
        int GetRaceLength();
        IEnumerable<string> GetAvailableRosters();
        void CreateSeason(string seasonName);
    }
}
