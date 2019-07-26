using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialReader
{
    public class BalanceDevice : IBalanceDevice
    {
        SerialPort SerialPort1 { get; set; }

        

        public void Connect()
        {
            SerialPort1 = new SerialPort
            {
                PortName = Configuracion.PortName,
                BaudRate = Configuracion.BaudRate,
                DataBits = Configuracion.DataBits,
                Parity = Configuracion.Parity,
                StopBits = Configuracion.StopBits,
                Handshake = Configuracion.Handshake
            };

            SerialPort1.PinChanged += SerialPort1_PinChanged;
            SerialPort1.ErrorReceived += SerialPort1_ErrorReceived;

            SerialPort1.Open();
        }

        public void Disconnect()
        {
            if (SerialPort1?.IsOpen?? false)
            {
                SerialPort1.Close();
            }
        }

        public string SendAndRead(string command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes($"{command}\r\n");
            SerialPort1.Write(buffer, 0, buffer.Length);

            Thread.Sleep(50);

            if (!SerialPort1.IsOpen)
            {
                return null;
            }

            var peso = SerialPort1.ReadExisting();

            return peso;
        }

        public void Send(string command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes($"{command}\r\n");
            SerialPort1.Write(buffer, 0, buffer.Length);
        }

        public string Read()
        {
            if (SerialPort1.IsOpen)
            {
                return SerialPort1.ReadExisting();
            }
            return null;
        }

        private void SerialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialPinChange.CtsChanged:
                    break;
                case SerialPinChange.DsrChanged:
                    break;
                case SerialPinChange.CDChanged:
                    break;
                case SerialPinChange.Ring:
                    break;
                case SerialPinChange.Break:
                    break;
            }
        }

        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }
    }
}
