using AiSeasonCreator.ScheduleClasses;
using System.Text.Json;
using System.Reflection;
using AiSeasonCreator.DefaultUserSettings;
using ReaLTaiizor.Controls;
using System.Diagnostics;
using AiSeasonCreator.Roster;
using static ReaLTaiizor.Controls.ExtendedPanel;
using AiSeasonCreator.FormOptions;

namespace AiSeasonCreator
{
    public partial class MainForm : Form
    {
        private readonly SeasonBuilder<SeasonSchedule> _seasonBuilder;
        private readonly UserSelectedOptions _userSelectedOptions;
        private readonly JsonService _jsonService;
        private readonly SeasonService _seasonService;
        private readonly TrackSelectionForm _trackSelectionForm;
        public MainForm(
            SeasonBuilder<SeasonSchedule> seasonBuilder,
            UserSelectedOptions userSelectedOptions,
            JsonService jsonService,
            SeasonService seasonService,
            TrackSelectionForm tsf)
        {
            InitializeComponent();
            _seasonBuilder = seasonBuilder;
            _userSelectedOptions = userSelectedOptions;
            _jsonService = jsonService;
            _seasonService = seasonService;
            _trackSelectionForm = tsf;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var updater = new Updater();
            updater.CheckForUpdates();

            SetTheme();
            SetRedLocations();
            aboutSectionLabel.Text = _seasonService.AboutDescription();
            versionLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            _seasonService.ProgramLoad();

            foreach (var season in _userSelectedOptions.SeasonFileNames)
            {
                seasonComboBox.Items.Add(season);
            }

            seasonComboBox.Text = seasonComboBox.Items[0].ToString();

            foreach (var series in _seasonService.GetAllSeries())
            {
                seriesListCombo.Items.Add(series);
            }

            LoadUserDefaultSettings();
            CheckFolderPaths();
        }

        private async void createSeason_Click(object sender, EventArgs e)
        {
            SeasonCreationSetter();
            RosterCreationSetter();

            var sfawed = _userSelectedOptions.FullSchedule.FirstOrDefault(id => id.SeasonName == seriesListCombo.Text);
            if (IsSeasonFormBlank())
            {
                return;
            }

            if (useExistingRosterCheckBox.Checked && useExistingRosterComboBox.Text == "")
            {
                useExistingRosterCheckBox.Checked = false;
            }

            incompleteFormLabel.Text = "";
            var newSeasonName = "";
            var completionString = "season";

            try
            {
                if (selectTracksCheckBox.Checked)
                {
                    _trackSelectionForm.ShowDialog();
                }

                string baseFileName = _userSelectedOptions.SeasonName;
                string filePath = $@"{_userSelectedOptions.SeasonFolderPath}\{baseFileName}.json";

                int fileCounter = 0;
                while (File.Exists(filePath))
                {
                    fileCounter++;
                    baseFileName = $"{_userSelectedOptions.SeasonName} ({fileCounter})";
                    filePath = $@"{_userSelectedOptions.SeasonFolderPath}\{baseFileName}.json";
                }

                if (fileCounter > 0)
                {
                    _userSelectedOptions.SeasonName = $"{_userSelectedOptions.SeasonName} ({fileCounter})";
                    newSeasonName = _userSelectedOptions.SeasonName;
                }

                var sb = _seasonBuilder.BuildSeason();
                _jsonService.Save(filePath, sb);
            }
            catch
            {
                completionString = "error";
            }

            var completion = new CompletionForm(completionString, newSeasonName, _userSelectedOptions.NotAvailableTracks);
            completion.ShowDialog();
        }

