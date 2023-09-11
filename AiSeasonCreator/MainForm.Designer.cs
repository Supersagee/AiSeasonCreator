namespace AiSeasonCreator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            seriesListLabel = new Label();
            seasonNameLabel = new Label();
            carListLabel = new Label();
            filePathLabel = new Label();
            toolTip1 = new ToolTip(components);
            consistentWeatherCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            afternoonRacesCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            aiAvoidPlayerCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            incompleteFormLabel = new Label();
            carPanel = new Panel();
            seriesPanel = new Panel();
            seasonNamePanel = new Panel();
            folderPathPanel = new Panel();
            seasonLabel = new Label();
            poisonStyleExtender1 = new ReaLTaiizor.Controls.PoisonStyleExtender(components);
            tabPage1 = new TabPage();
            createSeason = new ReaLTaiizor.Controls.PoisonButton();
            filePathTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            aiSkillPanel = new Panel();
            aiMinTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            aiMaxTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            aiSkillBox = new ReaLTaiizor.Controls.PoisonLabel();
            aiSkillLevelLabel = new ReaLTaiizor.Controls.PoisonLabel();
            shortParadeCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            qualiAloneCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            selectTracksCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            disableCarDamageCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            carListCombo = new ReaLTaiizor.Controls.PoisonComboBox();
            seriesListCombo = new ReaLTaiizor.Controls.PoisonComboBox();
            seasonComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            seasonNameTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            tabPage2 = new TabPage();
            versionLabel = new Label();
            forumLinkLabel = new ReaLTaiizor.Controls.PoisonLinkLabel();
            mainTabControl = new ReaLTaiizor.Controls.PoisonTabControl();
            poisonStyleManager1 = new ReaLTaiizor.Manager.PoisonStyleManager(components);
            closeButton = new ReaLTaiizor.Controls.PoisonButton();
            topBarPanel = new ReaLTaiizor.Controls.PoisonPanel();
            titleLabel = new ReaLTaiizor.Controls.PoisonLabel();
            minimizeButton = new ReaLTaiizor.Controls.PoisonButton();
            tabPage1.SuspendLayout();
            aiSkillPanel.SuspendLayout();
            tabPage2.SuspendLayout();
            mainTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)poisonStyleManager1).BeginInit();
            topBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // seriesListLabel
            // 
            seriesListLabel.AutoSize = true;
            seriesListLabel.Location = new Point(50, 124);
            seriesListLabel.Name = "seriesListLabel";
            seriesListLabel.Size = new Size(37, 15);
            seriesListLabel.TabIndex = 2;
            seriesListLabel.Text = "Series";
            // 
            // seasonNameLabel
            // 
            seasonNameLabel.AutoSize = true;
            seasonNameLabel.Location = new Point(8, 34);
            seasonNameLabel.Name = "seasonNameLabel";
            seasonNameLabel.Size = new Size(79, 15);
            seasonNameLabel.TabIndex = 4;
            seasonNameLabel.Text = "Season Name";
            // 
            // carListLabel
            // 
            carListLabel.AutoSize = true;
            carListLabel.Location = new Point(62, 169);
            carListLabel.Name = "carListLabel";
            carListLabel.Size = new Size(25, 15);
            carListLabel.TabIndex = 6;
            carListLabel.Text = "Car";
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Location = new Point(31, 463);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(40, 15);
            filePathLabel.TabIndex = 14;
            filePathLabel.Text = "Folder";
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 500000;
            toolTip1.BackColor = Color.FromArgb(30, 30, 30);
            toolTip1.ForeColor = Color.White;
            toolTip1.InitialDelay = 10;
            toolTip1.OwnerDraw = true;
            toolTip1.ReshowDelay = 10;
            toolTip1.Draw += toolTip1_Draw;
            // 
            // consistentWeatherCheckBox
            // 
            consistentWeatherCheckBox.AutoSize = true;
            consistentWeatherCheckBox.BackColor = Color.Transparent;
            consistentWeatherCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            consistentWeatherCheckBox.Location = new Point(93, 248);
            consistentWeatherCheckBox.Name = "consistentWeatherCheckBox";
            consistentWeatherCheckBox.Size = new Size(145, 19);
            consistentWeatherCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            consistentWeatherCheckBox.TabIndex = 37;
            consistentWeatherCheckBox.Text = "Consistent Weather";
            consistentWeatherCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            toolTip1.SetToolTip(consistentWeatherCheckBox, "Sets all races to 78 degees F and 55% humidity. This can help the Ai to race more consistently.");
            consistentWeatherCheckBox.UseCustomBackColor = true;
            consistentWeatherCheckBox.UseSelectable = true;
            consistentWeatherCheckBox.UseVisualStyleBackColor = false;
            // 
            // afternoonRacesCheckBox
            // 
            afternoonRacesCheckBox.AutoSize = true;
            afternoonRacesCheckBox.BackColor = Color.Transparent;
            afternoonRacesCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            afternoonRacesCheckBox.Location = new Point(93, 295);
            afternoonRacesCheckBox.Name = "afternoonRacesCheckBox";
            afternoonRacesCheckBox.Size = new Size(125, 19);
            afternoonRacesCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            afternoonRacesCheckBox.TabIndex = 38;
            afternoonRacesCheckBox.Text = "Afternoon Races";
            afternoonRacesCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            toolTip1.SetToolTip(afternoonRacesCheckBox, "Sets all races to 2pm. This can help the Ai to race more consistently.");
            afternoonRacesCheckBox.UseCustomBackColor = true;
            afternoonRacesCheckBox.UseSelectable = true;
            afternoonRacesCheckBox.UseVisualStyleBackColor = false;
            // 
            // aiAvoidPlayerCheckBox
            // 
            aiAvoidPlayerCheckBox.AutoSize = true;
            aiAvoidPlayerCheckBox.BackColor = Color.Transparent;
            aiAvoidPlayerCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            aiAvoidPlayerCheckBox.Location = new Point(263, 201);
            aiAvoidPlayerCheckBox.Name = "aiAvoidPlayerCheckBox";
            aiAvoidPlayerCheckBox.Size = new Size(124, 19);
            aiAvoidPlayerCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiAvoidPlayerCheckBox.TabIndex = 40;
            aiAvoidPlayerCheckBox.Text = "AI Avoids Player";
            aiAvoidPlayerCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiAvoidPlayerCheckBox.UseCustomBackColor = true;
            aiAvoidPlayerCheckBox.UseSelectable = true;
            aiAvoidPlayerCheckBox.UseVisualStyleBackColor = false;
            // 
            // incompleteFormLabel
            // 
            incompleteFormLabel.AutoSize = true;
            incompleteFormLabel.ForeColor = Color.IndianRed;
            incompleteFormLabel.Location = new Point(84, 515);
            incompleteFormLabel.Name = "incompleteFormLabel";
            incompleteFormLabel.Size = new Size(0, 15);
            incompleteFormLabel.TabIndex = 24;
            // 
            // carPanel
            // 
            carPanel.BackColor = Color.Transparent;
            carPanel.Location = new Point(74, 519);
            carPanel.Name = "carPanel";
            carPanel.Size = new Size(27, 27);
            carPanel.TabIndex = 25;
            // 
            // seriesPanel
            // 
            seriesPanel.BackColor = Color.Transparent;
            seriesPanel.Location = new Point(41, 519);
            seriesPanel.Name = "seriesPanel";
            seriesPanel.Size = new Size(27, 27);
            seriesPanel.TabIndex = 26;
            // 
            // seasonNamePanel
            // 
            seasonNamePanel.Location = new Point(8, 519);
            seasonNamePanel.Name = "seasonNamePanel";
            seasonNamePanel.Size = new Size(27, 27);
            seasonNamePanel.TabIndex = 27;
            // 
            // folderPathPanel
            // 
            folderPathPanel.Location = new Point(107, 519);
            folderPathPanel.Name = "folderPathPanel";
            folderPathPanel.Size = new Size(27, 27);
            folderPathPanel.TabIndex = 28;
            // 
            // seasonLabel
            // 
            seasonLabel.AutoSize = true;
            seasonLabel.Location = new Point(43, 79);
            seasonLabel.Name = "seasonLabel";
            seasonLabel.Size = new Size(44, 15);
            seasonLabel.TabIndex = 30;
            seasonLabel.Text = "Season";
            // 
            // poisonStyleExtender1
            // 
            poisonStyleExtender1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // tabPage1
            // 
            poisonStyleExtender1.SetApplyPoisonTheme(tabPage1, true);
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage1.Controls.Add(afternoonRacesCheckBox);
            tabPage1.Controls.Add(createSeason);
            tabPage1.Controls.Add(filePathTextBox);
            tabPage1.Controls.Add(aiSkillPanel);
            tabPage1.Controls.Add(shortParadeCheckBox);
            tabPage1.Controls.Add(qualiAloneCheckBox);
            tabPage1.Controls.Add(aiAvoidPlayerCheckBox);
            tabPage1.Controls.Add(selectTracksCheckBox);
            tabPage1.Controls.Add(consistentWeatherCheckBox);
            tabPage1.Controls.Add(disableCarDamageCheckBox);
            tabPage1.Controls.Add(carListCombo);
            tabPage1.Controls.Add(seriesListCombo);
            tabPage1.Controls.Add(seasonComboBox);
            tabPage1.Controls.Add(seasonNameTextBox);
            tabPage1.Controls.Add(seasonLabel);
            tabPage1.Controls.Add(incompleteFormLabel);
            tabPage1.Controls.Add(filePathLabel);
            tabPage1.Controls.Add(carListLabel);
            tabPage1.Controls.Add(seasonNameLabel);
            tabPage1.Controls.Add(seriesListLabel);
            tabPage1.Controls.Add(folderPathPanel);
            tabPage1.Controls.Add(carPanel);
            tabPage1.Controls.Add(seriesPanel);
            tabPage1.Controls.Add(seasonNamePanel);
            tabPage1.Location = new Point(4, 38);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(412, 555);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Season";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // createSeason
            // 
            createSeason.Location = new Point(258, 507);
            createSeason.Name = "createSeason";
            createSeason.Size = new Size(135, 23);
            createSeason.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            createSeason.TabIndex = 45;
            createSeason.Text = "Create Season";
            createSeason.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            createSeason.UseSelectable = true;
            createSeason.Click += createSeason_Click;
            // 
            // filePathTextBox
            // 
            // 
            // 
            // 
            filePathTextBox.CustomButton.Image = null;
            filePathTextBox.CustomButton.Location = new Point(288, 1);
            filePathTextBox.CustomButton.Name = "";
            filePathTextBox.CustomButton.Size = new Size(27, 27);
            filePathTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            filePathTextBox.CustomButton.TabIndex = 1;
            filePathTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            filePathTextBox.CustomButton.UseSelectable = true;
            filePathTextBox.CustomButton.Visible = false;
            filePathTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
            filePathTextBox.Lines = new string[] { "Click to add folder path. iRacing\\aiseasons" };
            filePathTextBox.Location = new Point(77, 463);
            filePathTextBox.MaxLength = 32767;
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.PasswordChar = '\0';
            filePathTextBox.ReadOnly = true;
            filePathTextBox.ScrollBars = ScrollBars.None;
            filePathTextBox.SelectedText = "";
            filePathTextBox.SelectionLength = 0;
            filePathTextBox.SelectionStart = 0;
            filePathTextBox.ShortcutsEnabled = true;
            filePathTextBox.Size = new Size(316, 29);
            filePathTextBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            filePathTextBox.TabIndex = 44;
            filePathTextBox.Text = "Click to add folder path. iRacing\\aiseasons";
            filePathTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            filePathTextBox.UseSelectable = true;
            filePathTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            filePathTextBox.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            filePathTextBox.Click += filePathTextBox_Click;
            // 
            // aiSkillPanel
            // 
            aiSkillPanel.BackColor = Color.FromArgb(80, 30, 30, 30);
            aiSkillPanel.Controls.Add(aiMinTrackBar);
            aiSkillPanel.Controls.Add(aiMaxTrackBar);
            aiSkillPanel.Controls.Add(aiSkillBox);
            aiSkillPanel.Controls.Add(aiSkillLevelLabel);
            aiSkillPanel.Location = new Point(77, 378);
            aiSkillPanel.Name = "aiSkillPanel";
            aiSkillPanel.Size = new Size(316, 67);
            aiSkillPanel.TabIndex = 43;
            // 
            // aiMinTrackBar
            // 
            aiMinTrackBar.BackColor = Color.Transparent;
            aiMinTrackBar.Location = new Point(16, 29);
            aiMinTrackBar.Maximum = 125;
            aiMinTrackBar.Name = "aiMinTrackBar";
            aiMinTrackBar.Size = new Size(297, 16);
            aiMinTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiMinTrackBar.TabIndex = 22;
            aiMinTrackBar.Text = "poisonTrackBar1";
            aiMinTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiMinTrackBar.UseCustomBackColor = true;
            aiMinTrackBar.Value = 25;
            aiMinTrackBar.Scroll += aiMinTrackBar_Scroll;
            // 
            // aiMaxTrackBar
            // 
            aiMaxTrackBar.BackColor = Color.Transparent;
            aiMaxTrackBar.Location = new Point(16, 45);
            aiMaxTrackBar.Maximum = 125;
            aiMaxTrackBar.Name = "aiMaxTrackBar";
            aiMaxTrackBar.Size = new Size(297, 16);
            aiMaxTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aiMaxTrackBar.TabIndex = 25;
            aiMaxTrackBar.Text = "poisonTrackBar2";
            aiMaxTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiMaxTrackBar.UseCustomBackColor = true;
            aiMaxTrackBar.Scroll += aiMaxTrackBar_Scroll;
            // 
            // aiSkillBox
            // 
            aiSkillBox.AutoSize = true;
            aiSkillBox.Font = new Font("Arial", 9F, FontStyle.Italic, GraphicsUnit.Point);
            aiSkillBox.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            aiSkillBox.Location = new Point(108, 7);
            aiSkillBox.Name = "aiSkillBox";
            aiSkillBox.Size = new Size(17, 19);
            aiSkillBox.TabIndex = 26;
            aiSkillBox.Text = "0";
            aiSkillBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillBox.UseCustomBackColor = true;
            // 
            // aiSkillLevelLabel
            // 
            aiSkillLevelLabel.AutoSize = true;
            aiSkillLevelLabel.Font = new Font("MV Boli", 9F, FontStyle.Regular, GraphicsUnit.Point);
            aiSkillLevelLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            aiSkillLevelLabel.Location = new Point(16, 7);
            aiSkillLevelLabel.Name = "aiSkillLevelLabel";
            aiSkillLevelLabel.Size = new Size(86, 19);
            aiSkillLevelLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            aiSkillLevelLabel.TabIndex = 27;
            aiSkillLevelLabel.Text = "Ai Skill Level:";
            aiSkillLevelLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aiSkillLevelLabel.UseCustomBackColor = true;
            // 
            // shortParadeCheckBox
            // 
            shortParadeCheckBox.AutoSize = true;
            shortParadeCheckBox.BackColor = Color.Transparent;
            shortParadeCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            shortParadeCheckBox.Location = new Point(263, 295);
            shortParadeCheckBox.Name = "shortParadeCheckBox";
            shortParadeCheckBox.Size = new Size(130, 19);
            shortParadeCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            shortParadeCheckBox.TabIndex = 42;
            shortParadeCheckBox.Text = "Short Parade Lap";
            shortParadeCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            shortParadeCheckBox.UseCustomBackColor = true;
            shortParadeCheckBox.UseSelectable = true;
            shortParadeCheckBox.UseVisualStyleBackColor = false;
            // 
            // qualiAloneCheckBox
            // 
            qualiAloneCheckBox.AutoSize = true;
            qualiAloneCheckBox.BackColor = Color.Transparent;
            qualiAloneCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            qualiAloneCheckBox.Location = new Point(263, 248);
            qualiAloneCheckBox.Name = "qualiAloneCheckBox";
            qualiAloneCheckBox.Size = new Size(107, 19);
            qualiAloneCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            qualiAloneCheckBox.TabIndex = 41;
            qualiAloneCheckBox.Text = "Qualify Alone";
            qualiAloneCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            qualiAloneCheckBox.UseCustomBackColor = true;
            qualiAloneCheckBox.UseSelectable = true;
            qualiAloneCheckBox.UseVisualStyleBackColor = false;
            // 
            // selectTracksCheckBox
            // 
            selectTracksCheckBox.AutoSize = true;
            selectTracksCheckBox.BackColor = Color.Transparent;
            selectTracksCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            selectTracksCheckBox.Location = new Point(93, 342);
            selectTracksCheckBox.Name = "selectTracksCheckBox";
            selectTracksCheckBox.Size = new Size(101, 19);
            selectTracksCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            selectTracksCheckBox.TabIndex = 39;
            selectTracksCheckBox.Text = "Select Tracks";
            selectTracksCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            selectTracksCheckBox.UseCustomBackColor = true;
            selectTracksCheckBox.UseSelectable = true;
            selectTracksCheckBox.UseVisualStyleBackColor = false;
            // 
            // disableCarDamageCheckBox
            // 
            disableCarDamageCheckBox.AutoSize = true;
            disableCarDamageCheckBox.BackColor = Color.Transparent;
            disableCarDamageCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            disableCarDamageCheckBox.Location = new Point(93, 201);
            disableCarDamageCheckBox.Name = "disableCarDamageCheckBox";
            disableCarDamageCheckBox.Size = new Size(149, 19);
            disableCarDamageCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            disableCarDamageCheckBox.TabIndex = 36;
            disableCarDamageCheckBox.Text = "Disable Car Damage";
            disableCarDamageCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            disableCarDamageCheckBox.UseCustomBackColor = true;
            disableCarDamageCheckBox.UseSelectable = true;
            disableCarDamageCheckBox.UseVisualStyleBackColor = false;
            // 
            // carListCombo
            // 
            carListCombo.DropDownHeight = 320;
            carListCombo.FormattingEnabled = true;
            carListCombo.IntegralHeight = false;
            carListCombo.ItemHeight = 23;
            carListCombo.Location = new Point(93, 155);
            carListCombo.Name = "carListCombo";
            carListCombo.Size = new Size(300, 29);
            carListCombo.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            carListCombo.TabIndex = 35;
            carListCombo.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            carListCombo.UseSelectable = true;
            // 
            // seriesListCombo
            // 
            seriesListCombo.DropDownHeight = 415;
            seriesListCombo.FormattingEnabled = true;
            seriesListCombo.IntegralHeight = false;
            seriesListCombo.ItemHeight = 23;
            seriesListCombo.Location = new Point(93, 110);
            seriesListCombo.Name = "seriesListCombo";
            seriesListCombo.Size = new Size(300, 29);
            seriesListCombo.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seriesListCombo.TabIndex = 34;
            seriesListCombo.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seriesListCombo.UseSelectable = true;
            seriesListCombo.SelectedIndexChanged += seriesListCombo_SelectedIndexChanged;
            // 
            // seasonComboBox
            // 
            seasonComboBox.DropDownHeight = 420;
            seasonComboBox.FormattingEnabled = true;
            seasonComboBox.IntegralHeight = false;
            seasonComboBox.ItemHeight = 23;
            seasonComboBox.Location = new Point(93, 65);
            seasonComboBox.Name = "seasonComboBox";
            seasonComboBox.Size = new Size(300, 29);
            seasonComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seasonComboBox.TabIndex = 33;
            seasonComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seasonComboBox.UseSelectable = true;
            seasonComboBox.SelectionChangeCommitted += seasonComboBox_SelectionChangeCommitted;
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
            seasonNameTextBox.Location = new Point(93, 20);
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
            seasonNameTextBox.TabIndex = 32;
            seasonNameTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seasonNameTextBox.UseSelectable = true;
            seasonNameTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            seasonNameTextBox.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // tabPage2
            // 
            poisonStyleExtender1.SetApplyPoisonTheme(tabPage2, true);
            tabPage2.BackgroundImage = (Image)resources.GetObject("tabPage2.BackgroundImage");
            tabPage2.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage2.Controls.Add(versionLabel);
            tabPage2.Controls.Add(forumLinkLabel);
            tabPage2.Location = new Point(4, 35);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(412, 558);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "About";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Location = new Point(366, 534);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(31, 15);
            versionLabel.TabIndex = 1;
            versionLabel.Text = "0000";
            // 
            // forumLinkLabel
            // 
            forumLinkLabel.Location = new Point(152, 297);
            forumLinkLabel.Name = "forumLinkLabel";
            forumLinkLabel.Size = new Size(108, 23);
            forumLinkLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            forumLinkLabel.TabIndex = 0;
            forumLinkLabel.Text = "AiSeasonCreator";
            forumLinkLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            forumLinkLabel.UseCustomBackColor = true;
            forumLinkLabel.UseSelectable = true;
            forumLinkLabel.UseStyleColors = true;
            forumLinkLabel.Click += forumLinkLabel_Click;
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(tabPage1);
            mainTabControl.Controls.Add(tabPage2);
            mainTabControl.Location = new Point(0, 24);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.Padding = new Point(6, 8);
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(420, 597);
            mainTabControl.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            mainTabControl.TabIndex = 31;
            mainTabControl.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            mainTabControl.UseSelectable = true;
            mainTabControl.UseStyleColors = true;
            mainTabControl.MouseDown += mainTabControl_MouseDown;
            // 
            // poisonStyleManager1
            // 
            poisonStyleManager1.Owner = null;
            poisonStyleManager1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            poisonStyleManager1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.Transparent;
            closeButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Tall;
            closeButton.Location = new Point(396, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(24, 24);
            closeButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            closeButton.TabIndex = 37;
            closeButton.Text = "X";
            closeButton.TextAlign = ContentAlignment.TopCenter;
            closeButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            closeButton.UseCustomBackColor = true;
            closeButton.UseSelectable = true;
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // topBarPanel
            // 
            topBarPanel.Controls.Add(titleLabel);
            topBarPanel.Controls.Add(minimizeButton);
            topBarPanel.Controls.Add(closeButton);
            topBarPanel.HorizontalScrollbarBarColor = true;
            topBarPanel.HorizontalScrollbarHighlightOnWheel = false;
            topBarPanel.HorizontalScrollbarSize = 10;
            topBarPanel.Location = new Point(0, 0);
            topBarPanel.Name = "topBarPanel";
            topBarPanel.Size = new Size(420, 24);
            topBarPanel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            topBarPanel.TabIndex = 38;
            topBarPanel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            topBarPanel.VerticalScrollbarBarColor = true;
            topBarPanel.VerticalScrollbarHighlightOnWheel = false;
            topBarPanel.VerticalScrollbarSize = 10;
            topBarPanel.MouseDown += topBarPanel_MouseDown;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Location = new Point(156, 2);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(115, 19);
            titleLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            titleLabel.TabIndex = 46;
            titleLabel.Text = "Ai Season Creator";
            titleLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            titleLabel.UseCustomBackColor = true;
            titleLabel.MouseDown += titleLabel_MouseDown;
            // 
            // minimizeButton
            // 
            minimizeButton.BackColor = Color.Transparent;
            minimizeButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Tall;
            minimizeButton.Location = new Point(373, 0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(24, 24);
            minimizeButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            minimizeButton.TabIndex = 45;
            minimizeButton.Text = "_";
            minimizeButton.TextAlign = ContentAlignment.TopCenter;
            minimizeButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            minimizeButton.UseCustomBackColor = true;
            minimizeButton.UseSelectable = true;
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 620);
            Controls.Add(topBarPanel);
            Controls.Add(mainTabControl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = " AiSeasonCreator";
            TransparencyKey = Color.Fuchsia;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            aiSkillPanel.ResumeLayout(false);
            aiSkillPanel.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            mainTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)poisonStyleManager1).EndInit();
            topBarPanel.ResumeLayout(false);
            topBarPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        //private Button createSeason;
        private Label seriesListLabel;
        private Label seasonNameLabel;
        private Label carListLabel;
        private Label filePathLabel;
        //private CheckBox consistentWeatherCheckBox;
        private ToolTip toolTip1;
        //private CheckBox qualiAloneCheckBox;
        //private CheckBox selectTracksCheckBox;
        private Label incompleteFormLabel;
        private Panel carPanel;
        private Panel seriesPanel;
        private Panel seasonNamePanel;
        private Panel folderPathPanel;
        private Label seasonLabel;
        //private CheckBox shortParadeCheckBox;
        private ReaLTaiizor.Controls.PoisonStyleExtender poisonStyleExtender1;
        private ReaLTaiizor.Controls.PoisonTabControl mainTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ReaLTaiizor.Manager.PoisonStyleManager poisonStyleManager1;
        private ReaLTaiizor.Controls.PoisonTextBox seasonNameTextBox;
        private ReaLTaiizor.Controls.PoisonComboBox seasonComboBox;
        private ReaLTaiizor.Controls.PoisonComboBox seriesListCombo;
        private ReaLTaiizor.Controls.PoisonComboBox carListCombo;
        private ReaLTaiizor.Controls.PoisonCheckBox disableCarDamageCheckBox;
        private ReaLTaiizor.Controls.PoisonButton closeButton;
        private ReaLTaiizor.Controls.PoisonPanel topBarPanel;
        private ReaLTaiizor.Controls.PoisonCheckBox shortParadeCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox qualiAloneCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox aiAvoidPlayerCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox selectTracksCheckBox;
        private ReaLTaiizor.Controls.PoisonCheckBox consistentWeatherCheckBox;
        private Panel aiSkillPanel;
        private ReaLTaiizor.Controls.PoisonTrackBar aiMinTrackBar;
        private ReaLTaiizor.Controls.PoisonTrackBar aiMaxTrackBar;
        private ReaLTaiizor.Controls.PoisonLabel aiSkillBox;
        private ReaLTaiizor.Controls.PoisonLabel aiSkillLevelLabel;
        private ReaLTaiizor.Controls.PoisonTextBox filePathTextBox;
        private ReaLTaiizor.Controls.PoisonButton createSeason;
        private ReaLTaiizor.Controls.PoisonButton minimizeButton;
        private ReaLTaiizor.Controls.PoisonLabel titleLabel;
        private ReaLTaiizor.Controls.PoisonLinkLabel forumLinkLabel;
        private Label versionLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox afternoonRacesCheckBox;
    }
}