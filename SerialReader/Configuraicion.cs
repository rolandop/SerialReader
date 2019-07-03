using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader
{
    public class Configuracion
    {
        public static string PortName { get; set; } = "";
        public static int BaudRate { get; set; } = 9600;
        public static int DataBits { get; set; } = 8;
        public static Parity Parity { get; set; } = Parity.None;
        public static StopBits StopBits { get; set; } = StopBits.One;
        public static Handshake Handshake { get; set; } = Handshake.None;
    }
}
