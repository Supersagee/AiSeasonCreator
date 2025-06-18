namespace AiSeasonCreator.Views
{
    partial class SeasonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeasonForm));
            aiOpponentsGroupBox = new GroupBox();
            aiSkillRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            adaptiveAiCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            adaptiveAiComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            aiSkillLevelLabel = new ReaLTaiizor.Controls.PoisonLabel();
            aiSkillPerLabel = new ReaLTaiizor.Controls.PoisonLabel();
            rosterLabel = new Label();
            rosterNameComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            optionalsGroupBox = new GroupBox();
            carCountPanel = new Panel();
            carCountValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            carCountLabel = new ReaLTaiizor.Controls.PoisonLabel();
            carCountTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            neverRainsCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            disableCarDamageCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            staticWeatherCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            afternoonRacesCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            aiAvoidPlayerCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            shortParadeCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            qualiAloneCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            createSeasonButton = new ReaLTaiizor.Controls.PoisonButton();
            seasonNameTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            messageFormLabel = new Label();
            availableTracksFlowLayoutPanel = new FlowLayoutPanel();
            trackSelectionLabel = new Label();
            sessionLengthsGroupBox = new GroupBox();
            raceMinutesOrPercentageLabel = new ReaLTaiizor.Controls.PoisonLabel();
            raceLengthValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            qualiLapsOrMinutesLabel = new ReaLTaiizor.Controls.PoisonLabel();
            qualiLengthValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            practiceMinutesLabel = new ReaLTaiizor.Controls.PoisonLabel();
            practiceLengthValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            raceLengthLabel = new ReaLTaiizor.Controls.PoisonLabel();
            qualiLengthLabel = new ReaLTaiizor.Controls.PoisonLabel();
            practiceLengthLabel = new ReaLTaiizor.Controls.PoisonLabel();
            raceLengthTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            qualiLengthTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            practiceLengthTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            seriesFlowLayoutPanel = new FlowLayoutPanel();
            carsFlowLayoutPanel = new FlowLayoutPanel();
            toolTip1 = new ToolTip(components);
            seriesSelectionLabel = new Label();
            carSelectionLabel = new Label();
            aiOpponentsGroupBox.SuspendLayout();
            optionalsGroupBox.SuspendLayout();
            carCountPanel.SuspendLayout();
            sessionLengthsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // aiOpponentsGroupBox
            // 
            aiOpponentsGroupBox.BackColor = Color.FromArgb(150, 18, 18, 27);
            aiOpponentsGroupBox.Controls.Add(aiSkillRangeTrackBar);
            aiOpponentsGroupBox.Controls.Add(adaptiveAiCheckBox);
            aiOpponentsGroupBox.Controls.Add(adaptiveAiComboBox);
            aiOpponentsGroupBox.Controls.Add(aiSkillLevelLabel);
            aiOpponentsGroupBox.Controls.Add(aiSkillPerLabel);
            aiOpponentsGroupBox.Controls.Add(rosterLabel);
            aiOpponentsGroupBox.Controls.Add(rosterNameComboBox);
            aiOpponentsGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aiOpponentsGroupBox.ForeColor = Color.White;
            aiOpponentsGroupBox.Location = new Point(429, 618);
            aiOpponentsGroupBox.Name = "aiOpponentsGroupBox";
            aiOpponentsGroupBox.Size = new Size(400, 182);
            aiOpponentsGroupBox.TabIndex = 47;
            aiOpponentsGroupBox.TabStop = false;
            aiOpponentsGroupBox.Text = "AI Opponents";
            // 
            // aiSkillRangeTrackBar
            // 
            aiSkillRangeTrackBar.BackColor = Color.FromArgb(18, 18, 27);
            aiSkillRangeTrackBar.Location = new Point(117, 68);
            aiSkillRangeTrackBar.LowerValue = 10;
            aiSkillRangeTrackBar.Maximum = 125;
            aiSkillRangeTrackBar.Minimum = 0;
            aiSkillRangeTrackBar.Name = "aiSkillRangeTrackBar";
            aiSkillRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            aiSkillRangeTrackBar.Size = new Size(260, 32);
            aiSkillRangeTrackBar.TabIndex = 90;
            aiSkillRangeTrackBar.Text = "rangeTrackBar1";
            aiSkillRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            aiSkillRangeTrackBar.ThumbHoverColor = Color.LightGray;
            aiSkillRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            aiSkillRangeTrackBar.UpperValue = 80;
            aiSkillRangeTrackBar.RangeChanged += aiSkillRangeTrackBar_RangeChanged;
            // 
            // adaptiveAiCheckBox
            // 
            adaptiveAiCheckBox.AutoSize = true;
            adaptiveAiCheckBox.BackColor = Color.Transparent;
            adaptiveAiCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            adaptiveAiCheckBox.Location = new Point(20, 25);
            adaptiveAiCheckBox.Name = "adaptiveAiCheckBox";
            adaptiveAiCheckBox.Size = new Size(96, 19);
            adaptiveAiCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            adaptiveAiCheckBox.TabIndex = 32;
            adaptiveAiCheckBox.Text = "Adaptive AI";
            adaptiveAiCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            adaptiveAiCheckBox.UseCustomBackColor = true;
            adaptiveAiCheckBox.UseCustomForeColor = true;
            adaptiveAiCheckBox.UseSelectable = true;
            adaptiveAiCheckBox.UseVisualStyleBackColor = false;
            adaptiveAiCheckBox.CheckedChanged += adaptiveAiCheckBox_CheckedChanged;
            // 
            // adaptiveAiComboBox
            // 
            adaptiveAiComboBox.BackColor = Color.FromArgb(18, 18, 27);
            adaptiveAiComboBox.DropDownHeight = 320;
            adaptiveAiComboBox.Enabled = false;
            adaptiveAiComboBox.FormattingEnabled = true;
            adaptiveAiComboBox.IntegralHeight = false;
            adaptiveAiComboBox.ItemHeight = 23;
            adaptiveAiComboBox.Items.AddRange(new object[] { "Low", "Medium", "Hard" });
            adaptiveAiComboBox.Location = new Point(122, 15);
            adaptiveAiComboBox.Name = "adaptiveAiComboBox";
            adaptiveAiComboBox.Size = new Size(255, 29);
            adaptiveAiComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            adaptiveAiComboBox.TabIndex = 31;
            adaptiveAiComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            adaptiveAiComboBox.UseCustomBackColor = true;
            adaptiveAiComboBox.UseSelectable = true;
            // 
            // aiSkillLevelLabel
            // 
            aiSkillLevelLabel.AutoSize = true;
            aiSkillLevelLabel.BackColor = Color.Transparent;
            aiSkillLevelLabel.Font = new Font("MV Boli", 9F);
            aiSkillLevelLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            aiSkillLevelLabel.Location = new Point(20, 63);
            aiSkillLevelLabel.Name = "aiSkillLevelLabel";
            aiSkillLevelLabel.Size = new Size(86, 19);
            aiSkillLevelLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            aiSkillLevelLabel.TabIndex = 27;
            aiSkillLevelLabel.Text = "Ai Skill Level:";
            aiSkillLevelLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillLevelLabel.UseCustomBackColor = true;
            aiSkillLevelLabel.UseCustomForeColor = true;
            // 
            // aiSkillPerLabel
            // 
            aiSkillPerLabel.AutoSize = true;
            aiSkillPerLabel.BackColor = Color.Transparent;
            aiSkillPerLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            aiSkillPerLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            aiSkillPerLabel.Location = new Point(20, 82);
            aiSkillPerLabel.Name = "aiSkillPerLabel";
            aiSkillPerLabel.Size = new Size(71, 19);
            aiSkillPerLabel.TabIndex = 26;
            aiSkillPerLabel.Text = "25%-50%";
            aiSkillPerLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillPerLabel.UseCustomBackColor = true;
            aiSkillPerLabel.UseCustomForeColor = true;
            // 
            // rosterLabel
            // 
            rosterLabel.AutoSize = true;
            rosterLabel.BackColor = Color.Transparent;
            rosterLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rosterLabel.ForeColor = Color.White;
            rosterLabel.Location = new Point(20, 112);
            rosterLabel.Name = "rosterLabel";
            rosterLabel.Size = new Size(43, 15);
            rosterLabel.TabIndex = 51;
            rosterLabel.Text = "Roster";
            // 
            // rosterNameComboBox
            // 
            rosterNameComboBox.BackColor = Color.FromArgb(18, 18, 27);
            rosterNameComboBox.DropDownHeight = 260;
            rosterNameComboBox.ForeColor = Color.White;
            rosterNameComboBox.FormattingEnabled = true;
            rosterNameComboBox.IntegralHeight = false;
            rosterNameComboBox.ItemHeight = 23;
            rosterNameComboBox.Location = new Point(20, 130);
            rosterNameComboBox.Name = "rosterNameComboBox";
            rosterNameComboBox.Size = new Size(357, 29);
            rosterNameComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            rosterNameComboBox.TabIndex = 21;
            rosterNameComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            rosterNameComboBox.UseCustomBackColor = true;
            rosterNameComboBox.UseCustomForeColor = true;
            rosterNameComboBox.UseSelectable = true;
            rosterNameComboBox.Click += rosterNameComboBox_Click;
            // 
            // optionalsGroupBox
            // 
            optionalsGroupBox.BackColor = Color.FromArgb(150, 18, 18, 27);
            optionalsGroupBox.Controls.Add(carCountPanel);
            optionalsGroupBox.Controls.Add(neverRainsCheckBox);
            optionalsGroupBox.Controls.Add(disableCarDamageCheckBox);
            optionalsGroupBox.Controls.Add(staticWeatherCheckBox);
            optionalsGroupBox.Controls.Add(afternoonRacesCheckBox);
            optionalsGroupBox.Controls.Add(aiAvoidPlayerCheckBox);
            optionalsGroupBox.Controls.Add(shortParadeCheckBox);
            optionalsGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionalsGroupBox.ForeColor = Color.White;
            optionalsGroupBox.Location = new Point(846, 618);
            optionalsGroupBox.Name = "optionalsGroupBox";
            optionalsGroupBox.Size = new Size(400, 182);
            optionalsGroupBox.TabIndex = 39;
            optionalsGroupBox.TabStop = false;
            optionalsGroupBox.Text = "Optionals";
            // 
            // carCountPanel
            // 
            carCountPanel.BackColor = Color.FromArgb(80, 30, 30, 30);
            carCountPanel.Controls.Add(carCountValueLabel);
            carCountPanel.Controls.Add(carCountLabel);
            carCountPanel.Controls.Add(carCountTrackBar);
            carCountPanel.Location = new Point(6, 20);
            carCountPanel.Name = "carCountPanel";
            carCountPanel.Size = new Size(382, 28);
            carCountPanel.TabIndex = 51;
            // 
            // carCountValueLabel
            // 
            carCountValueLabel.AutoSize = true;
            carCountValueLabel.BackColor = Color.Transparent;
            carCountValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            carCountValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            carCountValueLabel.Location = new Point(87, 3);
            carCountValueLabel.Name = "carCountValueLabel";
            carCountValueLabel.Size = new Size(25, 19);
            carCountValueLabel.TabIndex = 26;
            carCountValueLabel.Text = "30";
            carCountValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carCountValueLabel.UseCustomBackColor = true;
            carCountValueLabel.UseCustomForeColor = true;
            // 
            // carCountLabel
            // 
            carCountLabel.AutoSize = true;
            carCountLabel.BackColor = Color.Transparent;
            carCountLabel.Font = new Font("MV Boli", 9F);
            carCountLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            carCountLabel.Location = new Point(9, 2);
            carCountLabel.Name = "carCountLabel";
            carCountLabel.Size = new Size(72, 19);
            carCountLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            carCountLabel.TabIndex = 27;
            carCountLabel.Text = "Car Count";
            carCountLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carCountLabel.UseCustomBackColor = true;
            carCountLabel.UseCustomForeColor = true;
            // 
            // carCountTrackBar
            // 
            carCountTrackBar.BackColor = Color.Transparent;
            carCountTrackBar.Location = new Point(114, 5);
            carCountTrackBar.Maximum = 60;
            carCountTrackBar.Minimum = 12;
            carCountTrackBar.Name = "carCountTrackBar";
            carCountTrackBar.Size = new Size(260, 16);
            carCountTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            carCountTrackBar.TabIndex = 8;
            carCountTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carCountTrackBar.UseCustomBackColor = true;
            carCountTrackBar.Value = 30;
            carCountTrackBar.ValueChanged += carCountTrackBar_ValueChanged;
            // 
            // neverRainsCheckBox
            // 
            neverRainsCheckBox.AutoSize = true;
            neverRainsCheckBox.BackColor = Color.Transparent;
            neverRainsCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            neverRainsCheckBox.Location = new Point(221, 98);
            neverRainsCheckBox.Name = "neverRainsCheckBox";
            neverRainsCheckBox.Size = new Size(97, 19);
            neverRainsCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            neverRainsCheckBox.TabIndex = 15;
            neverRainsCheckBox.Text = "Never Rains";
            neverRainsCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            neverRainsCheckBox.UseCustomBackColor = true;
            neverRainsCheckBox.UseCustomForeColor = true;
            neverRainsCheckBox.UseSelectable = true;
            neverRainsCheckBox.UseVisualStyleBackColor = false;
            // 
            // disableCarDamageCheckBox
            // 
            disableCarDamageCheckBox.AutoSize = true;
            disableCarDamageCheckBox.BackColor = Color.Transparent;
            disableCarDamageCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            disableCarDamageCheckBox.Location = new Point(10, 60);
            disableCarDamageCheckBox.Name = "disableCarDamageCheckBox";
            disableCarDamageCheckBox.Size = new Size(149, 19);
            disableCarDamageCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            disableCarDamageCheckBox.TabIndex = 9;
            disableCarDamageCheckBox.Text = "Disable Car Damage";
            disableCarDamageCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            disableCarDamageCheckBox.UseCustomBackColor = true;
            disableCarDamageCheckBox.UseCustomForeColor = true;
            disableCarDamageCheckBox.UseSelectable = true;
            disableCarDamageCheckBox.UseVisualStyleBackColor = false;
            // 
            // staticWeatherCheckBox
            // 
            staticWeatherCheckBox.AutoSize = true;
            staticWeatherCheckBox.BackColor = Color.Transparent;
            staticWeatherCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            staticWeatherCheckBox.Location = new Point(10, 98);
            staticWeatherCheckBox.Name = "staticWeatherCheckBox";
            staticWeatherCheckBox.Size = new Size(113, 19);
            staticWeatherCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            staticWeatherCheckBox.TabIndex = 11;
            staticWeatherCheckBox.Text = "Static Weather";
            staticWeatherCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            staticWeatherCheckBox.UseCustomBackColor = true;
            staticWeatherCheckBox.UseCustomForeColor = true;
            staticWeatherCheckBox.UseSelectable = true;
            staticWeatherCheckBox.UseVisualStyleBackColor = false;
            // 
            // afternoonRacesCheckBox
            // 
            afternoonRacesCheckBox.AutoSize = true;
            afternoonRacesCheckBox.BackColor = Color.Transparent;
            afternoonRacesCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            afternoonRacesCheckBox.Location = new Point(10, 136);
            afternoonRacesCheckBox.Name = "afternoonRacesCheckBox";
            afternoonRacesCheckBox.Size = new Size(125, 19);
            afternoonRacesCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            afternoonRacesCheckBox.TabIndex = 13;
            afternoonRacesCheckBox.Text = "Afternoon Races";
            afternoonRacesCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            afternoonRacesCheckBox.UseCustomBackColor = true;
            afternoonRacesCheckBox.UseCustomForeColor = true;
            afternoonRacesCheckBox.UseSelectable = true;
            afternoonRacesCheckBox.UseVisualStyleBackColor = false;
            // 
            // aiAvoidPlayerCheckBox
            // 
            aiAvoidPlayerCheckBox.AutoSize = true;
            aiAvoidPlayerCheckBox.BackColor = Color.Transparent;
            aiAvoidPlayerCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            aiAvoidPlayerCheckBox.Location = new Point(221, 60);
            aiAvoidPlayerCheckBox.Name = "aiAvoidPlayerCheckBox";
            aiAvoidPlayerCheckBox.Size = new Size(124, 19);
            aiAvoidPlayerCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiAvoidPlayerCheckBox.TabIndex = 10;
            aiAvoidPlayerCheckBox.Text = "AI Avoids Player";
            aiAvoidPlayerCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiAvoidPlayerCheckBox.UseCustomBackColor = true;
            aiAvoidPlayerCheckBox.UseCustomForeColor = true;
            aiAvoidPlayerCheckBox.UseSelectable = true;
            aiAvoidPlayerCheckBox.UseVisualStyleBackColor = false;
            // 
            // shortParadeCheckBox
            // 
            shortParadeCheckBox.AutoSize = true;
            shortParadeCheckBox.BackColor = Color.Transparent;
            shortParadeCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            shortParadeCheckBox.Location = new Point(221, 136);
            shortParadeCheckBox.Name = "shortParadeCheckBox";
            shortParadeCheckBox.Size = new Size(130, 19);
            shortParadeCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            shortParadeCheckBox.TabIndex = 17;
            shortParadeCheckBox.Text = "Short Parade Lap";
            shortParadeCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            shortParadeCheckBox.UseCustomBackColor = true;
            shortParadeCheckBox.UseCustomForeColor = true;
            shortParadeCheckBox.UseSelectable = true;
            shortParadeCheckBox.UseVisualStyleBackColor = false;
            // 
            // qualiAloneCheckBox
            // 
            qualiAloneCheckBox.AutoSize = true;
            qualiAloneCheckBox.BackColor = Color.Transparent;
            qualiAloneCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            qualiAloneCheckBox.Location = new Point(242, 73);
            qualiAloneCheckBox.Name = "qualiAloneCheckBox";
            qualiAloneCheckBox.Size = new Size(107, 19);
            qualiAloneCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            qualiAloneCheckBox.TabIndex = 12;
            qualiAloneCheckBox.Text = "Qualify Alone";
            qualiAloneCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiAloneCheckBox.UseCustomBackColor = true;
            qualiAloneCheckBox.UseCustomForeColor = true;
            qualiAloneCheckBox.UseSelectable = true;
            qualiAloneCheckBox.UseVisualStyleBackColor = false;
            qualiAloneCheckBox.CheckedChanged += qualiAloneCheckBox_CheckedChanged;
            // 
            // createSeasonButton
            // 
            createSeasonButton.BackColor = Color.FromArgb(18, 18, 27);
            createSeasonButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createSeasonButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Tall;
            createSeasonButton.Highlight = true;
            createSeasonButton.Location = new Point(536, 856);
            createSeasonButton.Name = "createSeasonButton";
            createSeasonButton.Size = new Size(204, 62);
            createSeasonButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            createSeasonButton.TabIndex = 41;
            createSeasonButton.Text = "Create Season";
            createSeasonButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            createSeasonButton.UseCustomBackColor = true;
            createSeasonButton.UseSelectable = true;
            createSeasonButton.UseVisualStyleBackColor = false;
            createSeasonButton.Click += createSeasonButton_Click;
            // 
            // seasonNameTextBox
            // 
            seasonNameTextBox.BackColor = Color.FromArgb(18, 18, 27);
            // 
            // 
            // 
            seasonNameTextBox.CustomButton.Image = null;
            seasonNameTextBox.CustomButton.Location = new Point(372, 1);
            seasonNameTextBox.CustomButton.Name = "";
            seasonNameTextBox.CustomButton.Size = new Size(27, 27);
            seasonNameTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            seasonNameTextBox.CustomButton.TabIndex = 1;
            seasonNameTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            seasonNameTextBox.CustomButton.UseSelectable = true;
            seasonNameTextBox.CustomButton.Visible = false;
            seasonNameTextBox.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seasonNameTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Tall;
            seasonNameTextBox.ForeColor = Color.White;
            seasonNameTextBox.Location = new Point(429, 817);
            seasonNameTextBox.MaxLength = 32767;
            seasonNameTextBox.Name = "seasonNameTextBox";
            seasonNameTextBox.PasswordChar = '\0';
            seasonNameTextBox.PromptText = "SeasonName";
            seasonNameTextBox.ScrollBars = ScrollBars.None;
            seasonNameTextBox.SelectedText = "";
            seasonNameTextBox.SelectionLength = 0;
            seasonNameTextBox.SelectionStart = 0;
            seasonNameTextBox.ShortcutsEnabled = true;
            seasonNameTextBox.Size = new Size(400, 29);
            seasonNameTextBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seasonNameTextBox.TabIndex = 33;
            seasonNameTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seasonNameTextBox.UseCustomBackColor = true;
            seasonNameTextBox.UseCustomForeColor = true;
            seasonNameTextBox.UseSelectable = true;
            seasonNameTextBox.WaterMark = "SeasonName";
            seasonNameTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            seasonNameTextBox.WaterMarkFont = new Font("Segoe UI", 16F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // messageFormLabel
            // 
            messageFormLabel.AutoSize = true;
            messageFormLabel.BackColor = Color.Transparent;
            messageFormLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageFormLabel.ForeColor = Color.FromArgb(128, 187, 0);
            messageFormLabel.Location = new Point(753, 876);
            messageFormLabel.Name = "messageFormLabel";
            messageFormLabel.Size = new Size(150, 20);
            messageFormLabel.TabIndex = 42;
            messageFormLabel.Text = "messageFormLabel";
            // 
            // availableTracksFlowLayoutPanel
            // 
            availableTracksFlowLayoutPanel.AutoScroll = true;
            availableTracksFlowLayoutPanel.BackColor = Color.FromArgb(150, 18, 18, 27);
            availableTracksFlowLayoutPanel.Location = new Point(846, 41);
            availableTracksFlowLayoutPanel.Name = "availableTracksFlowLayoutPanel";
            availableTracksFlowLayoutPanel.Size = new Size(400, 570);
            availableTracksFlowLayoutPanel.TabIndex = 49;
            // 
            // trackSelectionLabel
            // 
            trackSelectionLabel.AutoSize = true;
            trackSelectionLabel.BackColor = Color.Transparent;
            trackSelectionLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            trackSelectionLabel.ForeColor = Color.White;
            trackSelectionLabel.Location = new Point(846, 9);
            trackSelectionLabel.Name = "trackSelectionLabel";
            trackSelectionLabel.Size = new Size(140, 24);
            trackSelectionLabel.TabIndex = 50;
            trackSelectionLabel.Text = "Track Selection";
            // 
            // sessionLengthsGroupBox
            // 
            sessionLengthsGroupBox.BackColor = Color.FromArgb(150, 18, 18, 27);
            sessionLengthsGroupBox.Controls.Add(raceMinutesOrPercentageLabel);
            sessionLengthsGroupBox.Controls.Add(raceLengthValueLabel);
            sessionLengthsGroupBox.Controls.Add(qualiLapsOrMinutesLabel);
            sessionLengthsGroupBox.Controls.Add(qualiLengthValueLabel);
            sessionLengthsGroupBox.Controls.Add(practiceMinutesLabel);
            sessionLengthsGroupBox.Controls.Add(practiceLengthValueLabel);
            sessionLengthsGroupBox.Controls.Add(qualiAloneCheckBox);
            sessionLengthsGroupBox.Controls.Add(raceLengthLabel);
            sessionLengthsGroupBox.Controls.Add(qualiLengthLabel);
            sessionLengthsGroupBox.Controls.Add(practiceLengthLabel);
            sessionLengthsGroupBox.Controls.Add(raceLengthTrackBar);
            sessionLengthsGroupBox.Controls.Add(qualiLengthTrackBar);
            sessionLengthsGroupBox.Controls.Add(practiceLengthTrackBar);
            sessionLengthsGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sessionLengthsGroupBox.ForeColor = Color.White;
            sessionLengthsGroupBox.Location = new Point(12, 618);
            sessionLengthsGroupBox.Name = "sessionLengthsGroupBox";
            sessionLengthsGroupBox.Size = new Size(400, 182);
            sessionLengthsGroupBox.TabIndex = 52;
            sessionLengthsGroupBox.TabStop = false;
            sessionLengthsGroupBox.Text = "Session Lengths";
            // 
            // raceMinutesOrPercentageLabel
            // 
            raceMinutesOrPercentageLabel.AutoSize = true;
            raceMinutesOrPercentageLabel.BackColor = Color.Transparent;
            raceMinutesOrPercentageLabel.Font = new Font("MV Boli", 9F);
            raceMinutesOrPercentageLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            raceMinutesOrPercentageLabel.Location = new Point(121, 126);
            raceMinutesOrPercentageLabel.Name = "raceMinutesOrPercentageLabel";
            raceMinutesOrPercentageLabel.Size = new Size(59, 19);
            raceMinutesOrPercentageLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            raceMinutesOrPercentageLabel.TabIndex = 36;
            raceMinutesOrPercentageLabel.Text = "Minutes";
            raceMinutesOrPercentageLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            raceMinutesOrPercentageLabel.UseCustomBackColor = true;
            raceMinutesOrPercentageLabel.UseCustomForeColor = true;
            // 
            // raceLengthValueLabel
            // 
            raceLengthValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            raceLengthValueLabel.BackColor = Color.Transparent;
            raceLengthValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            raceLengthValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            raceLengthValueLabel.Location = new Point(91, 126);
            raceLengthValueLabel.Name = "raceLengthValueLabel";
            raceLengthValueLabel.Size = new Size(33, 19);
            raceLengthValueLabel.TabIndex = 35;
            raceLengthValueLabel.Text = "8";
            raceLengthValueLabel.TextAlign = ContentAlignment.MiddleRight;
            raceLengthValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            raceLengthValueLabel.UseCustomBackColor = true;
            raceLengthValueLabel.UseCustomForeColor = true;
            // 
            // qualiLapsOrMinutesLabel
            // 
            qualiLapsOrMinutesLabel.AutoSize = true;
            qualiLapsOrMinutesLabel.BackColor = Color.Transparent;
            qualiLapsOrMinutesLabel.Font = new Font("MV Boli", 9F);
            qualiLapsOrMinutesLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            qualiLapsOrMinutesLabel.Location = new Point(151, 73);
            qualiLapsOrMinutesLabel.Name = "qualiLapsOrMinutesLabel";
            qualiLapsOrMinutesLabel.Size = new Size(59, 19);
            qualiLapsOrMinutesLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            qualiLapsOrMinutesLabel.TabIndex = 34;
            qualiLapsOrMinutesLabel.Text = "Minutes";
            qualiLapsOrMinutesLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiLapsOrMinutesLabel.UseCustomBackColor = true;
            qualiLapsOrMinutesLabel.UseCustomForeColor = true;
            // 
            // qualiLengthValueLabel
            // 
            qualiLengthValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            qualiLengthValueLabel.BackColor = Color.Transparent;
            qualiLengthValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            qualiLengthValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            qualiLengthValueLabel.Location = new Point(121, 73);
            qualiLengthValueLabel.Name = "qualiLengthValueLabel";
            qualiLengthValueLabel.Size = new Size(33, 19);
            qualiLengthValueLabel.TabIndex = 33;
            qualiLengthValueLabel.Text = "8";
            qualiLengthValueLabel.TextAlign = ContentAlignment.MiddleRight;
            qualiLengthValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiLengthValueLabel.UseCustomBackColor = true;
            qualiLengthValueLabel.UseCustomForeColor = true;
            // 
            // practiceMinutesLabel
            // 
            practiceMinutesLabel.AutoSize = true;
            practiceMinutesLabel.BackColor = Color.Transparent;
            practiceMinutesLabel.Font = new Font("MV Boli", 9F);
            practiceMinutesLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            practiceMinutesLabel.Location = new Point(134, 24);
            practiceMinutesLabel.Name = "practiceMinutesLabel";
            practiceMinutesLabel.Size = new Size(59, 19);
            practiceMinutesLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            practiceMinutesLabel.TabIndex = 32;
            practiceMinutesLabel.Text = "Minutes";
            practiceMinutesLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            practiceMinutesLabel.UseCustomBackColor = true;
            practiceMinutesLabel.UseCustomForeColor = true;
            // 
            // practiceLengthValueLabel
            // 
            practiceLengthValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            practiceLengthValueLabel.BackColor = Color.Transparent;
            practiceLengthValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            practiceLengthValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            practiceLengthValueLabel.Location = new Point(105, 24);
            practiceLengthValueLabel.Name = "practiceLengthValueLabel";
            practiceLengthValueLabel.Size = new Size(33, 19);
            practiceLengthValueLabel.TabIndex = 31;
            practiceLengthValueLabel.Text = "3";
            practiceLengthValueLabel.TextAlign = ContentAlignment.MiddleRight;
            practiceLengthValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            practiceLengthValueLabel.UseCustomBackColor = true;
            practiceLengthValueLabel.UseCustomForeColor = true;
            // 
            // raceLengthLabel
            // 
            raceLengthLabel.AutoSize = true;
            raceLengthLabel.BackColor = Color.Transparent;
            raceLengthLabel.Font = new Font("MV Boli", 9F);
            raceLengthLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            raceLengthLabel.Location = new Point(50, 126);
            raceLengthLabel.Name = "raceLengthLabel";
            raceLengthLabel.Size = new Size(40, 19);
            raceLengthLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            raceLengthLabel.TabIndex = 30;
            raceLengthLabel.Text = "Race:";
            raceLengthLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            raceLengthLabel.UseCustomBackColor = true;
            raceLengthLabel.UseCustomForeColor = true;
            // 
            // qualiLengthLabel
            // 
            qualiLengthLabel.AutoSize = true;
            qualiLengthLabel.BackColor = Color.Transparent;
            qualiLengthLabel.Font = new Font("MV Boli", 9F);
            qualiLengthLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            qualiLengthLabel.Location = new Point(50, 73);
            qualiLengthLabel.Name = "qualiLengthLabel";
            qualiLengthLabel.Size = new Size(74, 19);
            qualiLengthLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            qualiLengthLabel.TabIndex = 29;
            qualiLengthLabel.Text = "Qualifying:";
            qualiLengthLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiLengthLabel.UseCustomBackColor = true;
            qualiLengthLabel.UseCustomForeColor = true;
            // 
            // practiceLengthLabel
            // 
            practiceLengthLabel.AutoSize = true;
            practiceLengthLabel.BackColor = Color.Transparent;
            practiceLengthLabel.Font = new Font("MV Boli", 9F);
            practiceLengthLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            practiceLengthLabel.Location = new Point(50, 24);
            practiceLengthLabel.Name = "practiceLengthLabel";
            practiceLengthLabel.Size = new Size(59, 19);
            practiceLengthLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            practiceLengthLabel.TabIndex = 28;
            practiceLengthLabel.Text = "Practice:";
            practiceLengthLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            practiceLengthLabel.UseCustomBackColor = true;
            practiceLengthLabel.UseCustomForeColor = true;
            // 
            // raceLengthTrackBar
            // 
            raceLengthTrackBar.BackColor = Color.Transparent;
            raceLengthTrackBar.Location = new Point(50, 150);
            raceLengthTrackBar.Maximum = 300;
            raceLengthTrackBar.Minimum = 10;
            raceLengthTrackBar.Name = "raceLengthTrackBar";
            raceLengthTrackBar.Size = new Size(299, 16);
            raceLengthTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            raceLengthTrackBar.TabIndex = 8;
            raceLengthTrackBar.Text = "poisonTrackBar1";
            raceLengthTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            raceLengthTrackBar.UseCustomBackColor = true;
            raceLengthTrackBar.Value = 25;
            raceLengthTrackBar.ValueChanged += raceLengthTrackBar_ValueChanged;
            // 
            // qualiLengthTrackBar
            // 
            qualiLengthTrackBar.BackColor = Color.Transparent;
            qualiLengthTrackBar.Location = new Point(50, 98);
            qualiLengthTrackBar.Maximum = 30;
            qualiLengthTrackBar.Name = "qualiLengthTrackBar";
            qualiLengthTrackBar.Size = new Size(300, 16);
            qualiLengthTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            qualiLengthTrackBar.TabIndex = 7;
            qualiLengthTrackBar.Text = "poisonTrackBar1";
            qualiLengthTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiLengthTrackBar.UseCustomBackColor = true;
            qualiLengthTrackBar.Value = 8;
            qualiLengthTrackBar.ValueChanged += qualiLengthTrackBar_ValueChanged;
            // 
            // practiceLengthTrackBar
            // 
            practiceLengthTrackBar.BackColor = Color.Transparent;
            practiceLengthTrackBar.Location = new Point(50, 46);
            practiceLengthTrackBar.Maximum = 120;
            practiceLengthTrackBar.Name = "practiceLengthTrackBar";
            practiceLengthTrackBar.Size = new Size(299, 16);
            practiceLengthTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            practiceLengthTrackBar.TabIndex = 6;
            practiceLengthTrackBar.Text = "poisonTrackBar1";
            practiceLengthTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            practiceLengthTrackBar.UseCustomBackColor = true;
            practiceLengthTrackBar.Value = 3;
            practiceLengthTrackBar.ValueChanged += practiceLengthTrackBar_ValueChanged;
            // 
            // seriesFlowLayoutPanel
            // 
            seriesFlowLayoutPanel.AutoScroll = true;
            seriesFlowLayoutPanel.BackColor = Color.FromArgb(150, 18, 18, 27);
            seriesFlowLayoutPanel.Location = new Point(12, 41);
            seriesFlowLayoutPanel.Name = "seriesFlowLayoutPanel";
            seriesFlowLayoutPanel.Size = new Size(400, 570);
            seriesFlowLayoutPanel.TabIndex = 54;
            // 
            // carsFlowLayoutPanel
            // 
            carsFlowLayoutPanel.AutoScroll = true;
            carsFlowLayoutPanel.BackColor = Color.FromArgb(150, 18, 18, 27);
            carsFlowLayoutPanel.Location = new Point(429, 41);
            carsFlowLayoutPanel.Name = "carsFlowLayoutPanel";
            carsFlowLayoutPanel.Size = new Size(400, 570);
            carsFlowLayoutPanel.TabIndex = 55;
            // 
            // seriesSelectionLabel
            // 
            seriesSelectionLabel.AutoSize = true;
            seriesSelectionLabel.BackColor = Color.Transparent;
            seriesSelectionLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seriesSelectionLabel.ForeColor = Color.White;
            seriesSelectionLabel.Location = new Point(12, 9);
            seriesSelectionLabel.Name = "seriesSelectionLabel";
            seriesSelectionLabel.Size = new Size(146, 24);
            seriesSelectionLabel.TabIndex = 56;
            seriesSelectionLabel.Text = "Series Selection";
            // 
            // carSelectionLabel
            // 
            carSelectionLabel.AutoSize = true;
            carSelectionLabel.BackColor = Color.Transparent;
            carSelectionLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            carSelectionLabel.ForeColor = Color.White;
            carSelectionLabel.Location = new Point(429, 9);
            carSelectionLabel.Name = "carSelectionLabel";
            carSelectionLabel.Size = new Size(122, 24);
            carSelectionLabel.TabIndex = 57;
            carSelectionLabel.Text = "Car Selection";
            // 
            // SeasonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1260, 930);
            Controls.Add(carSelectionLabel);
            Controls.Add(seriesSelectionLabel);
            Controls.Add(carsFlowLayoutPanel);
            Controls.Add(seriesFlowLayoutPanel);
            Controls.Add(sessionLengthsGroupBox);
            Controls.Add(trackSelectionLabel);
            Controls.Add(availableTracksFlowLayoutPanel);
            Controls.Add(aiOpponentsGroupBox);
            Controls.Add(optionalsGroupBox);
            Controls.Add(createSeasonButton);
            Controls.Add(seasonNameTextBox);
            Controls.Add(messageFormLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SeasonForm";
            Text = "SeasonForm";
            Load += SeasonForm_Load;
            aiOpponentsGroupBox.ResumeLayout(false);
            aiOpponentsGroupBox.PerformLayout();
            optionalsGroupBox.ResumeLayout(false);
            optionalsGroupBox.PerformLayout();
            carCountPanel.ResumeLayout(false);
            carCountPanel.PerformLayout();
            sessionLengthsGroupBox.ResumeLayout(false);
            sessionLengthsGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox aiOpponentsGroupBox;
        private ReaLTaiizor.Controls.PoisonCheckBox adaptiveAiCheckBox;
        private ReaLTaiizor.Controls.PoisonComboBox adaptiveAiComboBox;
        private ReaLTaiizor.Controls.PoisonLabel aiSkillPerLabel;
        private ReaLTaiizor.Controls.PoisonLabel aiSkillLevelLabel;
        private GroupBox optionalsGroupBox;
        private ReaLTaiizor.Controls.PoisonCheckBox neverRainsCheckBox;
        private ReaLTaiizor.Controls.PoisonComboBox rosterNameComboBox;
        private ReaLTaiizor.Controls.PoisonCheckBox customCarSeasonCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox useExistingRosterCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox useRosterAttributesCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox disableCarDamageCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox excludeRosterCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox staticWeatherCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox afternoonRacesCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox aiAvoidPlayerCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox qualiAloneCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox shortParadeCheckBox;
        private ReaLTaiizor.Controls.PoisonButton createSeasonButton;
        private ReaLTaiizor.Controls.PoisonTextBox seasonNameTextBox;
        private Label messageFormLabel;
        private FlowLayoutPanel availableTracksFlowLayoutPanel;
        private Label trackSelectionLabel;
        private ReaLTaiizor.Controls.PoisonLabel carCountLabel;
        private ReaLTaiizor.Controls.PoisonLabel carCountValueLabel;
        private ReaLTaiizor.Controls.PoisonTrackBar carCountTrackBar;
        private Panel carCountPanel;
        private Label rosterLabel;
        private GroupBox sessionLengthsGroupBox;
        private ReaLTaiizor.Controls.PoisonTrackBar raceLengthTrackBar;
        private ReaLTaiizor.Controls.PoisonTrackBar qualiLengthTrackBar;
        private ReaLTaiizor.Controls.PoisonTrackBar practiceLengthTrackBar;
        private ReaLTaiizor.Controls.PoisonLabel raceLengthLabel;
        private ReaLTaiizor.Controls.PoisonLabel qualiLengthLabel;
        private ReaLTaiizor.Controls.PoisonLabel practiceLengthLabel;
        private FlowLayoutPanel seriesFlowLayoutPanel;
        private FlowLayoutPanel carsFlowLayoutPanel;
        private ToolTip toolTip1;
        private Label seriesSelectionLabel;
        private Label carSelectionLabel;
        private ReaLTaiizor.Controls.PoisonLabel practiceLengthValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel practiceMinutesLabel;
        private ReaLTaiizor.Controls.PoisonLabel qualiLapsOrMinutesLabel;
        private ReaLTaiizor.Controls.PoisonLabel qualiLengthValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel raceMinutesOrPercentageLabel;
        private ReaLTaiizor.Controls.PoisonLabel raceLengthValueLabel;
        private Helpers.RangeTrackBar aiSkillRangeTrackBar;
    }
}