using Discord;
using Discord.WebSocket;
using OpenTl.ClientApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telecord
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtTGAppId.Text = Properties.Settings.Default.TelegramAppId.ToString();
            txtTGApiHash.Text = Properties.Settings.Default.TelegramApiHash;
            txtDiscordToken.Text = Properties.Settings.Default.DiscordBotToken;
            txtIp.Text = Properties.Settings.Default.TelegramIp;
            txtKey.Text = Properties.Settings.Default.PublicKey;
            txtPort.Text = Properties.Settings.Default.TelegramPort.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://my.telegram.org/apps");
        }

        private void txtTGAppId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new Task(async () =>
            {
                int id;
                var hash = txtTGApiHash.Text;
                var key = txtKey.Text;
                var ip = txtIp.Text;
                var port = int.Parse(txtPort.Text);
                ip = ip.Replace(":443", "");
                if (int.TryParse(txtTGAppId.Text, out id))
                {

                    try
                    {
                        var settings = new FactorySettings
                        {
                            AppHash = hash,
                            AppId = id,
                            ServerAddress = ip,
                            ServerPublicKey = txtKey.Text,
                            ServerPort = port,
                            SessionTag = "telecord", // by defaut
                            Properties = new ApplicationProperties
                            {
                                AppVersion = "1.0.0", // You can leave as in the example
                                DeviceModel = "PC", // You can leave as in the example
                                LangCode = "en", // You can leave as in the example
                                LangPack = "tdesktop", // You can leave as in the example
                                SystemLangCode = "en", // You can leave as in the example
                                SystemVersion = "Win 10 Pro" // You can leave as in the example
                            }
                        };

                        var clientApi = await ClientFactory.BuildClientAsync(settings).ConfigureAwait(false);
                        
                        //Telegram.Client = new TelegramClient(id, hash, null, "session");
                        //Task.Run(() => Telegram.Client.ConnectAsync(false)).Wait();
                        Properties.Settings.Default.TelegramApiHash = hash;
                        Properties.Settings.Default.TelegramAppId = id;
                        Properties.Settings.Default.TelegramIp = ip;
                        Properties.Settings.Default.PublicKey = key;
                        Properties.Settings.Default.TelegramPort = port;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("App settings saved!");
                    }
                    catch (AggregateException ex)
                    {
                        MessageBox.Show(ex.InnerExceptions[0].Message, "Error");
                        //txtTGApiHash.Text = "";
                        //txtTGAppId.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        //txtTGApiHash.Text = "";
                        //txtTGAppId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("App Id must be a number");
                    txtTGAppId.Text = "";
                }
            }).Start();


        }

        private void btnSaveDiscord_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new DiscordSocketClient();
                Task.Run(() => client.LoginAsync(TokenType.Bot, txtDiscordToken.Text, true)).Wait();
                MessageBox.Show("Discord token validated, saved!");
                Properties.Settings.Default.DiscordBotToken = txtDiscordToken.Text;
                Properties.Settings.Default.Save();

            }
            catch(AggregateException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
