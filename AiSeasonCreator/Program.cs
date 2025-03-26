using AiSeasonCreator.FormOptions;
using AiSeasonCreator.Mappers;
using AiSeasonCreator.ScheduleClasses;
using AiSeasonCreator.Roster;
using AiSeasonCreator.Repos;
using AiSeasonCreator.Services;
using AiSeasonCreator.Views;
using Microsoft.Extensions.DependencyInjection;
using AiSeasonCreator.Presenters;
using AiSeasonCreator.Data;

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

            //services.AddTransient<IMapper<List<CarSettings>>, CarSettingsMapper>();
            //services.AddTransient<IMapper<List<Events>>, EventsMapper>();
            //services.AddTransient<IMapper<GuidedParameters>, GuidedParametersMapper>();
            //services.AddTransient<IMapper<List<Keyframes>>, KeyframesMapper>();
            //services.AddTransient<IMapper<PaceCar>, PaceCarMapper>();
            //services.AddTransient<IMapper<SeasonSchedule>, SeasonScheduleMapper>();
            //services.AddTransient<IMapper<TrackState>, TrackStateMapper>();
            //services.AddTransient<IMapper<Weather>, WeatherMapper>();
            //services.AddTransient<IMapper<DriverRoster>, RosterMapper>();

            //services.AddSingleton<UserSelectedOptions>();
            //services.AddSingleton<SeasonService>();
            //services.AddSingleton<IJsonRepo, JsonRepo>();

            //services.AddTransient<SeasonBuilder<SeasonSchedule>>();

            //services.AddSingleton<MainForm>();
            //services.AddTransient<TrackSelectionForm>();
            //var serviceProvider = services.BuildServiceProvider();

            //ApplicationConfiguration.Initialize();
            //Application.Run(serviceProvider.GetRequiredService<MainForm>());

            //***************************************************************************************

            services.AddSingleton<IJsonRepo, JsonRepo>();
            services.AddSingleton<LoadedData>();
            services.AddSingleton<ISeasonService, Services.SeasonService>();
            services.AddSingleton<ISeasonPresenter, SeasonPresenter>();

            // Register SeasonForm as itself
            services.AddSingleton<SeasonForm>();

            // Map ISeasonView to the same SeasonForm instance
            services.AddSingleton<ISeasonView>(provider => provider.GetRequiredService<SeasonForm>());

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Resolve SeasonForm and ISeasonPresenter
            var seasonForm = serviceProvider.GetRequiredService<SeasonForm>();
            var seasonPresenter = serviceProvider.GetRequiredService<ISeasonPresenter>();

            // Assign the presenter to the SeasonForm via a property (make sure SeasonForm has a public property for this)
            seasonForm.Presenter = seasonPresenter;

            Application.Run(seasonForm);
        }
    }
}