        private void createRosterButton_Click(object sender, EventArgs e)
        {
            RosterCreationSetter();

            if (IsRosterFormBlank())
            {
                return;
            }

            var completionString = "createRoster";

            try
            {
                if (whatSourceComboBox.SelectedIndex == 0)
                {
                    _seasonService.CreateRoster(1, rosterNameTextBox.Text);
                }
                else
                {
                    completionString = "updateRoster";
                    var roster = Path.Combine(rosterFolderPathTextBox.Text, rosterSeriesComboBox.Text, "roster.json");

                    if (File.Exists(roster))
                    {
                        _seasonService.UpdateRoster(roster);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                completionString = "error";
            }

            var completion = new CompletionForm(completionString, "", new List<string> { });
            completion.ShowDialog();

        }

        private void CheckFolderPaths()
        {
            if (seasonFolderPathTextBox.Text == "Click to add folder path. iRacing\\aiseasons" || rosterFolderPathTextBox.Text == "Click to add folder path. iRacing\\airosters")
            {
                mainTabControl.SelectedTab = mainTabControl.TabPages["settingsTabPage"];
                checkFolderPathLabel.Text = "Please set the seasons and rosters folder locations";
                Blink();
            }
            else
            {
                checkFolderPathLabel.Text = "";
            }
        }

        private async void Blink()
        {
            for (var i = 0; i < 6; i++)
            {
                await Task.Delay(100);
                checkFolderPathLabel.ForeColor = checkFolderPathLabel.ForeColor == Color.FromArgb(128, 187, 0) ? Color.Black : Color.FromArgb(128, 187, 0);
            }
        }

        private bool IsSeasonFormBlank()
        {
            var blank = false;

            if (seasonNameTextBox.Text == "")
            {
                seasonNamePanel.Visible = true;
                blank = true;
            }
            else
            {
                seasonNamePanel.Visible = false;
            }

            if (seriesListCombo.Text == "")
            {
                seriesPanel.Visible = true;
                blank = true;
            }
            else
            {
                seriesPanel.Visible = false;
            }

            if (carListCombo.Text == "")
            {
                blank = true;
                carPanel.Visible = true;
            }
            else
            {
                carPanel.Visible = false;
            }

            if (seasonFolderPathTextBox.Text == "Click to add folder path. iRacing\\aiseasons" || rosterFolderPathTextBox.Text == "Click to add folder path. iRacing\\airosters")
            {
                blank = true;
            }

            return blank;
        }

        private bool IsRosterFormBlank()
        {
            var blank = false;

            if (rosterNameTextBox.Text == "")
            {
                blank = true;
                rosterNamePanel.Visible = true;
            }
            else
            {
                rosterNamePanel.Visible = false;
            }

            if (whatSourceComboBox.Text == "")
            {
                blank = true;
                whatSourcePanel.Visible = true;
            }
            else
            {
                whatSourcePanel.Visible = false;
            }

            if (rosterSeriesComboBox.Text == "")
            {
                blank = true;
                rosterSeriesPanel.Visible = true;
            }
            else
            {
                rosterSeriesPanel.Visible = false;
            }

            return blank;
        }

        private void FolderPathTextBox_Click(object sender, EventArgs e)
        {
            var fp = sender as PoisonTextBox;

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fp.Text = folderBrowserDialog.SelectedPath;
                }
            }

            CheckFolderPaths();
        }

        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            var tab = sender as PoisonTabControl;

            if (tab.SelectedTab.Name == "seasonTabPage" || tab.SelectedTab.Name == "rosterTabPage")
            {
                CheckFolderPaths();
                return;
            }
        }

        private void seasonComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            seriesListCombo.Items.Clear();
            seriesListCombo.Text = "";
            seriesListCombo.Refresh();

            carListCombo.Items.Clear();
            carListCombo.Text = "";
            carListCombo.Refresh();
            carListCombo.Enabled = false;

            var i = seasonComboBox.SelectedIndex;
            var season = _userSelectedOptions.SeasonFileNames[i];
            var series = _userSelectedOptions.SeriesFileNames[i];

            _seasonService.LoadJsonFiles(season, series, false);

