using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialReader
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Configuracion.PortName = ddlPorts.Text;
            Configuracion.BaudRate = Convert.ToInt32(txtBaudRate.Text);
            Configuracion.DataBits = Convert.ToInt32(Configuracion.DataBits);
            Configuracion.Parity = (Parity)ddlParity.SelectedItem;
            Configuracion.StopBits = (StopBits)ddlStopBits.SelectedItem;
            Configuracion.Handshake = (Handshake)ddlHandshake.SelectedItem;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            var puertos = SerialPort.GetPortNames();
            ddlPorts.Items.AddRange(puertos);
           
            ddlParity.DataSource = Enum.GetNames(typeof(Parity));
            ddlStopBits.DataSource = Enum.GetNames(typeof(StopBits));
            ddlHandshake.DataSource = Enum.GetNames(typeof(Handshake));

            ddlPorts.SelectedItem = Configuracion.PortName;
            txtBaudRate.Text = Configuracion.BaudRate.ToString();
            txtDataBits.Text = Configuracion.DataBits.ToString();
            ddlParity.SelectedItem = Configuracion.Parity.ToString();
            ddlStopBits.SelectedItem = Configuracion.StopBits.ToString();
            ddlHandshake.SelectedItem = Configuracion.Handshake.ToString();

        }
    }
}
