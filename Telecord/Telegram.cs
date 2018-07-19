using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telecord.Models;

using OpenTl.ClientApi;
using OpenTl.ClientApi.MtProto.Exceptions;
using OpenTl.Schema;
using OpenTl.Schema.Help;

namespace Telecord
{

    internal static class Telegram
    {
        //internal static TelegramClient Client;
        internal static HashSet<long> SentMessages = new HashSet<long>();
        internal static IClientApi clientApi;


        private static bool Run = true;
        internal static async Task Initialize()
        {
            Log.WriteLine("Checking Telegram Settings...");
            //check settings
            if (Properties.Settings.Default.TelegramAppId == 0 || String.IsNullOrEmpty(Properties.Settings.Default.TelegramApiHash) || String.IsNullOrEmpty(Properties.Settings.Default.TelegramIp) || String.IsNullOrEmpty(Properties.Settings.Default.PublicKey))
            {
                new SettingsForm().ShowDialog();
            }
            if (Properties.Settings.Default.TelegramAppId != 0 && !String.IsNullOrEmpty(Properties.Settings.Default.TelegramApiHash) && !String.IsNullOrEmpty(Properties.Settings.Default.TelegramIp) && !String.IsNullOrEmpty(Properties.Settings.Default.PublicKey))
            {
                Log.WriteLine("Connecting to Telegram");
                //Client = new TelegramClient(Properties.Settings.Default.TelegramAppId, Properties.Settings.Default.TelegramApiHash);
                //Client.ConnectAsync();
                await ConfigureClient();

            }

            //StartAsync();
        }