            foreach (var item in _seasonService.GetAllSeries())
            {
                seriesListCombo.Items.Add(item);
            }
        }

        private void poisonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            useExistingRosterComboBox.Items.Clear();

            if (useExistingRosterCheckBox.Checked)
            {
                useExistingRosterComboBox.Enabled = true;
                excludeRosterCheckBox.Checked = false;
                excludeRosterCheckBox.Enabled = false;
                useRosterAttributesCheckBox.Checked = false;
                useRosterAttributesCheckBox.Enabled = false;

                var rosters = Directory.GetDirectories(rosterFolderPathTextBox.Text);

                foreach (var roster in rosters)
                {
                    useExistingRosterComboBox.Items.Add(Path.GetFileName(roster));
                }
            }
            else
            {
                useExistingRosterComboBox.Enabled = false;
                useExistingRosterComboBox.Text = "";
                useExistingRosterComboBox.Refresh();

                excludeRosterCheckBox.Enabled = true;
                useRosterAttributesCheckBox.Enabled = true;
            }

        }

        private void whatSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            driversComboBox.Items.Clear();
            rosterSeriesComboBox.Items.Clear();
            rosterSeriesComboBox.Text = "";
            rosterSeriesComboBox.Refresh();
            rosterSeriesComboBox.Enabled = true;
            rosterNameTextBox.Enabled = true;

            if (whatSourceComboBox.SelectedIndex == 0)
            {
                foreach (var item in _seasonService.GetAllSeries())
                {
                    rosterSeriesComboBox.Items.Add(item);
                }

                driversLabel.Visible = false;
                driversComboBox.Visible = false;
                customCarRosterPanel.Enabled = true;
                customCarRosterPanel.Visible = true;

                ShowHideAttributeCheckBoxes(false);

            }
            else
            {
                customCarRosterPanel.Enabled = false;
                customCarRosterPanel.Visible = false;
                customCarRosterCheckBox.Checked = false;
                driversLabel.Visible = true;
                driversComboBox.Visible = true;
                rosterNameTextBox.Enabled = false;
                rosterNameTextBox.Text = "";

                ShowHideAttributeCheckBoxes(true);

                var rosters = Directory.GetDirectories(rosterFolderPathTextBox.Text);

                foreach (var roster in rosters)
                {
                    rosterSeriesComboBox.Items.Add(Path.GetFileName(roster));
                }
            }
        }

        private void rosterSeriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (whatSourceComboBox.SelectedIndex == 1)
            {
                rosterNameTextBox.Text = rosterSeriesComboBox.Text;

                var path = Path.Combine(rosterFolderPathTextBox.Text, rosterSeriesComboBox.Text, "roster.json");
                var roster = _jsonService.Load<DriverRoster>(path);
                var drivers = roster.Drivers;
                driversComboBox.Items.Clear();
                driversComboBox.Items.Add("Update All Drivers");
                driversComboBox.SelectedIndex = 0;

                foreach (var driver in drivers)
                {
                    driversComboBox.Items.Add(driver.DriverName);
                }
            }

            _userSelectedOptions.RosterSeriesIndex = rosterSeriesComboBox.SelectedIndex;
        }

        private void ShowHideAttributeCheckBoxes(bool showBoxes)
        {
            if (showBoxes)
            {
                relativeSkillCheckBox.Visible = true;
                aggressionCheckBox.Visible = true;
                optimismCheckBox.Visible = true;
                smoothnessCheckBox.Visible = true;
                ageCheckBox.Visible = true;
                pitCrewCheckBox.Visible = true;
                pitStratCheckBox.Visible = true;
            }
            else
            {
                relativeSkillCheckBox.Visible = false;
                aggressionCheckBox.Visible = false;
                optimismCheckBox.Visible = false;
                smoothnessCheckBox.Visible = false;
                ageCheckBox.Visible = false;
                pitCrewCheckBox.Visible = false;
                pitStratCheckBox.Visible = false;
            }

            relativeSkillCheckBox.Checked = true;
            aggressionCheckBox.Checked = true;
            optimismCheckBox.Checked = true;
            smoothnessCheckBox.Checked = true;
            ageCheckBox.Checked = true;
            pitCrewCheckBox.Checked = true;
            pitStratCheckBox.Checked = true;
        }

        private void seriesListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userSelectedOptions.SeriesName = seriesListCombo.SelectedItem.ToString();
            var carList = _seasonService.PopulateCarComboBox();
            carListCombo.Items.Clear();
            carListCombo.Text = "";
            carListCombo.Refresh();
            carListCombo.Enabled = true;

            _seasonService.SetSelectedSeasonAndSeries(seriesListCombo.Text);

            foreach (var car in carList)
            {
                carListCombo.Items.Add(car);
            }

            if (carList.Count == 1)
            {
                carListCombo.Text = carListCombo.Items[0].ToString();
            }
        }
        private void adaptiveAiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (adaptiveAiCheckBox.Checked)
            {
                aiSkillPanel.Enabled = false;

                adaptiveAiComboBox.Enabled = true;
                adaptiveAiComboBox.Text = adaptiveAiComboBox.Items[0].ToString();
            }
            else
            {
                aiSkillPanel.Enabled = true;

                adaptiveAiComboBox.Enabled = false;
                adaptiveAiComboBox.Text = "";
            }

            adaptiveAiComboBox.Refresh();
        }
        private void aiMaxTrackBar_Scroll(object sender, EventArgs e)
        {
            MaxTrackBar(aiSkillPerLabel, aiSkillMinTrackBar, aiSkillMaxTrackBar);
        }

        private void relativeSkillMinTrackBar_Scroll(object sender, EventArgs e)
        {
            MinTrackBar(relativeSkillPerLabel, relativeSkillMinTrackBar, relativeSkillMaxTrackBar);
        }

        private void relativeSkillMaxTrackBar_Scroll(object sender, EventArgs e)
        {
            MaxTrackBar(relativeSkillPerLabel, relativeSkillMinTrackBar, relativeSkillMaxTrackBar);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void forumLinkLabel_Click(object sender, EventArgs e)
        {
            var url = "https://forums.iracing.com/discussion/40203/aiseasoncreator-make-ai-seasons-based-on-the-the-series-schedules-on-the-fly";

            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the link: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserDefaultSettings();
        }

        private void AttributesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as PoisonCheckBox;

            var minName = cb.Name.Substring(0, cb.Name.Length - 8) + "MinTrackBar";
            var maxName = cb.Name.Substring(0, cb.Name.Length - 8) + "MaxTrackBar";

            var minSlider = Controls.Find(minName, true).FirstOrDefault() as PoisonTrackBar;
            var maxSlider = Controls.Find(maxName, true).FirstOrDefault() as PoisonTrackBar;

            minSlider.Enabled = cb.Checked;
            maxSlider.Enabled = cb.Checked;
        }

        private void MinTrackBar(PoisonLabel label, PoisonTrackBar minTrack, PoisonTrackBar maxTrack)
        {
            label.Text = label.Name.StartsWith("age") ? $"{minTrack.Value}-{maxTrack.Value} years" : $"{minTrack.Value}%-{maxTrack.Value}%";

            if (minTrack.Value > maxTrack.Value)
            {
                maxTrack.Value = minTrack.Value;
                label.Text = label.Name.StartsWith("age") ? $"{minTrack.Value}-{maxTrack.Value} years" : $"{minTrack.Value}%-{maxTrack.Value}%";
            }
        }

        private void MaxTrackBar(PoisonLabel label, PoisonTrackBar minTrack, PoisonTrackBar maxTrack)
        {
            label.Text = label.Name.StartsWith("age") ? $"{minTrack.Value}-{maxTrack.Value} years" : $"{minTrack.Value}%-{maxTrack.Value}%";

            if (maxTrack.Value < minTrack.Value)
            {
                minTrack.Value = maxTrack.Value;
                label.Text = label.Name.StartsWith("age") ? $"{minTrack.Value}-{maxTrack.Value} years" : $"{minTrack.Value}%-{maxTrack.Value}%";
            }
        }

        private void TrackBar_Scroll(object sender, ScrollEventArgs e)
        {
            var slider = sender as PoisonTrackBar;
            var labelName = slider.Name.Substring(0, slider.Name.Length - 11) + "PerLabel";
            PoisonLabel label = Controls.Find(labelName, true).FirstOrDefault() as PoisonLabel;

            if (slider.Name.Contains("Min"))
            {
                var maxName = slider.Name.Replace("Min", "Max");
                PoisonTrackBar maxSlider = Controls.Find(maxName, true).FirstOrDefault() as PoisonTrackBar;
                MinTrackBar(label, slider, maxSlider);
            }
            else
            {
                var minName = slider.Name.Replace("Max", "Min");
                PoisonTrackBar minSlider = Controls.Find(minName, true).FirstOrDefault() as PoisonTrackBar;
                MaxTrackBar(label, minSlider, slider);
            }
        }

        private void customCarSeasonTrackBar_Scroll(object sender, ScrollEventArgs e)
        {
            customCarCountSeasonLabel.Text = customCarSeasonTrackBar.Value.ToString();
        }

        private void customCarRosterTrackBar_Scroll(object sender, ScrollEventArgs e)
        {
            customCarCountRosterLabel.Text = customCarRosterTrackBar.Value.ToString();
        }

        private void SetTheme()
        {
            var t = Color.Transparent;

            seasonNameLabel.BackColor = t;
            seasonLabel.BackColor = t;
            seriesListLabel.BackColor = t;
            carListLabel.BackColor = t;
            seasonFolderPathLabel.BackColor = t;
            closeButton.BackColor = t;
            minimizeButton.BackColor = t;
            forumLinkLabel.BackColor = t;
            versionLabel.BackColor = t;
        }

        private void SeasonCreationSetter()
        {
            _userSelectedOptions.SeasonFolderPath = seasonFolderPathTextBox.Text;
            _userSelectedOptions.RosterFolderPath = rosterFolderPathTextBox.Text;
            _userSelectedOptions.SeasonName = seasonNameTextBox.Text;
            _userSelectedOptions.SeriesName = seriesListCombo.Text;
            _userSelectedOptions.CarName = carListCombo.Text;
            _userSelectedOptions.UseAdaptiveAi = adaptiveAiCheckBox.Checked;
            _userSelectedOptions.AdaptiveAiSkillLevel = adaptiveAiComboBox.Text;
            _userSelectedOptions.AiMin = aiSkillMinTrackBar.Value;
            _userSelectedOptions.AiMax = aiSkillMaxTrackBar.Value;
            _userSelectedOptions.DisableDamage = disableCarDamageCheckBox.Checked;
            _userSelectedOptions.AiAvoids = aiAvoidPlayerCheckBox.Checked;
            _userSelectedOptions.StaticWeather = consistentWeatherCheckBox.Checked;
            _userSelectedOptions.AfternoonRaces = afternoonRacesCheckBox.Checked;
            _userSelectedOptions.NeverRain = neverRainsCheckBox.Checked;
            _userSelectedOptions.QualiAlone = qualiAloneCheckBox.Checked;
            _userSelectedOptions.ShortParade = shortParadeCheckBox.Checked;
            _userSelectedOptions.ExcludeRoster = excludeRosterCheckBox.Checked;
            _userSelectedOptions.UseRosterTabAtt = useRosterAttributesCheckBox.Checked;
            _userSelectedOptions.ExistingRosterName = useExistingRosterComboBox.Text;
            _userSelectedOptions.UseExistingRoster = useExistingRosterCheckBox.Checked;
            _userSelectedOptions.CustCarCountSeason = customCarSeasonCheckBox.Checked;
            _userSelectedOptions.CustCarSeasonCountValue = customCarSeasonTrackBar.Value;
        }

        private void RosterCreationSetter()
        {
            _userSelectedOptions.RosterSeriesName = rosterSeriesComboBox.Text;
            _userSelectedOptions.SeasonFolderPath = seasonFolderPathTextBox.Text;
            _userSelectedOptions.RosterFolderPath = rosterFolderPathTextBox.Text;
            _userSelectedOptions.RosterName = rosterNameTextBox.Text;
            _userSelectedOptions.DriversComboBoxName = driversComboBox.Text;
            _userSelectedOptions.RelateiveSkillMin = relativeSkillMinTrackBar.Value;
            _userSelectedOptions.RelativeSkillMax = relativeSkillMaxTrackBar.Value;
            _userSelectedOptions.AggressionMin = aggressionMinTrackBar.Value;
            _userSelectedOptions.AggressionMax = aggressionMaxTrackBar.Value;
            _userSelectedOptions.OptimismMin = optimismMinTrackBar.Value;
            _userSelectedOptions.OptimismMax = optimismMaxTrackBar.Value;
            _userSelectedOptions.SmoothnessMin = smoothnessMinTrackBar.Value;
            _userSelectedOptions.SmoothnessMax = smoothnessMaxTrackBar.Value;
            _userSelectedOptions.AgeMin = ageMinTrackBar.Value;
            _userSelectedOptions.AgeMax = ageMaxTrackBar.Value;
            _userSelectedOptions.PitCrewMin = pitCrewMinTrackBar.Value;
            _userSelectedOptions.PitCrewMax = pitCrewMaxTrackBar.Value;
            _userSelectedOptions.PitStratMin = pitStratMinTrackBar.Value;
            _userSelectedOptions.PitStratMax = pitStratMaxTrackBar.Value;
            _userSelectedOptions.UseRelativeSkill = relativeSkillCheckBox.Checked;
            _userSelectedOptions.UseAggression = aggressionCheckBox.Checked;
            _userSelectedOptions.UseOptimism = optimismCheckBox.Checked;
            _userSelectedOptions.UseSmoothness = smoothnessCheckBox.Checked;
            _userSelectedOptions.UseAge = ageCheckBox.Checked;
            _userSelectedOptions.UsePitCrew = pitCrewCheckBox.Checked;
            _userSelectedOptions.UsePitStrat = pitStratCheckBox.Checked;
            _userSelectedOptions.CustCarCountRoster = customCarRosterCheckBox.Checked;
            _userSelectedOptions.CustCarRosterCountValue = customCarRosterTrackBar.Value;
        }

        private void SetRedLocations()
        {
            seasonNamePanel.Location = new Point(seasonNameTextBox.Location.X - 2, seasonNameTextBox.Location.Y - 2);
            seasonNamePanel.Size = new Size(seasonNameTextBox.Size.Width + 4, seasonNameTextBox.Size.Height + 4);

            seriesPanel.Location = new Point(seriesListCombo.Location.X - 2, seriesListCombo.Location.Y - 2);
            seriesPanel.Size = new Size(seriesListCombo.Size.Width + 4, seriesListCombo.Size.Height + 4);

            carPanel.Location = new Point(carListCombo.Location.X - 2, carListCombo.Location.Y - 2);
            carPanel.Size = new Size(carListCombo.Size.Width + 4, carListCombo.Size.Height + 4);

            rosterNamePanel.Location = new Point(rosterNameTextBox.Location.X - 2, rosterNameTextBox.Location.Y - 2);
            rosterNamePanel.Size = new Size(rosterNameTextBox.Size.Width + 4, rosterNameTextBox.Size.Height + 4);

            whatSourcePanel.Location = new Point(whatSourceComboBox.Location.X - 2, whatSourceComboBox.Location.Y - 2);
            whatSourcePanel.Size = new Size(whatSourceComboBox.Size.Width + 4, whatSourceComboBox.Size.Height + 4);

            rosterSeriesPanel.Location = new Point(rosterSeriesComboBox.Location.X - 2, rosterSeriesComboBox.Location.Y - 2);
            rosterSeriesPanel.Size = new Size(rosterSeriesComboBox.Size.Width + 4, rosterSeriesComboBox.Size.Height + 4);
        }

        private void SetTrackBarValueText()
        {
            aiSkillPerLabel.Text = $"{aiSkillMinTrackBar.Value}%-{aiSkillMaxTrackBar.Value}%";
            customCarCountSeasonLabel.Text = $"{customCarSeasonTrackBar.Value}";
            customCarCountRosterLabel.Text = $"{customCarRosterTrackBar.Value}";
            relativeSkillPerLabel.Text = $"{relativeSkillMinTrackBar.Value}%-{relativeSkillMaxTrackBar.Value}%";
            aggressionPerLabel.Text = $"{aggressionMinTrackBar.Value}%-{aggressionMaxTrackBar.Value}%";
            optimismPerLabel.Text = $"{optimismMinTrackBar.Value}%-{optimismMaxTrackBar.Value}%";
            smoothnessPerLabel.Text = $"{smoothnessMinTrackBar.Value}%-{smoothnessMaxTrackBar.Value}%";
            agePerLabel.Text = $"{ageMinTrackBar.Value}-{ageMaxTrackBar.Value} years";
            pitCrewPerLabel.Text = $"{pitCrewMinTrackBar.Value}%-{pitCrewMaxTrackBar.Value}%";
            pitStratPerLabel.Text = $"{pitStratMinTrackBar.Value}%-{pitStratMaxTrackBar.Value}%";
        }

        private void SaveUserDefaultSettings()
        {
            var ud = new UserDefaultSettings();

            ud.SettingsVersion = 2;

            ud.CheckBoxesUserValues = new CheckBoxesUserValues
            {
                UseAdaptiveAi = adaptiveAiCheckBox.Checked,
                DisableCarDamage = disableCarDamageCheckBox.Checked,
                AiAvoidsPlayer = aiAvoidPlayerCheckBox.Checked,
                ConsistentWeather = consistentWeatherCheckBox.Checked,
                AfternoonRaces = afternoonRacesCheckBox.Checked,
                NeverRain = neverRainsCheckBox.Checked,
                QualifyAlone = qualiAloneCheckBox.Checked,
                ShortParade = shortParadeCheckBox.Checked,
                SelectTracks = selectTracksCheckBox.Checked,
                ExcludeRoster = excludeRosterCheckBox.Checked,
                UseRosterTabAtt = useRosterAttributesCheckBox.Checked
            };

            ud.ComboBoxesUserValues = new ComboBoxesUserValues
            {
                AdaptiveAiSkillLevel = adaptiveAiComboBox.Text
            };

            ud.TrackBarUserValues = new TrackBarUserValues
            {
                AiMinSkill = aiSkillMinTrackBar.Value,
                AiMaxSkill = aiSkillMaxTrackBar.Value,
                RelativeMinSkill = relativeSkillMinTrackBar.Value,
                RelativeMaxSkill = relativeSkillMaxTrackBar.Value,
                AggressionMinSkill = aggressionMinTrackBar.Value,
                AggressionMaxSkill = aggressionMaxTrackBar.Value,
                OptimismMinSkill = optimismMinTrackBar.Value,
                OptimismMaxSkill = optimismMaxTrackBar.Value,
                SmoothnessMinSkill = smoothnessMinTrackBar.Value,
                SmoothnessMaxSkill = smoothnessMaxTrackBar.Value,
                AgeMinSkill = ageMinTrackBar.Value,
                AgeMaxSkill = ageMaxTrackBar.Value,
                PitCrewMinSkill = pitCrewMinTrackBar.Value,
                PitCrewMaxSkill = pitCrewMaxTrackBar.Value,
                PitStratMinSkill = pitStratMinTrackBar.Value,
                PitStratMaxSkill = pitStratMaxTrackBar.Value
            };

            ud.FolderLocations = new FolderLocations
            {
                SeasonsFolder = seasonFolderPathTextBox.Text,
                RostersFolder = rosterFolderPathTextBox.Text
            };

            ud.WindowLocation = new WindowLocation
            {
                X = Location.X,
                Y = Location.Y
            };

            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");

            if (!Directory.Exists(appSpecificFolderPath))
            {
                Directory.CreateDirectory(appSpecificFolderPath);
            }

            string configFilePath = Path.Combine(appSpecificFolderPath, "UserDefaultSettings.json");
            _jsonService.Save<UserDefaultSettings>(configFilePath, ud);
        }
        private void LoadUserDefaultSettings()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userDefaultSettingsPath = Path.Combine(appDataFolderPath, "AiSeasonCreator", "UserDefaultSettings.json");

            try
            {
                if (File.Exists(userDefaultSettingsPath))
                {
                    var ud = _jsonService.Load<UserDefaultSettings>(userDefaultSettingsPath);

                    adaptiveAiCheckBox.Checked = ud.CheckBoxesUserValues.UseAdaptiveAi;
                    disableCarDamageCheckBox.Checked = ud.CheckBoxesUserValues.DisableCarDamage;
                    aiAvoidPlayerCheckBox.Checked = ud.CheckBoxesUserValues.AiAvoidsPlayer;
                    consistentWeatherCheckBox.Checked = ud.CheckBoxesUserValues.ConsistentWeather;
                    afternoonRacesCheckBox.Checked = ud.CheckBoxesUserValues.AfternoonRaces;
                    neverRainsCheckBox.Checked = ud.CheckBoxesUserValues.NeverRain;
                    qualiAloneCheckBox.Checked = ud.CheckBoxesUserValues.QualifyAlone;
                    selectTracksCheckBox.Checked = ud.CheckBoxesUserValues.SelectTracks;
                    shortParadeCheckBox.Checked = ud.CheckBoxesUserValues.ShortParade;
                    excludeRosterCheckBox.Checked = ud.CheckBoxesUserValues.ExcludeRoster;
                    useRosterAttributesCheckBox.Checked = ud.CheckBoxesUserValues.UseRosterTabAtt;

                    aiSkillMinTrackBar.Value = ud.TrackBarUserValues.AiMinSkill;
                    aiSkillMaxTrackBar.Value = ud.TrackBarUserValues.AiMaxSkill;
                    relativeSkillMinTrackBar.Value = ud.TrackBarUserValues.RelativeMinSkill < 0 ? 0 : ud.TrackBarUserValues.RelativeMinSkill;
                    relativeSkillMaxTrackBar.Value = ud.TrackBarUserValues.RelativeMaxSkill < 0 ? 0 : ud.TrackBarUserValues.RelativeMaxSkill;
                    aggressionMinTrackBar.Value = ud.TrackBarUserValues.AggressionMinSkill;
                    aggressionMaxTrackBar.Value = ud.TrackBarUserValues.AggressionMaxSkill;
                    optimismMinTrackBar.Value = ud.TrackBarUserValues.OptimismMinSkill;
                    optimismMaxTrackBar.Value = ud.TrackBarUserValues.OptimismMaxSkill;
                    smoothnessMinTrackBar.Value = ud.TrackBarUserValues.SmoothnessMinSkill;
                    smoothnessMaxTrackBar.Value = ud.TrackBarUserValues.SmoothnessMaxSkill;
                    ageMinTrackBar.Value = ud.TrackBarUserValues.AgeMinSkill;
                    ageMaxTrackBar.Value = ud.TrackBarUserValues.AgeMaxSkill;
                    pitCrewMinTrackBar.Value = ud.TrackBarUserValues.PitCrewMinSkill;
                    pitCrewMaxTrackBar.Value = ud.TrackBarUserValues.PitCrewMaxSkill;
                    pitStratMinTrackBar.Value = ud.TrackBarUserValues.PitStratMinSkill;
                    pitStratMaxTrackBar.Value = ud.TrackBarUserValues.PitStratMaxSkill;

                    seasonFolderPathTextBox.Text = ud.FolderLocations.SeasonsFolder;
                    rosterFolderPathTextBox.Text = ud.FolderLocations.RostersFolder;

                    Location = new Point(ud.WindowLocation.X, ud.WindowLocation.Y);

                    if (ud.SettingsVersion > 1)
                    {
                        adaptiveAiCheckBox.Checked = ud.CheckBoxesUserValues.UseAdaptiveAi;
                        adaptiveAiComboBox.Text = ud.ComboBoxesUserValues.AdaptiveAiSkillLevel;
                    }
                }
            }
            catch { }
            
            SetTrackBarValueText();
        }
    }
}