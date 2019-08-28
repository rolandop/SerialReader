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

        private string _decimalPoint;
        private string DecimalPoint
        {
            get {
                if (_decimalPoint == null)
                {
                    if (System.Configuration.ConfigurationManager.AppSettings["NumberDecimalSeparator"] != null)
                    {
                        _decimalPoint = System.Configuration.ConfigurationManager.AppSettings["NumberDecimalSeparator"];
                    }
                    else
                    {
                        _decimalPoint = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    }
                }
                return _decimalPoint;
            }
        }

        protected float GetNumericWeight(string weight) {

            try
            {
           
                string b = string.Empty;
                float val = 0;

                for (int i = 0; i < weight.Length; i++)
                {
                    var c = weight[i];

                    if (c == '-')
                        b += c;
                    else if (char.IsDigit(c))
                        b += c;
                    else if (c.ToString() == DecimalPoint)
                        b += c;
                }

                if (b.Length > 0)
                {
                    if (Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator != DecimalPoint)
                    {
                        b = b.Replace(DecimalPoint, Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    }

                    val = float.Parse(b);
                }

                return val;



                //var expresion = @"^-?\\d*(\\.\\d+)?$";
                ////var expresion = @"-?\d+";

                //var reg = Regex.Match(weight, expresion).Value;

                ////var factor = weight.StartsWith("-") ? -1 : 1;
                //var numericWeight = Convert.ToInt64(reg);

                //return numericWeight;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    public delegate void BalanceDataRead(string weight, BalanceReadStatus status);
}
