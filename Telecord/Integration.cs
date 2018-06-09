using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telecord.Models;

namespace Telecord
{
    public partial class Integration : Form
    {
        public Integration()
        {
            InitializeComponent();


            var t = Task.Run(() => Telegram.GetChannels()).Result;
            foreach (var c in t)
            {
                listTelegram.Items.Add(new ListViewItem(new string[] { c.Name, c.BlockediOS.ToString(), c.Id.ToString() }));
            }
            var d = Discord.GetChannels();
            
            foreach (var c in d)
            {
                listDiscord.Items.Add(new ListViewItem(new string[] { c.Guild.Name, c.Name, c.Id.ToString() }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create our connection
            var c = new ChannelConnection();
            c.TelegramChannelName = listTelegram.SelectedItems[0].SubItems[0].Text;
            c.TelegramChannelId = long.Parse(listTelegram.SelectedItems[0].SubItems[2].Text);
            c.DiscordChannelId = ulong.Parse(listDiscord.SelectedItems[0].SubItems[2].Text);
            c.DiscordChannelName = listDiscord.SelectedItems[0].SubItems[0].Text + ": " + listDiscord.SelectedItems[0].SubItems[1].Text;
            c.AllowUrls = chkUrls.Checked;
            c.Everyone = chkEveryone.Checked;
            c.ShowName = chkShowName.Checked;
            //save the connection
            Program.Connections.Add(c);
            Program.SaveConnections();
        }
    }
}
