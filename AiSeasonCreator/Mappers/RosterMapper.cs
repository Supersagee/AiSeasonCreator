using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;
using AiSeasonCreator.Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Mappers
{
    public class RosterMapper : IMapper<DriverRoster>
    {
        private readonly UserSelectedOptions _userSelectedOptions;
        private readonly IJsonRepo _jsonService;
        public RosterMapper(UserSelectedOptions userSelectedOptions, IJsonRepo jsonService)
        {
            _userSelectedOptions = userSelectedOptions;
            _jsonService = jsonService;
        }

        public DriverRoster Map(int isRosterButton, string rosterName)
        {
            var maxDrivers = MaxDrivers(isRosterButton);

            var dr = new DriverRoster();

            var names = new List<string>()
            {
                "Liam Johnson", "Noah Martinez", "Oliver Thompson", "Elijah Taylor", "William Anderson", "James White", "Benjamin Harris", "Lucas Clark",
                "Henry Lewis", "Alexander Walker", "Sebastian Hall", "Jack Allen", "Samuel Young", "Luke King", "Daniel Wright", "Gabriel Hill",
                "Anthony Scott", "Isaac Green", "Grayson Adams", "Joseph Baker", "Aiden Nelson", "Ethan Mitchell", "Leo Ramirez", "Carter Carter",
                "Mason Roberts", "Josiah Phillips", "Andrew Evans", "Thomas Torres", "Joshua Hughes", "Christopher Morris", "Ian Price", "Hudson Sanchez",
                "Nathan Perry", "Aaron Reed", "Julian Bryant", "Levi Cruz", "David Long", "Jaxon Foster", "Adam Ward", "Jonathan Howard",
                "Christian Grant", "Lincoln Cooper", "Jordan Rivera", "Ezra Hayes", "Xavier Simmons", "Brayden Griffin", "Micah West", "Brandon Brooks",
                "Miles Kelly", "Easton Spencer", "Harrison Alexander", "Wesley Hoffman", "Emmett Weaver", "Caleb Chapman", "Declan Gardner",
                "Colton Fisher", "Zachary Mason", "Olivia Holland", "Billy Sage", "Emma Luna", "Ava May", "Isabella Ray","Amelia Daniels",
                "Charlotte Harmon", "Harper George", "Evelyn Reid"
            };

            var designs = new List<string>()
            {
                "9A0000,35005D,BCBCBC", "447ac0,ffffff,ee3442", "111111,ffffff,5481fc", "391c83,111111,ccff00", "ffffff,013990,4bd3fd", "5e5e5e,135324,111111",
                "4bd3fd,013990,ffffff", "184252,111111,03bbbd", "111111,ffee47,0300c2", "981a9b,00f0e7,ffffff", "135324,5e5e5e,111111", "0300c2,111111,ffee47",
                "284a94,b82f37,111111", "f06e34,ffffff,111111", "28536B,FFD838,21EDE5", "111111,ffffff,f06e34", "111111,03bbbd,184252", "111111,391c83,ccff00",
                "135324,5e5e5e,111111", "5e5e5e,111111,135324", "ffffff,0ada00,111111", "b82f37,111111,284a94", "d7162d,efd600,111111", "ffee47,0300c2,111111",
                "0ada00,111111,ffffff", "F9D10F,031163,FFFFFF", "7de54c,1f2892,ffffff", "111111,ccff00,391c83", "FFFFFF,184B91,D82520", "4bd3fd,013990,ffffff",
                "1f2892,ffffff,7de54c", "dff000,1a4b9b,ffffff", "ffffff,4bd3fd,013990", "391c83,ccff00,111111", "d7162d,efd600,111111", "ccff00,111111,391c83",
                "ffffff,ee3442,447ac0", "f1732e,372a75,ffffff", "447ac0,ffffff,ee3442", "5e5e5e,135324,111111", "ffee47,111111,0300c2", "1f2892,7de54c,ffffff",
                "447ac0,ffffff,ee3442", "f26522,00aeef,0a0a0a", "f1732e,372a75,ffffff", "013990,ffffff,4bd3fd", "ffffff,447ac0,ee3442", "EBDA28,000000,000000",
                "5481fc,ffffff,111111", "ed1c24,111111,cccccc", "111111,d7162d,efd600", "000000,2A3795,2A3795", "111111,135324,5e5e5e", "000000,0090FF,E7F700",
                "5481fc,111111,ffffff", "111111,d7162d,efd600", "f06e34,ffffff,111111", "FFFFFF,FFFFFF,FFFFFF", "000000,000000,000000", "000000,FFFFFF,000000",
                "000000,FFFFFF,FFFFFF", "ffffff,111111,5481fc", "111111,ffffff,fc0706", "b82f37,111111,284a94", "d7162d,efd600,111111", "ffee47,0300c2,111111"
            };

            var cc = _userSelectedOptions.CarClasses;
            var carNum = 0;

            
            var carClassIds = new List<int>();

            var seasonOrRoster = isRosterButton == 1 ? _userSelectedOptions.RosterSeriesName : _userSelectedOptions.SeriesName;
            var seriesIndex = isRosterButton == 1 ? _userSelectedOptions.RosterSeriesIndex : _userSelectedOptions.SeasonSeriesIndex;

            var rosterId = _userSelectedOptions.RosterFullSchedule[seriesIndex].SeriesId;
            var seriesId = _userSelectedOptions.FullSchedule[seriesIndex].SeriesId;

            for (var i = 0; i < _userSelectedOptions.RosterFullSchedule.Length; i++)
            {
                if (_userSelectedOptions.RosterFullSchedule[i].Schedules[0].SeriesName == seasonOrRoster)
                {
                    for (var j = 0; j < _userSelectedOptions.RosterFullSchedule[i].CarClassIds.Count; j++)
                    {
                        carClassIds.Add(_userSelectedOptions.RosterFullSchedule[i].CarClassIds[j]);
                    }
                    break;
                }
            }

            var rand = new Random();
            var split = maxDrivers / carClassIds.Count;

            for (var i = 0; i < carClassIds.Count; i++)
            {
                for (var j = 0; j < split; j++)
                {
                    var d = new Drivers();

                    var num = rand.Next(1, 20);
                    var randIndex = rand.Next(0, names.Count);

                    d.RowIndex = carNum;
                    carNum++;
                    d.DriverName = $"{names[randIndex]}";
                    var design = $"{num},{designs[randIndex]}";
                    names.RemoveAt(randIndex);
                    designs.RemoveAt(randIndex);
                    d.CarNumber = carNum.ToString();

                    //asign random cars to proper classes
                    for (var k = 0; k < cc.Length; k++)
                    {
                        if (cc[k].CarClassId == carClassIds[i])
                        {
                            if (cc[k].CarsInClass.Length == 1)
                            {
                                d.CarId = cc[k].CarsInClass[0].CarId;
                                d.CarPath = cc[k].CarsInClass[0].CarDirpath;
                            }
                            else
                            {
                                var pickOne = rand.Next(0, cc[k].CarsInClass.Length);
                                d.CarId = cc[k].CarsInClass[pickOne].CarId;
                                d.CarPath = cc[k].CarsInClass[pickOne].CarDirpath;
                            }
                        }
                    }

                    d.CarClassId = carClassIds[i];

                    d.Id = Guid.NewGuid().ToString();

                    d.CarDesign = design;
                    d.HelmetDesign = design;
                    d.SuitDesign = design;
                    d.NumberDesign = "0,0,ffffff,AAAAAA,000000";
                    d.DisableCarDecals = false;

                    var s1 = rand.Next(2, 221);
                    var s2 = rand.Next(2, 221);

                    d.Sponsor1 = s1;
                    d.Sponsor2 = s2;

                    d = isRosterButton == 1 || _userSelectedOptions.UseRosterTabAtt ? AttributesFromRanges(d, rand) : DriverAttributes(d, rand);

                    dr.Drivers.Add(d);
                }
            }

            var folderPath = Path.Combine(_userSelectedOptions.RosterFolderPath, rosterName);
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, "roster.json");
            _jsonService.Save(filePath, dr);

            return dr;
        }

        private int MaxDrivers(int isRosterButton)
        {
            var maxDrivers = 20;

            if (isRosterButton == 0)
            {
                var sIndex = _userSelectedOptions.SeasonSeriesIndex;
                var sSeriesId = _userSelectedOptions.FullSchedule[sIndex].SeriesId;

                if (_userSelectedOptions.CustCarCountSeason)
                {
                    maxDrivers = _userSelectedOptions.CustCarSeasonCountValue;
                }
                else
                {
                    maxDrivers = _userSelectedOptions.SeriesDetails.FirstOrDefault(id => id.SeriesId == sSeriesId).MaxStarters;
                }
            }
            else if (isRosterButton == 1)
            {
                var rIndex = _userSelectedOptions.RosterSeriesIndex;
                var rSeriesId = _userSelectedOptions.FullSchedule[rIndex].SeriesId;

                if (_userSelectedOptions.CustCarCountRoster)
                {
                    maxDrivers = _userSelectedOptions.CustCarRosterCountValue;
                }
                else
                {
                    maxDrivers = _userSelectedOptions.SeriesDetails.FirstOrDefault(id => id.SeriesId == rSeriesId).MaxStarters;
                }
            }

                return maxDrivers;
        }

        private Drivers DriverAttributes(Drivers d, Random rand)
        {
            var min = _userSelectedOptions.AiMin;
            var max = _userSelectedOptions.AiMax;
            var total = ((min + max) / 2) * 2;

            if (total < 50)
            {
                total = 50;
            }

            var a1 = 0;
            var a2 = 0;
            var a3 = 0;

            var balance = rand.Next(3, 6);

            for (var i = 0; i < total; i++)
            {
                var choice = rand.Next(balance);

                if (choice < 1)
                {
                    a1++;
                }
                else if (choice < 2)
                {
                    a2++;
                }
                else
                {
                    if (a3 > 99)
                    {
                        if (a1 > 99)
                        {
                            a2++;
                            continue;
                        }
                        a1++;
                        continue;
                    }
                    a3++;
                }
            }

            var aos = new List<int>() { a1, a2, a3 };
            aos = aos.OrderBy(x => rand.Next()).ToList();

            d.DriverAggression = aos[0];
            d.DriverOptimism = aos[1];
            d.DriverSmoothness = aos[2];

            //set pit skills
            var psTotal = Convert.ToInt32(((min + max) / 2) * 1.33);
            if (psTotal < 40)
            {
                psTotal = 40;
            }
            else if (psTotal > 160)
            {
                psTotal = 160;
            }

            var psBalance = rand.Next(3, 5);
            var p1 = 0;
            var p2 = 0;

            for (var i = 0; i < psTotal; i++)
            {
                var choice = rand.Next(balance);

                if (choice < 2)
                {
                    if (p1 > 99) { p2++; continue; }
                    p1++;
                }
                else
                {
                    if (p2 > 99) { p1++; continue; }
                    p2++;
                }
            }

            var ps = new List<int>() { p1, p2 };
            ps = ps.OrderBy(x => rand.Next()).ToList();

            d.PitCrewSkill = ps[0];
            d.StrategyRiskiness = ps[1];

            //set relative and age skills
            d.DriverSkill = rand.Next(1, 101);
            d.DriverAge = rand.Next(18, 70);

            return d;
        }

        private Drivers AttributesFromRanges(Drivers d, Random rand)
        {
            d.DriverSkill = rand.Next(_userSelectedOptions.RelateiveSkillMin, _userSelectedOptions.RelativeSkillMax + 1);
            d.DriverAggression = rand.Next(_userSelectedOptions.AggressionMin, _userSelectedOptions.AggressionMax + 1);
            d.DriverOptimism = rand.Next(_userSelectedOptions.OptimismMin, _userSelectedOptions.OptimismMax + 1);
            d.DriverSmoothness = rand.Next(_userSelectedOptions.SmoothnessMin, _userSelectedOptions.SmoothnessMax + 1);
            d.DriverAge = rand.Next(_userSelectedOptions.AgeMin, _userSelectedOptions.AgeMax + 1);
            d.PitCrewSkill = rand.Next(_userSelectedOptions.PitCrewMin, _userSelectedOptions.PitCrewMax + 1);
            d.StrategyRiskiness = rand.Next(_userSelectedOptions.PitStratMin, _userSelectedOptions.PitStratMax + 1);

            return d;
        }
    }
}
