using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Set the form's title
            this.Text = $"Update Available: {releaseName}";

            // Set the TextBox content
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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
