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
    public partial class RosterForm : Form, IRosterView
    {
        public RosterForm()
        {
            InitializeComponent();
        }

        private void RosterForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
        }

        private void rosterSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RosterSourceIndexChanged.Invoke(this, e);
        }

        private void seriesRosterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesRosterIndexChanged.Invoke(this, e);
        }

        private void driversComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriversIndexChanged.Invoke(this, e);
        }

        private void driverCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            driverCountValueLabel.Text = driverCountTrackBar.Value.ToString();
        }

        private void createRosterButton_Click(object sender, EventArgs e)
        {
            CreateUpdateRosterClicked.Invoke(this, e);
        }

        public event EventHandler ViewLoaded;
        public event EventHandler RosterSourceIndexChanged;
        public event EventHandler SeriesRosterIndexChanged;
        public event EventHandler DriversIndexChanged;
        public event EventHandler CreateUpdateRosterClicked;

        public IRosterPresenter Presenter { get; set; }

        public IEnumerable<string> RosterSourceList
        {
            set { rosterSourceComboBox.DataSource = value.ToList(); }
        }
        public IEnumerable<string> SeriesRosterList
        {
            set { seriesRosterComboBox.DataSource = value.ToList(); }
        }
        public IEnumerable<string> DriversList
        {
            set { driversComboBox.DataSource = value.ToList(); }
        }
        public string RosterName
        {
            get { return rosterNameTextBox.Text; }
        }
        public string RosterSource
        {
            get { return rosterSourceComboBox.Text; }
        }
        public string SeriesRosterName
        {
            get { return seriesRosterComboBox.Text; }
        }
        public string DriverName
        {
            get { return driversComboBox.Text; }
            set { driversComboBox.Text = value; }
        }
        public int DriverCount
        {
            get { return driverCountTrackBar.Value; }
            set { driverCountTrackBar.Value = value; }
        }
        public int RelativeSkillMin
        {
            get { return relativeSkillMinTrackBar.Value; }
            set { relativeSkillMinTrackBar.Value = value; }
        }
        public int RelativeSkillMax
        {
            get { return relativeSkillMaxTrackBar.Value; }
            set { relativeSkillMaxTrackBar.Value = value; }
        }
        public int AggressionMin
        {
            get { return aggressionMinTrackBar.Value; }
            set { aggressionMinTrackBar.Value = value; }
        }
        public int AggressionMax
        {
            get { return aggressionMaxTrackBar.Value; }
            set { aggressionMaxTrackBar.Value = value; }
        }
        public int OptimismMin
        {
            get { return optimismMinTrackBar.Value; }
            set { optimismMinTrackBar.Value = value; }
        }
        public int OptimismMax
        {
            get { return optimismMaxTrackBar.Value; }
            set { optimismMaxTrackBar.Value = value; }
        }
        public int SmoothnessMin
        {
            get { return smoothnessMinTrackBar.Value; }
            set { smoothnessMinTrackBar.Value = value; }
        }
        public int SmoothnessMax
        {
            get { return smoothnessMaxTrackBar.Value; }
            set { smoothnessMaxTrackBar.Value = value; }
        }
        public int AgeMin
        {
            get { return ageMinTrackBar.Value; }
            set { ageMinTrackBar.Value = value; }
        }
        public int AgeMax
        {
            get { return ageMaxTrackBar.Value; }
            set { ageMaxTrackBar.Value = value; }
        }
        public int PitCrewMin
        {
            get { return pitCrewMinTrackBar.Value; }
            set { pitCrewMinTrackBar.Value = value; }
        }
        public int PitCrewMax
        {
            get { return pitCrewMaxTrackBar.Value; }
            set { pitCrewMaxTrackBar.Value = value; }
        }
        public int PitStratMin
        {
            get { return pitStratMinTrackBar.Value; }
            set { pitStratMinTrackBar.Value = value; }
        }
        public int PitStratMax
        {
            get { return pitStratMaxTrackBar.Value; }
            set { pitStratMaxTrackBar.Value = value; }
        }
        public bool UseRelativeSkill
        {
            get { return relativeSkillCheckBox.Checked; }
            set { relativeSkillCheckBox.Checked = value; }
        }
        public bool UseAggression
        {
            get { return aggressionCheckBox.Checked; }
            set { aggressionCheckBox.Checked = value; }
        }
        public bool UseOptimism
        {
            get { return optimismCheckBox.Checked; }
            set { optimismCheckBox.Checked = value; }
        }
        public bool UseSmoothness
        {
            get { return smoothnessCheckBox.Checked; }
            set { smoothnessCheckBox.Checked = value; }
        }
        public bool UseAge
        {
            get { return ageCheckBox.Checked; }
            set { ageCheckBox.Checked = value; }
        }
        public bool UsePitCrew
        {
            get { return pitCrewCheckBox.Checked; }
            set { pitCrewCheckBox.Checked = value; }
        }
        public bool UsePitStrat
        {
            get { return pitStratCheckBox.Checked; }
            set { pitStratCheckBox.Checked = value; }
        }
        public int DriverNumber
        {
            set { driverNumber.Text = value.ToString(); }
        }
        public string DriverCar
        {
            set { driverCarLabel.Text = value; }
        }
        public string DriverColor1
        {
            set { driverColor1.BackColor = ColorTranslator.FromHtml(value); }
        }
        public string DriverColor2
        {
            set { driverColor2.BackColor = ColorTranslator.FromHtml(value); }
        }
        public string DriverColor3
        {
            set { driverColor3.BackColor = ColorTranslator.FromHtml(value); }
        }
    }
}
