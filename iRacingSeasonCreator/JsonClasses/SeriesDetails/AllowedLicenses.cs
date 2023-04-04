using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace iRacingSeasonCreator.JsonClasses.SeriesDetails
{
    public class AllowedLicenses
    {
        [JsonPropertyName("license_group")]
        public int LicenseGroup { get; set; }

        [JsonPropertyName("min_license_level")]
        public int MinLicenseLevel { get; set; }

        [JsonPropertyName("max_license_level")]
        public int MaxLicenseLevel { get; set; }

        [JsonPropertyName("group_name")]
        public string GroupName { get; set; } = default!;
    }
}
