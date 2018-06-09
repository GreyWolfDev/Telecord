using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecord
{
    public static class Log
    {
        public static void WriteLine(string line)
        {
            Write(line + "\r\n");
        }

        public static void Write(string text)
        {
            Program.Log += text;
        }
    }
}
