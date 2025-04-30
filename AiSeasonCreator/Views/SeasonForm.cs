using AiSeasonCreator.Helpers;
using AiSeasonCreator.Presenters;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            messageFormLabel.Text = "";
        }

        private void seriesListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesIndexChanged?.Invoke(this, e);
        }

        private void carCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            carCountValueLabel.Text = carCountTrackBar.Value.ToString();
        }

        private void rosterNameComboBox_Click(object sender, EventArgs e)
        {
            RosterClicked.Invoke(this, e);
        }

        private void SeriesSelectionButton_Click(object sender, EventArgs e)
        {
            SelectedCar = "";

            if (sender is Button clickedButton && clickedButton.Tag is ButtonInfo info)
            {
                foreach (Button button in seriesFlowLayoutPanel.Controls)
                {
                    if (button.Tag is ButtonInfo inf)
                        inf.IsSelected = false;
                    SetStandardButtonFont(button);
                }

                SetSelectedButtonFont(clickedButton);
                info.IsSelected = true;
                SelectedSeries = info.OriginalName;

                SeriesIndexChanged?.Invoke(this, e);

                if (RaceLength == 100)
                    raceMinutesOrPercentageLabel.Text = "%";
                else
                    raceMinutesOrPercentageLabel.Text = "Minutes";
            }
        }

        private void CarsSelectionButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.Tag is ButtonInfo info)
            {
                foreach (Button button in carsFlowLayoutPanel.Controls)
                {
                    if (button.Tag is ButtonInfo inf)
                        inf.IsSelected = false;
                    SetStandardButtonFont(button);
                }

                SetSelectedButtonFont(clickedButton);
                info.IsSelected = true;
                SelectedCar = info.OriginalName;
            }
        }

        private void TrackSelectionButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is ButtonInfo info)
            {
                info.IsSelected = !info.IsSelected;

                if (info.IsSelected)
                {
                    SetUnselectedButtonFont(button);
                }
                else
                {
                    SetStandardButtonFont(button);
                }
            }
        }

        private void createSeasonButton_Click(object sender, EventArgs e)
        {
            createSeasonButton.Visible = false;
            createSeasonButton.Visible = true;
            createSeasonButton.Refresh();

            if (IsFormBlank())
            {
                messageFormLabel.Text = "Please complete your selections";
                BlinkLabel(messageFormLabel);
                return;
            }

            messageFormLabel.Text = "";
            CreateSeasonClicked?.Invoke(this, e);
            TempDisableCreateSeasonButton();
        }

        private bool IsFormBlank()
        {
            if (SeasonName == null || SeasonName == "")
                return true;
            if (SelectedSeries == null || SelectedSeries == "")
                return true;
            if (SelectedCar == null || SelectedCar == "")
                return true;
            if (SelectedTracks.Count() == 0)
                return true;
            if (practiceLengthTrackBar.Value < 1 &&
                qualiLengthTrackBar.Value < 1 &&
                raceLengthTrackBar.Value < 1)
                return true;

            return false;
        }

        private async void TempDisableCreateSeasonButton()
        {
            messageFormLabel.Text = "Season Created Successfully!";
            BlinkLabel(messageFormLabel);
            createSeasonButton.Enabled = false;
            await Task.Delay(3000);
            createSeasonButton.Enabled = true;
            messageFormLabel.Text = "";
        }

        private async void BlinkLabel(Label label)
        {
            for (var i = 0; i < 6; i++)
            {
                await Task.Delay(100);
                label.ForeColor = label.ForeColor == Color.FromArgb(128, 187, 0) ? Color.Black : Color.FromArgb(128, 187, 0);
            }
        }

        private void PopulateSeriesButtons(IEnumerable<NameAndAsset> series)
        {
            seriesFlowLayoutPanel.Controls.Clear();

            foreach (var item in series)
            {
                var button = new Button();

                SetFlowPanelButton(button, item.Name, item.Asset);
                button.Click += SeriesSelectionButton_Click;
                seriesFlowLayoutPanel.Controls.Add(button);
            }
        }

        private void PopulateCarButtons(IEnumerable<NameAndAsset> cars)
        {
            carsFlowLayoutPanel.Controls.Clear();

            foreach (var car in cars)
            {
                var button = new Button();

                SetCarFlowPanelButton(button, car.Name, car.Asset);
                button.Click += CarsSelectionButton_Click;
                carsFlowLayoutPanel.Controls.Add(button);

                if (cars.ToList().Count == 1)
                {
                    EventArgs e = null;
                    CarsSelectionButton_Click(button, e);
                }
            }
        }

        private void PopulateTrackButtons(IEnumerable<NameAndAsset> tracks)
        {
            availableTracksFlowLayoutPanel.Controls.Clear();

            foreach (var track in tracks)
            {
                var button = new Button();

                SetFlowPanelButton(button, track.Name, track.Asset);
                button.TextImageRelation = TextImageRelation.Overlay;
                button.TextAlign = ContentAlignment.TopRight;
                button.Click += TrackSelectionButton_Click;
                availableTracksFlowLayoutPanel.Controls.Add(button);
            }
        }

        private void SetCarFlowPanelButton(Button button, string item, Image asset)
        {
            var info = new ButtonInfo { OriginalName = item, IsSelected = false };
            button.Tag = info;
            button.Text = $"                                       {item}";
            button.Image = asset;
            button.TextImageRelation = TextImageRelation.ImageAboveText;
            button.ImageAlign = ContentAlignment.TopCenter;
            button.Height = 100;
            button.Width = 180;
            button.FlatAppearance.BorderSize = 0;
            SetStandardButtonFont(button);
            button.FlatStyle = FlatStyle.Flat;
        }

        private void SetFlowPanelButton(Button button, string item, Image asset)
        {
            var info = new ButtonInfo { OriginalName = item, IsSelected = false };
            button.Tag = info;
            button.Text = $"  {item}";
            button.Image = asset;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Height = 40;
            button.Width = 360;
            button.FlatAppearance.BorderSize = 0;
            SetStandardButtonFont(button);
            button.TextAlign = ContentAlignment.MiddleRight;
            button.FlatStyle = FlatStyle.Flat;
        }

        private void practiceLengthTrackBar_ValueChanged(object sender, EventArgs e)
        {
            practiceLengthValueLabel.Text = practiceLengthTrackBar.Value.ToString();

            if (practiceLengthTrackBar.Value == 1)
                practiceMinutesLabel.Text = "Minute";
            else
                practiceMinutesLabel.Text = "Minutes";
        }

        private void qualiLengthTrackBar_ValueChanged(object sender, EventArgs e)
        {
            qualiLengthValueLabel.Text = qualiLengthTrackBar.Value.ToString();

            if (qualiAloneCheckBox.Checked)
            {
                if (qualiLengthTrackBar.Value == 1)
                    qualiLapsOrMinutesLabel.Text = "Lap";
                else
                    qualiLapsOrMinutesLabel.Text = "Laps";
            }
            else
            {
                if (qualiLengthTrackBar.Value == 1)
                    qualiLapsOrMinutesLabel.Text = "Minute";
                else
                    qualiLapsOrMinutesLabel.Text = "Minutes";
            }
        }

        private void raceLengthTrackBar_ValueChanged(object sender, EventArgs e)
        {
            raceLengthValueLabel.Text = raceLengthTrackBar.Value.ToString();
        }

        private void qualiAloneCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (qualiAloneCheckBox.Checked)
            {
                qualiLapsOrMinutesLabel.Text = "Laps";
                qualiLengthTrackBar.Maximum = 5;
            }
            else
            {
                qualiLapsOrMinutesLabel.Text = "Minutes";
                qualiLengthTrackBar.Maximum = 30;
            }

            QualiAloneChecked.Invoke(this, e);
        }

        private void adaptiveAiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (adaptiveAiCheckBox.Checked)
                adaptiveAiComboBox.Enabled = true;
            else
                adaptiveAiComboBox.Enabled = false;
        }

        private void SetStandardButtonFont(Button button)
        {
            button.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            button.ForeColor = Color.FromArgb(220, 220, 220);
            button.BackColor = Color.FromArgb(60, 30, 30, 30);
            button.FlatAppearance.BorderSize = 0;
        }

        private void SetSelectedButtonFont(Button button)
        {
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(200, 36, 36, 54);
            button.FlatAppearance.BorderSize = 1;
        }

        private void SetUnselectedButtonFont(Button button)
        {
            button.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            button.ForeColor = Color.Gray;
            button.BackColor = Color.FromArgb(240, 99, 99, 99);
        }

        private void aiSkillRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            aiSkillPerLabel.Text = $"{aiSkillRangeTrackBar.LowerValue.ToString()}%-{aiSkillRangeTrackBar.UpperValue.ToString()}%";
        }

        public event EventHandler ViewLoaded;
        public event EventHandler SeriesIndexChanged;
        public event EventHandler RosterClicked;
        public event EventHandler QualiAloneChecked;
        public event EventHandler CreateSeasonClicked;

        public ISeasonPresenter Presenter { get; set; }
        public IEnumerable<NameAndAsset> SeriesList
        {
            set { PopulateSeriesButtons(value); }
        }
        public IEnumerable<NameAndAsset> CarList
        {
            set { PopulateCarButtons(value); }
        }
        public IEnumerable<NameAndAsset> TrackList
        {
            set { PopulateTrackButtons(value); }
        }
        public IEnumerable<string> SelectedTracks
        {
            get
            {
                return availableTracksFlowLayoutPanel.Controls
                    .OfType<Button>()
                    .Where(btn => btn.Tag is ButtonInfo info && !info.IsSelected)
                    .Select(btn => ((ButtonInfo)btn.Tag).OriginalName)
                    .ToList();
            }
        }

        public IEnumerable<string> RosterList
        {
            set { rosterNameComboBox.DataSource = value.ToList(); }
        }
        public string SelectedSeries { get; private set; }
        public string SeasonName
        {
            get { return seasonNameTextBox.Text.Trim(); }
        }

        public string SelectedCar { get; private set; }

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
            get { return aiSkillRangeTrackBar.LowerValue; }
            set { aiSkillRangeTrackBar.LowerValue = value; }
        }

        public int AiMax
        {
            get { return aiSkillRangeTrackBar.UpperValue; }
            set { aiSkillRangeTrackBar.UpperValue = value; }
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

        public int PracticeLength
        {
            get { return practiceLengthTrackBar.Value; }
            set { practiceLengthTrackBar.Value = value; }
        }

        public int QualiLength
        {
            get { return qualiLengthTrackBar.Value; }
            set { qualiLengthTrackBar.Value = value; }
        }

        public int RaceLength
        {
            get { return raceLengthTrackBar.Value; }
            set { raceLengthTrackBar.Value = value; }
        }
    }
}
