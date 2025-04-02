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
            aboutSectionLabel = new Label();
            forumLinkLabel = new ReaLTaiizor.Controls.PoisonLinkLabel();
            SuspendLayout();
            // 
            // aboutSectionLabel
            // 
            aboutSectionLabel.AutoSize = true;
            aboutSectionLabel.BackColor = Color.Transparent;
            aboutSectionLabel.Font = new Font("Segoe UI", 12F);
            aboutSectionLabel.ForeColor = Color.LightGray;
            aboutSectionLabel.Location = new Point(12, 9);
            aboutSectionLabel.MaximumSize = new Size(400, 1000);
            aboutSectionLabel.Name = "aboutSectionLabel";
            aboutSectionLabel.Size = new Size(138, 21);
            aboutSectionLabel.TabIndex = 3;
            aboutSectionLabel.Text = "aboutSectionLabel";
            // 
            // forumLinkLabel
            // 
            forumLinkLabel.Location = new Point(618, 389);
            forumLinkLabel.Name = "forumLinkLabel";
            forumLinkLabel.Size = new Size(108, 23);
            forumLinkLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            forumLinkLabel.TabIndex = 4;
            forumLinkLabel.Text = "AiSeasonCreator";
            forumLinkLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            forumLinkLabel.UseCustomBackColor = true;
            forumLinkLabel.UseSelectable = true;
            forumLinkLabel.UseStyleColors = true;
            forumLinkLabel.Click += forumLinkLabel_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(forumLinkLabel);
            Controls.Add(aboutSectionLabel);
            Name = "AboutForm";
            Text = "AboutForm";
            Load += AboutForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label aboutSectionLabel;
        private ReaLTaiizor.Controls.PoisonLinkLabel forumLinkLabel;
    }
}