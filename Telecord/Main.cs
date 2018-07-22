using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTl.ClientApi;
using OpenTl.ClientApi.MtProto;
using OpenTl.ClientApi.MtProto.Exceptions;
using OpenTl.Schema;
using OpenTl.Schema.Auth;
using Telecord.Models;

namespace Telecord
{
    public partial class Main : Form
    {
        
        private static bool Exit;
        public Main()
        {
            InitializeComponent();
            Task.Run(() => Telegram.Initialize()).Wait();
            new Thread(WatchLog).Start();
            
            //Task.Run(() => Telegram.ConfigureClient()).Wait();
            if (!Telegram.clientApi?.AuthService.CurrentUserId.HasValue ?? true)
            {
                new Login().ShowDialog();
            }
            else
            {

                //Telegram.StartAsync();
            }
            LoadConnection();
        }

        private void LoadConnection()
        {
            listConnections.Items.Clear();
            Program.LoadConnections();
            var nsfw = new List<ChannelConnection>();
            foreach (var item in Program.Connections)
            {
                //if (item.DiscordChannelName.Contains("nsfw") || item.DiscordChannelName.Contains("Rule 34"))
                //    nsfw.Add(item);
                //else
                    listConnections.Items.Add(new ListViewItem(new string[] { item.TelegramChannelName, item.DiscordChannelName, item.Everyone.ToString(), item.AllowUrls.ToString(), item.ShowName.ToString(), item.Posts.ToString(), item.LastPost.ToString() }));
            }
        }

        private void WatchLog()
        {
            var text = "";
            while (!Exit)
            {
                if (Program.Log != text)
                {
                    IntPtr handle = default(IntPtr);
                    while (handle == default(IntPtr) || handle == null)
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new MethodInvoker(delegate
                            {
                                handle = Handle;
                            }));
                        }
                        else
                        {
                            //handle = Handle;
                        }
                        if (handle == default(IntPtr) || handle == null)
                            Thread.Sleep(1000);
                    }
                    text = Program.Log;
                    Invoke(new MethodInvoker(delegate { LoadConnection(); }));
                    Invoke(new MethodInvoker(delegate { txtLog.Text = Program.Log; txtLog.SelectionStart = txtLog.Text.Length - 1; txtLog.ScrollToCaret(); }));
                }
                Thread.Sleep(500);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                new Integration().ShowDialog();
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.InnerException.Message + "\nTry Again, Telegram is being weird..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nTry Again");
            }
            //reload connections list
            LoadConnection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listConnections.SelectedItems)
            {
                var dname = item.SubItems[1].Text;
                var tname = item.SubItems[0].Text;
                var everyone = bool.Parse(item.SubItems[2].Text);
                var c = Program.Connections.Where(x => x.TelegramChannelName == tname && x.DiscordChannelName == dname && x.Everyone == everyone);
                for (int i = c.Count() - 1; i >= 0; i--)
                {
                    Program.Connections.Remove(c.ElementAt(i));
                }
            }
            Program.SaveConnections();

            LoadConnection();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit = true;
        }
    }
}
