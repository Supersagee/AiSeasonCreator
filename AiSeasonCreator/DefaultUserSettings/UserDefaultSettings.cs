using System;
using System.Text.Json.Serialization;

namespace AiSeasonCreator.DefaultUserSettings
{
    public class UserDefaultSettings
    {
        [JsonPropertyName("settingsVersion")]
        public int SettingsVersion { get; set; }
        [JsonPropertyName("checkBoxesUserValues")]
        public CheckBoxesUserValues CheckBoxesUserValues { get; set; } = new CheckBoxesUserValues();
        [JsonPropertyName("comboBoxesUserValues")]
        public ComboBoxesUserValues ComboBoxesUserValues { get; set; } = new ComboBoxesUserValues();
        [JsonPropertyName("trackBarUserValues")]
        public TrackBarUserValues TrackBarUserValues { get; set; } = new TrackBarUserValues();
        [JsonPropertyName("folderLocations")]
        public FolderLocations FolderLocations { get; set; } = new FolderLocations();
        [JsonPropertyName("windowLocation")]
        public WindowLocation WindowLocation { get; set; } = new WindowLocation();
    }
}
