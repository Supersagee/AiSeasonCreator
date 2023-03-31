namespace iRacingSeasonCreator
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
            seriesListCombo.TabIndex = 0;
            seriesListCombo.SelectedIndexChanged += seriesListCombo_SelectedIndexChanged;
            // 
            // createSeason
            // 
            createSeason.Location = new Point(232, 396);
            createSeason.Name = "createSeason";
            createSeason.Size = new Size(135, 23);
            createSeason.TabIndex = 1;
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
            seasonNameTextBox.Location = new Point(93, 23);
            seasonNameTextBox.Name = "seasonNameTextBox";
            seasonNameTextBox.Size = new Size(274, 23);
            seasonNameTextBox.TabIndex = 3;
            // 
            // seasonNameLabel
            // 
            seasonNameLabel.AutoSize = true;
            seasonNameLabel.Location = new Point(8, 31);
            seasonNameLabel.Name = "seasonNameLabel";
            seasonNameLabel.Size = new Size(79, 15);
            seasonNameLabel.TabIndex = 4;
            seasonNameLabel.Text = "Season Name";
            // 
            // carListCombo
            // 
            carListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            carListCombo.FormattingEnabled = true;
            carListCombo.Location = new Point(93, 121);
            carListCombo.Name = "carListCombo";
            carListCombo.Size = new Size(274, 23);
            carListCombo.TabIndex = 5;
            // 
            // carListLabel
            // 
            carListLabel.AutoSize = true;
            carListLabel.Location = new Point(62, 129);
            carListLabel.Name = "carListLabel";
            carListLabel.Size = new Size(25, 15);
            carListLabel.TabIndex = 6;
            carListLabel.Text = "Car";
            // 
            // aiSkillLevelLabel
            // 
            aiSkillLevelLabel.AutoSize = true;
            aiSkillLevelLabel.Location = new Point(12, 272);
            aiSkillLevelLabel.Name = "aiSkillLevelLabel";
            aiSkillLevelLabel.Size = new Size(72, 30);
            aiSkillLevelLabel.TabIndex = 9;
            aiSkillLevelLabel.Text = "AI Skill Level\r\n(0-125)";
            // 
            // minSkillLabel
            // 
            minSkillLabel.AutoSize = true;
            minSkillLabel.Location = new Point(93, 261);
            minSkillLabel.Name = "minSkillLabel";
            minSkillLabel.Size = new Size(28, 15);
            minSkillLabel.TabIndex = 10;
            minSkillLabel.Text = "Min";
            // 
            // maxSkillLabel
            // 
            maxSkillLabel.AutoSize = true;
            maxSkillLabel.Location = new Point(141, 261);
            maxSkillLabel.Name = "maxSkillLabel";
            maxSkillLabel.Size = new Size(30, 15);
            maxSkillLabel.TabIndex = 11;
            maxSkillLabel.Text = "Max";
            // 
            // minSkillBox
            // 
            minSkillBox.Location = new Point(93, 279);
            minSkillBox.Name = "minSkillBox";
            minSkillBox.Size = new Size(30, 23);
            minSkillBox.TabIndex = 12;
            // 
            // maxSkillBox
            // 
            maxSkillBox.Location = new Point(141, 279);
            maxSkillBox.Name = "maxSkillBox";
            maxSkillBox.Size = new Size(30, 23);
            maxSkillBox.TabIndex = 13;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Location = new Point(20, 338);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(67, 15);
            filePathLabel.TabIndex = 14;
            filePathLabel.Text = "Folder Path";
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(93, 335);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.ReadOnly = true;
            filePathTextBox.Size = new Size(274, 23);
            filePathTextBox.TabIndex = 15;
            filePathTextBox.Text = "Double click to add folder path. iRacing\\aiseasons";
            filePathTextBox.MouseDoubleClick += filePathTextBox_MouseDoubleClick;
            // 
            // disableCarDamageCheckBox
            // 
            disableCarDamageCheckBox.AutoSize = true;
            disableCarDamageCheckBox.Location = new Point(93, 173);
            disableCarDamageCheckBox.Name = "disableCarDamageCheckBox";
            disableCarDamageCheckBox.Size = new Size(132, 19);
            disableCarDamageCheckBox.TabIndex = 16;
            disableCarDamageCheckBox.Text = "Disable Car Damage";
            disableCarDamageCheckBox.UseVisualStyleBackColor = true;
            // 
            // aiAvoidPlayerCheckBox
            // 
            aiAvoidPlayerCheckBox.AutoSize = true;
            aiAvoidPlayerCheckBox.Location = new Point(93, 211);
            aiAvoidPlayerCheckBox.Name = "aiAvoidPlayerCheckBox";
            aiAvoidPlayerCheckBox.Size = new Size(111, 19);
            aiAvoidPlayerCheckBox.TabIndex = 17;
            aiAvoidPlayerCheckBox.Text = "AI Avoids Player";
            aiAvoidPlayerCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 441);
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
            MaximizeBox = false;
            MaximumSize = new Size(400, 480);
            MinimumSize = new Size(400, 480);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "iRacing Season Creator";
            Load += MainForm_Load;
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
    }
}