namespace AiSeasonCreator
{
    partial class LoginForm
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
            userNameLabel = new Label();
            userPasswordLabel = new Label();
            userNameBox = new TextBox();
            userPasswordBox = new TextBox();
            loginButton = new Button();
            loginErrorLabel = new Label();
            SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(28, 19);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(65, 15);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "User Name";
            // 
            // userPasswordLabel
            // 
            userPasswordLabel.AutoSize = true;
            userPasswordLabel.Location = new Point(36, 48);
            userPasswordLabel.Name = "userPasswordLabel";
            userPasswordLabel.Size = new Size(57, 15);
            userPasswordLabel.TabIndex = 1;
            userPasswordLabel.Text = "Password";
            // 
            // userNameBox
            // 
            userNameBox.Location = new Point(99, 16);
            userNameBox.Name = "userNameBox";
            userNameBox.Size = new Size(132, 23);
            userNameBox.TabIndex = 2;
            // 
            // userPasswordBox
            // 
            userPasswordBox.Location = new Point(99, 45);
            userPasswordBox.Name = "userPasswordBox";
            userPasswordBox.Size = new Size(132, 23);
            userPasswordBox.TabIndex = 3;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(116, 74);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(95, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            loginButton.KeyPress += loginButton_KeyPress;
            // 
            // loginErrorLabel
            // 
            loginErrorLabel.AutoSize = true;
            loginErrorLabel.ForeColor = Color.Red;
            loginErrorLabel.Location = new Point(12, 114);
            loginErrorLabel.Name = "loginErrorLabel";
            loginErrorLabel.Size = new Size(0, 15);
            loginErrorLabel.TabIndex = 5;
            loginErrorLabel.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 138);
            Controls.Add(loginErrorLabel);
            Controls.Add(loginButton);
            Controls.Add(userPasswordBox);
            Controls.Add(userNameBox);
            Controls.Add(userPasswordLabel);
            Controls.Add(userNameLabel);
            MaximizeBox = false;
            MaximumSize = new Size(319, 177);
            MinimizeBox = false;
            MinimumSize = new Size(319, 177);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userNameLabel;
        private Label userPasswordLabel;
        private TextBox userNameBox;
        private TextBox userPasswordBox;
        private Button loginButton;
        private Label loginErrorLabel;
    }
}