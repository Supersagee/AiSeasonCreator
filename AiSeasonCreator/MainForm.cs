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

            SetRedLocations();

            minSkillBox.Text = aiMinTrackBar.Value.ToString();
            maxSkillBox.Text = aiMaxTrackBar.Value.ToString();

            string savedFolderPath = LoadSelectedFolderPath();
            if (!string.IsNullOrEmpty(savedFolderPath) && Directory.Exists(savedFolderPath))
            {
                filePathTextBox.Text = savedFolderPath;
            }

            LoadJsonFiles();

            foreach (var item in IRacingService.GetAllSeries())
            {
                seriesListCombo.Items.Add(item);
            }
        }

        private async void createSeason_Click(object sender, EventArgs e)
        {
            VariableSetter();

            if (IsFormBlank())
            {
                incompleteFormLabel.Text = "Please complete the form.";
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

            SeasonCreationPrompt();
        }

        private static void LoadJsonFiles()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var carClassesFilePath = Path.Combine(basePath, "JsonFiles", "carClassesJson.json");
            CarClasses = JsonSerializer.Deserialize<JsonClasses.CarClasses.CarClasses[]>(File.ReadAllText(carClassesFilePath));

            var carsFilePath = Path.Combine(basePath, "JsonFiles", "carsJson.json");
            CarDetails = JsonSerializer.Deserialize<CarDetails[]>(File.ReadAllText(carsFilePath));

            var scheduleFilePath = Path.Combine(basePath, "JsonFiles", "seasonScheduleJson.json");
            FullSchedule = JsonSerializer.Deserialize<FullSchedule[]>(File.ReadAllText(scheduleFilePath));

            var seriesFilePath = Path.Combine(basePath, "JsonFiles", "seriesListJson.json");
            SeriesDetails = JsonSerializer.Deserialize<SeriesDetails[]>(File.ReadAllText(seriesFilePath));

            var tracksFilePath = Path.Combine(basePath, "JsonFiles", "tracksJson.json");
            TrackDetails = JsonSerializer.Deserialize<TrackDetails[]>(File.ReadAllText(tracksFilePath));
        }

        private bool IsFormBlank()
        {
            var blank = false;
            var red = Color.IndianRed;

            if (SeasonName == "")
            {
                seasonNamePanel.BackColor = red;
                blank = true;
            }
            else
            {
                seasonNamePanel.BackColor = SystemColors.Control;
            }

            if (SeriesName == "")
            {
                blank = true;
                seriesPanel.BackColor = red;
            }
            else
            {
                seriesPanel.BackColor = SystemColors.Control;
            }

            if (CarName == "")
            {
                blank = true;
                carPanel.BackColor = red;
            }
            else
            {
                carPanel.BackColor = SystemColors.Control;
            }

            if (FilePath == "Double click to add folder path. iRacing\\aiseasons")
            {
                blank = true;
                folderPathPanel.BackColor = red;
            }
            else
            {
                folderPathPanel.BackColor = SystemColors.Control;
            }

            return blank;
        }

        private static void SeasonCreationPrompt()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Season created successfully!");
            builder.AppendLine("");

            if (IRacingService.CarClassIds.Count > 1)
            {
                builder.AppendLine("----------------------------------------------------------------------------------------");
                builder.AppendLine("");
                builder.AppendLine(@$"A Multi-Class season was created. Before starting the season, in iRacing, go to ""Opponent Rosters"" under the AI Racing tab and click on the {SeasonName} roster. Click ""Save Edits"" at the bottom right to set AI driver attributes.");
                builder.AppendLine("");
            }

            if (NotAvailableTracks.Any())
            {
                builder.AppendLine("----------------------------------------------------------------------------------------");
                builder.AppendLine("");
                builder.AppendLine("The following tracks were not included in the season as they are not available for AI racing:");
                builder.AppendLine("");

                foreach (var track in NotAvailableTracks)
                {
                    builder.AppendLine($"-{track.ToString()}");
                }

                NotAvailableTracks.Clear();
            }

            MessageBox.Show($"{builder}");
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
            QualiAlone = qualiAloneCheckBox.Checked;
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

        private void filePathTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private async void seriesListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesName = seriesListCombo.SelectedItem.ToString();
            var carList = IRacingService.PopulateCarComboBox();
            IRacingService.CreateCarSettings();
            carListCombo.Items.Clear();

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

        private string LoadSelectedFolderPath()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");
            string configFilePath = Path.Combine(appSpecificFolderPath, "AiSeasonCreatorConfig.txt");

            if (File.Exists(configFilePath))
            {
                return File.ReadAllText(configFilePath);
            }

            return null;
        }

        private void aiMinTrackBar_Scroll(object sender, EventArgs e)
        {
            minSkillBox.Text = aiMinTrackBar.Value.ToString();

            if (aiMinTrackBar.Value > aiMaxTrackBar.Value)
            {
                aiMaxTrackBar.Value = aiMinTrackBar.Value;
                maxSkillBox.Text = aiMaxTrackBar.Value.ToString();
            }
        }

        private void aiMaxTrackBar_Scroll(object sender, EventArgs e)
        {
            maxSkillBox.Text = aiMaxTrackBar.Value.ToString();

            if (aiMaxTrackBar.Value < aiMinTrackBar.Value)
            {
                aiMinTrackBar.Value = aiMaxTrackBar.Value;
                minSkillBox.Text = aiMinTrackBar.Value.ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
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
        public static bool QualiAlone { get; set; }
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