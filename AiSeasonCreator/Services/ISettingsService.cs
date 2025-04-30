using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface ISettingsService
    {
        void LoadUserDefaultSettings();
        string GetSeasonsFolderPathAuto(string name);
        string GetRostersFolderPathAuto(string name);
        string GetSeasonsFolderPath(string name);
        string GetRostersFolderPath(string name);
    }
}
