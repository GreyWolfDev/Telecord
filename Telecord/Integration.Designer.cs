namespace Telecord
{
    partial class Integration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Integration));
            this.button1 = new System.Windows.Forms.Button();
            this.listTelegram = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Blocked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listDiscord = new System.Windows.Forms.ListView();
            this.Server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChannelId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUrls = new System.Windows.Forms.CheckBox();
            this.chkEveryone = new System.Windows.Forms.CheckBox();
            this.chkShowName = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listTelegram
            // 
            this.listTelegram.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Blocked,
            this.Id});
            this.listTelegram.FullRowSelect = true;
            this.listTelegram.HideSelection = false;
            this.listTelegram.Location = new System.Drawing.Point(12, 12);
            this.listTelegram.Name = "listTelegram";
            this.listTelegram.ShowGroups = false;
            this.listTelegram.Size = new System.Drawing.Size(617, 258);
            this.listTelegram.TabIndex = 3;
            this.listTelegram.UseCompatibleStateImageBehavior = false;
            this.listTelegram.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 280;
            // 
            // Blocked
            // 
            this.Blocked.Text = "Blocked on iOS";
            this.Blocked.Width = 111;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 210;
            // 
            // listDiscord
            // 
            this.listDiscord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Server,
            this.Channel,
            this.ChannelId});
            this.listDiscord.FullRowSelect = true;
            this.listDiscord.HideSelection = false;
            this.listDiscord.Location = new System.Drawing.Point(12, 276);
            this.listDiscord.MultiSelect = false;
            this.listDiscord.Name = "listDiscord";
            this.listDiscord.ShowGroups = false;
            this.listDiscord.Size = new System.Drawing.Size(617, 313);
            this.listDiscord.TabIndex = 4;
            this.listDiscord.UseCompatibleStateImageBehavior = false;
            this.listDiscord.View = System.Windows.Forms.View.Details;
            // 
            // Server
            // 
            this.Server.Text = "Server";
            this.Server.Width = 285;
            // 
            // Channel
            // 
            this.Channel.Text = "Channel";
            this.Channel.Width = 191;
            // 
            // ChannelId
            // 
            this.ChannelId.Text = "Id";
            this.ChannelId.Width = 130;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShowName);
            this.groupBox1.Controls.Add(this.chkUrls);
            this.groupBox1.Controls.Add(this.chkEveryone);
            this.groupBox1.Location = new System.Drawing.Point(636, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 107);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkUrls
            // 
            this.chkUrls.AutoSize = true;
            this.chkUrls.Checked = true;
            this.chkUrls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUrls.Location = new System.Drawing.Point(7, 44);
            this.chkUrls.Name = "chkUrls";
            this.chkUrls.Size = new System.Drawing.Size(81, 17);
            this.chkUrls.TabIndex = 1;
            this.chkUrls.Text = "Allow URLs";
            this.chkUrls.UseVisualStyleBackColor = true;
            // 
            // chkEveryone
            // 
            this.chkEveryone.AutoSize = true;
            this.chkEveryone.Checked = true;
            this.chkEveryone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEveryone.Location = new System.Drawing.Point(7, 20);
            this.chkEveryone.Name = "chkEveryone";
            this.chkEveryone.Size = new System.Drawing.Size(81, 17);
            this.chkEveryone.TabIndex = 0;
            this.chkEveryone.Text = "@everyone";
            this.chkEveryone.UseVisualStyleBackColor = true;
            // 
            // chkShowName
            // 
            this.chkShowName.AutoSize = true;
            this.chkShowName.Location = new System.Drawing.Point(7, 68);
            this.chkShowName.Name = "chkShowName";
            this.chkShowName.Size = new System.Drawing.Size(126, 17);
            this.chkShowName.TabIndex = 2;
            this.chkShowName.Text = "Show Channel Name";
            this.chkShowName.UseVisualStyleBackColor = true;
            // 
            // Integration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listDiscord);
            this.Controls.Add(this.listTelegram);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Integration";
            this.Text = "Integration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listTelegram;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Blocked;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ListView listDiscord;
        private System.Windows.Forms.ColumnHeader Server;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.ColumnHeader ChannelId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUrls;
        private System.Windows.Forms.CheckBox chkEveryone;
        private System.Windows.Forms.CheckBox chkShowName;
    }
}