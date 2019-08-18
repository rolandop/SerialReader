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
        private string _balance;
        private SerialReaderContext _context;
        private IBalanceDevice _balanceDevice;
        private bool _isEditing = false;


        public FrmMain()
        {
            InitializeComponent();

            var mode = System.Configuration.ConfigurationSettings.AppSettings["mode"];

            if (mode == "test")
            {
                _balanceDevice = new BalanceTest();
            }
            else
            {
                _balanceDevice = new BalanceDevice();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (DateTime.Now > new DateTime(2019, 7, 8))
            {
                //MessageBox.Show("Licencia de prueba caducada, por favor contactarse con angel.rolandop@gmail.com para obtener una.");
            }
            _balance = System.Configuration.ConfigurationSettings.AppSettings["balance-code"];


            lblBalanza.Text = _balance;

            var puertos = SerialPort.GetPortNames();

            Configuracion.PortName = puertos.FirstOrDefault();
            dgData.AutoGenerateColumns = false;
            lblCurrentGuia.Text = "";
        }

        
        private void ConectarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {   
                _balanceDevice.Connect();

                btnAbrir.Enabled = true;
                btnCerrar.Enabled = false;

                btnEnviar.Enabled = true;
                gbLectura.Enabled = true;



                MessageBox.Show("Dispositivo conectado exitosamente!", "Serial Reader"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void DesconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                btnAbrir.Enabled = true;
                btnCerrar.Enabled = false;
                btnEnviar.Enabled = false;
                gbLectura.Enabled = false;

                _balanceDevice.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                btnAbrir.Enabled = false;
                btnCerrar.Enabled = true;
                desconectarToolStripMenuItem.Enabled = false;
                _context = new SerialReaderContext();


                IniciarLectura();

                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            pararLectura = true;
            btnAbrir.Enabled = true;
            btnCerrar.Enabled = false;
            desconectarToolStripMenuItem.Enabled = true;
            lblCurrentGuia.Text = "";

            Thread.Sleep(1000);

            if (Work != null)
            {
                var work = _context
                                    .BalanceWorks
                                    .FirstOrDefault(w => 
                                            w.Balance == _balance
                                            && w.Code == Work.Code);

                if (work != null)
                {
                    work.EndDate = DateTime.Now;
                    work.Status = BalanceStatus.Finished;
                }

                _context.SaveChanges();
            }

            toolStripStatusLabel1.Text = "Terminado";

            _context.Dispose();

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRecibir.Text = "";
                var enviar = txtEnviar.Text;
                _balanceDevice.Send(enviar);
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
                txtRecibir.Text = _balanceDevice.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _balanceDevice.Disconnect();

        }


        private bool nuevoPeso = false;
        private string ultimoPeso = "";
        private DateTime fechaCambioPeso;
        private DateTime fechaUltimaLectura;

        private bool pararLectura = false;
        private void IniciarLectura() {

            pararLectura = false;
            nuevoPeso = true;

            EscucharComandos();
            
            fechaCambioPeso = DateTime.Now;

            var thread = new Thread(()=> {

                while (true)
                {   
                    if (pararLectura)
                    {   
                        break;
                    }

                    if (_isEditing)
                    {
                        continue;
                    }
                    
                    var tipoImpresion = "IP";
                    var peso = _balanceDevice.SendAndRead(tipoImpresion);
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
                                    if (Work != null && Work.Status == BalanceStatus.Reading)
                                    {
                                        Data = new BalanceData
                                        {
                                            WorkId = Work.WorkId,
                                            OriginalData = ultimoPeso,
                                            Weight = utimoPesoNumerico,
                                            CreatedDate = DateTime.Now
                                        };

                                        _context.BalanceDatas.Add(Data);
                                        _context.SaveChanges();

                                        DataCollection.Add(Data);
                                        RefrescarDatos();
                                        nuevoPeso = false;

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
                                Data.OriginalData = ultimoPeso;
                                Data.Weight = utimoPesoNumerico;
                                Data.UpdateDate = DateTime.Now;

                                _context.Entry(Data).State = 
                                                System.Data.Entity.EntityState.Modified;
                                _context.SaveChanges();

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
            })
            { IsBackground = true};
            thread.Start();
        }

        public BalanceWork Work { get; set; }
        public BalanceData Data { get; set; }
        public List<BalanceData> DataCollection { get; set; } = new List<BalanceData>();

        private void EscucharComandos()
        {
            //Busca el último trabajo anterior y los retoma
            Work = _context.BalanceWorks
                                    .FirstOrDefault(w => 
                                                w.Balance == _balance                                                    
                                                && w.Status == BalanceStatus.Reading
                                            && w.StartDate < DateTime.Now);
            if (Work != null)
            {
                DataCollection = Work.Datas.ToList();
            }
            else
            {
                DataCollection.Clear();
            }

            RefrescarDatos();

            var thread = new Thread(() => {

                while (true)
                {
                    if (pararLectura)
                    {
                        break;
                    }
                    Thread.Sleep(500);

                    if (Work != null && Work.Status == BalanceStatus.Reading)
                    {
                        this.Invoke(new Action(() => {
                            lblCurrentGuia.Text = Work.Code;
                            toolStripStatusLabel1.Text = "Pesando...";
                        }));

                        continue;
                    }

                    try
                    {
                        if (pararLectura)
                        {
                            break;
                        }

                        Work = _context.BalanceWorks
                                       .FirstOrDefault(w =>
                                           w.Balance == _balance
                                           && w.Status == BalanceStatus.Pending);

                        if (Work != null)
                        {
                            Work.Status = BalanceStatus.Reading;
                            _context.SaveChanges();
                            
                            DataCollection = Work.Datas.ToList();
                            RefrescarDatos();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            })
            { IsBackground = true };
            thread.Start();
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

        private void DgData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _isEditing = true;
        }

        private void DgData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var lista = dgData.DataSource as List<BalanceData>;
                var dataId = lista[e.RowIndex].DataId;

                using (var contex = new SerialReaderContext())
                {
                    var data = contex.BalanceDatas
                                    .FirstOrDefault(d => d.DataId == dataId);

                    var value = dgData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value != null)
                    {
                        data.Remarks = value.ToString();
                        contex.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Editanto Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                _isEditing = false;
            }
        }
    }
}
