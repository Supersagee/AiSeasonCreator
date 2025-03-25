using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Interfaces;
using AiSeasonCreator.Mappers;
using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.Roster;
using Microsoft.Extensions.DependencyInjection;

namespace AiSeasonCreator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();

            services.AddTransient<IMapper<List<CarSettings>>, CarSettingsMapper>();
            services.AddTransient<IMapper<List<Events>>, EventsMapper>();
            services.AddTransient<IMapper<GuidedParameters>, GuidedParametersMapper>();
            services.AddTransient<IMapper<List<Keyframes>>, KeyframesMapper>();
            services.AddTransient<IMapper<PaceCar>, PaceCarMapper>();
            services.AddTransient<IMapper<SeasonSchedule>, SeasonScheduleMapper>();
            services.AddTransient<IMapper<TrackState>, TrackStateMapper>();
            services.AddTransient<IMapper<Weather>, WeatherMapper>();
            services.AddTransient<IMapper<DriverRoster>, RosterMapper>();

            services.AddSingleton<UserSelectedOptions>();
            services.AddSingleton<SeasonService>();
            services.AddSingleton<IJsonRepo, JsonRepo>();

            services.AddTransient<SeasonBuilder<SeasonSchedule>>();

            services.AddSingleton<MainForm>();
            services.AddTransient<TrackSelectionForm>();
            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}