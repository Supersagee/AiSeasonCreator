using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using AiSeasonCreator.ScheduleClasses;
using System.Text.Json;
using System.Reflection;
using AiSeasonCreator.JsonClasses.CarClasses;
using AiSeasonCreator.JsonClasses.CarDetails;
using AiSeasonCreator.JsonClasses.FullSchedule;
using AiSeasonCreator.JsonClasses.SeriesDetails;
using AiSeasonCreator.JsonClasses.TrackDetails;
using AiSeasonCreator.DefaultUserSettings;
using ReaLTaiizor.Controls;
using System.Diagnostics;
using AiSeasonCreator.Roster;
using static ReaLTaiizor.Controls.ExtendedPanel;
using iRacingWeatherURLParser.WeatherSchedule;

namespace AiSeasonCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var updater = new Updater();
            updater.CheckForUpdates();

            SetTheme();
            SetRedLocations();
            AboutDescription();

            versionLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            var seasonsAndSeries = SelectSeason();
            foreach (var season in seasonsAndSeries)
            {
                seasonComboBox.Items.Add(season.Season);
            }

            var cs = seasonsAndSeries[0];
            LoadJsonFiles(cs.Season, cs.Series, true);

            seasonComboBox.Text = seasonComboBox.Items[0].ToString();

            foreach (var series in IRacingService.GetAllSeries())
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
                    var trackSelection = new TrackSelectionForm();
                    trackSelection.ShowDialog();
                }

                string baseFileName = SeasonName;
                string filePath = $@"{SeasonFolderPath}\{baseFileName}.json";

                int fileCounter = 0;
                while (File.Exists(filePath))
                {
                    fileCounter++;
                    baseFileName = $"{SeasonName} ({fileCounter})";
                    filePath = $@"{SeasonFolderPath}\{baseFileName}.json";
                }

                if (fileCounter > 0)
                {
                    SeasonName = $"{SeasonName} ({fileCounter})";
                    newSeasonName = SeasonName;
                }

                var sb = IRacingService.SeasonBuilder();
                await IRacingService.SaveSeasonScheduleToJson(sb, filePath);
            }
            catch
            {
                completionString = "error";
            }

            var completion = new CompletionForm(completionString, newSeasonName, NotAvailableTracks);
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
                    var carClasses = new List<int>();

                    for (var i = 0; i < RosterFullSchedule.Length; i++)
                    {
                        if (RosterFullSchedule[i].Schedules[0].SeriesName == rosterSeriesComboBox.Text)
                        {
                            for (var j = 0; j < RosterFullSchedule[i].CarClassIds.Count; j++)
                            {
                                carClasses.Add(RosterFullSchedule[i].CarClassIds[j]);
                            }
                            break;
                        }
                    }

                    if (customCarRosterCheckBox.Checked)
                    {
                        IRacingService.CreateRoster(carClasses, customCarRosterTrackBar.Value, true);
                    }
                    else
                    {
                        var dc = 12;

                        for (var i = 0; i < RosterSeriesDetails.Length; i++)
                        {
                            if (RosterSeriesDetails[i].SeriesName == rosterSeriesComboBox.Text)
                            {
                                dc = RosterSeriesDetails[i].MaxStarters;
                                break;
                            }
                        }
                        IRacingService.CreateRoster(carClasses, dc, true);
                    }
                }
                else
                {
                    completionString = "updateRoster";
                    var roster = Path.Combine(rosterFolderPathTextBox.Text, rosterSeriesComboBox.Text, "roster.json");

                    if (File.Exists(roster))
                    {
                        IRacingService.UpdateRoster(roster);
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

        private List<SeasonsAndSeries> SelectSeason()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var seasonProp = Path.Combine(basePath, "JsonFiles", "Schedules");
            var seasonFiles = Directory.GetFiles(seasonProp);

            var seriesProp = Path.Combine(basePath, "JsonFiles", "SeriesDetails");
            var seriesFiles = Directory.GetFiles(seriesProp);

            var sAs = new List<SeasonsAndSeries>();
            for (int i = 0; i < seasonFiles.Length; i++)
            {
                var sasLoop = new SeasonsAndSeries();

                sasLoop.Season = Path.GetFileNameWithoutExtension(seasonFiles[i]);
                sasLoop.Series = Path.GetFileNameWithoutExtension(seriesFiles[i]);

                sAs.Add(sasLoop);
            }
            sAs.Reverse();

            return sAs;
        }

        private static void LoadJsonFiles(string season, string series, bool isPageLoad)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (isPageLoad)
            {
                var rosterScheduleFilePath = Path.Combine(basePath, "JsonFiles", "Schedules", $"{season}.json");
                RosterFullSchedule = JsonSerializer.Deserialize<FullSchedule[]>(File.ReadAllText(rosterScheduleFilePath));

                var rosterSeriesFilePath = Path.Combine(basePath, "JsonFiles", "SeriesDetails", $"{series}.json");
                RosterSeriesDetails = JsonSerializer.Deserialize<SeriesDetails[]>(File.ReadAllText(rosterSeriesFilePath));

                var carClassesFilePath = Path.Combine(basePath, "JsonFiles", "carClassesJson.json");
                CarClasses = JsonSerializer.Deserialize<JsonClasses.CarClasses.CarClasses[]>(File.ReadAllText(carClassesFilePath));

                var carsFilePath = Path.Combine(basePath, "JsonFiles", "carsJson.json");
                CarDetails = JsonSerializer.Deserialize<CarDetails[]>(File.ReadAllText(carsFilePath));

                var tracksFilePath = Path.Combine(basePath, "JsonFiles", "tracksJson.json");
                TrackDetails = JsonSerializer.Deserialize<TrackDetails[]>(File.ReadAllText(tracksFilePath));
            }

            var scheduleFilePath = Path.Combine(basePath, "JsonFiles", "Schedules", $"{season}.json");
            FullSchedule = JsonSerializer.Deserialize<FullSchedule[]>(File.ReadAllText(scheduleFilePath));

            var seriesFilePath = Path.Combine(basePath, "JsonFiles", "SeriesDetails", $"{series}.json");
            SeriesDetails = JsonSerializer.Deserialize<SeriesDetails[]>(File.ReadAllText(seriesFilePath));

            var weatherFilePath = Path.Combine(basePath, "JsonFiles", "WeatherSchedules", $"WeatherSchedule {season}.json");
            if (File.Exists(weatherFilePath))
            {
                WeatherSchedule = JsonSerializer.Deserialize<WeatherSchedule>(File.ReadAllText(weatherFilePath));
            }

            var bp = 1;
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

            if (SeasonName == "")
            {
                seasonNamePanel.Visible = true;
                blank = true;
            }
            else
            {
                seasonNamePanel.Visible = false;
            }

            if (SeriesName == "")
            {
                seriesPanel.Visible = true;
                blank = true;
            }
            else
            {
                seriesPanel.Visible = false;
            }

            if (CarName == "")
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
            seriesListCombo.Visible = false;
            seriesListCombo.Visible = true;

            carListCombo.Items.Clear();
            carListCombo.Text = "";
            carListCombo.Visible = false;
            carListCombo.Visible = true;
            carListCombo.Enabled = false;

            var selectedSeason = SelectSeason();

            var i = seasonComboBox.SelectedIndex;
            var season = selectedSeason[i].Season;
            var series = selectedSeason[i].Series;

            LoadJsonFiles(season, series, false);

            foreach (var item in IRacingService.GetAllSeries())
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
                useExistingRosterComboBox.Visible = false;
                useExistingRosterComboBox.Visible = true;

                excludeRosterCheckBox.Enabled = true;
                useRosterAttributesCheckBox.Enabled = true;
            }

        }

        private void whatSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            driversComboBox.Items.Clear();
            rosterSeriesComboBox.Items.Clear();
            rosterSeriesComboBox.Text = "";
            rosterSeriesComboBox.Visible = false;
            rosterSeriesComboBox.Visible = true;
            rosterSeriesComboBox.Enabled = true;
            rosterNameTextBox.Enabled = true;

            if (whatSourceComboBox.SelectedIndex == 0)
            {
                foreach (var item in IRacingService.GetAllSeries())
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
                var roster = JsonSerializer.Deserialize<DriverRoster>(File.ReadAllText(path));
                var drivers = roster.Drivers;
                driversComboBox.Items.Clear();
                driversComboBox.Items.Add("Update All Drivers");
                driversComboBox.SelectedIndex = 0;

                foreach (var driver in drivers)
                {
                    driversComboBox.Items.Add(driver.DriverName);
                }
            }
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
            SeriesName = seriesListCombo.SelectedItem.ToString();
            var carList = IRacingService.PopulateCarComboBox();
            IRacingService.CreateCarSettings();
            carListCombo.Items.Clear();
            carListCombo.Text = "";
            carListCombo.Visible = false;
            carListCombo.Visible = true;
            carListCombo.Enabled = true;

            foreach (var car in carList)
            {
                carListCombo.Items.Add(car);
            }

            if (carList.Count == 1)
            {
                carListCombo.Text = carListCombo.Items[0].ToString();
            }
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

        private void AboutDescription()
        {
            var builder = new StringBuilder();

            builder.AppendLine("The purpose of this program is to create AI seasons and rosters based on the iRacing multiplayer seasons, " +
                "along with editing existing user rosters with minimal effort.");

            builder.AppendLine("");
            builder.AppendLine("The AI seasons that are created will contain the proper tracks, cars, time/laps, etc. in order to match the multiplayer series. " +
                "All seasons will also automatically create a roster, except when the 'Exclude Roster' checkbox is checked.");

            builder.AppendLine("");
            builder.AppendLine("Individual AI rosters can also be created based on a series, and existing rosters can also be updated with different attributes. " +
                "The attribute sliders in the 'Roster' tab are min and max ranges for a particular attribute. " +
                "For example, if 'Aggression' is set to 25%-75%, all drivers in that roster will have their aggression set randomly between those percentages. " +
                "When updating a roster, unchecking an attribute will leave that particular attribute as is for all drivers.");

            builder.AppendLine("");
            builder.AppendLine("Keep in mind that some cars and tracks are not AI enabled.");

            aboutSectionLabel.Text = builder.ToString();
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
            SeasonFolderPath = seasonFolderPathTextBox.Text;
            RosterFolderPath = rosterFolderPathTextBox.Text;
            SeasonName = seasonNameTextBox.Text;
            SeriesName = seriesListCombo.Text;
            CarName = carListCombo.Text;
            AiMin = aiSkillMinTrackBar.Value;
            AiMax = aiSkillMaxTrackBar.Value;
            DisableDamage = disableCarDamageCheckBox.Checked;
            AiAvoids = aiAvoidPlayerCheckBox.Checked;
            ConsistentWeather = consistentWeatherCheckBox.Checked;
            AfternoonRaces = afternoonRacesCheckBox.Checked;
            NeverRain = neverRainsCheckBox.Checked;
            QualiAlone = qualiAloneCheckBox.Checked;
            ShortParade = shortParadeCheckBox.Checked;
            ExcludeRoster = excludeRosterCheckBox.Checked;
            UseRosterTabAtt = useRosterAttributesCheckBox.Checked;
            ExistingRosterName = useExistingRosterComboBox.Text;
            UseExistingRoster = useExistingRosterCheckBox.Checked;
            CustCarCountSeason = customCarSeasonCheckBox.Checked;
            CustCarCountValue = customCarSeasonTrackBar.Value;
        }

        private void RosterCreationSetter()
        {
            SeasonFolderPath = seasonFolderPathTextBox.Text;
            RosterFolderPath = rosterFolderPathTextBox.Text;
            RosterName = rosterNameTextBox.Text;
            DriversComboBoxName = driversComboBox.Text;
            RelateiveSkillMin = relativeSkillMinTrackBar.Value;
            RelativeSkillMax = relativeSkillMaxTrackBar.Value;
            AggressionMin = aggressionMinTrackBar.Value;
            AggressionMax = aggressionMaxTrackBar.Value;
            OptimismMin = optimismMinTrackBar.Value;
            OptimismMax = optimismMaxTrackBar.Value;
            SmoothnessMin = smoothnessMinTrackBar.Value;
            SmoothnessMax = smoothnessMaxTrackBar.Value;
            AgeMin = ageMinTrackBar.Value;
            AgeMax = ageMaxTrackBar.Value;
            PitCrewMin = pitCrewMinTrackBar.Value;
            PitCrewMax = pitCrewMaxTrackBar.Value;
            PitStratMin = pitStratMinTrackBar.Value;
            PitStratMax = pitStratMaxTrackBar.Value;
            UseRelativeSkill = relativeSkillCheckBox.Checked;
            UseAggression = aggressionCheckBox.Checked;
            UseOptimism = optimismCheckBox.Checked;
            UseSmoothness = smoothnessCheckBox.Checked;
            UseAge = ageCheckBox.Checked;
            UsePitCrew = pitCrewCheckBox.Checked;
            UsePitStrat = pitStratCheckBox.Checked;
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
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");

            if (!Directory.Exists(appSpecificFolderPath))
            {
                Directory.CreateDirectory(appSpecificFolderPath);
            }

            var ud = new UserDefaultSettings();

            ud.SettingsVersion = 1;

            ud.CheckBoxesUserValues = new CheckBoxesUserValues
            {
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

            string configFilePath = Path.Combine(appSpecificFolderPath, "UserDefaultSettings.json");
            string jsonSettings = JsonSerializer.Serialize(ud, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFilePath, jsonSettings);
        }
        private void LoadUserDefaultSettings()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSpecificFolderPath = Path.Combine(appDataFolderPath, "AiSeasonCreator");
            string udPath = Path.Combine(appSpecificFolderPath, "UserDefaultSettings.json");
            string userFolderPath = Path.Combine(appSpecificFolderPath, "AiSeasonCreatorConfig.txt");

            try
            {
                if (File.Exists(udPath))
                {
                    var ud = JsonSerializer.Deserialize<UserDefaultSettings>(File.ReadAllText(udPath));

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
                }
            }
            catch { }

            SetTrackBarValueText();
        }
        public class SeasonsAndSeries
        {
            public string Season { get; set; }
            public string Series { get; set; }
        }

        public static string? SeasonName { get; set; }
        public static string RosterName { get; set; }
        public static string? SeriesName { get; set; }
        public static string? CarName { get; set; }
        public static int? AiMin { get; set; }
        public static int? AiMax { get; set; }
        public static int RelateiveSkillMin { get; set; }
        public static int RelativeSkillMax { get; set; }
        public static int AggressionMin { get; set; }
        public static int AggressionMax { get; set; }
        public static int OptimismMin { get; set; }
        public static int OptimismMax { get; set; }
        public static int SmoothnessMin { get; set; }
        public static int SmoothnessMax { get; set; }
        public static int AgeMin { get; set; }
        public static int AgeMax { get; set; }
        public static int PitCrewMin { get; set; }
        public static int PitCrewMax { get; set; }
        public static int PitStratMin { get; set; }
        public static int PitStratMax { get; set; }
        public static string? SeasonFolderPath { get; set; }
        public static string RosterFolderPath { get; set; }
        public static bool DisableDamage { get; set; }
        public static bool AiAvoids { get; set; }
        public static bool ConsistentWeather { get; set; }
        public static bool AfternoonRaces { get; set; }
        public static bool NeverRain { get; set; }
        public static bool QualiAlone { get; set; }
        public static bool ShortParade { get; set; }
        public static bool ExcludeRoster { get; set; }
        public static bool CustCarCountSeason { get; set; }
        public static int CustCarCountValue { get; set; }
        public static string ExistingRosterName { get; set; }
        public static bool UseExistingRoster { get; set; }
        public static string DriversComboBoxName { get; set; }
        public static bool UseRosterTabAtt { get; set; }
        public static bool UseRelativeSkill { get; set; } = true;
        public static bool UseAggression { get; set; } = true;
        public static bool UseOptimism { get; set; } = true;
        public static bool UseSmoothness { get; set; } = true;
        public static bool UseAge { get; set; } = true;
        public static bool UsePitCrew { get; set; } = true;
        public static bool UsePitStrat { get; set; } = true;
        public static int SeasonSeriesIndex { get; set; }
        public static List<int>? UnselectedTracks { get; set; }
        public static JsonClasses.CarClasses.CarClasses[] CarClasses { get; set; }
        public static CarDetails[] CarDetails { get; set; }
        public static FullSchedule[] FullSchedule { get; set; }
        public static FullSchedule[] RosterFullSchedule { get; set; }
        public static SeriesDetails[] SeriesDetails { get; set; }
        public static SeriesDetails[] RosterSeriesDetails { get; set; }
        public static TrackDetails[] TrackDetails { get; set; }
        public static WeatherSchedule WeatherSchedule { get; set; }
        public static List<string> NotAvailableTracks { get; set; } = new List<string>();
    }
}