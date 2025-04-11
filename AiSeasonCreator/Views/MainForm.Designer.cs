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
            menuPanel.BackColor = Color.FromArgb(166, 166, 166);
            menuPanel.Controls.Add(settingsButton);
            menuPanel.Controls.Add(seasonButton);
            menuPanel.Controls.Add(aboutButton);
            menuPanel.Controls.Add(rosterButton);
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(60, 951);
            menuPanel.TabIndex = 0;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Transparent;
            settingsButton.BackgroundImage = (Image)resources.GetObject("settingsButton.BackgroundImage");
            settingsButton.BackgroundImageLayout = ImageLayout.Zoom;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Location = new Point(5, 455);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(50, 50);
            settingsButton.TabIndex = 4;
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // seasonButton
            // 
            seasonButton.BackColor = Color.Transparent;
            seasonButton.BackgroundImage = (Image)resources.GetObject("seasonButton.BackgroundImage");
            seasonButton.BackgroundImageLayout = ImageLayout.Zoom;
            seasonButton.FlatAppearance.BorderSize = 0;
            seasonButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(142, 188, 0);
            seasonButton.FlatAppearance.MouseOverBackColor = Color.DimGray;
            seasonButton.FlatStyle = FlatStyle.Flat;
            seasonButton.Location = new Point(5, 260);
            seasonButton.Name = "seasonButton";
            seasonButton.Padding = new Padding(5);
            seasonButton.Size = new Size(50, 50);
            seasonButton.TabIndex = 3;
            seasonButton.UseVisualStyleBackColor = false;
            seasonButton.Click += seasonButton_Click;
            // 
            // aboutButton
            // 
            aboutButton.BackColor = Color.Transparent;
            aboutButton.BackgroundImage = (Image)resources.GetObject("aboutButton.BackgroundImage");
            aboutButton.BackgroundImageLayout = ImageLayout.Zoom;
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Location = new Point(5, 390);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(50, 50);
            aboutButton.TabIndex = 3;
            aboutButton.UseVisualStyleBackColor = false;
            aboutButton.Click += aboutButton_Click;
            // 
            // rosterButton
            // 
            rosterButton.BackColor = Color.Transparent;
            rosterButton.BackgroundImage = (Image)resources.GetObject("rosterButton.BackgroundImage");
            rosterButton.BackgroundImageLayout = ImageLayout.Zoom;
            rosterButton.FlatAppearance.BorderSize = 0;
            rosterButton.FlatAppearance.MouseDownBackColor = Color.RosyBrown;
            rosterButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            rosterButton.FlatStyle = FlatStyle.Flat;
            rosterButton.Location = new Point(5, 325);
            rosterButton.Name = "rosterButton";
            rosterButton.Padding = new Padding(5);
            rosterButton.Size = new Size(50, 50);
            rosterButton.TabIndex = 2;
            rosterButton.UseVisualStyleBackColor = false;
            rosterButton.Click += rosterButton_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.ActiveBorder;
            mainPanel.Location = new Point(60, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1500, 950);
            mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1560, 951);
            Controls.Add(mainPanel);
            Controls.Add(menuPanel);
            Name = "MainForm";
            Text = "AiSeasonCreator";
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