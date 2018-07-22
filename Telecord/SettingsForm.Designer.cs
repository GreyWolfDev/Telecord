namespace Telecord
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lbl4532 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTGApiHash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTGAppId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveDiscord = new System.Windows.Forms.Button();
            this.txtDiscordToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.lbl4532);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtTGApiHash);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTGAppId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telegram";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(206, 90);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(244, 50);
            this.txtKey.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Public Key";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(203, 36);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(170, 20);
            this.txtIp.TabIndex = 7;
            // 
            // lbl4532
            // 
            this.lbl4532.AutoSize = true;
            this.lbl4532.Location = new System.Drawing.Point(200, 20);
            this.lbl4532.Name = "lbl4532";
            this.lbl4532.Size = new System.Drawing.Size(136, 13);
            this.lbl4532.TabIndex = 6;
            this.lbl4532.Text = "Production DC (IP Address)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTGApiHash
            // 
            this.txtTGApiHash.Location = new System.Drawing.Point(6, 90);
            this.txtTGApiHash.Name = "txtTGApiHash";
            this.txtTGApiHash.Size = new System.Drawing.Size(188, 20);
            this.txtTGApiHash.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Api Hash";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(87, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get API Info";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "App ID";
            // 
            // txtTGAppId
            // 
            this.txtTGAppId.Location = new System.Drawing.Point(6, 36);
            this.txtTGAppId.Name = "txtTGAppId";
            this.txtTGAppId.Size = new System.Drawing.Size(188, 20);
            this.txtTGAppId.TabIndex = 0;
            this.txtTGAppId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTGAppId_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveDiscord);
            this.groupBox2.Controls.Add(this.txtDiscordToken);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Discord";
            // 
            // btnSaveDiscord
            // 
            this.btnSaveDiscord.Location = new System.Drawing.Point(6, 59);
            this.btnSaveDiscord.Name = "btnSaveDiscord";
            this.btnSaveDiscord.Size = new System.Drawing.Size(188, 23);
            this.btnSaveDiscord.TabIndex = 2;
            this.btnSaveDiscord.Text = "Save";
            this.btnSaveDiscord.UseVisualStyleBackColor = true;
            this.btnSaveDiscord.Click += new System.EventHandler(this.btnSaveDiscord_Click);
            // 
            // txtDiscordToken
            // 
            this.txtDiscordToken.Location = new System.Drawing.Point(6, 32);
            this.txtDiscordToken.Name = "txtDiscordToken";
            this.txtDiscordToken.Size = new System.Drawing.Size(188, 20);
            this.txtDiscordToken.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bot Token";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Port";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(379, 36);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(71, 20);
            this.txtPort.TabIndex = 11;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 271);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTGAppId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTGApiHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveDiscord;
        private System.Windows.Forms.TextBox txtDiscordToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lbl4532;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
    }
}