using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialReader.Utilities.Test
{
    public partial class Form1 : Form
    {
        BalanceDevice Device;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Device_OnReading(string weight, BalanceReadStatus status)
        {
            Invoke(new Action(() => {
                textBox1.Text = weight;
            }));

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Device = new BalanceTest();
            }
            else
            {
                Device = new Balance();
            }

            Device.OnReading += Device_OnReading;
            Device.ReadMode = checkBox2.Checked ? BalanceReadMode.OnDemand
                                 : BalanceReadMode.Automatic;

            Device.Connect();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Device.ReadNumeric().ToString());
        }
    }
}
