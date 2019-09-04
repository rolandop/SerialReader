using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SerialReader.Utilities
{
    public class Balance : BalanceDevice
    {
        SerialPort SerialPort1 { get; set; }
        public override void Connect()
        {
            var portName = ConfigurationManager.AppSettings["PortName"];
            Connect(portName);
        }
        public override void Connect(string portName)
        {
            var config = new BalanceConfig();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["BaudRate"]))
            {
                config.BaudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DataBits"]))
            {
                config.DataBits = Convert.ToInt32(ConfigurationManager.AppSettings["DataBits"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Parity"]))
            {
                config.Parity = 
                        (Parity)Enum.Parse(typeof(Parity),ConfigurationManager.AppSettings["Parity"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["StopBits"]))
            {
                config.StopBits = 
                        (StopBits)Enum.Parse(typeof(StopBits), ConfigurationManager.AppSettings["StopBits"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Handshake"]))
            {
                config.Handshake = 
                        (Handshake)Enum.Parse(typeof(Handshake), ConfigurationManager.AppSettings["Handshake"]);
            }


            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EmptyWeigth"]))
            {
                config.EmptyWeigth = Convert.ToInt64(ConfigurationManager.AppSettings["EmptyWeigth"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["StabilityTime"]))
            {
                config.StabilityTime = Convert.ToInt64(ConfigurationManager.AppSettings["StabilityTime"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AccommodateTime"]))
            {
                config.AccommodateTime = Convert.ToInt64(ConfigurationManager.AppSettings["AccommodateTime"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AccommodateWeigthMin"]))
            {
                config.AccommodateWeigthMin = Convert.ToInt64(ConfigurationManager.AppSettings["AccommodateWeigthMin"]);
            }

            Connect(portName, config);

        }
        public override void Connect(string portName, BalanceConfig config)
        {
            try
            {
                Config = config;

                SerialPort1 = new SerialPort
                {
                    PortName = portName,
                    BaudRate = Config.BaudRate,
                    DataBits = Config.DataBits,
                    Parity = Config.Parity,
                    StopBits = Config.StopBits,
                    Handshake = Config.Handshake
                };

                SerialPort1.PinChanged += SerialPort1_PinChanged;
                SerialPort1.ErrorReceived += SerialPort1_ErrorReceived;

                SerialPort1.Open();

                if (ReadMode == BalanceReadMode.Automatic)
                {
                    StartReading();
                }
            }
            catch {
                
            }
        }
        public override void Disconnect()
        {
            if (SerialPort1?.IsOpen?? false)
            {
                SerialPort1.Close();
            }
        }
        public override string SendAndRead(string command)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes($"{command}\r\n");
                SerialPort1.Write(buffer, 0, buffer.Length);

                Thread.Sleep(50);

                if (!SerialPort1.IsOpen)
                {
                    return "";
                }

                var weight = SerialPort1.ReadExisting();

                WeightRead(weight, BalanceReadStatus.New);

                return weight;
            }
            catch { }
            return "";
        }
        public override void Send(string command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes($"{command}\r\n");
            SerialPort1.Write(buffer, 0, buffer.Length);
        }
        public override string Read()
        {
            try
            {
                if (SerialPort1.IsOpen)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes($"IP\r\n");
                    SerialPort1.Write(buffer, 0, buffer.Length);

                    Thread.Sleep(50);

                    var weight = SerialPort1.ReadExisting();

                    WeightRead(weight, BalanceReadStatus.New);

                    return weight;
                }

            }
            catch { }
            return "";
        }
        private  void SerialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
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
        public override float SendAndReadNumeric(string command)
        {
            return GetNumericWeight(SendAndRead(command));
        }
        public override float ReadNumeric()
        {
            return GetNumericWeight(Read());
        }
    }
}
