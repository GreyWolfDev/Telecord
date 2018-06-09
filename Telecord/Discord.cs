using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using OpenTl.Schema;
using Telecord.Models;

namespace Telecord
{
    internal static class Discord
    {
        internal static DiscordSocketClient Client;
        internal static void Initialize()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.DiscordBotToken))
            {
                new SettingsForm().ShowDialog();
            }
            Client = new DiscordSocketClient();
            try
            {
                Task.Run(() => Client.LoginAsync(TokenType.Bot, Properties.Settings.Default.DiscordBotToken, true)).Wait();
                Task.Run(() => Client.StartAsync()).Wait();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        internal static List<SocketTextChannel> GetChannels()
        {
            return Client.Guilds.SelectMany(x => x.TextChannels).ToList();
        }

        internal static async Task SendMessage(TMessage message, ChannelConnection c, TChannel chan)
        {
            try { 
            var channel = Client.Guilds.First(x => x.TextChannels.Any(t => t.Id == c.DiscordChannelId)).TextChannels.FirstOrDefault(x => x.Id == c.DiscordChannelId);
            var text = "";
            if (c.ShowName)
            {
                text = chan.Title + " posted:" + Environment.NewLine;
            }
            text += message.Message;

            if (message.Entities?.Any(x => x is TMessageEntityTextUrl) ?? false)
            {
                var urls = message.Entities.Where(x => x is TMessageEntityTextUrl).Cast<TMessageEntityTextUrl>().OrderByDescending(x => x.Offset);
                foreach (var u in urls)
                {
                    text = text.Insert(u.Offset + u.Length, $" ({(u.Url.StartsWith("http") ? u.Url : "http://" + u.Url)}) ");
                }
            }
            if (message.Entities?.Any(x => x is TMessageEntityUrl) ?? false)
            {
                var urls = message.Entities.Where(x => x is TMessageEntityUrl).Cast<TMessageEntityUrl>().OrderByDescending(x => x.Offset);
                foreach (var u in urls)
                {
                    //get original text 
                    var tu = message.Message.Substring(u.Offset, u.Length);
                    if (!tu.StartsWith("http"))
                    {
                        text = text.Replace(tu, "http://" + tu);
                    }
                }
            }
            if (message.Entities?.Any(x => x is TMessageEntityTextUrl || x is TMessageEntityUrl) ?? false)
            {
                if (!c.AllowUrls)
                {
                    Log.WriteLine("Message has a link: " + text + "\r\nnot sending");
                    return;
                }
            }

                if (message.Media == null || message.Media is TMessageMediaWebPage)
                {
                    Log.WriteLine("Posting " + text + " to " + channel.Name);
                    await channel.SendMessageAsync((c.Everyone ? "@everyone " : "") + text);
                }
                else
                {
                    if (message.Media is TMessageMediaPhoto mp)
                    {
                        try
                        {
                            Log.WriteLine("Message is photo");
                            var p = mp.Photo as TPhoto;
                            var s = p.Sizes.Where(x => x is TPhotoSize).Cast<TPhotoSize>().OrderByDescending(x => x.Size).First();
                            var l = s.Location as TFileLocation;
                            var file = await Telegram.clientApi.FileService.DownloadFullFileAsync(new TInputFileLocation { LocalId = l.LocalId, Secret = l.Secret, VolumeId = l.VolumeId });
                            var name = $"photo_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}.jpg";
                            Log.WriteLine($"Posting photo {name} to {channel.Name} with text {text}");
                            await channel.SendFileAsync(new MemoryStream(file), name, (c.Everyone ? "@everyone " : "") + text);
                        }
                        catch (AggregateException e)
                        {
                            Log.WriteLine(e.InnerException.Message);
                            //MessageBox.Show(e.InnerException.Message);
                        }
                        catch (Exception e)
                        {
                            Log.WriteLine(e.Message);
                            //MessageBox.Show(e.InnerException.Message);
                        }
                    }
                }
            }
            catch(AggregateException e)
            {
                Log.WriteLine($"ERROR!!\r\n{e.InnerException.Message}\r\n{e.InnerException.StackTrace}");
            }
            catch(Exception e)
            {
                Log.WriteLine($"ERROR!!\r\n{e.Message}\r\n{e.StackTrace}");
            }
        }
    }
}
