using SerialReader.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialReader
{
    public partial class FrmMain : Form
    {
        private bool _enviando = false;
        public FrmMain()
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
            if (DateTime.Now > new DateTime(2019, 7, 8))
            {
                //MessageBox.Show("Licencia de prueba caducada, por favor contactarse con angel.rolandop@gmail.com para obtener una.");
            }

            var puertos = SerialPort.GetPortNames();

            Configuracion.PortName = puertos.FirstOrDefault();
            dgData.AutoGenerateColumns = false;
            lblCurrentGuia.Text = "";
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = Configuracion.PortName;
                serialPort1.BaudRate = Configuracion.BaudRate;
                serialPort1.DataBits = Configuracion.DataBits;
                serialPort1.Parity = Configuracion.Parity;
                serialPort1.StopBits = Configuracion.StopBits;
                serialPort1.Handshake = Configuracion.Handshake;
                
                serialPort1.Open();

                btnAbrir.Enabled = false;
                btnCerrar.Enabled = true;
                btnEnviar.Enabled = true;
                gbLectura.Enabled = true;

                BtnIniciarLectura_Click(null, null);
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
                BtnPararLectura_Click(null, null);

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

        private bool nuevoPeso = false;
        private bool actualizaPeso = false;
        private string ultimoPeso = "";
        private int tiempoEstabilidad = 2000;
        private DateTime fechaCambioPeso;
        private DateTime fechaUltimaLectura;

        private bool pararLectura = false;
        private void IniciarLectura() {

            EscucharComandos();

            pararLectura = false;
            fechaCambioPeso = DateTime.Now;

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
                    
                    var tipoImpresion = "IP";

                    byte[] buffer = Encoding.ASCII.GetBytes($"{tipoImpresion}\r\n");
                    serialPort1.Write(buffer, 0, buffer.Length);
                    Thread.Sleep(50);

                    if (!serialPort1.IsOpen)
                    {
                        break;
                    }

                    var peso = serialPort1.ReadExisting();
                    var pesoNumerico =
                                    Convert.ToInt64(Regex.Match(peso, @"-?\d+").Value);

                    var utimoPesoNumerico = ultimoPeso != ""
                                    ? Convert.ToInt64(Regex.Match(ultimoPeso, @"-?\d+").Value)
                                    : 0;

                    if (peso != ultimoPeso)
                    {
                        ultimoPeso = peso;
                        fechaCambioPeso = DateTime.Now;
                        
                        if (pesoNumerico <= Configuracion.EmptyWeigth)
                        {
                            nuevoPeso = true;
                        }

                        this.Invoke(new Action(() =>
                        {   
                            if (nuevoPeso)
                            {
                                
                            }
                            lblPeso.ForeColor = SystemColors.HotTrack;
                            lblPeso.Text = ultimoPeso;
                        }));
                    }
                    else
                    {
                        if (nuevoPeso)
                        {
                            var ahora = DateTime.Now;
                            var tiempoTranscurrido = (ahora - fechaCambioPeso)
                                                        .TotalMilliseconds; //Tiempo desde que cambió el último valor

                            if (tiempoTranscurrido >= Configuracion.StabilityTime
                                && pesoNumerico > 0)
                            {
                                fechaUltimaLectura = DateTime.Now;

                                this.Invoke(new Action(() =>
                                {
                                    if (Work != null)
                                    {
                                        using (var context = new SerialReaderContext())
                                        {
                                            Data = new BalanceData
                                            {
                                                WorkId = Work.WorkId,
                                                OriginalData = ultimoPeso,
                                                Weight = utimoPesoNumerico,
                                                CreatedDate = DateTime.Now
                                            };

                                            context.BalanceDatas.Add(Data);
                                            context.SaveChanges();

                                            DataCollection.Add(Data);
                                            RefrescarDatos();
                                            nuevoPeso = false;
                                        }
                                        lblPeso.ForeColor = Color.Green;
                                    }

                                }));
                            }
                        }
                        else if (Data != null)
                        {
                            var tiempoAcomodar = (DateTime.Now - fechaCambioPeso)
                                                        .TotalMilliseconds; //Tiempo en acomodar peso, luego de haber estabilizado el peso

                            var diferenciaPeso = Math.Abs(Data.Weight - pesoNumerico); //Diferencia de peso mínima para contabilizar

                            if (diferenciaPeso >= Configuracion.AccommodateWeigthMin
                                    && tiempoAcomodar > Configuracion.AccommodateTime)
                            {
                                using (var context = new SerialReaderContext())
                                {
                                    Data.OriginalData = ultimoPeso;
                                    Data.Weight = utimoPesoNumerico;
                                    Data.UpdateDate = DateTime.Now;

                                    context.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                                    context.SaveChanges();

                                    this.Invoke(new Action(() =>
                                    {
                                        lblPeso.ForeColor = Color.Green;
                                    }));

                                    fechaUltimaLectura = DateTime.Now;
                                    RefrescarDatos();
                                }
                            }
                        }
                    }
                }
            })
            { IsBackground = true};
            thread.Start();
        }

        public BalanceWork Work { get; set; }
        public BalanceData Data { get; set; }
        public List<BalanceData> DataCollection { get; set; } = new List<BalanceData>();

        private void EscucharComandos()
        {

            pararLectura = false;

            //Busca el último trabajo anterior y los retoma
            using (var context = new SerialReaderContext())
            {   
                Work = context.BalanceWorks
                                    .FirstOrDefault(w => w.Status == BalanceStatus.Reading
                                            && w.StartDate < DateTime.Now);
                if (Work != null)
                {
                    DataCollection = Work.Datas.ToList();
                    RefrescarDatos();
                }
            }

            var thread = new Thread(() => {

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
                    Thread.Sleep(500);
                    using (var context = new SerialReaderContext())
                    {
                        if (Work != null && Work.Status == BalanceStatus.Reading)
                        {
                            var work = context.BalanceWorks
                                                   .FirstOrDefault(w => w.WorkId == Work.WorkId);

                            if (work.Status == BalanceStatus.Finished)
                            {
                                Work = null;
                                this.Invoke(new Action(() => {
                                    toolStripStatusLabel1.Text = "Terminado";
                                }));
                            }
                            else
                            {
                                this.Invoke(new Action(() => {
                                    lblCurrentGuia.Text = Work.Code;
                                    toolStripStatusLabel1.Text = "Pesando...";
                                }));
                                continue;
                            }
                        }

                        Work = context.BalanceWorks
                                            .FirstOrDefault(w => w.Status == BalanceStatus.Pending);

                        if (Work != null)
                        {
                            Work.Status = BalanceStatus.Reading;
                            context.SaveChanges();
                            DataCollection.Clear();
                            RefrescarDatos();
                        }
                    }
                }
            })
            { IsBackground = true };
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

        private void ParámetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConfiguracion = new FrmConfiguracion();
            frmConfiguracion.ShowDialog();
        }

        public void RefrescarDatos()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(()=> {
                    RefrescarDatos();
                }));
            }
            else
            {
                var data = DataCollection.OrderByDescending(d => d.CreatedDate)
                                                .ToList();
                dgData.DataSource = data;
                lblTotalPeso.Text = data.Sum(d=> d.Weight).ToString();
                dgData.Update();
                dgData.Refresh();
                Application.DoEvents();
            }

            

            //using (var context = new SerialReaderContext())
            //{
            //    var data = context.BalanceDatas
            //                    .Where(d => d.WorkId == workId)
            //                    .OrderByDescending(d => d.CreatedDate)
            //                    .ToList();


            //}

        }

        private void ValidarConeccionBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var now = DateTime.Now;
                var workCode = "RP_" + now.Ticks;

                using (var context = new SerialReaderContext())
                {                    
                    var work = new BalanceWork
                    {
                        Code = workCode,
                        StartDate = now,
                        EndDate = now,
                        Status = BalanceStatus.Finished
                    };

                    work.Datas.Add(new BalanceData {
                        CreatedDate = now,
                        OriginalData = "100 Kg",
                        Weight = 100
                    });
                    
                    context.BalanceWorks.Add(work);
                    context.SaveChanges();
                }

                using (var context = new SerialReaderContext())
                { 
                    var work = context.BalanceWorks.FirstOrDefault(w=> w.Code == workCode);
                    if (work == null)
                    {
                        throw new Exception("No se pudo realizar las pruebas de integración. Work");
                    }

                    var data = context.BalanceDatas.FirstOrDefault(w => w.WorkId == work.WorkId);
                    if (data == null)
                    {
                        throw new Exception("No se pudo realizar las pruebas de integración. Data");
                    }                    
                }
                MessageBox.Show("Validación correcta", "Validando Conexión", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {                
                var msg = "";

                while (ex != null)
                {
                    msg = string.Concat(msg, " ", ex.Message);
                    ex = ex.InnerException;
                }

                MessageBox.Show(msg, "Validando Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
