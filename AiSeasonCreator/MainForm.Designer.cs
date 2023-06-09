﻿namespace AiSeasonCreator
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
            seriesListCombo = new ComboBox();
            createSeason = new Button();
            seriesListLabel = new Label();
            seasonNameTextBox = new TextBox();
            seasonNameLabel = new Label();
            carListCombo = new ComboBox();
            carListLabel = new Label();
            aiSkillLevelLabel = new Label();
            minSkillLabel = new Label();
            maxSkillLabel = new Label();
            minSkillBox = new TextBox();
            maxSkillBox = new TextBox();
            filePathLabel = new Label();
            filePathTextBox = new TextBox();
            disableCarDamageCheckBox = new CheckBox();
            aiAvoidPlayerCheckBox = new CheckBox();
            aiMinTrackBar = new TrackBar();
            aiMaxTrackBar = new TrackBar();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            consistentWeatherCheckBox = new CheckBox();
            toolTip1 = new ToolTip(components);
            qualiAloneCheckBox = new CheckBox();
            selectTracksCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)aiMinTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aiMaxTrackBar).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // seriesListCombo
            // 
            seriesListCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            seriesListCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            seriesListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            seriesListCombo.FormattingEnabled = true;
            seriesListCombo.Location = new Point(93, 68);
            seriesListCombo.Name = "seriesListCombo";
            seriesListCombo.Size = new Size(274, 23);
            seriesListCombo.TabIndex = 2;
            seriesListCombo.SelectedIndexChanged += seriesListCombo_SelectedIndexChanged;
            // 
            // createSeason
            // 
            createSeason.Location = new Point(232, 428);
            createSeason.Name = "createSeason";
            createSeason.Size = new Size(135, 23);
            createSeason.TabIndex = 10;
            createSeason.Text = "Create Season";
            createSeason.UseVisualStyleBackColor = true;
            createSeason.Click += createSeason_Click;
            // 
            // seriesListLabel
            // 
            seriesListLabel.AutoSize = true;
            seriesListLabel.Location = new Point(50, 76);
            seriesListLabel.Name = "seriesListLabel";
            seriesListLabel.Size = new Size(37, 15);
            seriesListLabel.TabIndex = 2;
            seriesListLabel.Text = "Series";
            // 
            // seasonNameTextBox
            // 
            seasonNameTextBox.Location = new Point(93, 28);
            seasonNameTextBox.Name = "seasonNameTextBox";
            seasonNameTextBox.Size = new Size(274, 23);
            seasonNameTextBox.TabIndex = 1;
            // 
            // seasonNameLabel
            // 
            seasonNameLabel.AutoSize = true;
            seasonNameLabel.Location = new Point(8, 36);
            seasonNameLabel.Name = "seasonNameLabel";
            seasonNameLabel.Size = new Size(79, 15);
            seasonNameLabel.TabIndex = 4;
            seasonNameLabel.Text = "Season Name";
            // 
            // carListCombo
            // 
            carListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            carListCombo.FormattingEnabled = true;
            carListCombo.Location = new Point(93, 112);
            carListCombo.Name = "carListCombo";
            carListCombo.Size = new Size(274, 23);
            carListCombo.TabIndex = 3;
            // 
            // carListLabel
            // 
            carListLabel.AutoSize = true;
            carListLabel.Location = new Point(62, 120);
            carListLabel.Name = "carListLabel";
            carListLabel.Size = new Size(25, 15);
            carListLabel.TabIndex = 6;
            carListLabel.Text = "Car";
            // 
            // aiSkillLevelLabel
            // 
            aiSkillLevelLabel.AutoSize = true;
            aiSkillLevelLabel.Location = new Point(15, 312);
            aiSkillLevelLabel.Name = "aiSkillLevelLabel";
            aiSkillLevelLabel.Size = new Size(72, 30);
            aiSkillLevelLabel.TabIndex = 9;
            aiSkillLevelLabel.Text = "AI Skill Level\r\n(0-125)";
            // 
            // minSkillLabel
            // 
            minSkillLabel.AutoSize = true;
            minSkillLabel.Location = new Point(59, 297);
            minSkillLabel.Name = "minSkillLabel";
            minSkillLabel.Size = new Size(28, 15);
            minSkillLabel.TabIndex = 10;
            minSkillLabel.Text = "Min";
            // 
            // maxSkillLabel
            // 
            maxSkillLabel.AutoSize = true;
            maxSkillLabel.Location = new Point(59, 342);
            maxSkillLabel.Name = "maxSkillLabel";
            maxSkillLabel.Size = new Size(30, 15);
            maxSkillLabel.TabIndex = 11;
            maxSkillLabel.Text = "Max";
            // 
            // minSkillBox
            // 
            minSkillBox.Enabled = false;
            minSkillBox.Location = new Point(337, 297);
            minSkillBox.Name = "minSkillBox";
            minSkillBox.Size = new Size(30, 23);
            minSkillBox.TabIndex = 12;
            // 
            // maxSkillBox
            // 
            maxSkillBox.Enabled = false;
            maxSkillBox.Location = new Point(337, 339);
            maxSkillBox.Name = "maxSkillBox";
            maxSkillBox.Size = new Size(30, 23);
            maxSkillBox.TabIndex = 13;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Location = new Point(20, 390);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(67, 15);
            filePathLabel.TabIndex = 14;
            filePathLabel.Text = "Folder Path";
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(93, 387);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.ReadOnly = true;
            filePathTextBox.Size = new Size(274, 23);
            filePathTextBox.TabIndex = 9;
            filePathTextBox.Text = "Double click to add folder path. iRacing\\aiseasons";
            filePathTextBox.MouseDoubleClick += filePathTextBox_MouseDoubleClick;
            // 
            // disableCarDamageCheckBox
            // 
            disableCarDamageCheckBox.AutoSize = true;
            disableCarDamageCheckBox.Location = new Point(93, 148);
            disableCarDamageCheckBox.Name = "disableCarDamageCheckBox";
            disableCarDamageCheckBox.Size = new Size(132, 19);
            disableCarDamageCheckBox.TabIndex = 4;
            disableCarDamageCheckBox.Text = "Disable Car Damage";
            disableCarDamageCheckBox.UseVisualStyleBackColor = true;
            // 
            // aiAvoidPlayerCheckBox
            // 
            aiAvoidPlayerCheckBox.AutoSize = true;
            aiAvoidPlayerCheckBox.Location = new Point(93, 173);
            aiAvoidPlayerCheckBox.Name = "aiAvoidPlayerCheckBox";
            aiAvoidPlayerCheckBox.Size = new Size(111, 19);
            aiAvoidPlayerCheckBox.TabIndex = 5;
            aiAvoidPlayerCheckBox.Text = "AI Avoids Player";
            aiAvoidPlayerCheckBox.UseVisualStyleBackColor = true;
            // 
            // aiMinTrackBar
            // 
            aiMinTrackBar.Location = new Point(93, 282);
            aiMinTrackBar.Maximum = 125;
            aiMinTrackBar.Name = "aiMinTrackBar";
            aiMinTrackBar.Size = new Size(238, 45);
            aiMinTrackBar.TabIndex = 7;
            aiMinTrackBar.Value = 25;
            aiMinTrackBar.Scroll += aiMinTrackBar_Scroll;
            // 
            // aiMaxTrackBar
            // 
            aiMaxTrackBar.Location = new Point(93, 326);
            aiMaxTrackBar.Maximum = 125;
            aiMaxTrackBar.Name = "aiMaxTrackBar";
            aiMaxTrackBar.Size = new Size(238, 45);
            aiMaxTrackBar.TabIndex = 8;
            aiMaxTrackBar.Value = 50;
            aiMaxTrackBar.Scroll += aiMaxTrackBar_Scroll;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(384, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, aboutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "&Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // consistentWeatherCheckBox
            // 
            consistentWeatherCheckBox.AutoSize = true;
            consistentWeatherCheckBox.Location = new Point(93, 198);
            consistentWeatherCheckBox.Name = "consistentWeatherCheckBox";
            consistentWeatherCheckBox.Size = new Size(129, 19);
            consistentWeatherCheckBox.TabIndex = 6;
            consistentWeatherCheckBox.Text = "Consistent Weather";
            toolTip1.SetToolTip(consistentWeatherCheckBox, "Checking this box will set the weather to 78 degrees, with 55% humidity for every race. This may help the AI to race more consistently. ");
            consistentWeatherCheckBox.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 500000;
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 10;
            // 
            // qualiAloneCheckBox
            // 
            qualiAloneCheckBox.AutoSize = true;
            qualiAloneCheckBox.Location = new Point(93, 223);
            qualiAloneCheckBox.Name = "qualiAloneCheckBox";
            qualiAloneCheckBox.Size = new Size(98, 19);
            qualiAloneCheckBox.TabIndex = 22;
            qualiAloneCheckBox.Text = "Qualify Alone";
            qualiAloneCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectTracksCheckBox
            // 
            selectTracksCheckBox.AutoSize = true;
            selectTracksCheckBox.Location = new Point(93, 248);
            selectTracksCheckBox.Name = "selectTracksCheckBox";
            selectTracksCheckBox.Size = new Size(92, 19);
            selectTracksCheckBox.TabIndex = 23;
            selectTracksCheckBox.Text = "Select Tracks";
            selectTracksCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 463);
            Controls.Add(selectTracksCheckBox);
            Controls.Add(qualiAloneCheckBox);
            Controls.Add(consistentWeatherCheckBox);
            Controls.Add(aiMaxTrackBar);
            Controls.Add(aiMinTrackBar);
            Controls.Add(aiAvoidPlayerCheckBox);
            Controls.Add(disableCarDamageCheckBox);
            Controls.Add(filePathTextBox);
            Controls.Add(filePathLabel);
            Controls.Add(maxSkillBox);
            Controls.Add(minSkillBox);
            Controls.Add(maxSkillLabel);
            Controls.Add(minSkillLabel);
            Controls.Add(aiSkillLevelLabel);
            Controls.Add(carListLabel);
            Controls.Add(carListCombo);
            Controls.Add(seasonNameLabel);
            Controls.Add(seasonNameTextBox);
            Controls.Add(seriesListLabel);
            Controls.Add(createSeason);
            Controls.Add(seriesListCombo);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " AiSeasonCreator";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)aiMinTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)aiMaxTrackBar).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox seriesListCombo;
        private Button createSeason;
        private Label seriesListLabel;
        private TextBox seasonNameTextBox;
        private Label seasonNameLabel;
        private ComboBox carListCombo;
        private Label carListLabel;
        private Label aiSkillLevelLabel;
        private Label minSkillLabel;
        private Label maxSkillLabel;
        private TextBox minSkillBox;
        private TextBox maxSkillBox;
        private Label filePathLabel;
        private TextBox filePathTextBox;
        private CheckBox disableCarDamageCheckBox;
        private CheckBox aiAvoidPlayerCheckBox;
        private TrackBar aiMinTrackBar;
        private TrackBar aiMaxTrackBar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private CheckBox consistentWeatherCheckBox;
        private ToolTip toolTip1;
        private CheckBox qualiAloneCheckBox;
        private CheckBox selectTracksCheckBox;
    }
}