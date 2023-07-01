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

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var updater = new Updater();
            updater.CheckForUpdates();

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
            Cursor = Cursors.WaitCursor;

            SeasonName = seasonNameTextBox.Text;
            SeriesName = seriesListCombo.Text;
            CarName = carListCombo.Text;
            AiMin = aiMinTrackBar.Value;
            AiMax = aiMaxTrackBar.Value;
            FilePath = filePathTextBox.Text;
            DisableDamage = disableCarDamageCheckBox.Checked;
            AiAvoids = aiAvoidPlayerCheckBox.Checked;
            ConsistentWeather = consistentWeatherCheckBox.Checked;

            try
            {
                if (BlankFormChecker() == false)
                {
                    MessageBox.Show($"Please finish filling out the form before attempting to create a season. Make sure the minimum AI skill is less than or equal to the maximum.");
                    return;
                }

                var ss = IRacingService.SeasonBuilder();
                string filePath = $@"{FilePath}\{SeasonName}.json";
                await IRacingService.SaveSeasonScheduleToJson(ss, filePath);

                if (NotAvailableTracks.Any())
                {
                    if (IRacingService.CarClassIds.Count > 1)
                    {
                        MessageBox.Show(@$"A Multi-Class season was created. Before starting the season, in iRacing, go to ""Opponent Rosters"" under the AI Racing tab and click on the {SeasonName} roster. Click ""Save Edits"" at the bottom right to set AI driver attributes. ");
                    }
                    NotAllowedTracksMessage();
                    return;
                }
                else if (IRacingService.CarClassIds.Count > 1)
                {
                    MessageBox.Show(@$"A Multi-Class season was created. Before starting the season, in iRacing, go to ""Opponent Rosters"" under the AI Racing tab and click on the '{SeasonName}' roster. Click ""Save Edits"" at the bottom right to set AI driver attributes. Restart iRacing if it is currently open.");
                    return;
                }
                else
                {
                    MessageBox.Show("Season created successfully! Restart iRacing if it is currently open.");
                }
            }
            catch
            {
                MessageBox.Show("ATTENTION: Unable to create season. Please try again.");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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

        private static bool BlankFormChecker()
        {
            if (SeasonName == "" || SeasonName == null)
                return false;
            if (SeriesName == "" || SeriesName == null)
                return false;
            if (CarName == "" || CarName == null)
                return false;
            if (FilePath == @"Double click to add folder path. iRacing\aiseasons" || FilePath == null)
                return false;
            if (AiMin > AiMax)
                return false;

            return true;
        }

        private static void NotAllowedTracksMessage()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Season created successfully!");
            builder.AppendLine("");
            builder.AppendLine("The following tracks were not included in the season as they are not available for AI racing:");
            builder.AppendLine("");
            foreach (var track in NotAvailableTracks)
            {
                builder.Append($"-{track.ToString()}").AppendLine();
            }
            MessageBox.Show($"{builder}");

            NotAvailableTracks.Clear();
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
        }

        private void aiMaxTrackBar_Scroll(object sender, EventArgs e)
        {
            maxSkillBox.Text = aiMaxTrackBar.Value.ToString();
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
        public static int SeasonSeriesIndex { get; set; }
        public static JsonClasses.CarClasses.CarClasses[] CarClasses { get; set; }
        public static CarDetails[] CarDetails { get; set; } 
        public static FullSchedule[] FullSchedule { get; set; }
        public static SeriesDetails[] SeriesDetails { get; set; }
        public static TrackDetails[] TrackDetails { get; set; }
        public static List<string> NotAvailableTracks { get; set; } = new List<string>();
    }
}