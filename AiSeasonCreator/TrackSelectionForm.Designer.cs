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
            okButton = new Button();
            SuspendLayout();
            // 
            // trackSelectionLabel
            // 
            trackSelectionLabel.AutoSize = true;
            trackSelectionLabel.Location = new Point(12, 9);
            trackSelectionLabel.Name = "trackSelectionLabel";
            trackSelectionLabel.Size = new Size(252, 15);
            trackSelectionLabel.TabIndex = 0;
            trackSelectionLabel.Text = "Uncheck any unwanted tracks. Then press 'OK'";
            // 
            // tracksCheckedListBox
            // 
            tracksCheckedListBox.CheckOnClick = true;
            tracksCheckedListBox.FormattingEnabled = true;
            tracksCheckedListBox.Location = new Point(12, 27);
            tracksCheckedListBox.Name = "tracksCheckedListBox";
            tracksCheckedListBox.Size = new Size(310, 292);
            tracksCheckedListBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Location = new Point(247, 326);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // TrackSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 361);
            Controls.Add(okButton);
            Controls.Add(tracksCheckedListBox);
            Controls.Add(trackSelectionLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private Button okButton;
    }
}