using Microsoft.VisualBasic.ApplicationServices;

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
            try
            {
                irs = IRacingService.IRacingServiceLogin;

                await irs.SetCurrentSeason();
                await irs.SetCars();

                IRacingService.CurrentSeries = await irs.GetAllSeries();

                foreach (var item in IRacingService.CurrentSeries)
                {
                    seriesListCombo.Items.Add(item);
                }
            }
            catch
            {
                Close();
            }
        }
        private async void createSeason_Click(object sender, EventArgs e)
        {
            SeasonName = seasonNameTextBox.Text;
            SeriesName = seriesListCombo.Text;
            CarName = carListCombo.Text;
            AiMin = Convert.ToInt32(minSkillBox.Text);
            AiMax = Convert.ToInt32(maxSkillBox.Text);
            FilePath = filePathTextBox.Text;
            DisableDamage = disableCarDamageCheckBox.Checked;
            AiAvoids = aiAvoidPlayerCheckBox.Checked;

            //check for any empty boxes
            if (BlankFormChecker() == false)
            {
                MessageBox.Show($"Please finish filling out form before creating season.");
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

            //await IRacingService.SeasonBuilder(SeriesName);
            MessageBox.Show($"{seriesListCombo.Text}");
        }

        private static bool BlankFormChecker()
        {
            if (SeasonName == "" || SeasonName == null)
                return false;
            if (SeriesName == "" || SeriesName == null)
                return false;
            if (CarName == "" || CarName == null)
                return false;
            if (AiMin.HasValue == false)
                return false;
            if (AiMax.HasValue == false)
                return false;
            if (FilePath == "" || FilePath == null)
                return false;
            return true;
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
            carListCombo.Items.Clear();

            foreach (var car in carList)
            {
                carListCombo.Items.Add(car);
            }
        }

        public static string? SeasonName { get; set; }
        public static string? SeriesName { get; set; }
        public static string? CarName { get; set; }
        public static int? AiMin { get; set; }
        public static int? AiMax { get; set; }
        public static string? FilePath { get; set; }
        public static bool DisableDamage { get; set; }
        public static bool AiAvoids { get; set; }
        public static Aydsko.iRacingData.Common.DataResponse<Aydsko.iRacingData.Cars.CarInfo[]> CarInfo { get; set; }
    }
}