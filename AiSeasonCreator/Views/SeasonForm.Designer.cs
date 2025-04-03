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
            aiSkillMinTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            adaptiveAiCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            adaptiveAiComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            aiSkillMaxTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            aiSkillLevelLabel = new ReaLTaiizor.Controls.PoisonLabel();
            aiSkillPerLabel = new ReaLTaiizor.Controls.PoisonLabel();
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
            qualiAloneCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            shortParadeCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            rosterNameComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            createSeasonButton = new ReaLTaiizor.Controls.PoisonButton();
            carListCombo = new ReaLTaiizor.Controls.PoisonComboBox();
            seriesListCombo = new ReaLTaiizor.Controls.PoisonComboBox();
            seasonNameTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            incompleteFormLabel = new Label();
            carListLabel = new Label();
            seasonNameLabel = new Label();
            seriesListLabel = new Label();
            availableTracksFlowLayoutPanel = new FlowLayoutPanel();
            label1 = new Label();
            rosterLabel = new Label();
            sessionLengthsGroupBox = new GroupBox();
            raceLengthLabel = new ReaLTaiizor.Controls.PoisonLabel();
            qualiLengthLabel = new ReaLTaiizor.Controls.PoisonLabel();
            practiceLengthLabel = new ReaLTaiizor.Controls.PoisonLabel();
            raceLengthTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            qualiLengthTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            practiceLengthTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            button1 = new Button();
            seriesFlowLayoutPanel = new FlowLayoutPanel();
            carsFlowLayoutPanel = new FlowLayoutPanel();
            aiSkillGroupBox.SuspendLayout();
            optionalsGroupBox.SuspendLayout();
            carCountPanel.SuspendLayout();
            sessionLengthsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // aiSkillGroupBox
            // 
            aiSkillGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            aiSkillGroupBox.BackColor = Color.FromArgb(200, 30, 30, 30);
            aiSkillGroupBox.Controls.Add(aiSkillMinTrackBar);
            aiSkillGroupBox.Controls.Add(adaptiveAiCheckBox);
            aiSkillGroupBox.Controls.Add(adaptiveAiComboBox);
            aiSkillGroupBox.Controls.Add(aiSkillMaxTrackBar);
            aiSkillGroupBox.Controls.Add(aiSkillLevelLabel);
            aiSkillGroupBox.Controls.Add(aiSkillPerLabel);
            aiSkillGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aiSkillGroupBox.ForeColor = Color.White;
            aiSkillGroupBox.Location = new Point(674, 295);
            aiSkillGroupBox.Name = "aiSkillGroupBox";
            aiSkillGroupBox.Size = new Size(400, 100);
            aiSkillGroupBox.TabIndex = 47;
            aiSkillGroupBox.TabStop = false;
            aiSkillGroupBox.Text = "AI Skill";
            // 
            // aiSkillMinTrackBar
            // 
            aiSkillMinTrackBar.BackColor = Color.Transparent;
            aiSkillMinTrackBar.Location = new Point(112, 57);
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
            adaptiveAiComboBox.BackColor = Color.FromArgb(17, 17, 17);
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
            // aiSkillMaxTrackBar
            // 
            aiSkillMaxTrackBar.BackColor = Color.Transparent;
            aiSkillMaxTrackBar.Location = new Point(112, 73);
            aiSkillMaxTrackBar.Maximum = 125;
            aiSkillMaxTrackBar.Name = "aiSkillMaxTrackBar";
            aiSkillMaxTrackBar.Size = new Size(258, 16);
            aiSkillMaxTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiSkillMaxTrackBar.TabIndex = 6;
            aiSkillMaxTrackBar.Text = "poisonTrackBar2";
            aiSkillMaxTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillMaxTrackBar.UseCustomBackColor = true;
            // 
            // aiSkillLevelLabel
            // 
            aiSkillLevelLabel.AutoSize = true;
            aiSkillLevelLabel.BackColor = Color.Transparent;
            aiSkillLevelLabel.Font = new Font("MV Boli", 9F);
            aiSkillLevelLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            aiSkillLevelLabel.Location = new Point(20, 54);
            aiSkillLevelLabel.Name = "aiSkillLevelLabel";
            aiSkillLevelLabel.Size = new Size(86, 19);
            aiSkillLevelLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            aiSkillLevelLabel.TabIndex = 27;
            aiSkillLevelLabel.Text = "Ai Skill Level:";
            aiSkillLevelLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillLevelLabel.UseCustomBackColor = true;
            // 
            // aiSkillPerLabel
            // 
            aiSkillPerLabel.AutoSize = true;
            aiSkillPerLabel.BackColor = Color.Transparent;
            aiSkillPerLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            aiSkillPerLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            aiSkillPerLabel.Location = new Point(20, 73);
            aiSkillPerLabel.Name = "aiSkillPerLabel";
            aiSkillPerLabel.Size = new Size(17, 19);
            aiSkillPerLabel.TabIndex = 26;
            aiSkillPerLabel.Text = "0";
            aiSkillPerLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillPerLabel.UseCustomBackColor = true;
            // 
            // optionalsGroupBox
            // 
            optionalsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            optionalsGroupBox.BackColor = Color.FromArgb(200, 30, 30, 30);
            optionalsGroupBox.Controls.Add(carCountPanel);
            optionalsGroupBox.Controls.Add(neverRainsCheckBox);
            optionalsGroupBox.Controls.Add(disableCarDamageCheckBox);
            optionalsGroupBox.Controls.Add(staticWeatherCheckBox);
            optionalsGroupBox.Controls.Add(afternoonRacesCheckBox);
            optionalsGroupBox.Controls.Add(aiAvoidPlayerCheckBox);
            optionalsGroupBox.Controls.Add(qualiAloneCheckBox);
            optionalsGroupBox.Controls.Add(shortParadeCheckBox);
            optionalsGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionalsGroupBox.ForeColor = Color.White;
            optionalsGroupBox.Location = new Point(674, 425);
            optionalsGroupBox.Name = "optionalsGroupBox";
            optionalsGroupBox.Size = new Size(400, 183);
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
            carCountPanel.Location = new Point(6, 18);
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
            carCountLabel.Location = new Point(9, 2);
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
            // staticWeatherCheckBox
            // 
            staticWeatherCheckBox.AutoSize = true;
            staticWeatherCheckBox.BackColor = Color.Transparent;
            staticWeatherCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            staticWeatherCheckBox.Location = new Point(10, 82);
            staticWeatherCheckBox.Name = "staticWeatherCheckBox";
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
            shortParadeCheckBox.Location = new Point(10, 142);
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
            // rosterNameComboBox
            // 
            rosterNameComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rosterNameComboBox.BackColor = Color.FromArgb(17, 17, 17);
            rosterNameComboBox.DropDownHeight = 260;
            rosterNameComboBox.FormattingEnabled = true;
            rosterNameComboBox.IntegralHeight = false;
            rosterNameComboBox.ItemHeight = 23;
            rosterNameComboBox.Location = new Point(674, 225);
            rosterNameComboBox.Name = "rosterNameComboBox";
            rosterNameComboBox.Size = new Size(400, 29);
            rosterNameComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            rosterNameComboBox.TabIndex = 21;
            rosterNameComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            rosterNameComboBox.UseSelectable = true;
            rosterNameComboBox.Click += rosterNameComboBox_Click;
            // 
            // createSeasonButton
            // 
            createSeasonButton.Anchor = AnchorStyles.Bottom;
            createSeasonButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createSeasonButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Tall;
            createSeasonButton.Highlight = true;
            createSeasonButton.Location = new Point(838, 803);
            createSeasonButton.Name = "createSeasonButton";
            createSeasonButton.Size = new Size(204, 62);
            createSeasonButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            createSeasonButton.TabIndex = 41;
            createSeasonButton.Text = "Create Season";
            createSeasonButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            createSeasonButton.UseSelectable = true;
            createSeasonButton.Click += createSeasonButton_Click;
            // 
            // carListCombo
            // 
            carListCombo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            carListCombo.BackColor = Color.FromArgb(17, 17, 17);
            carListCombo.DropDownHeight = 400;
            carListCombo.FormattingEnabled = true;
            carListCombo.IntegralHeight = false;
            carListCombo.ItemHeight = 23;
            carListCombo.Location = new Point(674, 165);
            carListCombo.Name = "carListCombo";
            carListCombo.Size = new Size(400, 29);
            carListCombo.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            carListCombo.TabIndex = 37;
            carListCombo.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carListCombo.UseSelectable = true;
            // 
            // seriesListCombo
            // 
            seriesListCombo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            seriesListCombo.BackColor = Color.FromArgb(17, 17, 17);
            seriesListCombo.DropDownHeight = 415;
            seriesListCombo.FormattingEnabled = true;
            seriesListCombo.IntegralHeight = false;
            seriesListCombo.ItemHeight = 23;
            seriesListCombo.Location = new Point(674, 102);
            seriesListCombo.Name = "seriesListCombo";
            seriesListCombo.Size = new Size(400, 29);
            seriesListCombo.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seriesListCombo.TabIndex = 36;
            seriesListCombo.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seriesListCombo.UseSelectable = true;
            seriesListCombo.SelectedIndexChanged += seriesListCombo_SelectedIndexChanged;
            // 
            // seasonNameTextBox
            // 
            seasonNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // 
            // 
            seasonNameTextBox.CustomButton.Image = null;
            seasonNameTextBox.CustomButton.Location = new Point(371, 1);
            seasonNameTextBox.CustomButton.Name = "";
            seasonNameTextBox.CustomButton.Size = new Size(27, 27);
            seasonNameTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            seasonNameTextBox.CustomButton.TabIndex = 1;
            seasonNameTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            seasonNameTextBox.CustomButton.UseSelectable = true;
            seasonNameTextBox.CustomButton.Visible = false;
            seasonNameTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
            seasonNameTextBox.Location = new Point(675, 37);
            seasonNameTextBox.MaxLength = 32767;
            seasonNameTextBox.Name = "seasonNameTextBox";
            seasonNameTextBox.PasswordChar = '\0';
            seasonNameTextBox.ScrollBars = ScrollBars.None;
            seasonNameTextBox.SelectedText = "";
            seasonNameTextBox.SelectionLength = 0;
            seasonNameTextBox.SelectionStart = 0;
            seasonNameTextBox.ShortcutsEnabled = true;
            seasonNameTextBox.Size = new Size(399, 29);
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
            incompleteFormLabel.Location = new Point(471, 551);
            incompleteFormLabel.Name = "incompleteFormLabel";
            incompleteFormLabel.Size = new Size(0, 15);
            incompleteFormLabel.TabIndex = 42;
            // 
            // carListLabel
            // 
            carListLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            carListLabel.AutoSize = true;
            carListLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            carListLabel.ForeColor = SystemColors.ControlDark;
            carListLabel.Location = new Point(674, 147);
            carListLabel.Name = "carListLabel";
            carListLabel.Size = new Size(26, 15);
            carListLabel.TabIndex = 40;
            carListLabel.Text = "Car";
            // 
            // seasonNameLabel
            // 
            seasonNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            seasonNameLabel.AutoSize = true;
            seasonNameLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seasonNameLabel.ForeColor = SystemColors.ControlDark;
            seasonNameLabel.Location = new Point(674, 18);
            seasonNameLabel.Name = "seasonNameLabel";
            seasonNameLabel.Size = new Size(86, 15);
            seasonNameLabel.TabIndex = 38;
            seasonNameLabel.Text = "Season Name";
            // 
            // seriesListLabel
            // 
            seriesListLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            seriesListLabel.AutoSize = true;
            seriesListLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seriesListLabel.ForeColor = SystemColors.ControlDark;
            seriesListLabel.Location = new Point(674, 84);
            seriesListLabel.Name = "seriesListLabel";
            seriesListLabel.Size = new Size(42, 15);
            seriesListLabel.TabIndex = 35;
            seriesListLabel.Text = "Series";
            // 
            // availableTracksFlowLayoutPanel
            // 
            availableTracksFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            availableTracksFlowLayoutPanel.AutoScroll = true;
            availableTracksFlowLayoutPanel.BackColor = Color.FromArgb(200, 30, 30, 30);
            availableTracksFlowLayoutPanel.Location = new Point(1080, 37);
            availableTracksFlowLayoutPanel.Name = "availableTracksFlowLayoutPanel";
            availableTracksFlowLayoutPanel.Size = new Size(400, 571);
            availableTracksFlowLayoutPanel.TabIndex = 49;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(200, 30, 30, 30);
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1080, 9);
            label1.Name = "label1";
            label1.Size = new Size(140, 24);
            label1.TabIndex = 50;
            label1.Text = "Track Selection";
            // 
            // rosterLabel
            // 
            rosterLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rosterLabel.AutoSize = true;
            rosterLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rosterLabel.ForeColor = SystemColors.ControlDark;
            rosterLabel.Location = new Point(674, 207);
            rosterLabel.Name = "rosterLabel";
            rosterLabel.Size = new Size(43, 15);
            rosterLabel.TabIndex = 51;
            rosterLabel.Text = "Roster";
            // 
            // sessionLengthsGroupBox
            // 
            sessionLengthsGroupBox.BackColor = Color.FromArgb(200, 30, 30, 30);
            sessionLengthsGroupBox.Controls.Add(raceLengthLabel);
            sessionLengthsGroupBox.Controls.Add(qualiLengthLabel);
            sessionLengthsGroupBox.Controls.Add(practiceLengthLabel);
            sessionLengthsGroupBox.Controls.Add(raceLengthTrackBar);
            sessionLengthsGroupBox.Controls.Add(qualiLengthTrackBar);
            sessionLengthsGroupBox.Controls.Add(practiceLengthTrackBar);
            sessionLengthsGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sessionLengthsGroupBox.ForeColor = Color.White;
            sessionLengthsGroupBox.Location = new Point(12, 633);
            sessionLengthsGroupBox.Name = "sessionLengthsGroupBox";
            sessionLengthsGroupBox.Size = new Size(400, 167);
            sessionLengthsGroupBox.TabIndex = 52;
            sessionLengthsGroupBox.TabStop = false;
            sessionLengthsGroupBox.Text = "Session Lengths";
            // 
            // raceLengthLabel
            // 
            raceLengthLabel.AutoSize = true;
            raceLengthLabel.BackColor = Color.Transparent;
            raceLengthLabel.Font = new Font("MV Boli", 9F);
            raceLengthLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            raceLengthLabel.Location = new Point(70, 109);
            raceLengthLabel.Name = "raceLengthLabel";
            raceLengthLabel.Size = new Size(37, 19);
            raceLengthLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            raceLengthLabel.TabIndex = 30;
            raceLengthLabel.Text = "Race";
            raceLengthLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            raceLengthLabel.UseCustomBackColor = true;
            // 
            // qualiLengthLabel
            // 
            qualiLengthLabel.AutoSize = true;
            qualiLengthLabel.BackColor = Color.Transparent;
            qualiLengthLabel.Font = new Font("MV Boli", 9F);
            qualiLengthLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            qualiLengthLabel.Location = new Point(70, 65);
            qualiLengthLabel.Name = "qualiLengthLabel";
            qualiLengthLabel.Size = new Size(71, 19);
            qualiLengthLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            qualiLengthLabel.TabIndex = 29;
            qualiLengthLabel.Text = "Qualifying";
            qualiLengthLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiLengthLabel.UseCustomBackColor = true;
            // 
            // practiceLengthLabel
            // 
            practiceLengthLabel.AutoSize = true;
            practiceLengthLabel.BackColor = Color.Transparent;
            practiceLengthLabel.Font = new Font("MV Boli", 9F);
            practiceLengthLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            practiceLengthLabel.Location = new Point(70, 24);
            practiceLengthLabel.Name = "practiceLengthLabel";
            practiceLengthLabel.Size = new Size(56, 19);
            practiceLengthLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            practiceLengthLabel.TabIndex = 28;
            practiceLengthLabel.Text = "Practice";
            practiceLengthLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            practiceLengthLabel.UseCustomBackColor = true;
            // 
            // raceLengthTrackBar
            // 
            raceLengthTrackBar.BackColor = Color.Transparent;
            raceLengthTrackBar.Location = new Point(70, 136);
            raceLengthTrackBar.Maximum = 125;
            raceLengthTrackBar.Name = "raceLengthTrackBar";
            raceLengthTrackBar.Size = new Size(258, 16);
            raceLengthTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            raceLengthTrackBar.TabIndex = 8;
            raceLengthTrackBar.Text = "poisonTrackBar1";
            raceLengthTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            raceLengthTrackBar.UseCustomBackColor = true;
            raceLengthTrackBar.Value = 25;
            // 
            // qualiLengthTrackBar
            // 
            qualiLengthTrackBar.BackColor = Color.Transparent;
            qualiLengthTrackBar.Location = new Point(70, 90);
            qualiLengthTrackBar.Maximum = 125;
            qualiLengthTrackBar.Name = "qualiLengthTrackBar";
            qualiLengthTrackBar.Size = new Size(258, 16);
            qualiLengthTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            qualiLengthTrackBar.TabIndex = 7;
            qualiLengthTrackBar.Text = "poisonTrackBar1";
            qualiLengthTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiLengthTrackBar.UseCustomBackColor = true;
            qualiLengthTrackBar.Value = 25;
            // 
            // practiceLengthTrackBar
            // 
            practiceLengthTrackBar.BackColor = Color.Transparent;
            practiceLengthTrackBar.Location = new Point(70, 46);
            practiceLengthTrackBar.Maximum = 125;
            practiceLengthTrackBar.Name = "practiceLengthTrackBar";
            practiceLengthTrackBar.Size = new Size(258, 16);
            practiceLengthTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            practiceLengthTrackBar.TabIndex = 6;
            practiceLengthTrackBar.Text = "poisonTrackBar1";
            practiceLengthTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            practiceLengthTrackBar.UseCustomBackColor = true;
            practiceLengthTrackBar.Value = 25;
            // 
            // button1
            // 
            button1.Location = new Point(579, 703);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 53;
            button1.Text = "button1";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // seriesFlowLayoutPanel
            // 
            seriesFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            seriesFlowLayoutPanel.AutoScroll = true;
            seriesFlowLayoutPanel.BackColor = Color.FromArgb(200, 30, 30, 30);
            seriesFlowLayoutPanel.Location = new Point(12, 18);
            seriesFlowLayoutPanel.Name = "seriesFlowLayoutPanel";
            seriesFlowLayoutPanel.Size = new Size(284, 571);
            seriesFlowLayoutPanel.TabIndex = 54;
            // 
            // carsFlowLayoutPanel
            // 
            carsFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            carsFlowLayoutPanel.AutoScroll = true;
            carsFlowLayoutPanel.BackColor = Color.FromArgb(200, 30, 30, 30);
            carsFlowLayoutPanel.Location = new Point(317, 18);
            carsFlowLayoutPanel.Name = "carsFlowLayoutPanel";
            carsFlowLayoutPanel.Size = new Size(337, 571);
            carsFlowLayoutPanel.TabIndex = 55;
            // 
            // SeasonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1486, 914);
            Controls.Add(carsFlowLayoutPanel);
            Controls.Add(seriesFlowLayoutPanel);
            Controls.Add(button1);
            Controls.Add(sessionLengthsGroupBox);
            Controls.Add(rosterLabel);
            Controls.Add(label1);
            Controls.Add(rosterNameComboBox);
            Controls.Add(availableTracksFlowLayoutPanel);
            Controls.Add(aiSkillGroupBox);
            Controls.Add(optionalsGroupBox);
            Controls.Add(createSeasonButton);
            Controls.Add(carListCombo);
            Controls.Add(seriesListCombo);
            Controls.Add(seasonNameTextBox);
            Controls.Add(incompleteFormLabel);
            Controls.Add(carListLabel);
            Controls.Add(seasonNameLabel);
            Controls.Add(seriesListLabel);
            DoubleBuffered = true;
            Name = "SeasonForm";
            Text = "SeasonForm";
            Load += SeasonForm_Load;
            aiSkillGroupBox.ResumeLayout(false);
            aiSkillGroupBox.PerformLayout();
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

        private GroupBox aiSkillGroupBox;
        private ReaLTaiizor.Controls.PoisonCheckBox adaptiveAiCheckBox;
        private ReaLTaiizor.Controls.PoisonComboBox adaptiveAiComboBox;
        private ReaLTaiizor.Controls.PoisonTrackBar aiSkillMinTrackBar;
        private ReaLTaiizor.Controls.PoisonTrackBar aiSkillMaxTrackBar;
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
        private ReaLTaiizor.Controls.PoisonComboBox carListCombo;
        private ReaLTaiizor.Controls.PoisonComboBox seriesListCombo;
        private ReaLTaiizor.Controls.PoisonTextBox seasonNameTextBox;
        private Label incompleteFormLabel;
        private Label carListLabel;
        private Label seasonNameLabel;
        private Label seriesListLabel;
        private FlowLayoutPanel availableTracksFlowLayoutPanel;
        private Label label1;
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
        private Button button1;
        private FlowLayoutPanel seriesFlowLayoutPanel;
        private FlowLayoutPanel carsFlowLayoutPanel;
    }
}