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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeasonForm));
            aiSkillGroupBox = new GroupBox();
            adaptiveAiCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            adaptiveAiComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            aiSkillPanel = new Panel();
            aiSkillMinTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            aiSkillMaxTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            aiSkillPerLabel = new ReaLTaiizor.Controls.PoisonLabel();
            aiSkillLevelLabel = new ReaLTaiizor.Controls.PoisonLabel();
            groupBox1 = new GroupBox();
            neverRainsCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            rosterNameComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            panel1 = new Panel();
            carCountValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            carCountLabel = new ReaLTaiizor.Controls.PoisonLabel();
            carCountTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            disableCarDamageCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            staticWeatherCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            afternoonRacesCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            aiAvoidPlayerCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            selectTracksCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            qualiAloneCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            shortParadeCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            createSeasonButton = new ReaLTaiizor.Controls.PoisonButton();
            carListCombo = new ReaLTaiizor.Controls.PoisonComboBox();
            seriesListCombo = new ReaLTaiizor.Controls.PoisonComboBox();
            seasonNameTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            incompleteFormLabel = new Label();
            carListLabel = new Label();
            seasonNameLabel = new Label();
            seriesListLabel = new Label();
            carPanel = new Panel();
            seriesPanel = new Panel();
            seasonNamePanel = new Panel();
            availableTracksFlowLayoutPanel = new FlowLayoutPanel();
            button1 = new Button();
            aiSkillGroupBox.SuspendLayout();
            aiSkillPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // aiSkillGroupBox
            // 
            aiSkillGroupBox.Controls.Add(adaptiveAiCheckBox);
            aiSkillGroupBox.Controls.Add(adaptiveAiComboBox);
            aiSkillGroupBox.Controls.Add(aiSkillPanel);
            aiSkillGroupBox.ForeColor = SystemColors.ControlDark;
            aiSkillGroupBox.Location = new Point(262, 193);
            aiSkillGroupBox.Name = "aiSkillGroupBox";
            aiSkillGroupBox.Size = new Size(380, 100);
            aiSkillGroupBox.TabIndex = 47;
            aiSkillGroupBox.TabStop = false;
            aiSkillGroupBox.Text = "AI Skill";
            // 
            // adaptiveAiCheckBox
            // 
            adaptiveAiCheckBox.AutoSize = true;
            adaptiveAiCheckBox.BackColor = Color.Transparent;
            adaptiveAiCheckBox.Enabled = false;
            adaptiveAiCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            adaptiveAiCheckBox.Location = new Point(10, 22);
            adaptiveAiCheckBox.Name = "adaptiveAiCheckBox";
            adaptiveAiCheckBox.Size = new Size(96, 19);
            adaptiveAiCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            adaptiveAiCheckBox.TabIndex = 32;
            adaptiveAiCheckBox.Text = "Adaptive AI";
            adaptiveAiCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            adaptiveAiCheckBox.UseCustomBackColor = true;
            adaptiveAiCheckBox.UseSelectable = true;
            adaptiveAiCheckBox.UseVisualStyleBackColor = false;
            // 
            // adaptiveAiComboBox
            // 
            adaptiveAiComboBox.DropDownHeight = 320;
            adaptiveAiComboBox.Enabled = false;
            adaptiveAiComboBox.FormattingEnabled = true;
            adaptiveAiComboBox.IntegralHeight = false;
            adaptiveAiComboBox.ItemHeight = 23;
            adaptiveAiComboBox.Items.AddRange(new object[] { "Easy", "Medium", "Hard", "Extreme" });
            adaptiveAiComboBox.Location = new Point(117, 15);
            adaptiveAiComboBox.Name = "adaptiveAiComboBox";
            adaptiveAiComboBox.Size = new Size(257, 29);
            adaptiveAiComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            adaptiveAiComboBox.TabIndex = 31;
            adaptiveAiComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            adaptiveAiComboBox.UseSelectable = true;
            // 
            // aiSkillPanel
            // 
            aiSkillPanel.BackColor = Color.FromArgb(80, 30, 30, 30);
            aiSkillPanel.Controls.Add(aiSkillMinTrackBar);
            aiSkillPanel.Controls.Add(aiSkillMaxTrackBar);
            aiSkillPanel.Controls.Add(aiSkillPerLabel);
            aiSkillPanel.Controls.Add(aiSkillLevelLabel);
            aiSkillPanel.Location = new Point(1, 50);
            aiSkillPanel.Name = "aiSkillPanel";
            aiSkillPanel.Size = new Size(378, 44);
            aiSkillPanel.TabIndex = 5;
            // 
            // aiSkillMinTrackBar
            // 
            aiSkillMinTrackBar.BackColor = Color.Transparent;
            aiSkillMinTrackBar.Location = new Point(117, 6);
            aiSkillMinTrackBar.Maximum = 125;
            aiSkillMinTrackBar.Name = "aiSkillMinTrackBar";
            aiSkillMinTrackBar.Size = new Size(258, 16);
            aiSkillMinTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiSkillMinTrackBar.TabIndex = 5;
            aiSkillMinTrackBar.Text = "poisonTrackBar1";
            aiSkillMinTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillMinTrackBar.UseCustomBackColor = true;
            aiSkillMinTrackBar.Value = 25;
            // 
            // aiSkillMaxTrackBar
            // 
            aiSkillMaxTrackBar.BackColor = Color.Transparent;
            aiSkillMaxTrackBar.Location = new Point(117, 22);
            aiSkillMaxTrackBar.Maximum = 125;
            aiSkillMaxTrackBar.Name = "aiSkillMaxTrackBar";
            aiSkillMaxTrackBar.Size = new Size(258, 16);
            aiSkillMaxTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiSkillMaxTrackBar.TabIndex = 6;
            aiSkillMaxTrackBar.Text = "poisonTrackBar2";
            aiSkillMaxTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillMaxTrackBar.UseCustomBackColor = true;
            // 
            // aiSkillPerLabel
            // 
            aiSkillPerLabel.AutoSize = true;
            aiSkillPerLabel.BackColor = Color.Transparent;
            aiSkillPerLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            aiSkillPerLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            aiSkillPerLabel.Location = new Point(25, 22);
            aiSkillPerLabel.Name = "aiSkillPerLabel";
            aiSkillPerLabel.Size = new Size(17, 19);
            aiSkillPerLabel.TabIndex = 26;
            aiSkillPerLabel.Text = "0";
            aiSkillPerLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillPerLabel.UseCustomBackColor = true;
            // 
            // aiSkillLevelLabel
            // 
            aiSkillLevelLabel.AutoSize = true;
            aiSkillLevelLabel.BackColor = Color.Transparent;
            aiSkillLevelLabel.Font = new Font("MV Boli", 9F);
            aiSkillLevelLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            aiSkillLevelLabel.Location = new Point(25, 3);
            aiSkillLevelLabel.Name = "aiSkillLevelLabel";
            aiSkillLevelLabel.Size = new Size(86, 19);
            aiSkillLevelLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            aiSkillLevelLabel.TabIndex = 27;
            aiSkillLevelLabel.Text = "Ai Skill Level:";
            aiSkillLevelLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillLevelLabel.UseCustomBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(neverRainsCheckBox);
            groupBox1.Controls.Add(rosterNameComboBox);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(disableCarDamageCheckBox);
            groupBox1.Controls.Add(staticWeatherCheckBox);
            groupBox1.Controls.Add(afternoonRacesCheckBox);
            groupBox1.Controls.Add(aiAvoidPlayerCheckBox);
            groupBox1.Controls.Add(selectTracksCheckBox);
            groupBox1.Controls.Add(qualiAloneCheckBox);
            groupBox1.Controls.Add(shortParadeCheckBox);
            groupBox1.ForeColor = SystemColors.ControlDark;
            groupBox1.Location = new Point(262, 295);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 274);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Optionals";
            // 
            // neverRainsCheckBox
            // 
            neverRainsCheckBox.AutoSize = true;
            neverRainsCheckBox.BackColor = Color.Transparent;
            neverRainsCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            neverRainsCheckBox.Location = new Point(221, 112);
            neverRainsCheckBox.Name = "neverRainsCheckBox";
            neverRainsCheckBox.Size = new Size(97, 19);
            neverRainsCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            neverRainsCheckBox.TabIndex = 15;
            neverRainsCheckBox.Text = "Never Rains";
            neverRainsCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            neverRainsCheckBox.UseCustomBackColor = true;
            neverRainsCheckBox.UseSelectable = true;
            neverRainsCheckBox.UseVisualStyleBackColor = false;
            // 
            // rosterNameComboBox
            // 
            rosterNameComboBox.DropDownHeight = 260;
            rosterNameComboBox.FormattingEnabled = true;
            rosterNameComboBox.IntegralHeight = false;
            rosterNameComboBox.ItemHeight = 23;
            rosterNameComboBox.Location = new Point(7, 232);
            rosterNameComboBox.Name = "rosterNameComboBox";
            rosterNameComboBox.Size = new Size(366, 29);
            rosterNameComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            rosterNameComboBox.TabIndex = 21;
            rosterNameComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            rosterNameComboBox.UseSelectable = true;
            rosterNameComboBox.Click += rosterNameComboBox_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(80, 30, 30, 30);
            panel1.Controls.Add(carCountValueLabel);
            panel1.Controls.Add(carCountLabel);
            panel1.Controls.Add(carCountTrackBar);
            panel1.Location = new Point(7, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 28);
            panel1.TabIndex = 1;
            // 
            // carCountValueLabel
            // 
            carCountValueLabel.AutoSize = true;
            carCountValueLabel.BackColor = Color.Transparent;
            carCountValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            carCountValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            carCountValueLabel.Location = new Point(208, 3);
            carCountValueLabel.Name = "carCountValueLabel";
            carCountValueLabel.Size = new Size(17, 19);
            carCountValueLabel.TabIndex = 26;
            carCountValueLabel.Text = "0";
            carCountValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carCountValueLabel.UseCustomBackColor = true;
            // 
            // carCountLabel
            // 
            carCountLabel.AutoSize = true;
            carCountLabel.BackColor = Color.Transparent;
            carCountLabel.Font = new Font("MV Boli", 9F);
            carCountLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            carCountLabel.Location = new Point(22, 3);
            carCountLabel.Name = "carCountLabel";
            carCountLabel.Size = new Size(72, 19);
            carCountLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            carCountLabel.TabIndex = 27;
            carCountLabel.Text = "Car Count";
            carCountLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carCountLabel.UseCustomBackColor = true;
            // 
            // carCountTrackBar
            // 
            carCountTrackBar.BackColor = Color.Transparent;
            carCountTrackBar.Location = new Point(231, 6);
            carCountTrackBar.Maximum = 60;
            carCountTrackBar.Minimum = 12;
            carCountTrackBar.Name = "carCountTrackBar";
            carCountTrackBar.Size = new Size(131, 16);
            carCountTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            carCountTrackBar.TabIndex = 8;
            carCountTrackBar.Text = "poisonTrackBar1";
            carCountTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carCountTrackBar.UseCustomBackColor = true;
            carCountTrackBar.Value = 30;
            carCountTrackBar.ValueChanged += carCountTrackBar_ValueChanged;
            // 
            // disableCarDamageCheckBox
            // 
            disableCarDamageCheckBox.AutoSize = true;
            disableCarDamageCheckBox.BackColor = Color.Transparent;
            disableCarDamageCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            disableCarDamageCheckBox.Location = new Point(10, 52);
            disableCarDamageCheckBox.Name = "disableCarDamageCheckBox";
            disableCarDamageCheckBox.Size = new Size(149, 19);
            disableCarDamageCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            disableCarDamageCheckBox.TabIndex = 9;
            disableCarDamageCheckBox.Text = "Disable Car Damage";
            disableCarDamageCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            disableCarDamageCheckBox.UseCustomBackColor = true;
            disableCarDamageCheckBox.UseSelectable = true;
            disableCarDamageCheckBox.UseVisualStyleBackColor = false;
            // 
            // consistentWeatherCheckBox
            // 
            staticWeatherCheckBox.AutoSize = true;
            staticWeatherCheckBox.BackColor = Color.Transparent;
            staticWeatherCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            staticWeatherCheckBox.Location = new Point(10, 82);
            staticWeatherCheckBox.Name = "consistentWeatherCheckBox";
            staticWeatherCheckBox.Size = new Size(113, 19);
            staticWeatherCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            staticWeatherCheckBox.TabIndex = 11;
            staticWeatherCheckBox.Text = "Static Weather";
            staticWeatherCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            staticWeatherCheckBox.UseCustomBackColor = true;
            staticWeatherCheckBox.UseSelectable = true;
            staticWeatherCheckBox.UseVisualStyleBackColor = false;
            // 
            // afternoonRacesCheckBox
            // 
            afternoonRacesCheckBox.AutoSize = true;
            afternoonRacesCheckBox.BackColor = Color.Transparent;
            afternoonRacesCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            afternoonRacesCheckBox.Location = new Point(10, 112);
            afternoonRacesCheckBox.Name = "afternoonRacesCheckBox";
            afternoonRacesCheckBox.Size = new Size(125, 19);
            afternoonRacesCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            afternoonRacesCheckBox.TabIndex = 13;
            afternoonRacesCheckBox.Text = "Afternoon Races";
            afternoonRacesCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            afternoonRacesCheckBox.UseCustomBackColor = true;
            afternoonRacesCheckBox.UseSelectable = true;
            afternoonRacesCheckBox.UseVisualStyleBackColor = false;
            // 
            // aiAvoidPlayerCheckBox
            // 
            aiAvoidPlayerCheckBox.AutoSize = true;
            aiAvoidPlayerCheckBox.BackColor = Color.Transparent;
            aiAvoidPlayerCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            aiAvoidPlayerCheckBox.Location = new Point(221, 52);
            aiAvoidPlayerCheckBox.Name = "aiAvoidPlayerCheckBox";
            aiAvoidPlayerCheckBox.Size = new Size(124, 19);
            aiAvoidPlayerCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiAvoidPlayerCheckBox.TabIndex = 10;
            aiAvoidPlayerCheckBox.Text = "AI Avoids Player";
            aiAvoidPlayerCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiAvoidPlayerCheckBox.UseCustomBackColor = true;
            aiAvoidPlayerCheckBox.UseSelectable = true;
            aiAvoidPlayerCheckBox.UseVisualStyleBackColor = false;
            // 
            // selectTracksCheckBox
            // 
            selectTracksCheckBox.AutoSize = true;
            selectTracksCheckBox.BackColor = Color.Transparent;
            selectTracksCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            selectTracksCheckBox.Location = new Point(10, 142);
            selectTracksCheckBox.Name = "selectTracksCheckBox";
            selectTracksCheckBox.Size = new Size(101, 19);
            selectTracksCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            selectTracksCheckBox.TabIndex = 16;
            selectTracksCheckBox.Text = "Select Tracks";
            selectTracksCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            selectTracksCheckBox.UseCustomBackColor = true;
            selectTracksCheckBox.UseSelectable = true;
            selectTracksCheckBox.UseVisualStyleBackColor = false;
            // 
            // qualiAloneCheckBox
            // 
            qualiAloneCheckBox.AutoSize = true;
            qualiAloneCheckBox.BackColor = Color.Transparent;
            qualiAloneCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            qualiAloneCheckBox.Location = new Point(221, 82);
            qualiAloneCheckBox.Name = "qualiAloneCheckBox";
            qualiAloneCheckBox.Size = new Size(107, 19);
            qualiAloneCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            qualiAloneCheckBox.TabIndex = 12;
            qualiAloneCheckBox.Text = "Qualify Alone";
            qualiAloneCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiAloneCheckBox.UseCustomBackColor = true;
            qualiAloneCheckBox.UseSelectable = true;
            qualiAloneCheckBox.UseVisualStyleBackColor = false;
            // 
            // shortParadeCheckBox
            // 
            shortParadeCheckBox.AutoSize = true;
            shortParadeCheckBox.BackColor = Color.Transparent;
            shortParadeCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            shortParadeCheckBox.Location = new Point(221, 142);
            shortParadeCheckBox.Name = "shortParadeCheckBox";
            shortParadeCheckBox.Size = new Size(130, 19);
            shortParadeCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            shortParadeCheckBox.TabIndex = 17;
            shortParadeCheckBox.Text = "Short Parade Lap";
            shortParadeCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            shortParadeCheckBox.UseCustomBackColor = true;
            shortParadeCheckBox.UseSelectable = true;
            shortParadeCheckBox.UseVisualStyleBackColor = false;
            // 
            // createSeasonButton
            // 
            createSeasonButton.Location = new Point(507, 574);
            createSeasonButton.Name = "createSeasonButton";
            createSeasonButton.Size = new Size(135, 23);
            createSeasonButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            createSeasonButton.TabIndex = 41;
            createSeasonButton.Text = "Create Season";
            createSeasonButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            createSeasonButton.UseSelectable = true;
            createSeasonButton.Click += createSeasonButton_Click;
            // 
            // carListCombo
            // 
            carListCombo.DropDownHeight = 400;
            carListCombo.FormattingEnabled = true;
            carListCombo.IntegralHeight = false;
            carListCombo.ItemHeight = 23;
            carListCombo.Location = new Point(342, 158);
            carListCombo.Name = "carListCombo";
            carListCombo.Size = new Size(300, 29);
            carListCombo.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            carListCombo.TabIndex = 37;
            carListCombo.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carListCombo.UseSelectable = true;
            // 
            // seriesListCombo
            // 
            seriesListCombo.DropDownHeight = 415;
            seriesListCombo.FormattingEnabled = true;
            seriesListCombo.IntegralHeight = false;
            seriesListCombo.ItemHeight = 23;
            seriesListCombo.Location = new Point(342, 123);
            seriesListCombo.Name = "seriesListCombo";
            seriesListCombo.Size = new Size(300, 29);
            seriesListCombo.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seriesListCombo.TabIndex = 36;
            seriesListCombo.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seriesListCombo.UseSelectable = true;
            seriesListCombo.SelectedIndexChanged += seriesListCombo_SelectedIndexChanged;
            // 
            // seasonNameTextBox
            // 
            // 
            // 
            // 
            seasonNameTextBox.CustomButton.Image = null;
            seasonNameTextBox.CustomButton.Location = new Point(272, 1);
            seasonNameTextBox.CustomButton.Name = "";
            seasonNameTextBox.CustomButton.Size = new Size(27, 27);
            seasonNameTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            seasonNameTextBox.CustomButton.TabIndex = 1;
            seasonNameTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            seasonNameTextBox.CustomButton.UseSelectable = true;
            seasonNameTextBox.CustomButton.Visible = false;
            seasonNameTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
            seasonNameTextBox.Location = new Point(342, 53);
            seasonNameTextBox.MaxLength = 32767;
            seasonNameTextBox.Name = "seasonNameTextBox";
            seasonNameTextBox.PasswordChar = '\0';
            seasonNameTextBox.ScrollBars = ScrollBars.None;
            seasonNameTextBox.SelectedText = "";
            seasonNameTextBox.SelectionLength = 0;
            seasonNameTextBox.SelectionStart = 0;
            seasonNameTextBox.ShortcutsEnabled = true;
            seasonNameTextBox.Size = new Size(300, 29);
            seasonNameTextBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seasonNameTextBox.TabIndex = 33;
            seasonNameTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seasonNameTextBox.UseSelectable = true;
            seasonNameTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            seasonNameTextBox.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // incompleteFormLabel
            // 
            incompleteFormLabel.AutoSize = true;
            incompleteFormLabel.ForeColor = Color.FromArgb(128, 187, 0);
            incompleteFormLabel.Location = new Point(359, 562);
            incompleteFormLabel.Name = "incompleteFormLabel";
            incompleteFormLabel.Size = new Size(0, 15);
            incompleteFormLabel.TabIndex = 42;
            // 
            // carListLabel
            // 
            carListLabel.AutoSize = true;
            carListLabel.ForeColor = SystemColors.ControlDark;
            carListLabel.Location = new Point(311, 172);
            carListLabel.Name = "carListLabel";
            carListLabel.Size = new Size(25, 15);
            carListLabel.TabIndex = 40;
            carListLabel.Text = "Car";
            // 
            // seasonNameLabel
            // 
            seasonNameLabel.AutoSize = true;
            seasonNameLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seasonNameLabel.ForeColor = SystemColors.ControlDark;
            seasonNameLabel.Location = new Point(257, 67);
            seasonNameLabel.Name = "seasonNameLabel";
            seasonNameLabel.Size = new Size(86, 15);
            seasonNameLabel.TabIndex = 38;
            seasonNameLabel.Text = "Season Name";
            // 
            // seriesListLabel
            // 
            seriesListLabel.AutoSize = true;
            seriesListLabel.ForeColor = SystemColors.ControlDark;
            seriesListLabel.Location = new Point(299, 137);
            seriesListLabel.Name = "seriesListLabel";
            seriesListLabel.Size = new Size(37, 15);
            seriesListLabel.TabIndex = 35;
            seriesListLabel.Text = "Series";
            // 
            // carPanel
            // 
            carPanel.BackColor = Color.FromArgb(128, 187, 0);
            carPanel.Location = new Point(323, 572);
            carPanel.Name = "carPanel";
            carPanel.Size = new Size(27, 27);
            carPanel.TabIndex = 43;
            carPanel.Visible = false;
            // 
            // seriesPanel
            // 
            seriesPanel.BackColor = Color.FromArgb(128, 187, 0);
            seriesPanel.Location = new Point(290, 572);
            seriesPanel.Name = "seriesPanel";
            seriesPanel.Size = new Size(27, 27);
            seriesPanel.TabIndex = 44;
            seriesPanel.Visible = false;
            // 
            // seasonNamePanel
            // 
            seasonNamePanel.BackColor = Color.FromArgb(128, 187, 0);
            seasonNamePanel.Location = new Point(257, 572);
            seasonNamePanel.Name = "seasonNamePanel";
            seasonNamePanel.Size = new Size(27, 27);
            seasonNamePanel.TabIndex = 45;
            seasonNamePanel.Visible = false;
            // 
            // availableTracksFlowLayoutPanel
            // 
            availableTracksFlowLayoutPanel.AutoScroll = true;
            availableTracksFlowLayoutPanel.BackColor = Color.FromArgb(200, 30, 30, 30);
            availableTracksFlowLayoutPanel.Location = new Point(764, 142);
            availableTracksFlowLayoutPanel.Name = "availableTracksFlowLayoutPanel";
            availableTracksFlowLayoutPanel.Size = new Size(390, 419);
            availableTracksFlowLayoutPanel.TabIndex = 49;
            // 
            // button1
            // 
            button1.Location = new Point(96, 246);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 50;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // SeasonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1200, 750);
            Controls.Add(button1);
            Controls.Add(availableTracksFlowLayoutPanel);
            Controls.Add(aiSkillGroupBox);
            Controls.Add(groupBox1);
            Controls.Add(createSeasonButton);
            Controls.Add(carListCombo);
            Controls.Add(seriesListCombo);
            Controls.Add(seasonNameTextBox);
            Controls.Add(incompleteFormLabel);
            Controls.Add(carListLabel);
            Controls.Add(seasonNameLabel);
            Controls.Add(seriesListLabel);
            Controls.Add(carPanel);
            Controls.Add(seriesPanel);
            Controls.Add(seasonNamePanel);
            DoubleBuffered = true;
            Name = "SeasonForm";
            Text = "SeasonForm";
            Load += SeasonForm_Load;
            aiSkillGroupBox.ResumeLayout(false);
            aiSkillGroupBox.PerformLayout();
            aiSkillPanel.ResumeLayout(false);
            aiSkillPanel.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox aiSkillGroupBox;
        private ReaLTaiizor.Controls.PoisonCheckBox adaptiveAiCheckBox;
        private ReaLTaiizor.Controls.PoisonComboBox adaptiveAiComboBox;
        private Panel aiSkillPanel;
        private ReaLTaiizor.Controls.PoisonTrackBar aiSkillMinTrackBar;
        private ReaLTaiizor.Controls.PoisonTrackBar aiSkillMaxTrackBar;
        private ReaLTaiizor.Controls.PoisonLabel aiSkillPerLabel;
        private ReaLTaiizor.Controls.PoisonLabel aiSkillLevelLabel;
        private GroupBox groupBox1;
        private ReaLTaiizor.Controls.PoisonCheckBox neverRainsCheckBox;
        private ReaLTaiizor.Controls.PoisonComboBox rosterNameComboBox;
        private Panel panel1;
        private ReaLTaiizor.Controls.PoisonLabel carCountValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel carCountLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox customCarSeasonCheckBox;
        private ReaLTaiizor.Controls.PoisonTrackBar carCountTrackBar;
        private ReaLTaiizor.Controls.PoisonCheckBox useExistingRosterCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox useRosterAttributesCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox disableCarDamageCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox excludeRosterCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox staticWeatherCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox afternoonRacesCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox aiAvoidPlayerCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox selectTracksCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox qualiAloneCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox shortParadeCheckBox;
        private ReaLTaiizor.Controls.PoisonButton createSeasonButton;
        private ReaLTaiizor.Controls.PoisonComboBox carListCombo;
        private ReaLTaiizor.Controls.PoisonComboBox seriesListCombo;
        private ReaLTaiizor.Controls.PoisonTextBox seasonNameTextBox;
        private Label incompleteFormLabel;
        private Label carListLabel;
        private Label seasonNameLabel;
        private Label seriesListLabel;
        private Panel carPanel;
        private Panel seriesPanel;
        private Panel seasonNamePanel;
        private FlowLayoutPanel availableTracksFlowLayoutPanel;
        private Button button1;
    }
}