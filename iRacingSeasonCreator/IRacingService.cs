using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aydsko.iRacingData;
using iRacingSeasonCreator.ScheduleClasses;
using Microsoft.Extensions.DependencyInjection;

namespace iRacingSeasonCreator
{
    public class IRacingService
    {
        private readonly IDataClient dataClient;

        public IRacingService(IDataClient dataClient)
        {
            this.dataClient = dataClient;
        }

        public static IRacingService IRacingServiceLogin { get; set; }
        public Task<IRacingService> GetCurrentSeason { get; set; }
        public Aydsko.iRacingData.Common.DataResponse<Aydsko.iRacingData.Series.SeasonSeries[]> SeasonSeries { get; set; }
        public Aydsko.iRacingData.Common.DataResponse<Aydsko.iRacingData.Cars.CarInfo[]> CarInfo { get; set; }
        public static List<string> CurrentSeries { get; set; }

        public static async Task<bool> LoginWindow(string userName, string password)
        {
            var services = new ServiceCollection();
            services.AddIRacingDataApi(options =>
            {
                options.Username = userName;
                options.Password = password;
            });

            var provider = services.BuildServiceProvider();
            var appScope = provider.CreateScope();
            var iRacingClient = provider.GetRequiredService<IDataClient>();

            IRacingServiceLogin = new IRacingService(iRacingClient);

            try
            {
                var isLoggedIn = await IRacingServiceLogin.dataClient.GetMyInfoAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task SetCurrentSeason()
        {
            SeasonSeries = await dataClient.GetSeasonsAsync(true, default);
        }

        public async Task SetCars()
        {
            CarInfo = await dataClient.GetCarsAsync();
        }

        public async Task<List<string>> GetAllSeries()
        {
            var seasonSchedule = SeasonSeries.Data;
            var list = new List<string>();

            foreach (var item in seasonSchedule)
            {
                list.Add(item.Schedules[0].SeriesName);
            }

            return list;
        }

        public async Task<List<string>> PopulateCarComboBox()
        {
            var seasonSchedule = SeasonSeries.Data;
            var carIds = new List<int>();            

            for (var i = 0; i < seasonSchedule.Length; i++)
            {
                if (seasonSchedule[i].Schedules[0].SeriesName == MainForm.SeriesName)
                {
                    for (var j = 0; j < seasonSchedule[i].Schedules[0].CarRestrictions.Length; j++)
                    {
                        carIds.Add(seasonSchedule[i].Schedules[0].CarRestrictions[j].CarId);
                    }
                }
            }
            
            var carsInfo = CarInfo.Data;
            var carNames = new List<string>();
            for (var i = 0; i < carIds.Count; i++)
            {
                for (var j = 0; j < carsInfo.Length; j++)
                {
                    if (carIds[i] == carsInfo[j].CarId)
                    {
                        carNames.Add(carsInfo[j].CarName);
                    }
                }
            }

            return carNames;
        }

        public async Task SeasonBuilder(string seasonName)
        {
            var s = new SeasonSchedule();
            var client = await dataClient.GetSeasonsAsync(true, default);
            var cars = await dataClient.GetCarsAsync();

            for (var i = 0; i < client.Data.Length; i++)
            {
                var c = client.Data[i];

                if (c.SeasonName == seasonName)
                {
                    s.AiCarClassId = c.CarClassIds[0];
                    s.LuckyDog = c.LuckyDog;
                }
            }
        }

    }
}
