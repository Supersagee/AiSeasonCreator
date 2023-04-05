using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using iRacingSeasonCreator.ScheduleClasses;
using iRacingSeasonCreator.JsonClasses.TrackDetails;
using System.Text.Json;

namespace iRacingSeasonCreator
{
    public partial class MainForm : Form
    {
        IRacingService irs;
        public MainForm()
        {
            InitializeComponent();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            minSkillBox.Text = aiMinTrackBar.Value.ToString();
            maxSkillBox.Text = aiMaxTrackBar.Value.ToString();

            var buildJson = new StringBuilder();
            buildJson.AppendLine();

            try
            {
                irs = IRacingService.IRacingServiceLogin;

                await irs.SetCurrentSeason();
                await irs.SetCars();
            }
            catch
            {
                Close();
            }

            IRacingService.CurrentSeries = await irs.GetAllSeries();

            foreach (var item in IRacingService.CurrentSeries)
            {
                seriesListCombo.Items.Add(item);
            }
        }
        private async void createSeason_Click(object sender, EventArgs e)
        {
            SeasonName = seasonNameTextBox.Text;
            SeriesName = seriesListCombo.Text;
            CarName = carListCombo.Text;
            AiMin = aiMinTrackBar.Value;
            AiMax = aiMaxTrackBar.Value;
            FilePath = filePathTextBox.Text;
            DisableDamage = disableCarDamageCheckBox.Checked;
            AiAvoids = aiAvoidPlayerCheckBox.Checked;

            //check for any empty boxes
            if (BlankFormChecker() == false)
            {
                MessageBox.Show($"Please finish filling out the form before attempting to create a season.");
                return;
            }

            //check to make sure user hasn't timed out
            try
            {
                var ss = await irs.SeasonBuilder(SeasonName);
                string filePath = $@"{FilePath}\{SeasonName}.json";
                await IRacingService.SaveSeasonScheduleToJson(ss, filePath);
            }
            catch
            {
                LoginForm.ErrorLoginText = "Session timed out. Please sign in again.";
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }


            if (NotAvailableTracks.Any())
            {
                NotAllowedTracksMessage();
            }
            else
            {
                MessageBox.Show("Season created successfully! Restart iRacing if it is currently open.");
            }
        }

        private static bool BlankFormChecker()
        {
            if (SeasonName == "" || SeasonName == null)
                return false;
            if (SeriesName == "" || SeriesName == null)
                return false;
            if (CarName == "" || CarName == null)
                return false;
            if (FilePath == "" || FilePath == null)
                return false;
            if (AiMin > AiMax)
                return false;

            return true;
        }

        private static void ClearForm()
        {

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
                }
            }
        }

        private async void seriesListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesName = seriesListCombo.SelectedItem.ToString();
            var carList = await irs.PopulateCarComboBox();
            await irs.CreateCarSettings();
            carListCombo.Items.Clear();

            foreach (var car in carList)
            {
                carListCombo.Items.Add(car);
            }
        }

        private void aiMinTrackBar_Scroll(object sender, EventArgs e)
        {
            minSkillBox.Text = aiMinTrackBar.Value.ToString();
        }

        private void aiMaxTrackBar_Scroll(object sender, EventArgs e)
        {
            maxSkillBox.Text = aiMaxTrackBar.Value.ToString();
        }

        public static bool OfflineMode { get; set; } = false;
        public static string? SeasonName { get; set; }
        public static string? SeriesName { get; set; }
        public static string? CarName { get; set; }
        public static int? AiMin { get; set; }
        public static int? AiMax { get; set; }
        public static string? FilePath { get; set; }
        public static bool DisableDamage { get; set; }
        public static bool AiAvoids { get; set; }
        public static List<string> NotAvailableTracks { get; set; } = new List<string>();
        public static Aydsko.iRacingData.Common.DataResponse<Aydsko.iRacingData.Cars.CarInfo[]> CarInfo { get; set; }
    }
}