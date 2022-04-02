namespace Vax
{
    partial class Login
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.welcomeLable = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(442, 306);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(313, 171);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(204, 20);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Username";
            this.usernameBox.Click += new System.EventHandler(this.usernameBox_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(313, 253);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(204, 20);
            this.passwordBox.TabIndex = 2;
            this.passwordBox.Text = "Password";
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.Click += new System.EventHandler(this.passwordBox_Click);
            // 
            // welcomeLable
            // 
            this.welcomeLable.AutoSize = true;
            this.welcomeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLable.Location = new System.Drawing.Point(339, 45);
            this.welcomeLable.Name = "welcomeLable";
            this.welcomeLable.Size = new System.Drawing.Size(138, 20);
            this.welcomeLable.TabIndex = 3;
            this.welcomeLable.Text = "Welcome to Vax";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.Crimson;
            this.label.Location = new System.Drawing.Point(340, 155);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.welcomeLable);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.loginBtn);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label welcomeLable;
        private System.Windows.Forms.Label label;
    }
}