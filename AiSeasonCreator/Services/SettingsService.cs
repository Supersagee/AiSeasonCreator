using AiSeasonCreator.Data;
using AiSeasonCreator.DefaultUserSettings;
using AiSeasonCreator.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public class SettingsService : ISettingsService
    {
        private LoadedData _loadedData;
        private IJsonRepo _jsonRepo;
        
        public SettingsService(LoadedData loadedData, IJsonRepo jsonRepo)
        {
            _loadedData = loadedData;
            _jsonRepo = jsonRepo;
        }
        public string GetSeasonsFolderPathAuto(string name)
        {
            var ud = _loadedData.UserDefaultSettings;
            if (ud != null && Directory.Exists(ud.FolderLocations.SeasonsFolder)) 
            {
                return ud.FolderLocations.SeasonsFolder;
            }
            
            string docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string defaultPath = Path.Combine(docsFolder, "iRacin", name);

            if (!Directory.Exists(defaultPath))
            {
                return $"";
            }

            if (ud != null) { ud.FolderLocations.SeasonsFolder = defaultPath; }
            return defaultPath;
        }

        public string GetRostersFolderPathAuto(string name)
        {
            var ud = _loadedData.UserDefaultSettings;
            if (ud != null && Directory.Exists(ud.FolderLocations.RostersFolder))
            {
                return ud.FolderLocations.RostersFolder;
            }

            string docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string defaultPath = Path.Combine(docsFolder, "iRacing", name);

            if (!Directory.Exists(defaultPath))
            {
                return $"";
            }

            if (ud != null) { ud.FolderLocations.RostersFolder = defaultPath; }
            return defaultPath;
        }

        public string GetSeasonsFolderPath(string name)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _loadedData.UserDefaultSettings.FolderLocations.SeasonsFolder = folderBrowserDialog.SelectedPath;
                    return folderBrowserDialog.SelectedPath;
                }
            }

            return $"";
        }

        public string GetRostersFolderPath(string name)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _loadedData.UserDefaultSettings.FolderLocations.RostersFolder = folderBrowserDialog.SelectedPath;
                    return folderBrowserDialog.SelectedPath;
                }
            }

            return $"";
        }

        public void LoadUserDefaultSettings()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userDefaultSettingsPath = Path.Combine(appDataFolderPath, "AiSeasonCreator", "UserDefaultSettings.json");

            if (File.Exists(userDefaultSettingsPath))
            {
                _loadedData.UserDefaultSettings = _jsonRepo.Load<UserDefaultSettings>(userDefaultSettingsPath);
            }
        }
    }
}
