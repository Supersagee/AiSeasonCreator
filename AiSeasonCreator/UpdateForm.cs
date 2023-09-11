using Newtonsoft.Json.Linq;
using System;

namespace AiSeasonCreator
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private JObject _latestReleaseInfo;

        public UpdateForm(JObject latestReleaseInfo)
        {
            InitializeComponent();

            _latestReleaseInfo = latestReleaseInfo;
            DisplayReleaseInfo();
        }

        private void DisplayReleaseInfo()
        {
            string releaseName = _latestReleaseInfo["name"].ToString();
            string releaseNotes = _latestReleaseInfo["body"].ToString();

            updateLabel.Text = $"Update Available: {releaseName}";
            releaseNotesTextBox.Text = releaseNotes;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            var updater = new Updater();
            string installerUrl = updater.FindInstallerAsset(_latestReleaseInfo);

            if (installerUrl == null)
            {
                MessageBox.Show("No installer found in the latest release.");
                return;
            }

            await updater.DownloadAndRunInstaller(installerUrl);
            DialogResult = DialogResult.Yes;
            Close();
            Application.Exit();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
