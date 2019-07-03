using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialReader
{
    public partial class Form1 : Form
    {
        private bool _enviando = false;
        public Form1()
        {
            InitializeComponent();



            //SerialPort m_serialPort1 = new SerialPort("COM4"); //Puerto COM al que nos conectamos
            //m_serialPort1.ReadTimeout = 2000; //El timeout es esencial para parar la conexion pasado un tiempo. En este caso 2 segundos.
            //m_serialPort1.Open(); //Abrimos el puerto
            //try
            //{

            //    var lectura = m_serialPort1.ReadLine(); //Leemos una linea del puerto
            //}
            //catch (InvalidOperationException ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //try
            //{
            //    m_serialPort1.Close();//Cerramos puerto
            //    m_serialPort1.Dispose();//Liberamos recursos
            //}
            //catch
            //{

            //}  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var puertos = SerialPort.GetPortNames();
            ddlPuertos.Items.AddRange(puertos);
            btnCerrar.Enabled = false;
            btnEnviar.Enabled = false;
            gbLectura.Enabled = false;

            ddlPuertos.SelectedIndex = 0;
            
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = ddlPuertos.Text;
                serialPort1.Open();

                btnAbrir.Enabled = false;
                btnCerrar.Enabled = true;
                btnEnviar.Enabled = true;
                gbLectura.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                btnAbrir.Enabled = true;
                btnCerrar.Enabled = false;
                btnEnviar.Enabled = false;
                gbLectura.Enabled = false;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    txtRecibir.Text = "";
                    var enviar = txtEnviar.Text;
                    byte[] buffer = Encoding.ASCII.GetBytes(enviar + "\r\n");
                    serialPort1.Write(buffer, 0, buffer.Length);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    txtRecibir.Text = serialPort1.ReadExisting();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int intBuffer;
            intBuffer = serialPort1.BytesToRead;
            byte[] byteBuffer = new byte[intBuffer];
            //serialPort1.Read(byteBuffer, 0, intBuffer);

            this.Invoke(new Action(() =>
            {
                txtRecibir.Text += Encoding.UTF8.GetString(byteBuffer);
                //lblPeso.Text = Encoding.UTF8.GetString(byteBuffer);
            }));

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

        private string ultimoPeso = "";
        private int tiempoEstabilidad = 500;
        private DateTime ultimaLectura;

        private bool pararLectura = false;
        
        private void IniciarLectura() {

            pararLectura = false;
            var thread = new Thread(()=> {
                while (true)
                {   
                    if (pararLectura)
                    {
                        pararLectura = false;
                        this.Invoke(new Action(() =>
                        {
                            btnIniciarLectura.Enabled = true;
                            btnPararLectura.Enabled = false;
                        }));
                        break;
                    }
                    
                    var tipoImpresion = "";
                    this.Invoke(new Action(() =>
                    {
                        tipoImpresion = cbEstable.Checked
                                            ? "P": "IP";
                    }));

                    byte[] buffer = Encoding.ASCII.GetBytes($"{tipoImpresion}\r\n");
                    serialPort1.Write(buffer, 0, buffer.Length);
                    Thread.Sleep(250);

                    var peso = serialPort1.ReadExisting();
                    if (peso != ultimoPeso)
                    {
                        ultimoPeso = peso;
                        ultimaLectura = DateTime.Now;
                    }
                    else
                    {
                        var tiempoTranscurrido =
                                (DateTime.Now - ultimaLectura).TotalMilliseconds;
                        if (tiempoTranscurrido >= tiempoEstabilidad)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblPeso.Text = ultimoPeso;
                            }));
                        }
                    }
                }
            })
            { IsBackground = true};
            thread.Start();
        }

        private void BtnIniciarLectura_Click(object sender, EventArgs e)
        {
            if (!pararLectura)
            {
                IniciarLectura();
                btnIniciarLectura.Enabled = false;
                btnPararLectura.Enabled = true;
            }
        }

        private void BtnPararLectura_Click(object sender, EventArgs e)
        {
            pararLectura = true;
        }
    }
}
