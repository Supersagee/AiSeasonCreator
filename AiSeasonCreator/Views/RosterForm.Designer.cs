namespace AiSeasonCreator.Views
{
    partial class RosterForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RosterForm));
            rosterSeriesLabel = new Label();
            rosterSourceLabel = new Label();
            attributesGroupBox = new GroupBox();
            aggressionPanel = new Panel();
            aggressionValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            aggressionLabel = new ReaLTaiizor.Controls.PoisonLabel();
            aggressionCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            aggressionRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            relativeSkillPanel = new Panel();
            relativeSkillValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            relativeSkillLabel = new ReaLTaiizor.Controls.PoisonLabel();
            relativeSkillCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            relativeSkillRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            smoothnessPanel = new Panel();
            smoothnessValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            smoothnessLabel = new ReaLTaiizor.Controls.PoisonLabel();
            smoothnessCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            smoothnessRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            agePanel = new Panel();
            ageValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            ageLabel = new ReaLTaiizor.Controls.PoisonLabel();
            ageRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            ageCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            pitStratPanel = new Panel();
            pitStratRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            pitStratValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            pitStratLabel = new ReaLTaiizor.Controls.PoisonLabel();
            pitStratCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            optimismPanel = new Panel();
            optimismValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            optimismLabel = new ReaLTaiizor.Controls.PoisonLabel();
            optimismCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            optimismRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            pitCrewPanel = new Panel();
            pitCrewValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            pitCrewRangeTrackBar = new AiSeasonCreator.Helpers.RangeTrackBar();
            pitCrewLabel = new ReaLTaiizor.Controls.PoisonLabel();
            pitCrewCheckBox = new ReaLTaiizor.Controls.PoisonCheckBox();
            createRosterButton = new ReaLTaiizor.Controls.PoisonButton();
            driverCountLabel = new ReaLTaiizor.Controls.PoisonLabel();
            driverCountTrackBar = new ReaLTaiizor.Controls.PoisonTrackBar();
            driverCountValueLabel = new ReaLTaiizor.Controls.PoisonLabel();
            seriesComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            rosterNameTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            driversDataGridView = new DataGridView();
            Driver = new DataGridViewTextBoxColumn();
            CarNumber = new DataGridViewTextBoxColumn();
            CarLogo = new DataGridViewImageColumn();
            CarName = new DataGridViewTextBoxColumn();
            RelativeSkill = new DataGridViewTextBoxColumn();
            Aggression = new DataGridViewTextBoxColumn();
            Optimism = new DataGridViewTextBoxColumn();
            Smoothness = new DataGridViewTextBoxColumn();
            Age = new DataGridViewTextBoxColumn();
            PitCrewSkill = new DataGridViewTextBoxColumn();
            PitStrat = new DataGridViewTextBoxColumn();
            updateSelectedDriversButton = new ReaLTaiizor.Controls.PoisonButton();
            updateAllDriversButton = new ReaLTaiizor.Controls.PoisonButton();
            createRosterRadioButton = new ReaLTaiizor.Controls.PoisonRadioButton();
            updateRosterRadioButton = new ReaLTaiizor.Controls.PoisonRadioButton();
            updateRosterPanel = new Panel();
            rosterComboBox = new ReaLTaiizor.Controls.PoisonComboBox();
            fixedRangeRadioButton = new ReaLTaiizor.Controls.PoisonRadioButton();
            minusPlusRadioButton = new ReaLTaiizor.Controls.PoisonRadioButton();
            createRosterPanel = new Panel();
            messageFormLabel = new Label();
            rosterNamePanel = new Panel();
            attributesGroupBox.SuspendLayout();
            aggressionPanel.SuspendLayout();
            relativeSkillPanel.SuspendLayout();
            smoothnessPanel.SuspendLayout();
            agePanel.SuspendLayout();
            pitStratPanel.SuspendLayout();
            optimismPanel.SuspendLayout();
            pitCrewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).BeginInit();
            updateRosterPanel.SuspendLayout();
            createRosterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rosterSeriesLabel
            // 
            rosterSeriesLabel.AutoSize = true;
            rosterSeriesLabel.ForeColor = SystemColors.ControlDark;
            rosterSeriesLabel.Location = new Point(34, 107);
            rosterSeriesLabel.Name = "rosterSeriesLabel";
            rosterSeriesLabel.Size = new Size(37, 15);
            rosterSeriesLabel.TabIndex = 73;
            rosterSeriesLabel.Text = "Series";
            // 
            // rosterSourceLabel
            // 
            rosterSourceLabel.AutoSize = true;
            rosterSourceLabel.ForeColor = SystemColors.ControlDark;
            rosterSourceLabel.Location = new Point(34, 41);
            rosterSourceLabel.Name = "rosterSourceLabel";
            rosterSourceLabel.Size = new Size(40, 15);
            rosterSourceLabel.TabIndex = 72;
            rosterSourceLabel.Text = "Roster";
            // 
            // attributesGroupBox
            // 
            attributesGroupBox.Controls.Add(aggressionPanel);
            attributesGroupBox.Controls.Add(relativeSkillPanel);
            attributesGroupBox.Controls.Add(smoothnessPanel);
            attributesGroupBox.Controls.Add(agePanel);
            attributesGroupBox.Controls.Add(pitStratPanel);
            attributesGroupBox.Controls.Add(optimismPanel);
            attributesGroupBox.Controls.Add(pitCrewPanel);
            attributesGroupBox.ForeColor = SystemColors.ControlDark;
            attributesGroupBox.Location = new Point(820, 52);
            attributesGroupBox.Name = "attributesGroupBox";
            attributesGroupBox.Size = new Size(428, 334);
            attributesGroupBox.TabIndex = 70;
            attributesGroupBox.TabStop = false;
            attributesGroupBox.Text = "Attributes";
            // 
            // aggressionPanel
            // 
            aggressionPanel.BackColor = Color.FromArgb(220, 36, 36, 54);
            aggressionPanel.Controls.Add(aggressionValueLabel);
            aggressionPanel.Controls.Add(aggressionLabel);
            aggressionPanel.Controls.Add(aggressionCheckBox);
            aggressionPanel.Controls.Add(aggressionRangeTrackBar);
            aggressionPanel.Location = new Point(10, 62);
            aggressionPanel.Name = "aggressionPanel";
            aggressionPanel.Size = new Size(412, 44);
            aggressionPanel.TabIndex = 45;
            // 
            // aggressionValueLabel
            // 
            aggressionValueLabel.AutoSize = true;
            aggressionValueLabel.BackColor = Color.Transparent;
            aggressionValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            aggressionValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            aggressionValueLabel.Location = new Point(25, 22);
            aggressionValueLabel.Name = "aggressionValueLabel";
            aggressionValueLabel.Size = new Size(17, 19);
            aggressionValueLabel.TabIndex = 26;
            aggressionValueLabel.Text = "0";
            aggressionValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aggressionValueLabel.UseCustomBackColor = true;
            // 
            // aggressionLabel
            // 
            aggressionLabel.AutoSize = true;
            aggressionLabel.BackColor = Color.Transparent;
            aggressionLabel.Font = new Font("MV Boli", 9F);
            aggressionLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            aggressionLabel.Location = new Point(25, 3);
            aggressionLabel.Name = "aggressionLabel";
            aggressionLabel.Size = new Size(80, 19);
            aggressionLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            aggressionLabel.TabIndex = 27;
            aggressionLabel.Text = "Aggression:";
            aggressionLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aggressionLabel.UseCustomBackColor = true;
            // 
            // aggressionCheckBox
            // 
            aggressionCheckBox.AutoSize = true;
            aggressionCheckBox.BackColor = Color.Transparent;
            aggressionCheckBox.Checked = true;
            aggressionCheckBox.CheckState = CheckState.Checked;
            aggressionCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            aggressionCheckBox.Location = new Point(6, 12);
            aggressionCheckBox.Name = "aggressionCheckBox";
            aggressionCheckBox.Size = new Size(29, 19);
            aggressionCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            aggressionCheckBox.TabIndex = 45;
            aggressionCheckBox.Text = " ";
            aggressionCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            aggressionCheckBox.UseCustomBackColor = true;
            aggressionCheckBox.UseSelectable = true;
            aggressionCheckBox.UseVisualStyleBackColor = false;
            // 
            // aggressionRangeTrackBar
            // 
            aggressionRangeTrackBar.BackColor = Color.FromArgb(36, 36, 54);
            aggressionRangeTrackBar.Location = new Point(138, 6);
            aggressionRangeTrackBar.LowerValue = 0;
            aggressionRangeTrackBar.Maximum = 100;
            aggressionRangeTrackBar.Minimum = -100;
            aggressionRangeTrackBar.Name = "aggressionRangeTrackBar";
            aggressionRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            aggressionRangeTrackBar.Size = new Size(270, 32);
            aggressionRangeTrackBar.TabIndex = 90;
            aggressionRangeTrackBar.Text = "rangeTrackBar2";
            aggressionRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            aggressionRangeTrackBar.ThumbHoverColor = Color.LightGray;
            aggressionRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            aggressionRangeTrackBar.UpperValue = 10;
            aggressionRangeTrackBar.RangeChanged += aggressionRangeTrackBar_RangeChanged;
            // 
            // relativeSkillPanel
            // 
            relativeSkillPanel.BackColor = Color.FromArgb(220, 18, 18, 27);
            relativeSkillPanel.Controls.Add(relativeSkillValueLabel);
            relativeSkillPanel.Controls.Add(relativeSkillLabel);
            relativeSkillPanel.Controls.Add(relativeSkillCheckBox);
            relativeSkillPanel.Controls.Add(relativeSkillRangeTrackBar);
            relativeSkillPanel.Location = new Point(10, 18);
            relativeSkillPanel.Name = "relativeSkillPanel";
            relativeSkillPanel.Size = new Size(412, 44);
            relativeSkillPanel.TabIndex = 44;
            // 
            // relativeSkillValueLabel
            // 
            relativeSkillValueLabel.AutoSize = true;
            relativeSkillValueLabel.BackColor = Color.Transparent;
            relativeSkillValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            relativeSkillValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            relativeSkillValueLabel.Location = new Point(25, 22);
            relativeSkillValueLabel.Name = "relativeSkillValueLabel";
            relativeSkillValueLabel.Size = new Size(17, 19);
            relativeSkillValueLabel.TabIndex = 26;
            relativeSkillValueLabel.Text = "0";
            relativeSkillValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            relativeSkillValueLabel.UseCustomBackColor = true;
            // 
            // relativeSkillLabel
            // 
            relativeSkillLabel.AutoSize = true;
            relativeSkillLabel.BackColor = Color.Transparent;
            relativeSkillLabel.Font = new Font("MV Boli", 9F);
            relativeSkillLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            relativeSkillLabel.Location = new Point(25, 3);
            relativeSkillLabel.Name = "relativeSkillLabel";
            relativeSkillLabel.Size = new Size(86, 19);
            relativeSkillLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            relativeSkillLabel.TabIndex = 27;
            relativeSkillLabel.Text = "Relative Skill:";
            relativeSkillLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            relativeSkillLabel.UseCustomBackColor = true;
            // 
            // relativeSkillCheckBox
            // 
            relativeSkillCheckBox.AutoSize = true;
            relativeSkillCheckBox.BackColor = Color.Transparent;
            relativeSkillCheckBox.Checked = true;
            relativeSkillCheckBox.CheckState = CheckState.Checked;
            relativeSkillCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            relativeSkillCheckBox.Location = new Point(6, 12);
            relativeSkillCheckBox.Name = "relativeSkillCheckBox";
            relativeSkillCheckBox.Size = new Size(29, 19);
            relativeSkillCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            relativeSkillCheckBox.TabIndex = 45;
            relativeSkillCheckBox.Text = " ";
            relativeSkillCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            relativeSkillCheckBox.UseCustomBackColor = true;
            relativeSkillCheckBox.UseSelectable = true;
            relativeSkillCheckBox.UseVisualStyleBackColor = false;
            // 
            // relativeSkillRangeTrackBar
            // 
            relativeSkillRangeTrackBar.BackColor = Color.FromArgb(18, 18, 27);
            relativeSkillRangeTrackBar.Location = new Point(138, 6);
            relativeSkillRangeTrackBar.LowerValue = 0;
            relativeSkillRangeTrackBar.Maximum = 100;
            relativeSkillRangeTrackBar.Minimum = -100;
            relativeSkillRangeTrackBar.Name = "relativeSkillRangeTrackBar";
            relativeSkillRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            relativeSkillRangeTrackBar.Size = new Size(270, 32);
            relativeSkillRangeTrackBar.TabIndex = 89;
            relativeSkillRangeTrackBar.Text = "rangeTrackBar1";
            relativeSkillRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            relativeSkillRangeTrackBar.ThumbHoverColor = Color.LightGray;
            relativeSkillRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            relativeSkillRangeTrackBar.UpperValue = 10;
            relativeSkillRangeTrackBar.RangeChanged += relativeSkillRangeTrackBar_RangeChanged;
            // 
            // smoothnessPanel
            // 
            smoothnessPanel.BackColor = Color.FromArgb(220, 36, 36, 54);
            smoothnessPanel.Controls.Add(smoothnessValueLabel);
            smoothnessPanel.Controls.Add(smoothnessLabel);
            smoothnessPanel.Controls.Add(smoothnessCheckBox);
            smoothnessPanel.Controls.Add(smoothnessRangeTrackBar);
            smoothnessPanel.Location = new Point(10, 150);
            smoothnessPanel.Name = "smoothnessPanel";
            smoothnessPanel.Size = new Size(412, 44);
            smoothnessPanel.TabIndex = 51;
            // 
            // smoothnessValueLabel
            // 
            smoothnessValueLabel.AutoSize = true;
            smoothnessValueLabel.BackColor = Color.Transparent;
            smoothnessValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            smoothnessValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            smoothnessValueLabel.Location = new Point(25, 22);
            smoothnessValueLabel.Name = "smoothnessValueLabel";
            smoothnessValueLabel.Size = new Size(17, 19);
            smoothnessValueLabel.TabIndex = 26;
            smoothnessValueLabel.Text = "0";
            smoothnessValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            smoothnessValueLabel.UseCustomBackColor = true;
            // 
            // smoothnessLabel
            // 
            smoothnessLabel.AutoSize = true;
            smoothnessLabel.BackColor = Color.Transparent;
            smoothnessLabel.Font = new Font("MV Boli", 9F);
            smoothnessLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            smoothnessLabel.Location = new Point(25, 3);
            smoothnessLabel.Name = "smoothnessLabel";
            smoothnessLabel.Size = new Size(87, 19);
            smoothnessLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            smoothnessLabel.TabIndex = 27;
            smoothnessLabel.Text = "Smoothness:";
            smoothnessLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            smoothnessLabel.UseCustomBackColor = true;
            // 
            // smoothnessCheckBox
            // 
            smoothnessCheckBox.AutoSize = true;
            smoothnessCheckBox.BackColor = Color.Transparent;
            smoothnessCheckBox.Checked = true;
            smoothnessCheckBox.CheckState = CheckState.Checked;
            smoothnessCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            smoothnessCheckBox.Location = new Point(6, 12);
            smoothnessCheckBox.Name = "smoothnessCheckBox";
            smoothnessCheckBox.Size = new Size(29, 19);
            smoothnessCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            smoothnessCheckBox.TabIndex = 45;
            smoothnessCheckBox.Text = " ";
            smoothnessCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            smoothnessCheckBox.UseCustomBackColor = true;
            smoothnessCheckBox.UseSelectable = true;
            smoothnessCheckBox.UseVisualStyleBackColor = false;
            // 
            // smoothnessRangeTrackBar
            // 
            smoothnessRangeTrackBar.BackColor = Color.FromArgb(36, 36, 54);
            smoothnessRangeTrackBar.Location = new Point(138, 6);
            smoothnessRangeTrackBar.LowerValue = 0;
            smoothnessRangeTrackBar.Maximum = 100;
            smoothnessRangeTrackBar.Minimum = -100;
            smoothnessRangeTrackBar.Name = "smoothnessRangeTrackBar";
            smoothnessRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            smoothnessRangeTrackBar.Size = new Size(270, 32);
            smoothnessRangeTrackBar.TabIndex = 92;
            smoothnessRangeTrackBar.Text = "rangeTrackBar4";
            smoothnessRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            smoothnessRangeTrackBar.ThumbHoverColor = Color.LightGray;
            smoothnessRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            smoothnessRangeTrackBar.UpperValue = 10;
            smoothnessRangeTrackBar.RangeChanged += smoothnessRangeTrackBar_RangeChanged;
            // 
            // agePanel
            // 
            agePanel.BackColor = Color.FromArgb(220, 18, 18, 27);
            agePanel.Controls.Add(ageValueLabel);
            agePanel.Controls.Add(ageLabel);
            agePanel.Controls.Add(ageRangeTrackBar);
            agePanel.Controls.Add(ageCheckBox);
            agePanel.Location = new Point(10, 194);
            agePanel.Name = "agePanel";
            agePanel.Size = new Size(412, 44);
            agePanel.TabIndex = 52;
            // 
            // ageValueLabel
            // 
            ageValueLabel.AutoSize = true;
            ageValueLabel.BackColor = Color.Transparent;
            ageValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            ageValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            ageValueLabel.Location = new Point(25, 22);
            ageValueLabel.Name = "ageValueLabel";
            ageValueLabel.Size = new Size(17, 19);
            ageValueLabel.TabIndex = 26;
            ageValueLabel.Text = "0";
            ageValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            ageValueLabel.UseCustomBackColor = true;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.BackColor = Color.Transparent;
            ageLabel.Font = new Font("MV Boli", 9F);
            ageLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            ageLabel.Location = new Point(25, 3);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(36, 19);
            ageLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            ageLabel.TabIndex = 27;
            ageLabel.Text = "Age:";
            ageLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            ageLabel.UseCustomBackColor = true;
            // 
            // ageRangeTrackBar
            // 
            ageRangeTrackBar.BackColor = Color.FromArgb(18, 18, 27);
            ageRangeTrackBar.Location = new Point(138, 6);
            ageRangeTrackBar.LowerValue = 0;
            ageRangeTrackBar.Maximum = 77;
            ageRangeTrackBar.Minimum = -77;
            ageRangeTrackBar.Name = "ageRangeTrackBar";
            ageRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            ageRangeTrackBar.Size = new Size(270, 32);
            ageRangeTrackBar.TabIndex = 93;
            ageRangeTrackBar.Text = "rangeTrackBar5";
            ageRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            ageRangeTrackBar.ThumbHoverColor = Color.LightGray;
            ageRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            ageRangeTrackBar.UpperValue = 10;
            ageRangeTrackBar.RangeChanged += ageRangeTrackBar_RangeChanged;
            // 
            // ageCheckBox
            // 
            ageCheckBox.AutoSize = true;
            ageCheckBox.BackColor = Color.Transparent;
            ageCheckBox.Checked = true;
            ageCheckBox.CheckState = CheckState.Checked;
            ageCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            ageCheckBox.Location = new Point(6, 12);
            ageCheckBox.Name = "ageCheckBox";
            ageCheckBox.Size = new Size(29, 19);
            ageCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            ageCheckBox.TabIndex = 45;
            ageCheckBox.Text = " ";
            ageCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            ageCheckBox.UseCustomBackColor = true;
            ageCheckBox.UseSelectable = true;
            ageCheckBox.UseVisualStyleBackColor = false;
            // 
            // pitStratPanel
            // 
            pitStratPanel.BackColor = Color.FromArgb(220, 18, 18, 27);
            pitStratPanel.Controls.Add(pitStratRangeTrackBar);
            pitStratPanel.Controls.Add(pitStratValueLabel);
            pitStratPanel.Controls.Add(pitStratLabel);
            pitStratPanel.Controls.Add(pitStratCheckBox);
            pitStratPanel.Location = new Point(10, 282);
            pitStratPanel.Name = "pitStratPanel";
            pitStratPanel.Size = new Size(412, 44);
            pitStratPanel.TabIndex = 54;
            // 
            // pitStratRangeTrackBar
            // 
            pitStratRangeTrackBar.BackColor = Color.FromArgb(18, 18, 27);
            pitStratRangeTrackBar.Location = new Point(138, 6);
            pitStratRangeTrackBar.LowerValue = 0;
            pitStratRangeTrackBar.Maximum = 100;
            pitStratRangeTrackBar.Minimum = -100;
            pitStratRangeTrackBar.Name = "pitStratRangeTrackBar";
            pitStratRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            pitStratRangeTrackBar.Size = new Size(270, 32);
            pitStratRangeTrackBar.TabIndex = 95;
            pitStratRangeTrackBar.Text = "rangeTrackBar7";
            pitStratRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            pitStratRangeTrackBar.ThumbHoverColor = Color.LightGray;
            pitStratRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            pitStratRangeTrackBar.UpperValue = 10;
            pitStratRangeTrackBar.RangeChanged += pitStratRangeTrackBar_RangeChanged;
            // 
            // pitStratValueLabel
            // 
            pitStratValueLabel.AutoSize = true;
            pitStratValueLabel.BackColor = Color.Transparent;
            pitStratValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            pitStratValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            pitStratValueLabel.Location = new Point(25, 22);
            pitStratValueLabel.Name = "pitStratValueLabel";
            pitStratValueLabel.Size = new Size(17, 19);
            pitStratValueLabel.TabIndex = 26;
            pitStratValueLabel.Text = "0";
            pitStratValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            pitStratValueLabel.UseCustomBackColor = true;
            // 
            // pitStratLabel
            // 
            pitStratLabel.AutoSize = true;
            pitStratLabel.BackColor = Color.Transparent;
            pitStratLabel.Font = new Font("MV Boli", 9F);
            pitStratLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            pitStratLabel.Location = new Point(25, 3);
            pitStratLabel.Name = "pitStratLabel";
            pitStratLabel.Size = new Size(61, 19);
            pitStratLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            pitStratLabel.TabIndex = 27;
            pitStratLabel.Text = "Pit Strat:";
            pitStratLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            pitStratLabel.UseCustomBackColor = true;
            // 
            // pitStratCheckBox
            // 
            pitStratCheckBox.AutoSize = true;
            pitStratCheckBox.BackColor = Color.Transparent;
            pitStratCheckBox.Checked = true;
            pitStratCheckBox.CheckState = CheckState.Checked;
            pitStratCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            pitStratCheckBox.Location = new Point(6, 12);
            pitStratCheckBox.Name = "pitStratCheckBox";
            pitStratCheckBox.Size = new Size(29, 19);
            pitStratCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            pitStratCheckBox.TabIndex = 45;
            pitStratCheckBox.Text = " ";
            pitStratCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            pitStratCheckBox.UseCustomBackColor = true;
            pitStratCheckBox.UseSelectable = true;
            pitStratCheckBox.UseVisualStyleBackColor = false;
            // 
            // optimismPanel
            // 
            optimismPanel.BackColor = Color.FromArgb(220, 18, 18, 27);
            optimismPanel.Controls.Add(optimismValueLabel);
            optimismPanel.Controls.Add(optimismLabel);
            optimismPanel.Controls.Add(optimismCheckBox);
            optimismPanel.Controls.Add(optimismRangeTrackBar);
            optimismPanel.Location = new Point(10, 106);
            optimismPanel.Name = "optimismPanel";
            optimismPanel.Size = new Size(412, 44);
            optimismPanel.TabIndex = 50;
            // 
            // optimismValueLabel
            // 
            optimismValueLabel.AutoSize = true;
            optimismValueLabel.BackColor = Color.Transparent;
            optimismValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            optimismValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            optimismValueLabel.Location = new Point(25, 22);
            optimismValueLabel.Name = "optimismValueLabel";
            optimismValueLabel.Size = new Size(17, 19);
            optimismValueLabel.TabIndex = 26;
            optimismValueLabel.Text = "0";
            optimismValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            optimismValueLabel.UseCustomBackColor = true;
            // 
            // optimismLabel
            // 
            optimismLabel.AutoSize = true;
            optimismLabel.BackColor = Color.Transparent;
            optimismLabel.Font = new Font("MV Boli", 9F);
            optimismLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            optimismLabel.Location = new Point(25, 3);
            optimismLabel.Name = "optimismLabel";
            optimismLabel.Size = new Size(72, 19);
            optimismLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            optimismLabel.TabIndex = 27;
            optimismLabel.Text = "Optimism:";
            optimismLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            optimismLabel.UseCustomBackColor = true;
            // 
            // optimismCheckBox
            // 
            optimismCheckBox.AutoSize = true;
            optimismCheckBox.BackColor = Color.Transparent;
            optimismCheckBox.Checked = true;
            optimismCheckBox.CheckState = CheckState.Checked;
            optimismCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            optimismCheckBox.Location = new Point(6, 12);
            optimismCheckBox.Name = "optimismCheckBox";
            optimismCheckBox.Size = new Size(29, 19);
            optimismCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            optimismCheckBox.TabIndex = 45;
            optimismCheckBox.Text = " ";
            optimismCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            optimismCheckBox.UseCustomBackColor = true;
            optimismCheckBox.UseSelectable = true;
            optimismCheckBox.UseVisualStyleBackColor = false;
            // 
            // optimismRangeTrackBar
            // 
            optimismRangeTrackBar.BackColor = Color.FromArgb(18, 18, 27);
            optimismRangeTrackBar.Location = new Point(138, 6);
            optimismRangeTrackBar.LowerValue = 0;
            optimismRangeTrackBar.Maximum = 100;
            optimismRangeTrackBar.Minimum = -100;
            optimismRangeTrackBar.Name = "optimismRangeTrackBar";
            optimismRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            optimismRangeTrackBar.Size = new Size(270, 32);
            optimismRangeTrackBar.TabIndex = 91;
            optimismRangeTrackBar.Text = "rangeTrackBar3";
            optimismRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            optimismRangeTrackBar.ThumbHoverColor = Color.LightGray;
            optimismRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            optimismRangeTrackBar.UpperValue = 10;
            optimismRangeTrackBar.RangeChanged += optimismRangeTrackBar_RangeChanged;
            // 
            // pitCrewPanel
            // 
            pitCrewPanel.BackColor = Color.FromArgb(220, 36, 36, 54);
            pitCrewPanel.Controls.Add(pitCrewValueLabel);
            pitCrewPanel.Controls.Add(pitCrewRangeTrackBar);
            pitCrewPanel.Controls.Add(pitCrewLabel);
            pitCrewPanel.Controls.Add(pitCrewCheckBox);
            pitCrewPanel.Location = new Point(10, 238);
            pitCrewPanel.Name = "pitCrewPanel";
            pitCrewPanel.Size = new Size(412, 44);
            pitCrewPanel.TabIndex = 53;
            // 
            // pitCrewValueLabel
            // 
            pitCrewValueLabel.AutoSize = true;
            pitCrewValueLabel.BackColor = Color.Transparent;
            pitCrewValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            pitCrewValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            pitCrewValueLabel.Location = new Point(25, 22);
            pitCrewValueLabel.Name = "pitCrewValueLabel";
            pitCrewValueLabel.Size = new Size(17, 19);
            pitCrewValueLabel.TabIndex = 26;
            pitCrewValueLabel.Text = "0";
            pitCrewValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            pitCrewValueLabel.UseCustomBackColor = true;
            // 
            // pitCrewRangeTrackBar
            // 
            pitCrewRangeTrackBar.BackColor = Color.FromArgb(36, 36, 54);
            pitCrewRangeTrackBar.Location = new Point(138, 6);
            pitCrewRangeTrackBar.LowerValue = 0;
            pitCrewRangeTrackBar.Maximum = 100;
            pitCrewRangeTrackBar.Minimum = -100;
            pitCrewRangeTrackBar.Name = "pitCrewRangeTrackBar";
            pitCrewRangeTrackBar.RangeColor = Color.FromArgb(153, 153, 153);
            pitCrewRangeTrackBar.Size = new Size(270, 32);
            pitCrewRangeTrackBar.TabIndex = 94;
            pitCrewRangeTrackBar.Text = "rangeTrackBar6";
            pitCrewRangeTrackBar.ThumbColor = Color.FromArgb(153, 153, 153);
            pitCrewRangeTrackBar.ThumbHoverColor = Color.LightGray;
            pitCrewRangeTrackBar.TrackColor = Color.FromArgb(51, 51, 51);
            pitCrewRangeTrackBar.UpperValue = 10;
            pitCrewRangeTrackBar.RangeChanged += pitCrewRangeTrackBar_RangeChanged;
            // 
            // pitCrewLabel
            // 
            pitCrewLabel.AutoSize = true;
            pitCrewLabel.BackColor = Color.Transparent;
            pitCrewLabel.Font = new Font("MV Boli", 9F);
            pitCrewLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            pitCrewLabel.Location = new Point(25, 3);
            pitCrewLabel.Name = "pitCrewLabel";
            pitCrewLabel.Size = new Size(63, 19);
            pitCrewLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            pitCrewLabel.TabIndex = 27;
            pitCrewLabel.Text = "Pit Crew:";
            pitCrewLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            pitCrewLabel.UseCustomBackColor = true;
            // 
            // pitCrewCheckBox
            // 
            pitCrewCheckBox.AutoSize = true;
            pitCrewCheckBox.BackColor = Color.Transparent;
            pitCrewCheckBox.Checked = true;
            pitCrewCheckBox.CheckState = CheckState.Checked;
            pitCrewCheckBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            pitCrewCheckBox.Location = new Point(6, 12);
            pitCrewCheckBox.Name = "pitCrewCheckBox";
            pitCrewCheckBox.Size = new Size(29, 19);
            pitCrewCheckBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            pitCrewCheckBox.TabIndex = 45;
            pitCrewCheckBox.Text = " ";
            pitCrewCheckBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            pitCrewCheckBox.UseCustomBackColor = true;
            pitCrewCheckBox.UseSelectable = true;
            pitCrewCheckBox.UseVisualStyleBackColor = false;
            // 
            // createRosterButton
            // 
            createRosterButton.BackColor = Color.FromArgb(18, 18, 27);
            createRosterButton.Highlight = true;
            createRosterButton.Location = new Point(108, 223);
            createRosterButton.Name = "createRosterButton";
            createRosterButton.Size = new Size(135, 50);
            createRosterButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            createRosterButton.TabIndex = 69;
            createRosterButton.Text = "Create Roster";
            createRosterButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            createRosterButton.UseCustomBackColor = true;
            createRosterButton.UseSelectable = true;
            createRosterButton.UseVisualStyleBackColor = false;
            createRosterButton.Click += createRosterButton_Click;
            // 
            // driverCountLabel
            // 
            driverCountLabel.AutoSize = true;
            driverCountLabel.BackColor = Color.Transparent;
            driverCountLabel.Font = new Font("MV Boli", 9F);
            driverCountLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Regular;
            driverCountLabel.Location = new Point(34, 179);
            driverCountLabel.Name = "driverCountLabel";
            driverCountLabel.Size = new Size(88, 19);
            driverCountLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            driverCountLabel.TabIndex = 27;
            driverCountLabel.Text = "Driver Count";
            driverCountLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            driverCountLabel.UseCustomBackColor = true;
            // 
            // driverCountTrackBar
            // 
            driverCountTrackBar.BackColor = Color.Transparent;
            driverCountTrackBar.Location = new Point(158, 182);
            driverCountTrackBar.Maximum = 60;
            driverCountTrackBar.Minimum = 12;
            driverCountTrackBar.Name = "driverCountTrackBar";
            driverCountTrackBar.Size = new Size(131, 16);
            driverCountTrackBar.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            driverCountTrackBar.TabIndex = 22;
            driverCountTrackBar.Text = "poisonTrackBar1";
            driverCountTrackBar.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            driverCountTrackBar.UseCustomBackColor = true;
            driverCountTrackBar.Value = 30;
            driverCountTrackBar.ValueChanged += driverCountTrackBar_ValueChanged;
            // 
            // driverCountValueLabel
            // 
            driverCountValueLabel.AutoSize = true;
            driverCountValueLabel.BackColor = Color.Transparent;
            driverCountValueLabel.Font = new Font("Arial", 9F, FontStyle.Italic);
            driverCountValueLabel.FontWeight = ReaLTaiizor.Extension.Poison.PoisonLabelWeight.Bold;
            driverCountValueLabel.Location = new Point(135, 179);
            driverCountValueLabel.Name = "driverCountValueLabel";
            driverCountValueLabel.Size = new Size(17, 19);
            driverCountValueLabel.TabIndex = 26;
            driverCountValueLabel.Text = "0";
            driverCountValueLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            driverCountValueLabel.UseCustomBackColor = true;
            // 
            // seriesComboBox
            // 
            seriesComboBox.BackColor = Color.FromArgb(18, 18, 27);
            seriesComboBox.DropDownHeight = 415;
            seriesComboBox.FormattingEnabled = true;
            seriesComboBox.IntegralHeight = false;
            seriesComboBox.ItemHeight = 23;
            seriesComboBox.Location = new Point(34, 125);
            seriesComboBox.Name = "seriesComboBox";
            seriesComboBox.Size = new Size(300, 29);
            seriesComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seriesComboBox.TabIndex = 67;
            seriesComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seriesComboBox.UseCustomBackColor = true;
            seriesComboBox.UseSelectable = true;
            seriesComboBox.SelectedIndexChanged += seriesRosterComboBox_SelectedIndexChanged;
            // 
            // rosterNameTextBox
            // 
            rosterNameTextBox.BackColor = Color.FromArgb(18, 18, 27);
            // 
            // 
            // 
            rosterNameTextBox.CustomButton.Image = null;
            rosterNameTextBox.CustomButton.Location = new Point(272, 1);
            rosterNameTextBox.CustomButton.Name = "";
            rosterNameTextBox.CustomButton.Size = new Size(27, 27);
            rosterNameTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            rosterNameTextBox.CustomButton.TabIndex = 1;
            rosterNameTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            rosterNameTextBox.CustomButton.UseSelectable = true;
            rosterNameTextBox.CustomButton.Visible = false;
            rosterNameTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rosterNameTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Tall;
            rosterNameTextBox.ForeColor = Color.White;
            rosterNameTextBox.Location = new Point(34, 59);
            rosterNameTextBox.MaxLength = 32767;
            rosterNameTextBox.Name = "rosterNameTextBox";
            rosterNameTextBox.PasswordChar = '\0';
            rosterNameTextBox.PromptText = "Roster Name";
            rosterNameTextBox.ScrollBars = ScrollBars.None;
            rosterNameTextBox.SelectedText = "";
            rosterNameTextBox.SelectionLength = 0;
            rosterNameTextBox.SelectionStart = 0;
            rosterNameTextBox.ShortcutsEnabled = true;
            rosterNameTextBox.Size = new Size(300, 29);
            rosterNameTextBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            rosterNameTextBox.TabIndex = 65;
            rosterNameTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            rosterNameTextBox.UseCustomBackColor = true;
            rosterNameTextBox.UseCustomForeColor = true;
            rosterNameTextBox.UseSelectable = true;
            rosterNameTextBox.WaterMark = "Roster Name";
            rosterNameTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            rosterNameTextBox.WaterMarkFont = new Font("Segoe UI", 16F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // driversDataGridView
            // 
            driversDataGridView.AllowUserToAddRows = false;
            driversDataGridView.AllowUserToDeleteRows = false;
            driversDataGridView.AllowUserToResizeColumns = false;
            driversDataGridView.AllowUserToResizeRows = false;
            driversDataGridView.BackgroundColor = Color.FromArgb(18, 18, 27);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(18, 18, 27);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(128, 187, 0);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            driversDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            driversDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driversDataGridView.Columns.AddRange(new DataGridViewColumn[] { Driver, CarNumber, CarLogo, CarName, RelativeSkill, Aggression, Optimism, Smoothness, Age, PitCrewSkill, PitStrat });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(18, 18, 27);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(254, 255, 255);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(38, 54, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(254, 255, 255);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            driversDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            driversDataGridView.Location = new Point(12, 416);
            driversDataGridView.Name = "driversDataGridView";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(18, 18, 27);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(38, 54, 0);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            driversDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            driversDataGridView.ShowCellErrors = false;
            driversDataGridView.Size = new Size(1236, 502);
            driversDataGridView.TabIndex = 86;
            driversDataGridView.CellValidating += driversDataGridView_CellValidating;
            driversDataGridView.CellValueChanged += driversDataGridView_CellValueChanged;
            // 
            // Driver
            // 
            Driver.DataPropertyName = "Driver";
            Driver.HeaderText = "Driver";
            Driver.Name = "Driver";
            Driver.ReadOnly = true;
            Driver.Width = 220;
            // 
            // CarNumber
            // 
            CarNumber.DataPropertyName = "DriverNumber";
            CarNumber.HeaderText = "Car Num";
            CarNumber.Name = "CarNumber";
            CarNumber.ReadOnly = true;
            CarNumber.Width = 40;
            // 
            // CarLogo
            // 
            CarLogo.DataPropertyName = "CarLogo";
            CarLogo.HeaderText = "Car Logo";
            CarLogo.Name = "CarLogo";
            CarLogo.ReadOnly = true;
            CarLogo.Resizable = DataGridViewTriState.True;
            CarLogo.SortMode = DataGridViewColumnSortMode.Automatic;
            CarLogo.Width = 80;
            // 
            // CarName
            // 
            CarName.DataPropertyName = "CarName";
            CarName.HeaderText = "Car";
            CarName.Name = "CarName";
            CarName.ReadOnly = true;
            CarName.Width = 276;
            // 
            // RelativeSkill
            // 
            RelativeSkill.DataPropertyName = "RelativeSkill";
            RelativeSkill.HeaderText = "Relative Skill";
            RelativeSkill.Name = "RelativeSkill";
            RelativeSkill.Width = 80;
            // 
            // Aggression
            // 
            Aggression.DataPropertyName = "Aggression";
            Aggression.HeaderText = "Aggression";
            Aggression.Name = "Aggression";
            Aggression.Width = 80;
            // 
            // Optimism
            // 
            Optimism.DataPropertyName = "Optimism";
            Optimism.HeaderText = "Optimism";
            Optimism.Name = "Optimism";
            Optimism.Width = 80;
            // 
            // Smoothness
            // 
            Smoothness.DataPropertyName = "Smoothness";
            Smoothness.HeaderText = "Smoothness";
            Smoothness.Name = "Smoothness";
            Smoothness.Width = 80;
            // 
            // Age
            // 
            Age.DataPropertyName = "Age";
            Age.HeaderText = "Age";
            Age.Name = "Age";
            Age.Width = 80;
            // 
            // PitCrewSkill
            // 
            PitCrewSkill.DataPropertyName = "PitCrewSkill";
            PitCrewSkill.HeaderText = "Pit Crew Skill";
            PitCrewSkill.Name = "PitCrewSkill";
            PitCrewSkill.Width = 80;
            // 
            // PitStrat
            // 
            PitStrat.DataPropertyName = "PitStrat";
            PitStrat.HeaderText = "Pit Strat";
            PitStrat.Name = "PitStrat";
            PitStrat.Width = 80;
            // 
            // updateSelectedDriversButton
            // 
            updateSelectedDriversButton.BackColor = Color.FromArgb(18, 18, 27);
            updateSelectedDriversButton.Highlight = true;
            updateSelectedDriversButton.Location = new Point(34, 223);
            updateSelectedDriversButton.Name = "updateSelectedDriversButton";
            updateSelectedDriversButton.Size = new Size(135, 50);
            updateSelectedDriversButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            updateSelectedDriversButton.TabIndex = 87;
            updateSelectedDriversButton.Text = "Update Selected Drivers";
            updateSelectedDriversButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            updateSelectedDriversButton.UseCustomBackColor = true;
            updateSelectedDriversButton.UseSelectable = true;
            updateSelectedDriversButton.UseVisualStyleBackColor = false;
            updateSelectedDriversButton.Click += updateSelectedDriversButton_Click;
            // 
            // updateAllDriversButton
            // 
            updateAllDriversButton.BackColor = Color.FromArgb(18, 18, 27);
            updateAllDriversButton.Highlight = true;
            updateAllDriversButton.Location = new Point(199, 223);
            updateAllDriversButton.Name = "updateAllDriversButton";
            updateAllDriversButton.Size = new Size(135, 50);
            updateAllDriversButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            updateAllDriversButton.TabIndex = 88;
            updateAllDriversButton.Text = "Update All Drivers";
            updateAllDriversButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            updateAllDriversButton.UseCustomBackColor = true;
            updateAllDriversButton.UseSelectable = true;
            updateAllDriversButton.UseVisualStyleBackColor = false;
            updateAllDriversButton.Click += updateAllDriversButton_Click;
            // 
            // createRosterRadioButton
            // 
            createRosterRadioButton.AutoSize = true;
            createRosterRadioButton.BackColor = Color.Transparent;
            createRosterRadioButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Tall;
            createRosterRadioButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonCheckBoxWeight.Bold;
            createRosterRadioButton.ForeColor = Color.White;
            createRosterRadioButton.Location = new Point(12, 52);
            createRosterRadioButton.Name = "createRosterRadioButton";
            createRosterRadioButton.Size = new Size(143, 25);
            createRosterRadioButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            createRosterRadioButton.TabIndex = 89;
            createRosterRadioButton.Text = "Create Roster";
            createRosterRadioButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            createRosterRadioButton.UseCustomBackColor = true;
            createRosterRadioButton.UseCustomForeColor = true;
            createRosterRadioButton.UseSelectable = true;
            createRosterRadioButton.UseVisualStyleBackColor = false;
            // 
            // updateRosterRadioButton
            // 
            updateRosterRadioButton.AutoSize = true;
            updateRosterRadioButton.BackColor = Color.Transparent;
            updateRosterRadioButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Tall;
            updateRosterRadioButton.FontWeight = ReaLTaiizor.Extension.Poison.PoisonCheckBoxWeight.Bold;
            updateRosterRadioButton.ForeColor = Color.White;
            updateRosterRadioButton.Location = new Point(418, 52);
            updateRosterRadioButton.Name = "updateRosterRadioButton";
            updateRosterRadioButton.Size = new Size(150, 25);
            updateRosterRadioButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            updateRosterRadioButton.TabIndex = 90;
            updateRosterRadioButton.Text = "Update Roster";
            updateRosterRadioButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            updateRosterRadioButton.UseCustomBackColor = true;
            updateRosterRadioButton.UseCustomForeColor = true;
            updateRosterRadioButton.UseSelectable = true;
            updateRosterRadioButton.UseVisualStyleBackColor = false;
            updateRosterRadioButton.CheckedChanged += CreateOrUpdateRadioButton_CheckedChanged;
            // 
            // updateRosterPanel
            // 
            updateRosterPanel.BackColor = Color.FromArgb(150, 18, 18, 27);
            updateRosterPanel.Controls.Add(rosterComboBox);
            updateRosterPanel.Controls.Add(fixedRangeRadioButton);
            updateRosterPanel.Controls.Add(minusPlusRadioButton);
            updateRosterPanel.Controls.Add(rosterSourceLabel);
            updateRosterPanel.Controls.Add(updateAllDriversButton);
            updateRosterPanel.Controls.Add(updateSelectedDriversButton);
            updateRosterPanel.Enabled = false;
            updateRosterPanel.Location = new Point(418, 92);
            updateRosterPanel.Name = "updateRosterPanel";
            updateRosterPanel.Size = new Size(367, 294);
            updateRosterPanel.TabIndex = 91;
            // 
            // rosterComboBox
            // 
            rosterComboBox.BackColor = Color.FromArgb(18, 18, 27);
            rosterComboBox.DropDownHeight = 415;
            rosterComboBox.FormattingEnabled = true;
            rosterComboBox.IntegralHeight = false;
            rosterComboBox.ItemHeight = 23;
            rosterComboBox.Location = new Point(34, 59);
            rosterComboBox.Name = "rosterComboBox";
            rosterComboBox.Size = new Size(300, 29);
            rosterComboBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            rosterComboBox.TabIndex = 91;
            rosterComboBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            rosterComboBox.UseCustomBackColor = true;
            rosterComboBox.UseSelectable = true;
            rosterComboBox.SelectedIndexChanged += rosterComboBox_SelectedIndexChanged;
            rosterComboBox.Click += rosterComboBox_Click;
            // 
            // fixedRangeRadioButton
            // 
            fixedRangeRadioButton.AutoSize = true;
            fixedRangeRadioButton.BackColor = Color.Transparent;
            fixedRangeRadioButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            fixedRangeRadioButton.ForeColor = Color.White;
            fixedRangeRadioButton.Location = new Point(34, 159);
            fixedRangeRadioButton.Name = "fixedRangeRadioButton";
            fixedRangeRadioButton.Size = new Size(169, 19);
            fixedRangeRadioButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            fixedRangeRadioButton.TabIndex = 90;
            fixedRangeRadioButton.Text = "Fixed Range Randomize";
            fixedRangeRadioButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            fixedRangeRadioButton.UseCustomBackColor = true;
            fixedRangeRadioButton.UseCustomForeColor = true;
            fixedRangeRadioButton.UseSelectable = true;
            fixedRangeRadioButton.UseVisualStyleBackColor = false;
            // 
            // minusPlusRadioButton
            // 
            minusPlusRadioButton.AutoSize = true;
            minusPlusRadioButton.BackColor = Color.Transparent;
            minusPlusRadioButton.FontSize = ReaLTaiizor.Extension.Poison.PoisonCheckBoxSize.Medium;
            minusPlusRadioButton.ForeColor = Color.White;
            minusPlusRadioButton.Location = new Point(34, 125);
            minusPlusRadioButton.Name = "minusPlusRadioButton";
            minusPlusRadioButton.Size = new Size(117, 19);
            minusPlusRadioButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            minusPlusRadioButton.TabIndex = 89;
            minusPlusRadioButton.Text = "-/+ Randomize";
            minusPlusRadioButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            minusPlusRadioButton.UseCustomBackColor = true;
            minusPlusRadioButton.UseCustomForeColor = true;
            minusPlusRadioButton.UseSelectable = true;
            minusPlusRadioButton.UseVisualStyleBackColor = false;
            minusPlusRadioButton.CheckedChanged += RangeOrMinusPlusRadioButton_CheckedChanged;
            // 
            // createRosterPanel
            // 
            createRosterPanel.BackColor = Color.FromArgb(150, 18, 18, 27);
            createRosterPanel.Controls.Add(messageFormLabel);
            createRosterPanel.Controls.Add(driverCountTrackBar);
            createRosterPanel.Controls.Add(driverCountValueLabel);
            createRosterPanel.Controls.Add(driverCountLabel);
            createRosterPanel.Controls.Add(createRosterButton);
            createRosterPanel.Controls.Add(seriesComboBox);
            createRosterPanel.Controls.Add(rosterSeriesLabel);
            createRosterPanel.Controls.Add(rosterNameTextBox);
            createRosterPanel.Controls.Add(rosterNamePanel);
            createRosterPanel.Location = new Point(11, 92);
            createRosterPanel.Name = "createRosterPanel";
            createRosterPanel.Size = new Size(372, 294);
            createRosterPanel.TabIndex = 92;
            // 
            // messageFormLabel
            // 
            messageFormLabel.AutoSize = true;
            messageFormLabel.BackColor = Color.Transparent;
            messageFormLabel.ForeColor = Color.FromArgb(142, 188, 0);
            messageFormLabel.Location = new Point(251, 258);
            messageFormLabel.Name = "messageFormLabel";
            messageFormLabel.Size = new Size(53, 15);
            messageFormLabel.TabIndex = 75;
            messageFormLabel.Text = "message";
            // 
            // rosterNamePanel
            // 
            rosterNamePanel.BackColor = Color.FromArgb(128, 187, 0);
            rosterNamePanel.Location = new Point(12, 256);
            rosterNamePanel.Name = "rosterNamePanel";
            rosterNamePanel.Size = new Size(27, 27);
            rosterNamePanel.TabIndex = 74;
            rosterNamePanel.Visible = false;
            // 
            // RosterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1260, 930);
            Controls.Add(createRosterPanel);
            Controls.Add(updateRosterPanel);
            Controls.Add(updateRosterRadioButton);
            Controls.Add(createRosterRadioButton);
            Controls.Add(driversDataGridView);
            Controls.Add(attributesGroupBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "RosterForm";
            Load += RosterForm_Load;
            attributesGroupBox.ResumeLayout(false);
            aggressionPanel.ResumeLayout(false);
            aggressionPanel.PerformLayout();
            relativeSkillPanel.ResumeLayout(false);
            relativeSkillPanel.PerformLayout();
            smoothnessPanel.ResumeLayout(false);
            smoothnessPanel.PerformLayout();
            agePanel.ResumeLayout(false);
            agePanel.PerformLayout();
            pitStratPanel.ResumeLayout(false);
            pitStratPanel.PerformLayout();
            optimismPanel.ResumeLayout(false);
            optimismPanel.PerformLayout();
            pitCrewPanel.ResumeLayout(false);
            pitCrewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).EndInit();
            updateRosterPanel.ResumeLayout(false);
            updateRosterPanel.PerformLayout();
            createRosterPanel.ResumeLayout(false);
            createRosterPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label rosterSeriesLabel;
        private Label rosterSourceLabel;
        private GroupBox attributesGroupBox;
        private Panel aggressionPanel;
        private ReaLTaiizor.Controls.PoisonLabel aggressionValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel aggressionLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox aggressionCheckBox;
        private Panel relativeSkillPanel;
        private ReaLTaiizor.Controls.PoisonLabel relativeSkillValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel relativeSkillLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox relativeSkillCheckBox;
        private Panel smoothnessPanel;
        private ReaLTaiizor.Controls.PoisonLabel smoothnessValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel smoothnessLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox smoothnessCheckBox;
        private Panel agePanel;
        private ReaLTaiizor.Controls.PoisonLabel ageValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel ageLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox ageCheckBox;
        private Panel pitStratPanel;
        private ReaLTaiizor.Controls.PoisonLabel pitStratValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel pitStratLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox pitStratCheckBox;
        private Panel optimismPanel;
        private ReaLTaiizor.Controls.PoisonLabel optimismValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel optimismLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox optimismCheckBox;
        private Panel pitCrewPanel;
        private ReaLTaiizor.Controls.PoisonLabel pitCrewValueLabel;
        private ReaLTaiizor.Controls.PoisonLabel pitCrewLabel;
        private ReaLTaiizor.Controls.PoisonCheckBox pitCrewCheckBox;
        private ReaLTaiizor.Controls.PoisonButton createRosterButton;
        private ReaLTaiizor.Controls.PoisonLabel driverCountLabel;
        private ReaLTaiizor.Controls.PoisonTrackBar driverCountTrackBar;
        private ReaLTaiizor.Controls.PoisonLabel driverCountValueLabel;
        private ReaLTaiizor.Controls.PoisonComboBox seriesComboBox;
        private ReaLTaiizor.Controls.PoisonTextBox rosterNameTextBox;
        private DataGridView driversDataGridView;
        private ReaLTaiizor.Controls.PoisonButton updateSelectedDriversButton;
        private ReaLTaiizor.Controls.PoisonButton updateAllDriversButton;
        private Helpers.RangeTrackBar relativeSkillRangeTrackBar;
        private Helpers.RangeTrackBar aggressionRangeTrackBar;
        private Helpers.RangeTrackBar optimismRangeTrackBar;
        private Helpers.RangeTrackBar smoothnessRangeTrackBar;
        private Helpers.RangeTrackBar ageRangeTrackBar;
        private Helpers.RangeTrackBar pitCrewRangeTrackBar;
        private Helpers.RangeTrackBar pitStratRangeTrackBar;
        private ReaLTaiizor.Controls.PoisonRadioButton createRosterRadioButton;
        private ReaLTaiizor.Controls.PoisonRadioButton updateRosterRadioButton;
        private Panel updateRosterPanel;
        private Panel createRosterPanel;
        private ReaLTaiizor.Controls.PoisonRadioButton fixedRangeRadioButton;
        private ReaLTaiizor.Controls.PoisonRadioButton minusPlusRadioButton;
        private ReaLTaiizor.Controls.PoisonComboBox rosterComboBox;
        private DataGridViewTextBoxColumn Driver;
        private DataGridViewTextBoxColumn CarNumber;
        private DataGridViewImageColumn CarLogo;
        private DataGridViewTextBoxColumn CarName;
        private DataGridViewTextBoxColumn RelativeSkill;
        private DataGridViewTextBoxColumn Aggression;
        private DataGridViewTextBoxColumn Optimism;
        private DataGridViewTextBoxColumn Smoothness;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn PitCrewSkill;
        private DataGridViewTextBoxColumn PitStrat;
        private Panel rosterNamePanel;
        private Label messageFormLabel;
    }
}