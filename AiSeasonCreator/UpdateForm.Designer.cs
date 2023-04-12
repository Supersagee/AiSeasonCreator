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
            updateButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // releaseNotesTextBox
            // 
            releaseNotesTextBox.Location = new Point(12, 12);
            releaseNotesTextBox.Multiline = true;
            releaseNotesTextBox.Name = "releaseNotesTextBox";
            releaseNotesTextBox.ReadOnly = true;
            releaseNotesTextBox.ScrollBars = ScrollBars.Vertical;
            releaseNotesTextBox.Size = new Size(360, 380);
            releaseNotesTextBox.TabIndex = 0;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(297, 406);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 1;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(216, 406);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 441);
            Controls.Add(cancelButton);
            Controls.Add(updateButton);
            Controls.Add(releaseNotesTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateForm";
            Text = "Update";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox releaseNotesTextBox;
        private Button updateButton;
        private Button cancelButton;
    }
}