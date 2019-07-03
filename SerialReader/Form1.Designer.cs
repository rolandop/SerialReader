namespace SerialReader
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlPuertos = new System.Windows.Forms.ComboBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Enviar = new System.Windows.Forms.Label();
            this.txtEnviar = new System.Windows.Forms.TextBox();
            this.txtRecibir = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnIniciarLectura = new System.Windows.Forms.Button();
            this.gbLectura = new System.Windows.Forms.GroupBox();
            this.btnPararLectura = new System.Windows.Forms.Button();
            this.lblPeso = new System.Windows.Forms.Label();
            this.cbEstable = new System.Windows.Forms.CheckBox();
            this.gbLectura.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puertos";
            // 
            // ddlPuertos
            // 
            this.ddlPuertos.FormattingEnabled = true;
            this.ddlPuertos.Location = new System.Drawing.Point(109, 27);
            this.ddlPuertos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlPuertos.Name = "ddlPuertos";
            this.ddlPuertos.Size = new System.Drawing.Size(233, 24);
            this.ddlPuertos.TabIndex = 1;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(353, 25);
            this.btnAbrir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(100, 28);
            this.btnAbrir.TabIndex = 2;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(461, 25);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 28);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 345);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Recibir";
            // 
            // Enviar
            // 
            this.Enviar.AutoSize = true;
            this.Enviar.Location = new System.Drawing.Point(100, 314);
            this.Enviar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(48, 17);
            this.Enviar.TabIndex = 5;
            this.Enviar.Text = "Enviar";
            // 
            // txtEnviar
            // 
            this.txtEnviar.Location = new System.Drawing.Point(191, 311);
            this.txtEnviar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(345, 22);
            this.txtEnviar.TabIndex = 6;
            // 
            // txtRecibir
            // 
            this.txtRecibir.Location = new System.Drawing.Point(192, 342);
            this.txtRecibir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRecibir.Name = "txtRecibir";
            this.txtRecibir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRecibir.Size = new System.Drawing.Size(344, 22);
            this.txtRecibir.TabIndex = 7;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(544, 308);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 28);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SerialPort1_ErrorReceived);
            this.serialPort1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.SerialPort1_PinChanged);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // btnIniciarLectura
            // 
            this.btnIniciarLectura.Location = new System.Drawing.Point(23, 30);
            this.btnIniciarLectura.Name = "btnIniciarLectura";
            this.btnIniciarLectura.Size = new System.Drawing.Size(128, 27);
            this.btnIniciarLectura.TabIndex = 11;
            this.btnIniciarLectura.Text = "Iniciar Lectura";
            this.btnIniciarLectura.UseVisualStyleBackColor = true;
            this.btnIniciarLectura.Click += new System.EventHandler(this.BtnIniciarLectura_Click);
            // 
            // gbLectura
            // 
            this.gbLectura.Controls.Add(this.cbEstable);
            this.gbLectura.Controls.Add(this.lblPeso);
            this.gbLectura.Controls.Add(this.btnPararLectura);
            this.gbLectura.Controls.Add(this.btnIniciarLectura);
            this.gbLectura.Location = new System.Drawing.Point(20, 60);
            this.gbLectura.Name = "gbLectura";
            this.gbLectura.Size = new System.Drawing.Size(541, 171);
            this.gbLectura.TabIndex = 12;
            this.gbLectura.TabStop = false;
            // 
            // btnPararLectura
            // 
            this.btnPararLectura.Enabled = false;
            this.btnPararLectura.Location = new System.Drawing.Point(23, 63);
            this.btnPararLectura.Name = "btnPararLectura";
            this.btnPararLectura.Size = new System.Drawing.Size(128, 27);
            this.btnPararLectura.TabIndex = 12;
            this.btnPararLectura.Text = "Parar Lectura";
            this.btnPararLectura.UseVisualStyleBackColor = true;
            this.btnPararLectura.Click += new System.EventHandler(this.BtnPararLectura_Click);
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPeso.Location = new System.Drawing.Point(298, 74);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(0, 58);
            this.lblPeso.TabIndex = 13;
            // 
            // cbEstable
            // 
            this.cbEstable.AutoSize = true;
            this.cbEstable.Location = new System.Drawing.Point(158, 35);
            this.cbEstable.Name = "cbEstable";
            this.cbEstable.Size = new System.Drawing.Size(77, 21);
            this.cbEstable.TabIndex = 14;
            this.cbEstable.Text = "Estable";
            this.cbEstable.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 284);
            this.Controls.Add(this.gbLectura);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtRecibir);
            this.Controls.Add(this.txtEnviar);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.ddlPuertos);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLectura.ResumeLayout(false);
            this.gbLectura.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPuertos;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Enviar;
        private System.Windows.Forms.TextBox txtEnviar;
        private System.Windows.Forms.TextBox txtRecibir;
        private System.Windows.Forms.Button btnEnviar;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnIniciarLectura;
        private System.Windows.Forms.GroupBox gbLectura;
        private System.Windows.Forms.Button btnPararLectura;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.CheckBox cbEstable;
    }
}

