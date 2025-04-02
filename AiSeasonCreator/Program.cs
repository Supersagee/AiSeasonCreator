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
            services.AddTransient<SeasonBuilder<SeasonSchedule>>();

            services.AddSingleton<IJsonRepo, JsonRepo>();
            services.AddSingleton<AppSettings>();
            services.AddSingleton<LoadedData>();

            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<ISettingsPresenter, SettingsPresenter>();
            services.AddSingleton<SettingsForm>();
            services.AddSingleton<ISettingsView>(provider => provider.GetRequiredService<SettingsForm>());

            services.AddSingleton<IAboutService, AboutService>();
            services.AddSingleton<IAboutPresenter, AboutPresenter>();
            services.AddSingleton<AboutForm>();
            services.AddSingleton<IAboutView>(provider => provider.GetRequiredService<AboutForm>());

            services.AddSingleton<IRosterService, RosterService>();
            services.AddSingleton<IRosterPresenter, RosterPresenter>();
            services.AddSingleton<RosterForm>();
            services.AddSingleton<IRosterView>(provider => provider.GetRequiredService<RosterForm>());

            services.AddSingleton<ISeasonService, Services.SeasonService>();
            services.AddSingleton<ISeasonPresenter, SeasonPresenter>();
            services.AddSingleton<SeasonForm>();
            services.AddSingleton<ISeasonView>(provider => provider.GetRequiredService<SeasonForm>());
            

            services.AddSingleton<Views.MainForm>();
            services.AddSingleton<IMainView>(provider => provider.GetRequiredService<Views.MainForm>());

            ApplicationConfiguration.Initialize();

            var serviceProvider = services.BuildServiceProvider();

            var seasonForm = serviceProvider.GetRequiredService<SeasonForm>();
            seasonForm.Presenter = serviceProvider.GetRequiredService<ISeasonPresenter>();

            var rosterForm = serviceProvider.GetRequiredService<RosterForm>();
            rosterForm.Presenter = serviceProvider.GetRequiredService<IRosterPresenter>();

            var settingsForm = serviceProvider.GetRequiredService<SettingsForm>();
            settingsForm.Presenter = serviceProvider.GetRequiredService<ISettingsPresenter>();

            var aboutForm = serviceProvider.GetRequiredService<AboutForm>();
            aboutForm.Presenter = serviceProvider.GetRequiredService<IAboutPresenter>();

            var mainForm = serviceProvider.GetRequiredService<Views.MainForm>();
            //var seasonForm = serviceProvider.GetRequiredService<Views.SeasonForm>();

            Application.Run(mainForm);
            //Application.Run(seasonForm);


        }
    }
}