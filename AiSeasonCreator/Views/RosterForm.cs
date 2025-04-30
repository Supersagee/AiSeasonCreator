using AiSeasonCreator.Data;
using AiSeasonCreator.Helpers;
using AiSeasonCreator.Presenters;
using System.ComponentModel;
using System.Data;

namespace AiSeasonCreator.Views
{
    public partial class RosterForm : Form, IRosterView
    {
        private LoadedData _loadedData;
        public RosterForm(LoadedData loadedData)
        {
            InitializeComponent();
            _loadedData = loadedData;
        }

        private void RosterForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
            SetDriversDataGridProperties();
            SetEmptyControlLocations();
            FixedRangeTrackBarValueLabels();
            updateRosterRadioButton.Checked = true;
            minusPlusRadioButton.Checked = true;
            driversDataGridView.CellMouseDown += DriversGrid_CellMouseDown;
            driversDataGridView.Sorted += DriversGrid_Sorted;
            _loadedData.DriversDataGrid.ListChanged += DriversList_ListChanged;
            messageFormLabel.Text = "";
        }

        private void seriesRosterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesRosterIndexChanged.Invoke(this, e);
        }

        private void driverCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            driverCountValueLabel.Text = driverCountTrackBar.Value.ToString();
        }

        private void createRosterButton_Click(object sender, EventArgs e)
        {
            createRosterButton.Visible = false;
            createRosterButton.Visible = true;

            if (rosterNameTextBox.Text == "")
            {
                rosterNamePanel.Visible = true;
                return;
            }

            rosterNamePanel.Visible = false;

            TempDisableCreateSeasonButton();
            CreateUpdateRosterClicked.Invoke(this, e);
        }

        private async void TempDisableCreateSeasonButton()
        {
            messageFormLabel.Text = "Roster Created!";
            createRosterButton.Enabled = false;
            await Task.Delay(3000);
            createRosterButton.Enabled = true;
            messageFormLabel.Text = "";
        }

        private void SetDriversDataGridProperties()
        {
            driversDataGridView.DefaultCellStyle.ForeColor = Color.White;
            driversDataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(18, 18, 27);
            driversDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            driversDataGridView.EnableHeadersVisualStyles = false;
            driversDataGridView.DataSource = _loadedData.DriversDataGrid;
            driversDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void updateSelectedDriversButton_Click(object sender, EventArgs e)
        {
            UpdateSelectedDriversButtonClicked.Invoke(this, e);
            updateSelectedDriversButton.Visible = false;
            updateSelectedDriversButton.Visible = true;
            updateAllDriversButton.Visible = false;
            updateAllDriversButton.Visible = true;
        }

        private void updateAllDriversButton_Click(object sender, EventArgs e)
        {
            UpdateAllDriversButtonClicked.Invoke(this, e);
            updateAllDriversButton.Visible = false;
            updateAllDriversButton.Visible = true;
        }

        private void relativeSkillRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateTrackBarValueLabels(relativeSkillValueLabel, relativeSkillRangeTrackBar.LowerValue, relativeSkillRangeTrackBar.UpperValue);
        }

        private void aggressionRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateTrackBarValueLabels(aggressionValueLabel, aggressionRangeTrackBar.LowerValue, aggressionRangeTrackBar.UpperValue);
        }

        private void optimismRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateTrackBarValueLabels(optimismValueLabel, optimismRangeTrackBar.LowerValue, optimismRangeTrackBar.UpperValue);
        }

        private void smoothnessRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateTrackBarValueLabels(smoothnessValueLabel, smoothnessRangeTrackBar.LowerValue, smoothnessRangeTrackBar.UpperValue);
        }

        private void ageRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateAgeTrackBarValueLabel(ageValueLabel, ageRangeTrackBar.LowerValue, ageRangeTrackBar.UpperValue);
        }

        private void pitCrewRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateTrackBarValueLabels(pitCrewValueLabel, pitCrewRangeTrackBar.LowerValue, pitCrewRangeTrackBar.UpperValue);
        }

        private void pitStratRangeTrackBar_RangeChanged(object sender, EventArgs e)
        {
            UpdateTrackBarValueLabels(pitStratValueLabel, pitStratRangeTrackBar.LowerValue, pitStratRangeTrackBar.UpperValue);
        }

        private void CreateOrUpdateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (updateRosterRadioButton.Checked)
            {
                updateRosterPanel.Enabled = true;
                createRosterPanel.Enabled = false;
                RosterComboBoxClicked.Invoke(this, e);
                minusPlusRadioButton.Checked = true;
            }
            else
            {
                updateRosterPanel.Enabled = false;
                createRosterPanel.Enabled = true;
                driversDataGridView.Rows.Clear();
                fixedRangeRadioButton.Checked = true;
            }
        }

        private void RangeOrMinusPlusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (minusPlusRadioButton.Checked)
            {
                ChangeAllTrackBarValuesToMinusPlus();
            }
            else
            {
                ChangeAllTrackBarValuesToFixedRange();
            }
        }

        private void UpdateTrackBarValueLabels(Label label, int min, int max)
        {
            label.Text = $"{min.ToString()}% to {max.ToString()}%";
        }

        private void UpdateAgeTrackBarValueLabel(Label label, int min, int max)
        {
            label.Text = $"{min.ToString()} to {max.ToString()} Years";
        }

        private void FixedRangeTrackBarValueLabels()
        {
            UpdateTrackBarValueLabels(relativeSkillValueLabel, relativeSkillRangeTrackBar.LowerValue, relativeSkillRangeTrackBar.UpperValue);
            UpdateTrackBarValueLabels(aggressionValueLabel, aggressionRangeTrackBar.LowerValue, aggressionRangeTrackBar.UpperValue);
            UpdateTrackBarValueLabels(optimismValueLabel, optimismRangeTrackBar.LowerValue, optimismRangeTrackBar.UpperValue);
            UpdateTrackBarValueLabels(smoothnessValueLabel, smoothnessRangeTrackBar.LowerValue, smoothnessRangeTrackBar.UpperValue);
            UpdateAgeTrackBarValueLabel(ageValueLabel, ageRangeTrackBar.LowerValue, ageRangeTrackBar.UpperValue);
            UpdateTrackBarValueLabels(pitCrewValueLabel, pitCrewRangeTrackBar.LowerValue, pitCrewRangeTrackBar.UpperValue);
            UpdateTrackBarValueLabels(pitStratValueLabel, pitStratRangeTrackBar.LowerValue, pitStratRangeTrackBar.UpperValue);
        }

        private void ChangeAllTrackBarValuesToFixedRange()
        {
            ChangeTrackBarToFixedRange(relativeSkillRangeTrackBar);
            ChangeTrackBarToFixedRange(aggressionRangeTrackBar);
            ChangeTrackBarToFixedRange(optimismRangeTrackBar);
            ChangeTrackBarToFixedRange(smoothnessRangeTrackBar);
            ChangeAgeTrackBarToFixedRange(ageRangeTrackBar);
            ChangeTrackBarToFixedRange(pitCrewRangeTrackBar);
            ChangeTrackBarToFixedRange(pitStratRangeTrackBar);
        }

        private void ChangeAllTrackBarValuesToMinusPlus()
        {
            ChangeTrackBarToMinusPlus(relativeSkillRangeTrackBar);
            ChangeTrackBarToMinusPlus(aggressionRangeTrackBar);
            ChangeTrackBarToMinusPlus(optimismRangeTrackBar);
            ChangeTrackBarToMinusPlus(smoothnessRangeTrackBar);
            ChangeAgeTrackBarToMinusPlus(ageRangeTrackBar);
            ChangeTrackBarToMinusPlus(pitCrewRangeTrackBar);
            ChangeTrackBarToMinusPlus(pitStratRangeTrackBar);
        }

        private void ChangeTrackBarToFixedRange(RangeTrackBar rtb)
        {
            rtb.UpperValue = 75;
            rtb.LowerValue = 25;
            rtb.Minimum = 0;
            rtb.Maximum = 100;
        }

        private void ChangeTrackBarToMinusPlus(RangeTrackBar rtb)
        {
            rtb.Minimum = -100;
            rtb.Maximum = 100;
            rtb.LowerValue = -10;
            rtb.UpperValue = 10;
        }

        private void ChangeAgeTrackBarToFixedRange(RangeTrackBar rtb)
        {
            rtb.UpperValue = 60;
            rtb.LowerValue = 20;
            rtb.Minimum = 13;
            rtb.Maximum = 90;
        }

        private void ChangeAgeTrackBarToMinusPlus(RangeTrackBar rtb)
        {
            rtb.Minimum = -77;
            rtb.Maximum = 77;
            rtb.LowerValue = -10;
            rtb.UpperValue = 10;
        }

        private List<string> _preSortSelectedNames;

        private void DriversGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 || e.Button != MouseButtons.Left) return;

            _preSortSelectedNames = driversDataGridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => ((DriversDataGrid)r.DataBoundItem).Driver)
                .ToList();
        }

        private void DriversGrid_Sorted(object sender, EventArgs e)
        {
            if (_preSortSelectedNames == null || !_preSortSelectedNames.Any())
                return;

            driversDataGridView.ClearSelection();
            foreach (DataGridViewRow row in driversDataGridView.Rows)
            {
                var drv = row.DataBoundItem as DriversDataGrid;
                if (drv != null && _preSortSelectedNames.Contains(drv.Driver))
                    row.Selected = true;
            }
            _preSortSelectedNames.Clear();
        }

        private void driversDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var bp = 0;
        }

        private void driversDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var col = driversDataGridView.Columns[e.ColumnIndex].Name;
            var skillsCols = new[] {
                "RelativeSkill", "Aggression", "Optimism",
                "Smoothness", "Age", "PitCrewSkill", "PitStrat" };
            if (!skillsCols.Contains(col)) return;

            int lower = (col == "Age") ? 13 : 0;
            int upper = (col == "Age") ? 90 : 100;

            if (driversDataGridView.Rows[e.RowIndex].IsNewRow) return;

            if (!int.TryParse(e.FormattedValue?.ToString(), out var val)
                || val < lower || val > upper)
            {
                driversDataGridView.CancelEdit();
            }

            var bp = 0;
        }

        private void DriversList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemChanged) return;

            SkillCellUpdated.Invoke(this, e);
        }

        private void rosterComboBox_Click(object sender, EventArgs e)
        {
            //RosterComboBoxClicked.Invoke(this, e);
            var bp = 0;
        }

        private void rosterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RosterComboBoxIndexChanged.Invoke(this, e);
        }

        private void SetEmptyControlLocations()
        {
            rosterNamePanel.Location = new Point(rosterNameTextBox.Location.X - 2, rosterNameTextBox.Location.Y - 2);
            rosterNamePanel.Size = new Size(rosterNameTextBox.Size.Width + 4, rosterNameTextBox.Size.Height + 4);
        }

        public event EventHandler ViewLoaded;
        public event EventHandler SeriesRosterIndexChanged;
        public event EventHandler RosterComboBoxClicked;
        public event EventHandler RosterComboBoxIndexChanged;
        public event EventHandler UpdateSelectedDriversButtonClicked;
        public event EventHandler UpdateAllDriversButtonClicked;
        public event EventHandler SkillCellUpdated;
        public event EventHandler CreateUpdateRosterClicked;

        public IRosterPresenter Presenter { get; set; }

        public IEnumerable<string> SeriesList
        {
            set { seriesComboBox.DataSource = value.ToList(); }
        }
        public IEnumerable<string> RosterList
        {
            set { rosterComboBox.DataSource = value.ToList(); }
        }
        public DataGridViewSelectedCellCollection SelectedDrivers
        {
            get { return driversDataGridView.SelectedCells; }
        }
        public string RosterName
        {
            get { return rosterNameTextBox.Text; }
        }
        public string ExistingRosterName
        {
            get { return rosterComboBox.Text; }
        }
        public string SeriesName
        {
            get { return seriesComboBox.Text; }
        }
        public int DriverCount
        {
            get { return driverCountTrackBar.Value; }
            set { driverCountTrackBar.Value = value; }
        }
        public int RelativeSkillMin
        {
            get { return relativeSkillRangeTrackBar.LowerValue; }
            set { relativeSkillRangeTrackBar.LowerValue = value; }
        }
        public int RelativeSkillMax
        {
            get { return relativeSkillRangeTrackBar.UpperValue; }
            set { relativeSkillRangeTrackBar.UpperValue = value; }
        }
        public int AggressionMin
        {
            get { return aggressionRangeTrackBar.LowerValue; }
            set { aggressionRangeTrackBar.LowerValue = value; }
        }
        public int AggressionMax
        {
            get { return aggressionRangeTrackBar.UpperValue; }
            set { aggressionRangeTrackBar.UpperValue = value; }
        }

        public int OptimismMin
        {
            get { return optimismRangeTrackBar.LowerValue; }
            set { optimismRangeTrackBar.LowerValue = value; }
        }
        public int OptimismMax
        {
            get { return optimismRangeTrackBar.UpperValue; }
            set { optimismRangeTrackBar.UpperValue = value; }
        }
        public int SmoothnessMin
        {
            get { return smoothnessRangeTrackBar.LowerValue; }
            set { smoothnessRangeTrackBar.LowerValue = value; }
        }
        public int SmoothnessMax
        {
            get { return smoothnessRangeTrackBar.UpperValue; }
            set { smoothnessRangeTrackBar.UpperValue = value; }
        }
        public int AgeMin
        {
            get { return ageRangeTrackBar.LowerValue; }
            set { ageRangeTrackBar.LowerValue = value; }
        }
        public int AgeMax
        {
            get { return ageRangeTrackBar.UpperValue; }
            set { ageRangeTrackBar.UpperValue = value; }
        }
        public int PitCrewMin
        {
            get { return pitCrewRangeTrackBar.LowerValue; }
            set { pitCrewRangeTrackBar.LowerValue = value; }
        }
        public int PitCrewMax
        {
            get { return pitCrewRangeTrackBar.UpperValue; }
            set { pitCrewRangeTrackBar.UpperValue = value; }
        }
        public int PitStratMin
        {
            get { return pitStratRangeTrackBar.LowerValue; }
            set { pitStratRangeTrackBar.LowerValue = value; }
        }
        public int PitStratMax
        {
            get { return pitStratRangeTrackBar.UpperValue; }
            set { pitStratRangeTrackBar.UpperValue = value; }
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
        public bool MinusPlusRandomize
        {
            get { return minusPlusRadioButton.Checked; }
        }
    }
}

