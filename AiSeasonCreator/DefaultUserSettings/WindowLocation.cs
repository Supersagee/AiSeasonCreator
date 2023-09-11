using System.Text.Json.Serialization;

namespace AiSeasonCreator.DefaultUserSettings
{
    public class WindowLocation
    {
        [JsonPropertyName("x")]
        public int X { get; set; } = 100;
        [JsonPropertyName("y")]
        public int Y { get; set; } = 100;
    } 
}
