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
            SuspendLayout();
            // 
            // seriesListCombo
            // 
            seriesListCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            seriesListCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            seriesListCombo.FormattingEnabled = true;
            seriesListCombo.Location = new Point(93, 68);
            seriesListCombo.Name = "seriesListCombo";
            seriesListCombo.Size = new Size(274, 23);
            seriesListCombo.TabIndex = 0;
            seriesListCombo.Text = "Choose series to create";
            // 
            // createSeason
            // 
            createSeason.Location = new Point(653, 404);
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
            carListCombo.FormattingEnabled = true;
            carListCombo.Location = new Point(93, 121);
            carListCombo.Name = "carListCombo";
            carListCombo.Size = new Size(274, 23);
            carListCombo.TabIndex = 5;
            carListCombo.Text = "Choose car to race";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(carListLabel);
            Controls.Add(carListCombo);
            Controls.Add(seasonNameLabel);
            Controls.Add(seasonNameTextBox);
            Controls.Add(seriesListLabel);
            Controls.Add(createSeason);
            Controls.Add(seriesListCombo);
            Name = "MainForm";
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
    }
}