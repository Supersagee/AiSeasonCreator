using System;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.DefaultUserSettings
{
    public class UserDefaultSettings
    {
        [JsonPropertyName("settingsVersion")]
        public int SettingsVersion { get; set; }
        [JsonPropertyName("checkBoxesUserValues")]
        public CheckBoxesUserValues CheckBoxesUserValues { get; set; }
        [JsonPropertyName("comboBoxesUserValues")]
        public ComboBoxesUserValues ComboBoxesUserValues { get; set; }
        [JsonPropertyName("trackBarUserValues")]
        public TrackBarUserValues TrackBarUserValues { get; set; }
        [JsonPropertyName("folderLocations")]
        public FolderLocations FolderLocations { get; set; }
        [JsonPropertyName("windowLocation")]
        public WindowLocation WindowLocation { get; set; }
    }
}
