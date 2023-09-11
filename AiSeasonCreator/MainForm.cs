using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using AiSeasonCreator.ScheduleClasses;
using System.Text.Json;
using System.Reflection;
using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using AiSeasonCreator.DefaultUserSettings;
using ReaLTaiizor.Controls;
using System.Diagnostics;

namespace AiSeasonCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var updater = new Updater();
            updater.CheckForUpdates();

            SetTheme();

            SetRedLocations();

            versionLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            var seasonsAndSeries = SelectSeason();
            foreach (var season in seasonsAndSeries)
            {
                seasonComboBox.Items.Add(season.Season);
            }

            var cs = seasonsAndSeries[0];
            LoadJsonFiles(cs.Season, cs.Series, true);

            seasonComboBox.Text = seasonComboBox.Items[0].ToString();

            foreach (var series in IRacingService.GetAllSeries())
            {
                seriesListCombo.Items.Add(series);
            }

            LoadUserDefaultSettings();
        }

        private async void createSeason_Click(object sender, EventArgs e)
        {
            VariableSetter();

            aiMaxTrackBar.Select();

            if (IsFormBlank())
            {
                incompleteFormLabel.ForeColor = Color.FromArgb(255, 128, 187, 0);
                incompleteFormLabel.Text = "Please complete the form";
                return;
            }

            incompleteFormLabel.Text = "";

            try
            {
                if (selectTracksCheckBox.Checked)
                {
                    var trackSelection = new TrackSelectionForm();
                    trackSelection.ShowDialog();
                }

                var sb = IRacingService.SeasonBuilder();
                string filePath = $@"{FilePath}\{SeasonName}.json";
                await IRacingService.SaveSeasonScheduleToJson(sb, filePath);
            }
            catch
            {
                MessageBox.Show("ATTENTION: Unable to create season. Please try again.");
                return;
            }

            var completion = new CompletionForm("season", NotAvailableTracks);
            completion.ShowDialog();
        }

        private List<SeasonsAndSeries> SelectSeason()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var seasonProp = Path.Combine(basePath, "JsonFiles", "Schedules");
            var seasonFiles = Directory.GetFiles(seasonProp);

            var seriesProp = Path.Combine(basePath, "JsonFiles", "SeriesDetails");
            var seriesFiles = Directory.GetFiles(seriesProp);

            var sAs = new List<SeasonsAndSeries>();
            for (int i = 0; i < seasonFiles.Length; i++)
            {
                var sasLoop = new SeasonsAndSeries();

                sasLoop.Season = Path.GetFileNameWithoutExtension(seasonFiles[i]);
                sasLoop.Series = Path.GetFileNameWithoutExtension(seriesFiles[i]);

                sAs.Add(sasLoop);
            }
            sAs.Reverse();

            return sAs;
        }

        private static void LoadJsonFiles(string season, string series, bool isPageLoad)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (isPageLoad)
            {
                var carClassesFilePath = Path.Combine(basePath, "JsonFiles", "carClassesJson.json");
                CarClasses = JsonSerializer.Deserialize<JsonClasses.CarClasses.CarClasses[]>(File.ReadAllText(carClassesFilePath));

                var carsFilePath = Path.Combine(basePath, "JsonFiles", "carsJson.json");
                CarDetails = JsonSerializer.Deserialize<CarDetails[]>(File.ReadAllText(carsFilePath));

                var tracksFilePath = Path.Combine(basePath, "JsonFiles", "tracksJson.json");
                TrackDetails = JsonSerializer.Deserialize<TrackDetails[]>(File.ReadAllText(tracksFilePath));
            }

            var scheduleFilePath = Path.Combine(basePath, "JsonFiles", "Schedules", $"{season}.json");
            FullSchedule = JsonSerializer.Deserialize<FullSchedule[]>(File.ReadAllText(scheduleFilePath));

            var seriesFilePath = Path.Combine(basePath, "JsonFiles", "SeriesDetails", $"{series}.json");
            SeriesDetails = JsonSerializer.Deserialize<SeriesDetails[]>(File.ReadAllText(seriesFilePath));
        }

        private bool IsFormBlank()
        {
            var blank = false;
            var empty = Color.FromArgb(255, 128, 187, 0);
            var filled = Color.Transparent;

            if (SeasonName == "")
            {
                seasonNamePanel.BackColor = empty;
                blank = true;
            }
            else
            {
                seasonNamePanel.BackColor = filled;
            }

            if (SeriesName == "")
            {
                blank = true;
                seriesPanel.BackColor = empty;
            }
            else
            {
                seriesPanel.BackColor = filled;
            }

            if (CarName == "")
            {
                blank = true;
                carPanel.BackColor = empty;
            }
            else
            {
                carPanel.BackColor = filled;
            }

            if (FilePath == "Click to add folder path. iRacing\aiseasons")
            {
                blank = true;
                folderPathPanel.BackColor = empty;
            }
            else
            {
                folderPathPanel.BackColor = filled;
            }

            return blank;
        }

        private void SetTheme()
        {
            var t = Color.Transparent;

            seasonNameLabel.BackColor = t;
            seasonLabel.BackColor = t;
            seriesListLabel.BackColor = t;
            carListLabel.BackColor = t;
            filePathLabel.BackColor = t;
            closeButton.BackColor = t;
            minimizeButton.BackColor = t;
            forumLinkLabel.BackColor = t;
            versionLabel.BackColor = t;
        }

        private void VariableSetter()
        {
            SeasonName = seasonNameTextBox.Text;
            SeriesName = seriesListCombo.Text;
            CarName = carListCombo.Text;
            AiMin = aiMinTrackBar.Value;
            AiMax = aiMaxTrackBar.Value;
            FilePath = filePathTextBox.Text;
            DisableDamage = disableCarDamageCheckBox.Checked;
            AiAvoids = aiAvoidPlayerCheckBox.Checked;
            ConsistentWeather = consistentWeatherCheckBox.Checked;
            AfternoonRaces = afternoonRacesCheckBox.Checked;
            QualiAlone = qualiAloneCheckBox.Checked;
            ShortParade = shortParadeCheckBox.Checked;
        }

        private void SetRedLocations()
        {
            seasonNamePanel.Location = new Point(seasonNameTextBox.Location.X - 2, seasonNameTextBox.Location.Y - 2);
            seasonNamePanel.Size = new Size(seasonNameTextBox.Size.Width + 4, seasonNameTextBox.Size.Height + 4);

            seriesPanel.Location = new Point(seriesListCombo.Location.X - 2, seriesListCombo.Location.Y - 2);
            seriesPanel.Size = new Size(seriesListCombo.Size.Width + 4, seriesListCombo.Size.Height + 4);

            carPanel.Location = new Point(carListCombo.Location.X - 2, carListCombo.Location.Y - 2);
            carPanel.Size = new Size(carListCombo.Size.Width + 4, carListCombo.Size.Height + 4);

            folderPathPanel.Location = new Point(filePathTextBox.Location.X - 2, filePathTextBox.Location.Y - 2);
            folderPathPanel.Size = new Size(filePathTextBox.Size.Width + 4, filePathTextBox.Size.Height + 4);
        }

        private void filePathTextBox_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    filePathTextBox.Text = folderBrowserDialog.SelectedPath;
                    SaveSelectedFolderPath(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void seasonComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            seriesListCombo.Items.Clear();
            seriesListCombo.Text = "";
            seriesListCombo.Visible = false;
            seriesListCombo.Visible = true;

            carListCombo.Items.Clear();
            carListCombo.Text = "";
            carListCombo.Visible = false;
            carListCombo.Visible = true;

            var selectedSeason = SelectSeason();

            var i = seasonComboBox.SelectedIndex;
            var season = selectedSeason[i].Season;
            var series = selectedSeason[i].Series;

            LoadJsonFiles(season, series, false);

            foreach (var item in IRacingService.GetAllSeries())
            {
                seriesListCombo.Items.Add(item);
            }
        }

        private void seriesListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesName = seriesListCombo.SelectedItem.ToString();
            var carList = IRacingService.PopulateCarComboBox();
            IRacingService.CreateCarSettings();
            carListCombo.Items.Clear();
            carListCombo.Text = "";
            carListCombo.Visible = false;
            carListCombo.Visible = true;

            foreach (var car in carList)
            {
                carListCombo.Items.Add(car);
            }

            if (carList.Count == 1)
            {
                carListCombo.Text = carListCombo.Items[0].ToString();
            }
        }

        private void SaveSelectedFolderPath(string folderPath)
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");

            if (!Directory.Exists(appSpecificFolderPath))
            {
                Directory.CreateDirectory(appSpecificFolderPath);
            }

            string configFilePath = Path.Combine(appSpecificFolderPath, "AiSeasonCreatorConfig.txt");
            File.WriteAllText(configFilePath, folderPath);
        }
        private void SaveUserDefaultSettings()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");

            if (!Directory.Exists(appSpecificFolderPath))
            {
                Directory.CreateDirectory(appSpecificFolderPath);
            }

            var ud = new UserDefaultSettings();

            ud.SettingsVersion = 1;
            ud.DisableCarDamage = disableCarDamageCheckBox.Checked;
            ud.AiAvoidsPlayer = aiAvoidPlayerCheckBox.Checked;
            ud.ConsistentWeather = consistentWeatherCheckBox.Checked;
            ud.AfternoonRaces = afternoonRacesCheckBox.Checked;
            ud.QualifyAlone = qualiAloneCheckBox.Checked;
            ud.SelectTracks = selectTracksCheckBox.Checked;
            ud.ShortParade = shortParadeCheckBox.Checked;
            ud.AiMinSkill = aiMinTrackBar.Value;
            ud.AiMaxSkill = aiMaxTrackBar.Value;
            ud.WindowLocation = new WindowLocation
            {
                X = Location.X,
                Y = Location.Y
            };

            string configFilePath = Path.Combine(appSpecificFolderPath, "UserDefaultSettings.json");
            string jsonSettings = JsonSerializer.Serialize(ud, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFilePath, jsonSettings);
        }
        private void LoadUserDefaultSettings()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");
            string udPath = Path.Combine(appSpecificFolderPath, "UserDefaultSettings.json");
            string userFolderPath = Path.Combine(appSpecificFolderPath, "AiSeasonCreatorConfig.txt");

            if (File.Exists(udPath))
            {
                var ud = JsonSerializer.Deserialize<UserDefaultSettings>(File.ReadAllText(udPath));

                disableCarDamageCheckBox.Checked = ud.DisableCarDamage;
                aiAvoidPlayerCheckBox.Checked = ud.AiAvoidsPlayer;
                consistentWeatherCheckBox.Checked = ud.ConsistentWeather;
                afternoonRacesCheckBox.Checked = ud.AfternoonRaces;
                qualiAloneCheckBox.Checked = ud.QualifyAlone;
                selectTracksCheckBox.Checked = ud.SelectTracks;
                shortParadeCheckBox.Checked = ud.ShortParade;
                aiMinTrackBar.Value = ud.AiMinSkill;
                aiMaxTrackBar.Value = ud.AiMaxSkill;
                Location = new Point(ud.WindowLocation.X, ud.WindowLocation.Y);
            }

            if (File.Exists(userFolderPath))
            {
                filePathTextBox.Text = File.ReadAllText(userFolderPath);
            }

            aiSkillBox.Text = $"{aiMinTrackBar.Value}%-{aiMaxTrackBar.Value}%";
        }

        private void aiMinTrackBar_Scroll(object sender, EventArgs e)
        {
            aiSkillBox.Text = $"{aiMinTrackBar.Value}%-{aiMaxTrackBar.Value}%";

            if (aiMinTrackBar.Value > aiMaxTrackBar.Value)
            {
                aiMaxTrackBar.Value = aiMinTrackBar.Value;
                aiSkillBox.Text = $"{aiMinTrackBar.Value}%-{aiMaxTrackBar.Value}%";
            }
        }

        private void aiMaxTrackBar_Scroll(object sender, EventArgs e)
        {
            aiSkillBox.Text = $"{aiMinTrackBar.Value}%-{aiMaxTrackBar.Value}%";

            if (aiMaxTrackBar.Value < aiMinTrackBar.Value)
            {
                aiMinTrackBar.Value = aiMaxTrackBar.Value;
                aiSkillBox.Text = $"{aiMinTrackBar.Value}%-{aiMaxTrackBar.Value}%";
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void forumLinkLabel_Click(object sender, EventArgs e)
        {
            var url = "https://forums.iracing.com/discussion/40203/aiseasoncreator-make-ai-seasons-based-on-the-the-series-schedules-on-the-fly";

            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the link: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserDefaultSettings();
        }

        public class SeasonsAndSeries
        {
            public string Season { get; set; }
            public string Series { get; set; }
        }

        public static string? SeasonName { get; set; }
        public static string? SeriesName { get; set; }
        public static string? CarName { get; set; }
        public static int? AiMin { get; set; }
        public static int? AiMax { get; set; }
        public static string? FilePath { get; set; }
        public static bool DisableDamage { get; set; }
        public static bool AiAvoids { get; set; }
        public static bool ConsistentWeather { get; set; }
        public static bool AfternoonRaces { get; set; }
        public static bool QualiAlone { get; set; }
        public static bool ShortParade { get; set; }
        public static int SeasonSeriesIndex { get; set; }
        public static List<int>? UnselectedTracks { get; set; }
        public static JsonClasses.CarClasses.CarClasses[] CarClasses { get; set; }
        public static CarDetails[] CarDetails { get; set; }
        public static FullSchedule[] FullSchedule { get; set; }
        public static SeriesDetails[] SeriesDetails { get; set; }
        public static TrackDetails[] TrackDetails { get; set; }
        public static List<string> NotAvailableTracks { get; set; } = new List<string>();
    }
}