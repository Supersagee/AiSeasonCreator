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
    public partial class SeasonForm : Form, ISeasonView
    {
        public SeasonForm()
        {
            InitializeComponent();
        }

        private void SeasonForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
            availableTracksFlowLayoutPanel.BackColor = Color.FromArgb(200, 30, 30, 30);
        }

        private void seriesListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesIndexChanged?.Invoke(this, e);
        }

        private void carCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            carCountValueLabel.Text = carCountTrackBar.Value.ToString();
        }

        private void createSeasonButton_Click(object sender, EventArgs e)
        {
            CreateSeasonClicked?.Invoke(this, e);
        }

        private void PopulateTrackButtons(IEnumerable<string> tracks)
        {
            availableTracksFlowLayoutPanel.Controls.Clear();

            foreach (var track in tracks)
            {
                var button = new Button();
                button.Text = track;
                button.Height = 36;
                button.Width = 360;
                button.FlatAppearance.BorderSize = 1;
                button.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                button.BackColor = Color.FromArgb(200, 30, 30, 30);
                button.ForeColor = Color.White;
                button.TextAlign = ContentAlignment.MiddleRight;
                button.FlatStyle = FlatStyle.Flat;
                button.Tag = false;
                button.Click += Button_Click;

                availableTracksFlowLayoutPanel.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                bool isSelected = (bool)button.Tag;

                if (isSelected)
                {
                    button.FlatAppearance.BorderSize = 1;
                    button.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                    button.ForeColor = Color.White;
                    button.BackColor = Color.FromArgb(200, 30, 30, 30);
                }
                else
                {
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Italic);
                    button.ForeColor = Color.Gray;
                    button.BackColor = Color.FromArgb(220, 50, 50, 50);
                }

                button.Tag = !isSelected;
            }
        }

        private void rosterNameComboBox_Click(object sender, EventArgs e)
        {
            RosterClicked.Invoke(this, e);
        }

        public event EventHandler ViewLoaded;
        public event EventHandler SeriesIndexChanged;
        public event EventHandler RosterClicked;
        public event EventHandler CreateSeasonClicked;

        public ISeasonPresenter Presenter { get; set; }
        public IEnumerable<string> SeriesList
        {
            set { seriesListCombo.DataSource = value.ToList(); }
        }
        public IEnumerable<string> CarList
        {
            set { carListCombo.DataSource = value.ToList(); }
        }

        public IEnumerable<string> TrackList
        {
            set { PopulateTrackButtons(value); }
        }
        public IEnumerable<string> SelectedTracks
        {
            get
            {
                return availableTracksFlowLayoutPanel.Controls
                    .OfType<Button>()
                    .Where(btn => btn.Tag is bool selected && !selected)
                    .Select(btn => btn.Text)
                    .ToList();
            }
        }

        public IEnumerable<string> RosterList
        {
            set { rosterNameComboBox.DataSource = value.ToList(); }
        }
        
        public string SeasonName
        {
            get { return seasonNameTextBox.Text; }
        }

        public string SeriesName
        {
            get { return seriesListCombo.Text; }
        }

        public string CarName
        {
            get { return carListCombo.Text; }
        }

        public bool UseAdaptiveAi
        {
            get { return adaptiveAiCheckBox.Checked; }
            set { adaptiveAiCheckBox.Checked = value; }
        }

        public string AdaptiveAiDifficulty
        {
            get { return adaptiveAiComboBox.Text; }
            set { adaptiveAiComboBox.Text = value; }
        }

        public int AiMin
        {
            get { return aiSkillMinTrackBar.Value; }
            set { aiSkillMinTrackBar.Value = value; }
        }

        public int AiMax
        {
            get { return aiSkillMaxTrackBar.Value; }
            set { aiSkillMaxTrackBar.Value = value; }
        }

        public bool DisableDamage
        {
            get { return disableCarDamageCheckBox.Checked; }
            set { disableCarDamageCheckBox.Checked = value; }
        }

        public bool AiAvoids
        {
            get { return aiAvoidPlayerCheckBox.Checked; }
            set { aiAvoidPlayerCheckBox.Checked = value; }
        }

        public bool StaticWeather
        {
            get { return staticWeatherCheckBox.Checked; }
            set { staticWeatherCheckBox.Checked = value; }
        }

        public bool AfternoonRaces
        {
            get { return afternoonRacesCheckBox.Checked; }
            set { afternoonRacesCheckBox.Checked = value; }
        }

        public bool NeverRain
        {
            get { return neverRainsCheckBox.Checked; }
            set { neverRainsCheckBox.Checked = value; }
        }

        public bool QualiAlone
        {
            get { return qualiAloneCheckBox.Checked; }
            set { qualiAloneCheckBox.Checked = value; }
        }

        public bool ShortParade
        {
            get { return shortParadeCheckBox.Checked; }
            set { shortParadeCheckBox.Checked = value; }
        }

        public string RosterName
        {
            get { return rosterNameComboBox.Text; }
            set { rosterNameComboBox.Text = value; }
        }

        public int CarCount
        {
            get { return carCountTrackBar.Value; }
            set { carCountTrackBar.Value = value; }
        }
    }
}
