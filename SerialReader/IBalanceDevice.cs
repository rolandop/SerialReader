using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader
{
    public interface IBalanceDevice
    {
        void Connect();
        void Disconnect();

        string SendAndRead(string command);

        void Send(string command);

        string Read();
    }
}
