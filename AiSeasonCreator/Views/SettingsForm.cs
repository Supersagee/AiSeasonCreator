using AiSeasonCreator.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiSeasonCreator.Views
{
    public partial class SettingsForm : Form, ISettingsView
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
        }

        private void seasonFolderPathTextBox_Click(object sender, EventArgs e)
        {
            SeasonFolderClicked.Invoke(this, e);
        }

        private void rosterFolderPathTextBox_Click(object sender, EventArgs e)
        {
            RosterFolderClicked.Invoke(this, e);
        }

        public event EventHandler ViewLoaded;
        public event EventHandler SeasonFolderClicked;
        public event EventHandler RosterFolderClicked;

        public ISettingsPresenter Presenter { get; set; }

        public string SeasonFolderPath
        {
            get { return seasonFolderPathTextBox.Text; }
            set { seasonFolderPathTextBox.Text = value; }
        }

        public string RosterFolderPath
        {
            get { return rosterFolderPathTextBox.Text; }
            set { rosterFolderPathTextBox.Text = value; }
        }

        public string SetFolderPathLabel
        {
            get { return checkFolderPathLabel.Text; }
            set { checkFolderPathLabel.Text = value; }
        }
    }
}
