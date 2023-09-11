namespace AiSeasonCreator
{
    partial class TrackSelectionForm
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
            trackSelectionLabel = new Label();
            tracksCheckedListBox = new CheckedListBox();
            okButton = new ReaLTaiizor.Controls.PoisonButton();
            cancelButton = new ReaLTaiizor.Controls.PoisonButton();
            SuspendLayout();
            // 
            // trackSelectionLabel
            // 
            trackSelectionLabel.AutoSize = true;
            trackSelectionLabel.ForeColor = SystemColors.Window;
            trackSelectionLabel.Location = new Point(12, 9);
            trackSelectionLabel.Name = "trackSelectionLabel";
            trackSelectionLabel.Size = new Size(252, 15);
            trackSelectionLabel.TabIndex = 0;
            trackSelectionLabel.Text = "Uncheck any unwanted tracks. Then press 'OK'";
            // 
            // tracksCheckedListBox
            // 
            tracksCheckedListBox.BackColor = Color.FromArgb(30, 30, 30);
            tracksCheckedListBox.CheckOnClick = true;
            tracksCheckedListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tracksCheckedListBox.ForeColor = SystemColors.AppWorkspace;
            tracksCheckedListBox.FormattingEnabled = true;
            tracksCheckedListBox.Location = new Point(12, 27);
            tracksCheckedListBox.Name = "tracksCheckedListBox";
            tracksCheckedListBox.Size = new Size(375, 508);
            tracksCheckedListBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Location = new Point(311, 548);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            okButton.TabIndex = 3;
            okButton.Text = "OK";
            okButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            okButton.UseSelectable = true;
            okButton.UseStyleColors = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(230, 548);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            cancelButton.UseSelectable = true;
            cancelButton.UseStyleColors = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // TrackSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(399, 583);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(tracksCheckedListBox);
            Controls.Add(trackSelectionLabel);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrackSelectionForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Track Selection";
            Load += TrackSelectionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label trackSelectionLabel;
        private CheckedListBox tracksCheckedListBox;
        private ReaLTaiizor.Controls.PoisonButton okButton;
        private ReaLTaiizor.Controls.PoisonButton cancelButton;
    }
}