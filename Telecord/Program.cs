using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telecord.Models;

namespace Telecord
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Discord.Initialize();
            Application.Run(new Main());
        }

        internal static List<ChannelConnection> Connections = new List<ChannelConnection>();

        internal static void SaveConnections()
        {
            using (var sw = new StreamWriter("connections.json"))
                sw.WriteLine(JsonConvert.SerializeObject(Connections, Formatting.Indented));
        }

        internal static void LoadConnections()
        {
            if (File.Exists("connections.json"))
                using (var sw = new StreamReader("connections.json"))
                {
                    Connections = JsonConvert.DeserializeObject<List<ChannelConnection>>(sw.ReadToEnd());
                }
        }

        internal static string Log { get; set; }
    }
}
