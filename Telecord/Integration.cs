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
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Net;
using Discord;
using System.IO;
using System.Threading;

namespace Telecord
{
    public partial class Integration : Form
    {
        public Integration()
        {
            InitializeComponent();


            Task.Run(() => Load()).Wait();
        }

        private async Task Load()
        {
            var t = await Telegram.GetChannels();
            foreach (var c in t)
            {
                listTelegram.Items.Add(new ListViewItem(new string[] { c.Name, c.BlockediOS.ToString(), c.Id.ToString() }));
            }

            var d = Discord.GetChannels();
            var stream = new FileStream("telecord.png", FileMode.OpenOrCreate);
            foreach (var c in d)
            {
                
                //get the webhook(s)
                try
                {
                    var hook = await c.GetWebhooksAsync(new RequestOptions { RetryMode = RetryMode.AlwaysRetry });
                    if (hook.Any())
                        listDiscord.Items.Add(new ListViewItem(new string[] { c.Guild.Name, c.Name, hook.First().Id.ToString(), hook.First().Token }));
                    else
                    {
                        Log.WriteLine("Creating webhook: Telecord - " + c.Name + " in server " + c.Guild.Name);
                        //create a webhook maybe?
                        var newhook = await c.CreateWebhookAsync("Telecord - " + c.Name, stream, options: new RequestOptions { RetryMode = RetryMode.AlwaysRetry });
                        listDiscord.Items.Add(new ListViewItem(new string[] { c.Guild.Name, c.Name, newhook.Id.ToString(), newhook.Token }));
                        //Thread.Sleep(5000);
                    }
                }
                catch
                {
                    // ignored
                }

            }
            stream.Close();
            stream.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create our connection
            var c = new ChannelConnection();
            c.TelegramChannelName = listTelegram.SelectedItems[0].SubItems[0].Text;
            c.TelegramChannelId = long.Parse(listTelegram.SelectedItems[0].SubItems[2].Text);
            c.DiscordHookId = ulong.Parse(listDiscord.SelectedItems[0].SubItems[2].Text);
            c.DiscordHookToken = listDiscord.SelectedItems[0].SubItems[3].Text;
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
