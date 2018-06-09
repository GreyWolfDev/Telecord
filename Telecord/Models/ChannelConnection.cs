using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecord.Models
{
    internal class ChannelConnection
    {
        public long TelegramChannelId { get; set; }
        public ulong DiscordChannelId { get; set; }
        public string TelegramChannelName { get; set; }
        public string DiscordChannelName { get; set; }
        public bool Everyone { get; set; }
        public bool AllowUrls { get; set; }
        public bool ShowName { get; set; }
    }
}
