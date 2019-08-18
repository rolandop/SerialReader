using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SerialReader.Utilities
{
    public class BalanceTest : BalanceDevice
    {
        Thread thread;
        Random random;
        int max;
        int min;

        public BalanceTest()
        {
            random = new Random();
        }
        public override void Connect()
        {
            Connect("");
        }

        public override void Connect(string portName)
        {
            Connect("", new BalanceConfig());
        }

        public override void Connect(string portName, BalanceConfig config)
        {
            Config = config;

            //return;
            thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    Peso = 0;

                    Thread.Sleep(2000);
                    var peso = new Random().Next(0, 100);
                    max = peso + 3;
                    min = peso - 3;

                    var thread2 = new Thread(() =>
                    {
                        Thread.Sleep(200);

                        var time = DateTime.Now;
                        while (true)
                        {
                            Peso = new Random().Next(min, max);

                            var time2 = DateTime.Now;
                            var lapsed = time2 - time;

                            if (lapsed.TotalMilliseconds > 500)
                            {
                                break;
                            }

                        }
                    })
                    { IsBackground = true };
                    thread2.Start();
                }
            })
            { IsBackground = true };
            thread.Start();

            if (ReadMode == BalanceReadMode.Automatic)
            {
                StartReading();
            }
        }

        public override void Disconnect()
        {
            
        }

        public override string Read()
        {
            var peso = $"{Peso}kg";

            WeightRead(peso, BalanceReadStatus.New);

            return peso;
        }

        public override void Send(string command)
        {
            
        }

        public int Peso { get; set; }        

        public override string SendAndRead(string command)
        {
            var peso = $"{Peso}kg";

            WeightRead(peso, BalanceReadStatus.New);

            return peso;
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
