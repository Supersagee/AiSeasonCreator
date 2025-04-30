using AiSeasonCreator.Data;
using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Helpers;
using AiSeasonCreator.JsonClasses.Assets;
using AiSeasonCreator.Mappers;
using AiSeasonCreator.Repos;
using AiSeasonCreator.Roster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AiSeasonCreator.Services
{
    public class RosterService : IRosterService
    {
        private IJsonRepo _jsonRepo;
        private LoadedData _loadedData;
        private AppSettings _appSettings;
        private readonly IMapper<DriverRoster> _driverRoster;
        public RosterService(IJsonRepo jsonRepo, 
            LoadedData loadedData, 
            AppSettings appSettings, 
            IMapper<DriverRoster> driverRoster)
        {
            _jsonRepo = jsonRepo;
            _loadedData = loadedData;
            _appSettings = appSettings;
            _driverRoster = driverRoster;
        }
        public void Initialize()
        {

        }
        public void SetSelectedSeasonAndSeries(string seriesName)
        {
            var selectedSeries = _loadedData.FullSchedule.FirstOrDefault(s => s.Schedules[0].SeriesName == seriesName);
            _loadedData.RosterSelectedSeries = selectedSeries;

            _loadedData.RosterSelectedSeriesDetails = _loadedData.SeriesDetails.FirstOrDefault(s => s.SeriesId == selectedSeries.SeriesId);
        }

        public IEnumerable<string> GetAvailableSeries()
        {
            var availableSeries = new List<string>();
            var schedules = _loadedData.FullSchedule;
            var carClasses = _loadedData.CarClasses;
            var carDetails = _loadedData.CarDetails;

            foreach (var schedule in schedules)
            {
                var carIds = schedule.CarClassIds;
                var carsInSeries = carClasses
                    .Where(cc => carIds.Contains(cc.CarClassId))
                    .SelectMany(cc => cc.CarsInClass.Select(car => car.CarId))
                    .ToList();

                var aiCarsInSeries = carDetails
                    .Where(cd => carsInSeries.Contains(cd.CarId) && cd.AiEnabled)
                    .ToList();

                if (aiCarsInSeries.Any())
                {
                    availableSeries.Add(schedule.Schedules[0].SeriesName);
                }
            }

            availableSeries.Sort();
            return availableSeries;
        }

        public IEnumerable<string> GetAvailableRosters()
        {
            var rosters = Directory.GetDirectories(_appSettings.RosterFolderPath);
            var rosterNames = new List<string>();

            foreach (var roster in rosters)
            {
                var path = Path.Combine(roster, "roster.json");
                if (File.Exists(path))
                    rosterNames.Add(Path.GetFileName(roster));
            }

            return rosterNames;
        }

        public void GetAvailableDrivers(string rosterName)
        {
            var rosterPath = Path.Combine(_appSettings.RosterFolderPath, rosterName, "roster.json");
            var roster = _jsonRepo.Load<DriverRoster>(rosterPath);

            _loadedData.SelectedRoster = roster;
            var lddg = _loadedData.DriversDataGrid;
            lddg.Clear();

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var driver in roster.Drivers)
            {
                var ddg = new DriversDataGrid();

                var carLogo = _loadedData.CarAssets.FirstOrDefault(c => Convert.ToInt32(c.Key) == driver.CarId).Value.Logo;
                var logoPath = Path.Combine(basePath, "Assets", "CarAssets", carLogo);
                var resizedLogo = ResizeImage(new Bitmap(Image.FromFile(logoPath)), new Size(70, 18));

                ddg.Driver = driver.DriverName;
                ddg.DriverNumber = Convert.ToInt32(driver.CarNumber);
                ddg.CarLogo = resizedLogo;
                ddg.CarName = _loadedData.CarDetails.FirstOrDefault(c => c.CarId == driver.CarId).CarName;
                ddg.RelativeSkill = driver.DriverSkill;
                ddg.Aggression = driver.DriverAggression;
                ddg.Optimism = driver.DriverOptimism;
                ddg.Smoothness = driver.DriverSmoothness;
                ddg.Age = driver.DriverAge;
                ddg.PitCrewSkill = driver.PitCrewSkill;
                ddg.PitStrat = driver.StrategyRiskiness;

                lddg.Add(ddg);
            }
        }
        public void UpdateDrivers(DataGridViewSelectedCellCollection selectedDrivers, AttributesInUse att, string rosterName, bool isAllDrivers, bool isMinusPlus)
        {
            var selectedDriverNames = GetSelectedDrivers(selectedDrivers);

            var rand = new Random();
            var roster = _loadedData.SelectedRoster;
            var drivers = roster.Drivers;

            var lddg = _loadedData.DriversDataGrid;

            foreach (var d in drivers)
            {
                if (selectedDriverNames.Contains(d.DriverName) || isAllDrivers)
                {
                    var ddgr = lddg.FirstOrDefault(i => i.Driver == d.DriverName);

                    if (isMinusPlus)
                    {
                        if (att.UseRelativeSkill)
                        {
                            d.DriverSkill = rand.Next(SetRange(d.DriverSkill, att.RelativeSkillMin), SetRange(d.DriverSkill, att.RelativeSkillMax) + 1);
                            ddgr.RelativeSkill = d.DriverSkill;
                        }

                        if (att.UseAggression)
                        {
                            d.DriverAggression = rand.Next(SetRange(d.DriverAggression, att.AggressionMin), SetRange(d.DriverAggression, att.AggressionMax) + 1);
                            ddgr.Aggression = d.DriverAggression;
                        }

                        if (att.UseOptimism)
                        {
                            d.DriverOptimism = rand.Next(SetRange(d.DriverOptimism, att.OptimismMin), SetRange(d.DriverOptimism, att.OptimismMax) + 1);
                            ddgr.Optimism = d.DriverOptimism;
                        }

                        if (att.UseSmoothness)
                        {
                            d.DriverSmoothness = rand.Next(SetRange(d.DriverSmoothness, att.SmoothnessMin), SetRange(d.DriverSmoothness, att.SmoothnessMax) + 1);
                            ddgr.Smoothness = d.DriverSmoothness;
                        }

                        if (att.UseAge)
                        {
                            d.DriverAge = rand.Next(SetAgeRange(d.DriverAge, att.AgeMin), SetAgeRange(d.DriverAge, att.AgeMax) + 1);
                            ddgr.Age = d.DriverAge;
                        }

                        if (att.UsePitCrew)
                        {
                            d.PitCrewSkill = rand.Next(SetRange(d.PitCrewSkill, att.PitCrewMin), SetRange(d.PitCrewSkill, att.PitCrewMax) + 1);
                            ddgr.PitCrewSkill = d.PitCrewSkill;
                        }

                        if (att.UsePitStrat)
                        {
                            d.StrategyRiskiness = rand.Next(SetRange(d.StrategyRiskiness, att.PitStratMin), SetRange(d.StrategyRiskiness, att.PitStratMax) + 1);
                            ddgr.PitStrat = d.StrategyRiskiness;
                        }
                    }
                    else
                    {
                        if (att.UseRelativeSkill)
                        {
                            d.DriverSkill = rand.Next(att.RelativeSkillMin, att.RelativeSkillMax + 1);
                            ddgr.RelativeSkill = d.DriverSkill;
                        }

                        if (att.UseAggression)
                        {
                            d.DriverAggression = rand.Next(att.AggressionMin, att.AggressionMax + 1);
                            ddgr.Aggression = d.DriverAggression;
                        }

                        if (att.UseOptimism)
                        {
                            d.DriverOptimism = rand.Next(att.OptimismMin, att.OptimismMax + 1);
                            ddgr.Optimism = d.DriverOptimism;
                        }

                        if (att.UseSmoothness)
                        {
                            d.DriverSmoothness = rand.Next(att.SmoothnessMin, att.SmoothnessMax + 1);
                            ddgr.Smoothness = d.DriverSmoothness;
                        }

                        if (att.UseAge)
                        {
                            d.DriverAge = rand.Next(att.AgeMin, att.AgeMax + 1);
                            ddgr.Age = d.DriverAge;
                        }

                        if (att.UsePitCrew)
                        {
                            d.PitCrewSkill = rand.Next(att.PitCrewMin, att.PitCrewMax + 1);
                            ddgr.PitCrewSkill = d.PitCrewSkill;
                        }

                        if (att.UsePitStrat)
                        {
                            d.StrategyRiskiness = rand.Next(att.PitStratMin, att.PitStratMax + 1);
                            ddgr.PitStrat = d.StrategyRiskiness;
                        }
                    }
                }
            }

            var rosterFilePath = Path.Combine(_appSettings.RosterFolderPath, rosterName, "roster.json");
            _jsonRepo.Save(rosterFilePath, roster);
        }

        private int SetRange(int att, int num)
        {
            if (num < 0)
            {
                num *= -1;
                return att - num > 0 ? att - num : 0;
            }
            else
            {
                return att + num < 100 ? att + num : 100;
            }
        }

        private int SetAgeRange(int att, int num)
        {
            if (num < 0)
            {
                num *= -1;
                return att - num > 13 ? att - num : 13;
            }
            else
            {
                return att + num < 90 ? att + num : 90;
            }
        }

        private IEnumerable<string> GetSelectedDrivers(DataGridViewSelectedCellCollection selectedDrivers)
        {
            var driverNames = new List<string>();

            if (selectedDrivers.Count > 0)
            {
                for (var i = 0; i < selectedDrivers.Count; i++)
                {
                    if (selectedDrivers[i].ColumnIndex == 0)
                        driverNames.Add(selectedDrivers[i].Value.ToString());
                }
            }

            return driverNames;
        }

        private Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            nPercent = Math.Min(nPercentW, nPercentH);
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public int GetDriverCount()
        {
            return _loadedData.RosterSelectedSeriesDetails.MaxStarters;
        }

        public Drivers GetDriver(string driverName)
        {
            var driver = _loadedData.SelectedRoster.Drivers.FirstOrDefault(d => d.DriverName == driverName);

            return driver;
        }

        public void SkillCellUpdated(string rosterName)
        {
            var rosterFilePath = Path.Combine(_appSettings.RosterFolderPath, rosterName, "roster.json");

            var roster = _loadedData.SelectedRoster;

            foreach (var d in roster.Drivers)
            {
                var driver = _loadedData.DriversDataGrid.FirstOrDefault(s => s.Driver == d.DriverName);

                d.DriverSkill = driver.RelativeSkill;
                d.DriverAggression = driver.Aggression;
                d.DriverOptimism = driver.Optimism;
                d.DriverSmoothness = driver.Smoothness;
                d.DriverAge = driver.Age;
                d.PitCrewSkill = driver.PitCrewSkill;
                d.StrategyRiskiness = driver.PitStrat;
            }

            _jsonRepo.Save(rosterFilePath, roster);
        }

        public void CreateRoster(string rosterName)
        {
            _driverRoster.Map(1, rosterName);
        }
    }
}
