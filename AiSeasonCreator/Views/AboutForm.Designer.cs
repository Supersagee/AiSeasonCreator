namespace AiSeasonCreator.Views
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            generalAboutLabel = new Label();
            forumLinkLabel = new ReaLTaiizor.Controls.PoisonLinkLabel();
            seasonAboutLabel = new Label();
            rosterAboutLabel = new Label();
            aboutGroupBox = new GroupBox();
            aboutGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // generalAboutLabel
            // 
            generalAboutLabel.AutoSize = true;
            generalAboutLabel.BackColor = Color.Transparent;
            generalAboutLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            generalAboutLabel.ForeColor = Color.LightGray;
            generalAboutLabel.Location = new Point(20, 28);
            generalAboutLabel.MaximumSize = new Size(400, 1000);
            generalAboutLabel.Name = "generalAboutLabel";
            generalAboutLabel.Size = new Size(144, 20);
            generalAboutLabel.TabIndex = 3;
            generalAboutLabel.Text = "generalAboutLabel";
            // 
            // forumLinkLabel
            // 
            forumLinkLabel.Location = new Point(158, 863);
            forumLinkLabel.Name = "forumLinkLabel";
            forumLinkLabel.Size = new Size(108, 23);
            forumLinkLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            forumLinkLabel.TabIndex = 4;
            forumLinkLabel.Text = "iRacing Forum";
            forumLinkLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            forumLinkLabel.UseCustomBackColor = true;
            forumLinkLabel.UseSelectable = true;
            forumLinkLabel.UseStyleColors = true;
            forumLinkLabel.Click += forumLinkLabel_Click;
            // 
            // seasonAboutLabel
            // 
            seasonAboutLabel.AutoSize = true;
            seasonAboutLabel.BackColor = Color.Transparent;
            seasonAboutLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seasonAboutLabel.ForeColor = Color.LightGray;
            seasonAboutLabel.Location = new Point(20, 200);
            seasonAboutLabel.MaximumSize = new Size(400, 1000);
            seasonAboutLabel.Name = "seasonAboutLabel";
            seasonAboutLabel.Size = new Size(143, 20);
            seasonAboutLabel.TabIndex = 5;
            seasonAboutLabel.Text = "seasonAboutLabel";
            // 
            // rosterAboutLabel
            // 
            rosterAboutLabel.AutoSize = true;
            rosterAboutLabel.BackColor = Color.Transparent;
            rosterAboutLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rosterAboutLabel.ForeColor = Color.LightGray;
            rosterAboutLabel.Location = new Point(20, 407);
            rosterAboutLabel.MaximumSize = new Size(400, 1000);
            rosterAboutLabel.Name = "rosterAboutLabel";
            rosterAboutLabel.Size = new Size(132, 20);
            rosterAboutLabel.TabIndex = 6;
            rosterAboutLabel.Text = "rosterAboutLabel";
            // 
            // aboutGroupBox
            // 
            aboutGroupBox.BackColor = Color.FromArgb(150, 18, 18, 27);
            aboutGroupBox.Controls.Add(generalAboutLabel);
            aboutGroupBox.Controls.Add(forumLinkLabel);
            aboutGroupBox.Controls.Add(rosterAboutLabel);
            aboutGroupBox.Controls.Add(seasonAboutLabel);
            aboutGroupBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aboutGroupBox.ForeColor = Color.White;
            aboutGroupBox.Location = new Point(12, 12);
            aboutGroupBox.Name = "aboutGroupBox";
            aboutGroupBox.Size = new Size(440, 906);
            aboutGroupBox.TabIndex = 40;
            aboutGroupBox.TabStop = false;
            aboutGroupBox.Text = "About";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1260, 930);
            Controls.Add(aboutGroupBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AboutForm";
            Text = "AboutForm";
            Load += AboutForm_Load;
            aboutGroupBox.ResumeLayout(false);
            aboutGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label generalAboutLabel;
        private ReaLTaiizor.Controls.PoisonLinkLabel forumLinkLabel;
        private Label seasonAboutLabel;
        private Label rosterAboutLabel;
        private GroupBox aboutGroupBox;
    }
}