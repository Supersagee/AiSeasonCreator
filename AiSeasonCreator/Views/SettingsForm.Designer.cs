namespace AiSeasonCreator.Views
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            checkFolderPathLabel = new Label();
            rosterFolderPathLabel = new Label();
            rosterFolderPathTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            seasonFolderPathLabel = new Label();
            seasonFolderPathTextBox = new ReaLTaiizor.Controls.PoisonTextBox();
            SuspendLayout();
            // 
            // checkFolderPathLabel
            // 
            checkFolderPathLabel.AutoSize = true;
            checkFolderPathLabel.ForeColor = Color.FromArgb(128, 187, 0);
            checkFolderPathLabel.Location = new Point(12, 133);
            checkFolderPathLabel.Name = "checkFolderPathLabel";
            checkFolderPathLabel.Size = new Size(0, 15);
            checkFolderPathLabel.TabIndex = 54;
            // 
            // rosterFolderPathLabel
            // 
            rosterFolderPathLabel.AutoSize = true;
            rosterFolderPathLabel.ForeColor = SystemColors.ControlDark;
            rosterFolderPathLabel.Location = new Point(12, 68);
            rosterFolderPathLabel.Name = "rosterFolderPathLabel";
            rosterFolderPathLabel.Size = new Size(81, 15);
            rosterFolderPathLabel.TabIndex = 53;
            rosterFolderPathLabel.Text = "Rosters Folder";
            // 
            // rosterFolderPathTextBox
            // 
            // 
            // 
            // 
            rosterFolderPathTextBox.CustomButton.Image = null;
            rosterFolderPathTextBox.CustomButton.Location = new Point(346, 1);
            rosterFolderPathTextBox.CustomButton.Name = "";
            rosterFolderPathTextBox.CustomButton.Size = new Size(27, 27);
            rosterFolderPathTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            rosterFolderPathTextBox.CustomButton.TabIndex = 1;
            rosterFolderPathTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            rosterFolderPathTextBox.CustomButton.UseSelectable = true;
            rosterFolderPathTextBox.CustomButton.Visible = false;
            rosterFolderPathTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
            rosterFolderPathTextBox.Location = new Point(12, 86);
            rosterFolderPathTextBox.MaxLength = 32767;
            rosterFolderPathTextBox.Name = "rosterFolderPathTextBox";
            rosterFolderPathTextBox.PasswordChar = '\0';
            rosterFolderPathTextBox.PromptText = "Click to add folder path. iRacing\\\\airosters";
            rosterFolderPathTextBox.ReadOnly = true;
            rosterFolderPathTextBox.ScrollBars = ScrollBars.None;
            rosterFolderPathTextBox.SelectedText = "";
            rosterFolderPathTextBox.SelectionLength = 0;
            rosterFolderPathTextBox.SelectionStart = 0;
            rosterFolderPathTextBox.ShortcutsEnabled = true;
            rosterFolderPathTextBox.Size = new Size(374, 29);
            rosterFolderPathTextBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            rosterFolderPathTextBox.TabIndex = 52;
            rosterFolderPathTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            rosterFolderPathTextBox.UseSelectable = true;
            rosterFolderPathTextBox.WaterMark = "Click to add folder path. iRacing\\\\airosters";
            rosterFolderPathTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            rosterFolderPathTextBox.WaterMarkFont = new Font("Segoe UI", 16F, FontStyle.Italic, GraphicsUnit.Pixel);
            rosterFolderPathTextBox.Click += rosterFolderPathTextBox_Click;
            // 
            // seasonFolderPathLabel
            // 
            seasonFolderPathLabel.AutoSize = true;
            seasonFolderPathLabel.ForeColor = SystemColors.ControlDark;
            seasonFolderPathLabel.Location = new Point(12, 8);
            seasonFolderPathLabel.Name = "seasonFolderPathLabel";
            seasonFolderPathLabel.Size = new Size(85, 15);
            seasonFolderPathLabel.TabIndex = 51;
            seasonFolderPathLabel.Text = "Seasons Folder";
            // 
            // seasonFolderPathTextBox
            // 
            // 
            // 
            // 
            seasonFolderPathTextBox.CustomButton.Image = null;
            seasonFolderPathTextBox.CustomButton.Location = new Point(346, 1);
            seasonFolderPathTextBox.CustomButton.Name = "";
            seasonFolderPathTextBox.CustomButton.Size = new Size(27, 27);
            seasonFolderPathTextBox.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            seasonFolderPathTextBox.CustomButton.TabIndex = 1;
            seasonFolderPathTextBox.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            seasonFolderPathTextBox.CustomButton.UseSelectable = true;
            seasonFolderPathTextBox.CustomButton.Visible = false;
            seasonFolderPathTextBox.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
            seasonFolderPathTextBox.Location = new Point(12, 26);
            seasonFolderPathTextBox.MaxLength = 32767;
            seasonFolderPathTextBox.Name = "seasonFolderPathTextBox";
            seasonFolderPathTextBox.PasswordChar = '\0';
            seasonFolderPathTextBox.PromptText = "Click to add folder path. iRacing\\\\aiseasons";
            seasonFolderPathTextBox.ReadOnly = true;
            seasonFolderPathTextBox.ScrollBars = ScrollBars.None;
            seasonFolderPathTextBox.SelectedText = "";
            seasonFolderPathTextBox.SelectionLength = 0;
            seasonFolderPathTextBox.SelectionStart = 0;
            seasonFolderPathTextBox.ShortcutsEnabled = true;
            seasonFolderPathTextBox.Size = new Size(374, 29);
            seasonFolderPathTextBox.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            seasonFolderPathTextBox.TabIndex = 50;
            seasonFolderPathTextBox.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            seasonFolderPathTextBox.UseSelectable = true;
            seasonFolderPathTextBox.WaterMark = "Click to add folder path. iRacing\\\\aiseasons";
            seasonFolderPathTextBox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            seasonFolderPathTextBox.WaterMarkFont = new Font("Segoe UI", 16F, FontStyle.Italic, GraphicsUnit.Pixel);
            seasonFolderPathTextBox.Click += seasonFolderPathTextBox_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1260, 930);
            Controls.Add(checkFolderPathLabel);
            Controls.Add(rosterFolderPathLabel);
            Controls.Add(rosterFolderPathTextBox);
            Controls.Add(seasonFolderPathLabel);
            Controls.Add(seasonFolderPathTextBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label checkFolderPathLabel;
        private Label rosterFolderPathLabel;
        private ReaLTaiizor.Controls.PoisonTextBox rosterFolderPathTextBox;
        private Label seasonFolderPathLabel;
        private ReaLTaiizor.Controls.PoisonTextBox seasonFolderPathTextBox;
    }
}