namespace AiSeasonCreator
{
    partial class CompletionForm
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
            components = new System.ComponentModel.Container();
            creationLabel = new Label();
            poisonStyleExtender1 = new ReaLTaiizor.Controls.PoisonStyleExtender(components);
            okButton = new ReaLTaiizor.Controls.PoisonButton();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // creationLabel
            // 
            creationLabel.AutoSize = true;
            creationLabel.BackColor = Color.Transparent;
            creationLabel.ForeColor = Color.LightGray;
            creationLabel.Location = new Point(3, 9);
            creationLabel.MaximumSize = new Size(400, 1000);
            creationLabel.Name = "creationLabel";
            creationLabel.Size = new Size(38, 15);
            creationLabel.TabIndex = 0;
            creationLabel.Text = "label1";
            creationLabel.MouseDown += creationLabel_MouseDown;
            // 
            // poisonStyleExtender1
            // 
            poisonStyleExtender1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // okButton
            // 
            okButton.Location = new Point(54, 37);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            okButton.UseSelectable = true;
            okButton.UseStyleColors = true;
            okButton.Click += okButton_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(okButton);
            panel1.Controls.Add(creationLabel);
            panel1.Location = new Point(3, 3);
            panel1.MaximumSize = new Size(400, 1000);
            panel1.Name = "panel1";
            panel1.Size = new Size(141, 72);
            panel1.TabIndex = 2;
            // 
            // CompletionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(128, 187, 0);
            ClientSize = new Size(156, 87);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1000, 1000);
            Name = "CompletionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CompletionForm";
            Load += CompletionForm_Load;
            MouseDown += CompletionForm_MoustDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label creationLabel;
        private ReaLTaiizor.Controls.PoisonStyleExtender poisonStyleExtender1;
        private ReaLTaiizor.Controls.PoisonButton okButton;
        private Panel panel1;
    }
}