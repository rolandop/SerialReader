using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialReader
{
    public class BalanceTest : IBalanceDevice
    {
        Thread thread;
        Random random;
        int max;
        int min;
        public BalanceTest()
        {
            random = new Random();
        }
        public void Connect()
        {
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
        }

        public void Disconnect()
        {
            
        }

        public string Read()
        {
            return "--";
        }

        public void Send(string command)
        {
            
        }

        public int Peso { get; set; }

        public string SendAndRead(string command)
        {
            var peso = $"{Peso}kg";

            return peso;
        }
    }
}
