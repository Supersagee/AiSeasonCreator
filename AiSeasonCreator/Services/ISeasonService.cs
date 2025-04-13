using AiSeasonCreator.Helpers;
using AiSeasonCreator.Views;
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
        IEnumerable<NameAndAsset> GetAvailableSeries();
        IEnumerable<NameAndAsset> GetAvailableCars();
        IEnumerable<NameAndAsset> GetAvailableTracks();
        int GetDriverCount();
        int GetPracticeLength();
        int GetQualiLength(bool qualiAlone);
        int GetRaceLength();
        IEnumerable<string> GetAvailableRosters();
        string GetImageFilePath(string assetType, string itemName);
        void CreateSeason(string seasonName);
    }
}
