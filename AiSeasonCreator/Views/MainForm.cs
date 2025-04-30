using AiSeasonCreator.Data;
using AiSeasonCreator.DefaultUserSettings;
using AiSeasonCreator.Helpers;
using AiSeasonCreator.Repos;

namespace AiSeasonCreator.Views
{
    public partial class MainForm : Form, IMainView
    {
        private SeasonForm _seasonForm;
        private RosterForm _rosterForm;
        private AboutForm _aboutForm;
        private SettingsForm _settingsForm;
        private IJsonRepo _jsonRepo;
        private LoadedData _loadedData;
        private Form _selectedForm;
        public static ISeasonView staticSeasonForm { get; set; }

        public MainForm(
            SeasonForm seasonView,
            RosterForm rosterForm,
            AboutForm aboutForm,
            SettingsForm settingsView,
            IJsonRepo jsonRepo,
            LoadedData loadedData)
        {
            InitializeComponent();
            _seasonForm = seasonView;
            _rosterForm = rosterForm;
            _aboutForm = aboutForm;
            _settingsForm = settingsView;
            _jsonRepo = jsonRepo;
            _loadedData = loadedData;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var updater = new Updater();
            updater.CheckForUpdates();

            OpenChildForm(_settingsForm);
            OpenChildForm(_seasonForm);
            SelectedNavButton(seasonButton);
            var udl = _loadedData.UserDefaultSettings.WindowLocation;
            Location = new Point(udl.X, udl.Y);
            AreFolderPathsBad();
        }

        private void OpenChildForm(Form childForm)
        {
            if (_selectedForm != childForm)
            {
                childForm.TopLevel = false;
                mainPanel.Controls.Add(childForm);
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                mainPanel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
                _selectedForm = childForm;
                ClearNavButtons();
            }
        }

        private void seasonButton_Click(object sender, EventArgs e)
        {
            if (AreFolderPathsBad()) { return; }
            OpenChildForm(_seasonForm);
            SelectedNavButton(sender as Button);
        }

        private void rosterButton_Click(object sender, EventArgs e)
        {
            if (AreFolderPathsBad()) { return; }
            OpenChildForm(_rosterForm);
            SelectedNavButton(sender as Button);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_aboutForm);
            SelectedNavButton(sender as Button);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_settingsForm);
            SelectedNavButton(sender as Button);
        }

        private void SelectedNavButton(Button button)
        {
            button.BackColor = Color.FromArgb(142, 188, 0);
        }

        private void ClearNavButtons()
        {
            seasonButton.BackColor = Color.Transparent;
            rosterButton.BackColor = Color.Transparent;
            aboutButton.BackColor = Color.Transparent;
            settingsButton.BackColor = Color.Transparent;
        }

        private bool AreFolderPathsBad()
        {
            var sp = _settingsForm.SeasonFolderPath;
            var rp = _settingsForm.RosterFolderPath;

            if (!Directory.Exists(sp) || !Directory.Exists(rp))
            {
                OpenChildForm(_settingsForm);
                _settingsForm.SetFolderPathLabel = "Please select a folder for Seasons and Rosters";
                return true;
            }
            _settingsForm.SetFolderPathLabel = "";
            return false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var ud = _loadedData.UserDefaultSettings;

            ud.FolderLocations.SeasonsFolder = _settingsForm.SeasonFolderPath;
            ud.FolderLocations.RostersFolder = _settingsForm.RosterFolderPath;

            var udc = ud.CheckBoxesUserValues;
            udc.UseAdaptiveAi = _seasonForm.UseAdaptiveAi;
            udc.DisableCarDamage = _seasonForm.DisableDamage;
            udc.AiAvoidsPlayer = _seasonForm.AiAvoids;
            udc.StaticWeather = _seasonForm.StaticWeather;
            udc.AfternoonRaces = _seasonForm.AfternoonRaces;
            udc.NeverRain = _seasonForm.NeverRain;
            udc.QualifyAlone = _seasonForm.QualiAlone;
            udc.ShortParade = _seasonForm.ShortParade;

            ud.TrackBarUserValues.AiMinSkill = _seasonForm.AiMin;
            ud.TrackBarUserValues.AiMaxSkill = _seasonForm.AiMax;
            ud.ComboBoxesUserValues.AdaptiveAiSkillLevel = _seasonForm.AdaptiveAiDifficulty;

            ud.WindowLocation.X = Location.X;
            ud.WindowLocation.Y = Location.Y;

            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");

            if (!Directory.Exists(appSpecificFolderPath))
            {
                Directory.CreateDirectory(appSpecificFolderPath);
            }

            string configFilePath = Path.Combine(appSpecificFolderPath, "UserDefaultSettings.json");
            _jsonRepo.Save<UserDefaultSettings>(configFilePath, ud);
        }
    }
}
