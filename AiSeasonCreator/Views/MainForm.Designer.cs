namespace AiSeasonCreator.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuPanel = new Panel();
            settingsButton = new Button();
            seasonButton = new Button();
            aboutButton = new Button();
            rosterButton = new Button();
            mainPanel = new Panel();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            menuPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            menuPanel.BackColor = Color.FromArgb(18, 18, 27);
            menuPanel.Controls.Add(settingsButton);
            menuPanel.Controls.Add(seasonButton);
            menuPanel.Controls.Add(aboutButton);
            menuPanel.Controls.Add(rosterButton);
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(60, 929);
            menuPanel.TabIndex = 0;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Transparent;
            settingsButton.BackgroundImageLayout = ImageLayout.Zoom;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(142, 188, 0);
            settingsButton.FlatAppearance.MouseOverBackColor = Color.DimGray;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Image = (Image)resources.GetObject("settingsButton.Image");
            settingsButton.Location = new Point(0, 120);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(60, 40);
            settingsButton.TabIndex = 4;
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // seasonButton
            // 
            seasonButton.BackColor = Color.Transparent;
            seasonButton.BackgroundImageLayout = ImageLayout.Zoom;
            seasonButton.FlatAppearance.BorderSize = 0;
            seasonButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(142, 188, 0);
            seasonButton.FlatAppearance.MouseOverBackColor = Color.DimGray;
            seasonButton.FlatStyle = FlatStyle.Flat;
            seasonButton.Image = (Image)resources.GetObject("seasonButton.Image");
            seasonButton.Location = new Point(0, 0);
            seasonButton.Name = "seasonButton";
            seasonButton.Padding = new Padding(5);
            seasonButton.Size = new Size(60, 40);
            seasonButton.TabIndex = 3;
            seasonButton.UseVisualStyleBackColor = false;
            seasonButton.Click += seasonButton_Click;
            // 
            // aboutButton
            // 
            aboutButton.BackColor = Color.Transparent;
            aboutButton.BackgroundImageLayout = ImageLayout.Zoom;
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(142, 188, 0);
            aboutButton.FlatAppearance.MouseOverBackColor = Color.DimGray;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Image = (Image)resources.GetObject("aboutButton.Image");
            aboutButton.Location = new Point(0, 80);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(60, 40);
            aboutButton.TabIndex = 3;
            aboutButton.UseVisualStyleBackColor = false;
            aboutButton.Click += aboutButton_Click;
            // 
            // rosterButton
            // 
            rosterButton.BackColor = Color.Transparent;
            rosterButton.BackgroundImageLayout = ImageLayout.Zoom;
            rosterButton.FlatAppearance.BorderSize = 0;
            rosterButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(142, 188, 0);
            rosterButton.FlatAppearance.MouseOverBackColor = Color.DimGray;
            rosterButton.FlatStyle = FlatStyle.Flat;
            rosterButton.Image = (Image)resources.GetObject("rosterButton.Image");
            rosterButton.Location = new Point(0, 40);
            rosterButton.Name = "rosterButton";
            rosterButton.Padding = new Padding(5);
            rosterButton.Size = new Size(60, 40);
            rosterButton.TabIndex = 2;
            rosterButton.UseVisualStyleBackColor = false;
            rosterButton.Click += rosterButton_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.ActiveBorder;
            mainPanel.Location = new Point(60, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1260, 930);
            mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1320, 929);
            Controls.Add(mainPanel);
            Controls.Add(menuPanel);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "AiSeasonCreator";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private Button rosterButton;
        private Button seasonButton;
        private Button settingsButton;
        private Button aboutButton;
        private Panel mainPanel;
    }
}