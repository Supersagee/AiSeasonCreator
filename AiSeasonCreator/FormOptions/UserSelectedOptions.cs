using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using iRacingWeatherURLParser.WeatherSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.FormOptions
{
    public class UserSelectedOptions
    {
        //checkboxes
        public bool UseAdaptiveAi { get; set; }
        public bool DisableDamage { get; set; }
        public bool AiAvoids { get; set; }
        public bool StaticWeather { get; set; }
        public bool AfternoonRaces { get; set; }
        public bool NeverRain { get; set; }
        public bool QualiAlone { get; set; }
        public bool ShortParade { get; set; }
        public bool ExcludeRoster { get; set; }
        public bool CustCarCountSeason { get; set; }
        public bool CustCarCountRoster { get; set; }
        public bool UseExistingRoster { get; set; }
        public bool UseRosterTabAtt { get; set; }
        public bool UseRelativeSkill { get; set; } = true;
        public bool UseAggression { get; set; } = true;
        public bool UseOptimism { get; set; } = true;
        public bool UseSmoothness { get; set; } = true;
        public bool UseAge { get; set; } = true;
        public bool UsePitCrew { get; set; } = true;
        public bool UsePitStrat { get; set; } = true;

        //comboboxes
        public string? SeriesName { get; set; }
        public string? CarName { get; set; }
        public string? AdaptiveAiSkillLevel { get; set; }
        public string? ExistingRosterName { get; set; }
        public string? DriversComboBoxName { get; set; }
        public string? RosterSeriesName { get; set; }

        //textboxes
        public string? SeasonName { get; set; }
        public string? RosterName { get; set; }
        public string? SeasonFolderPath { get; set; }
        public string? RosterFolderPath { get; set; }

        //tracksliders
        public int AiMin { get; set; }
        public int AiMax { get; set; }
        public int RelateiveSkillMin { get; set; }
        public int RelativeSkillMax { get; set; }
        public int AggressionMin { get; set; }
        public int AggressionMax { get; set; }
        public int OptimismMin { get; set; }
        public int OptimismMax { get; set; }
        public int SmoothnessMin { get; set; }
        public int SmoothnessMax { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int PitCrewMin { get; set; }
        public int PitCrewMax { get; set; }
        public int PitStratMin { get; set; }
        public int PitStratMax { get; set; }
        public int CustCarSeasonCountValue { get; set; }
        public int CustCarRosterCountValue { get; set; }

        //other settings
        public int SeasonSeriesIndex { get; set; }
        public int RosterSeriesIndex { get; set; }
        public List<int>? UnselectedTracks { get; set; }
        public JsonClasses.CarClasses.CarClasses[] CarClasses { get; set; }
        public CarDetails[] CarDetails { get; set; }
        public FullSchedule[] FullSchedule { get; set; }
        public FullSchedule[] RosterFullSchedule { get; set; }
        public SeriesDetails[] SeriesDetails { get; set; }
        public SeriesDetails[] RosterSeriesDetails { get; set; }
        public TrackDetails[] TrackDetails { get; set; }
        public WeatherSchedule WeatherSchedule { get; set; }
        public FullSchedule SelectedSeason { get; set; }
        public SeriesDetails SelectedSeries { get; set; }
        public List<string> SeasonFileNames { get; set; } = new List<string>();
        public List<string> SeriesFileNames { get; set; } = new List<string>();
        public List<string> NotAvailableTracks { get; set; } = new List<string>();
    }
}
