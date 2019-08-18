using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SerialReader.Utilities
{
    public class BalanceConfig
    {   
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Handshake Handshake { get; set; } = Handshake.None;
        public long EmptyWeigth { get; set; } = 5;
        public long StabilityTime { get;  set; } = 1000;
        public long AccommodateTime { get; set; } = 2000;
        public long AccommodateWeigthMin { get; set; } = 5;
    }
}
