using iRacingWeatherURLParser.WeatherSchedule;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiSeasonCreator.Views
{
    public partial class MainForm : Form, IMainView
    {
        private SeasonForm _seasonForm;
        private RosterForm _rosterForm;
        private AboutForm _aboutForm;
        private SettingsForm _settingsForm;
        public static ISeasonView staticSeasonForm { get; set; }
        public MainForm(
            SeasonForm seasonView, 
            RosterForm rosterForm,
            AboutForm aboutForm,
            SettingsForm settingsView)
        {
            InitializeComponent();
            _seasonForm = seasonView;
            _rosterForm = rosterForm;
            _aboutForm = aboutForm;
            _settingsForm = settingsView;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //seasonButton.MouseEnter += MouseOverNavButtons;
            seasonButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            OpenChildForm(_settingsForm, sender);
            OpenChildForm(_seasonForm, sender);
        }

        private void OpenChildForm(Form childForm, object buttonSender)
        {
            childForm.TopLevel = false;
            mainPanel.Controls.Add(childForm);
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void seasonButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_seasonForm, sender);
        }

        private void rosterButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_rosterForm, sender);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_aboutForm, sender);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(_settingsForm, sender);
        }
    }
}
