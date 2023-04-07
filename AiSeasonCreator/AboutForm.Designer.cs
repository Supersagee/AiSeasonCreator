namespace AiSeasonCreator
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
            versionTextBox = new TextBox();
            aboutTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // versionTextBox
            // 
            versionTextBox.Enabled = false;
            versionTextBox.Location = new Point(12, 326);
            versionTextBox.Name = "versionTextBox";
            versionTextBox.Size = new Size(56, 23);
            versionTextBox.TabIndex = 0;
            versionTextBox.Text = "v1.0.1";
            // 
            // aboutTextBox
            // 
            aboutTextBox.Enabled = false;
            aboutTextBox.Location = new Point(12, 12);
            aboutTextBox.Name = "aboutTextBox";
            aboutTextBox.Size = new Size(660, 308);
            aboutTextBox.TabIndex = 1;
            aboutTextBox.Text = resources.GetString("aboutTextBox.Text");
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 361);
            Controls.Add(aboutTextBox);
            Controls.Add(versionTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox versionTextBox;
        private RichTextBox aboutTextBox;
    }
}