        internal static async Task ConfigureClient()
        {
            Log.WriteLine("Configuring settings");
            var settings = new FactorySettings
            {
                AppHash = Properties.Settings.Default.TelegramApiHash,
                AppId = Properties.Settings.Default.TelegramAppId,
                ServerAddress = Properties.Settings.Default.TelegramIp,
                ServerPublicKey = Properties.Settings.Default.PublicKey,
                ServerPort = 443,
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

            clientApi = await ClientFactory.BuildClientAsync(settings).ConfigureAwait(false);
            Log.WriteLine("Connected, creating event handler");
            clientApi.UpdatesService.RecieveUpdates += UpdatesService_RecieveUpdates;
            clientApi.KeepAliveConnection();
            
            if (clientApi.AuthService.CurrentUserId.HasValue)
            {
                await clientApi.UsersService.GetCurrentUserFullAsync();
            }
        }

        private static Task UpdatesService_RecieveUpdates(IUpdates update)
        {
            //Log.WriteLine($"Update recieved: {update}");
            // handle updates
            switch (update)
            {
                case TUpdates updates:
                    var enumerator = updates.Updates.ToList().GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            if (enumerator.Current is TUpdateNewChannelMessage msg)
                            {
                                if (msg.Message is TMessage m)
                                {
                                    if (m.ToId is TPeerChannel c)
                                    {
                                        var conns = Program.Connections.Where(x => x.TelegramChannelId == c.ChannelId);
                                        if (!conns.Any()) continue;
                                        //-1001288603754
                                        //c.ChannelId == 1288603754
                                        if (SentMessages.Contains(m.Id))
                                            continue;
                                        Log.WriteLine("Channel message posted in " + conns.FirstOrDefault().TelegramChannelName);
                                        SentMessages.Add(m.Id);
                                        //get the channel
                                        var chan = updates.Chats.Where(x => x is TChannel).Cast<TChannel>().FirstOrDefault(x => x.Id == c.ChannelId);
                                        //forward the message to discord
                                        //445308465850613763
                                        //foreach (var conn in conns)
                                        Discord.SendMessage(m, conns.ToList(), chan);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case TUpdatesCombined updatesCombined:
                    break;
                case TUpdateShort updateShort:
                    break;
                case TUpdateShortChatMessage updateShortChatMessage:
                    break;
                case TUpdateShortMessage updateShortMessage:
                    break;
                case TUpdateShortSentMessage updateShortSentMessage:
                    break;
                case TUpdatesTooLong updatesTooLong:
                    break;
            }
            return Task.CompletedTask;
        }

        internal static async Task<List<Channel>> GetChannels()
        {
            Log.WriteLine("Getting channel list");
            var dialogs = await clientApi.MessagesService.GetUserDialogsAsync();
            List<TChannel> r = new List<TChannel>();
            r = dialogs.Chats.Where(x => x is TChannel).Cast<TChannel>().Where(x => x.Broadcast).ToList();
            return r.Select(x => new Channel { BlockediOS = x.Restricted, Id = x.Id, Name = x.Title }).ToList();
        }

        //internal static void Pause()
        //{
        //    Run = !Run;
        //    if (Run)
        //    {
        //        Log.WriteLine("Resuming telegram client");
        //        StartAsync();
        //    }
        //    else
        //    {
        //        Log.WriteLine("Pausing telegram client");
        //    }
        //}

        //internal static async Task Auth()
        //{
        //    try
        //    {
        //        Log.WriteLine("Attempting to authenticate with Telegram");
        //        Client = new TelegramClient(Properties.Settings.Default.TelegramAppId, Properties.Settings.Default.TelegramApiHash);
        //        await Client.ConnectAsync(false);
        //        if (!Client.IsUserAuthorized())
        //        {
        //            Log.WriteLine("User is not logged in!");
        //            MessageBox.Show("Logged out :(");
        //            //Console.Write("Please enter the auth code you just received: ");
        //            //string code = Console.ReadLine();
        //            //await client.MakeAuthAsync(_phoneNumber, hash, code);
        //        }
        //        else
        //        {
        //            Log.WriteLine("Authenticated");
        //        }
        //        //await client.SendRequestAsync<object>(new TLRequestGetDhConfig());
        //    }
        //    catch (Exception e)
        //    {
        //        Log.WriteLine(e.GetType() + "\n" + e.Message);
        //    }
        //}

        //internal static async Task StartAsync()
        //{
        //    await Auth();
        //    Log.WriteLine("Getting state");
        //    var state = await Client.SendRequestAsync<TLState>(new TLRequestGetState());
        //    int pts = state.Pts;
        //    int date = state.Date;
        //    int seq = state.Seq;
        //    while (Run)
        //    {
        //        TLAbsDifference update = new TLDifferenceEmpty();
        //        do
        //        {
        //            await Task.Delay(500);
        //            var requestGetDifference = new TLRequestGetDifference
        //            {
        //                Pts = pts,
        //                Date = date
        //            };
        //            try
        //            {
        //                Log.WriteLine("Getting updates");
        //                var getupdate = Client.SendRequestAsync<TLObject>(requestGetDifference).ConfigureAwait(false);
        //                var r = await getupdate;
        //                Log.WriteLine("Done");
        //                if (r is TLAbsDifference && r as TLConfig == null)
        //                    update = r as TLAbsDifference;
        //            }
        //            catch(AggregateException e)
        //            {
        //                Log.WriteLine("ERROR: " + e.InnerException.Message);
        //                await Task.Delay(2000);
        //                await Auth();
        //                pts = DateTime.UtcNow.GetUnixEpoch();
        //                date = pts;
        //                seq = 0;
        //            }
        //            catch(Exception e)
        //            {
        //                Log.WriteLine(e.Message);
        //                await Task.Delay(2000);
        //                await Auth();
        //                pts = DateTime.UtcNow.GetUnixEpoch();
        //                date = pts;
        //                seq = 0;
        //            }

        //        }
        //        while (update is TLDifferenceEmpty);

        //        var updates = update as TLDifference;
        //        pts = updates.State.Pts;
        //        date = updates.State.Date;
        //        seq = updates.State.Seq;
        //        var new_messages = updates.NewMessages;
        //        var enumerator = updates.OtherUpdates.ToList().GetEnumerator();
        //        try
        //        {
        //            while (enumerator.MoveNext())
        //            {
        //                if (enumerator.Current is TLUpdateNewChannelMessage msg)
        //                {
        //                    if (msg.Message is TLMessage m)
        //                    {
        //                        if (m.ToId is TLPeerChannel c)
        //                        {
        //                            var conns = Program.Connections.Where(x => x.TelegramChannelId == c.ChannelId);
        //                            if (!conns.Any()) continue;
        //                            //-1001288603754
        //                            //c.ChannelId == 1288603754
        //                            if (SentMessages.Contains(m.Id))
        //                                continue;
        //                            Log.WriteLine("Channel message posted");
        //                            SentMessages.Add(m.Id);
        //                            //forward the message to discord
        //                            //445308465850613763
        //                            foreach (var conn in conns)
        //                                await Discord.SendMessage(conn.DiscordChannelId, m, conn.Everyone);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}

        public static int GetUnixEpoch(this DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
