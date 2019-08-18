using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SerialReader.Utilities
{
    public abstract class BalanceDevice
    {
        public BalanceReadMode ReadMode { get; set; }
        protected BalanceConfig Config;

        public abstract void Connect();
        public abstract void Connect(string portName);
        public abstract void Connect(string portName, BalanceConfig config);

        private string lastWeight = "";
        private DateTime dateLastChanged;
        private bool newWeight;
        private long lastNumericWeightRegistered;

        protected void StartReading()
        {
            newWeight = true;

            var thread = new Thread(() => {

                while (true)
                {
                    var command = "IP";
                    var weight = SendAndRead(command);
                    var numericWeight =
                                    Convert.ToInt64(Regex.Match(weight, @"-?\d+").Value);

                    var lastNumericWeight = lastWeight != ""
                                    ? Convert.ToInt64(Regex.Match(lastWeight, @"-?\d+").Value)
                                    : 0;

                    if (weight != lastWeight)
                    {
                        lastWeight = weight;
                        dateLastChanged = DateTime.Now;

                        if (numericWeight <= Config.EmptyWeigth)
                        {
                            newWeight = true;
                        }
                    }
                    else
                    {
                        if (newWeight)
                        {
                            var now = DateTime.Now;
                            var elapsedTime = (now - dateLastChanged)
                                                        .TotalMilliseconds; //Tiempo desde que cambió el último valor

                            if (elapsedTime >= Config.StabilityTime
                                && numericWeight > 0)
                            {
                                lastNumericWeightRegistered = numericWeight;

                                WeightRead(weight, BalanceReadStatus.New);

                                newWeight = false;
                            }
                        }
                        else
                        {
                            var accommodateTime = (DateTime.Now - dateLastChanged)
                                                        .TotalMilliseconds; //Tiempo en acomodar peso, luego de haber estabilizado el peso

                            var differenceWeight = Math.Abs(lastNumericWeightRegistered - numericWeight); //Diferencia de peso mínima para contabilizar

                            if (differenceWeight >= Config.AccommodateWeigthMin
                                    && accommodateTime > Config.AccommodateTime)
                            {
                                WeightRead(weight, BalanceReadStatus.Update);
                            }
                        }
                    }
                }
            })
            { IsBackground = true };
            thread.Start();
        }

        protected void WeightRead(string weight, BalanceReadStatus status)
        {
            if (OnReading != null)
            {
                OnReading(weight, status);
            }
        }

        public abstract void Disconnect();
        public abstract string SendAndRead(string command);

        public abstract float SendAndReadNumeric(string command);

        public abstract void Send(string command);
        public abstract string Read();
        public abstract float ReadNumeric();

        public event BalanceDataRead OnReading;

        protected float GetNumericWeight(string weight) {
            try
            {
                //var factor = weight.StartsWith("-") ? -1 : 1;
                var numericWeight = Convert.ToInt64(Regex.Match(weight, @"-?\d+").Value);

                return numericWeight;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    public delegate void BalanceDataRead(string weight, BalanceReadStatus status);
}
