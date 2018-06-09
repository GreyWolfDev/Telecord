namespace Telecord
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
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnSendPassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendVerification = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.btnTelegramLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.btnSendPassword);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.label3);
            this.grpLogin.Controls.Add(this.btnSendVerification);
            this.grpLogin.Controls.Add(this.label2);
            this.grpLogin.Controls.Add(this.txtVerificationCode);
            this.grpLogin.Controls.Add(this.btnTelegramLogin);
            this.grpLogin.Controls.Add(this.label1);
            this.grpLogin.Controls.Add(this.txtPhoneNumber);
            this.grpLogin.Location = new System.Drawing.Point(12, 12);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(200, 235);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login";
            // 
            // btnSendPassword
            // 
            this.btnSendPassword.Enabled = false;
            this.btnSendPassword.Location = new System.Drawing.Point(6, 199);
            this.btnSendPassword.Name = "btnSendPassword";
            this.btnSendPassword.Size = new System.Drawing.Size(187, 23);
            this.btnSendPassword.TabIndex = 8;
            this.btnSendPassword.Text = "Send";
            this.btnSendPassword.UseVisualStyleBackColor = true;
            this.btnSendPassword.Click += new System.EventHandler(this.btnSendPassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(6, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(187, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // btnSendVerification
            // 
            this.btnSendVerification.Enabled = false;
            this.btnSendVerification.Location = new System.Drawing.Point(6, 129);
            this.btnSendVerification.Name = "btnSendVerification";
            this.btnSendVerification.Size = new System.Drawing.Size(187, 23);
            this.btnSendVerification.TabIndex = 5;
            this.btnSendVerification.Text = "Send";
            this.btnSendVerification.UseVisualStyleBackColor = true;
            this.btnSendVerification.Click += new System.EventHandler(this.btnSendVerification_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Verification Code";
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Enabled = false;
            this.txtVerificationCode.Location = new System.Drawing.Point(6, 103);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.Size = new System.Drawing.Size(187, 20);
            this.txtVerificationCode.TabIndex = 3;
            // 
            // btnTelegramLogin
            // 
            this.btnTelegramLogin.Enabled = false;
            this.btnTelegramLogin.Location = new System.Drawing.Point(6, 61);
            this.btnTelegramLogin.Name = "btnTelegramLogin";
            this.btnTelegramLogin.Size = new System.Drawing.Size(187, 23);
            this.btnTelegramLogin.TabIndex = 2;
            this.btnTelegramLogin.Text = "Login to Telegram";
            this.btnTelegramLogin.UseVisualStyleBackColor = true;
            this.btnTelegramLogin.Click += new System.EventHandler(this.btnTelegramLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(6, 35);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(187, 20);
            this.txtPhoneNumber.TabIndex = 0;
            this.txtPhoneNumber.Text = "+1";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 256);
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Login";
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnSendPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendVerification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVerificationCode;
        private System.Windows.Forms.Button btnTelegramLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhoneNumber;
    }
}