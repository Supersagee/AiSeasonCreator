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

        public async Task<List<string>> GetAllSeries()
        {
            var season = await dataClient.GetSeasonsAsync(true, default);

            var seasonSchedule = season.Data;

            var list = new List<string>();

            foreach (var item in seasonSchedule)
            {
                list.Add(item.Schedules[0].SeriesName);
            }

            return list;
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
                    s.LuckyDog = c.LuckyDog;
                }
            }
        }

    }
}
