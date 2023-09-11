namespace AiSeasonCreator
{
    partial class UpdateForm
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
            releaseNotesTextBox = new TextBox();
            cancelButton = new ReaLTaiizor.Controls.PoisonButton();
            updateButton = new ReaLTaiizor.Controls.PoisonButton();
            updateLabel = new Label();
            SuspendLayout();
            // 
            // releaseNotesTextBox
            // 
            releaseNotesTextBox.BackColor = Color.FromArgb(30, 30, 30);
            releaseNotesTextBox.ForeColor = SystemColors.Window;
            releaseNotesTextBox.Location = new Point(12, 33);
            releaseNotesTextBox.Multiline = true;
            releaseNotesTextBox.Name = "releaseNotesTextBox";
            releaseNotesTextBox.ReadOnly = true;
            releaseNotesTextBox.ScrollBars = ScrollBars.Vertical;
            releaseNotesTextBox.Size = new Size(360, 359);
            releaseNotesTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(216, 406);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            cancelButton.UseSelectable = true;
            cancelButton.Click += this.cancelButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(297, 406);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            updateButton.TabIndex = 4;
            updateButton.Text = "Update";
            updateButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            updateButton.UseSelectable = true;
            updateButton.Click += updateButton_Click;
            // 
            // updateLabel
            // 
            updateLabel.AutoSize = true;
            updateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            updateLabel.ForeColor = SystemColors.Window;
            updateLabel.Location = new Point(12, 9);
            updateLabel.Name = "updateLabel";
            updateLabel.Size = new Size(0, 21);
            updateLabel.TabIndex = 5;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(384, 441);
            Controls.Add(updateLabel);
            Controls.Add(updateButton);
            Controls.Add(cancelButton);
            Controls.Add(releaseNotesTextBox);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox releaseNotesTextBox;
        private ReaLTaiizor.Controls.PoisonButton cancelButton;
        private ReaLTaiizor.Controls.PoisonButton updateButton;
        private Label updateLabel;
    }
}