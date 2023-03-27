namespace iRacingSeasonCreator
{
    public partial class MainForm : Form
    {
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
                var list = await IRacingService.IRacingServiceLogin.GetAllSeries();

                foreach (var item in list)
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
            try
            {
                var isLoggedIn = await IRacingService.IRacingServiceLogin.GetAllSeries();
            }
            catch
            {
                LoginForm.ErrorLoginText = "Session timed out. Please sign in again.";
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }

            MessageBox.Show($"{seriesListCombo.Text}");
        }
    }
}