namespace SerialReader
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Enviar = new System.Windows.Forms.Label();
            this.txtEnviar = new System.Windows.Forms.TextBox();
            this.txtRecibir = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.gbLectura = new System.Windows.Forms.GroupBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.cbEstable = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validarConeccionBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentGuia = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPeso = new System.Windows.Forms.Label();
            this.lblBalanza = new System.Windows.Forms.Label();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbLectura.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Enabled = false;
            this.btnAbrir.Location = new System.Drawing.Point(20, 40);
            this.btnAbrir.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(143, 28);
            this.btnAbrir.TabIndex = 2;
            this.btnAbrir.Text = "Pesar";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Enabled = false;
            this.btnCerrar.Location = new System.Drawing.Point(171, 40);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(134, 28);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Terminar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Recibir";
            // 
            // Enviar
            // 
            this.Enviar.AutoSize = true;
            this.Enviar.Location = new System.Drawing.Point(680, 149);
            this.Enviar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(48, 17);
            this.Enviar.TabIndex = 5;
            this.Enviar.Text = "Enviar";
            // 
            // txtEnviar
            // 
            this.txtEnviar.Location = new System.Drawing.Point(771, 146);
            this.txtEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(345, 22);
            this.txtEnviar.TabIndex = 6;
            // 
            // txtRecibir
            // 
            this.txtRecibir.Location = new System.Drawing.Point(772, 177);
            this.txtRecibir.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecibir.Name = "txtRecibir";
            this.txtRecibir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRecibir.Size = new System.Drawing.Size(344, 22);
            this.txtRecibir.TabIndex = 7;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(691, 201);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 28);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // gbLectura
            // 
            this.gbLectura.Controls.Add(this.lblPeso);
            this.gbLectura.Location = new System.Drawing.Point(19, 72);
            this.gbLectura.Name = "gbLectura";
            this.gbLectura.Size = new System.Drawing.Size(632, 171);
            this.gbLectura.TabIndex = 12;
            this.gbLectura.TabStop = false;
            // 
            // lblPeso
            // 
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPeso.Location = new System.Drawing.Point(123, 29);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(501, 113);
            this.lblPeso.TabIndex = 13;
            this.lblPeso.Text = "0";
            this.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEstable
            // 
            this.cbEstable.AutoSize = true;
            this.cbEstable.Location = new System.Drawing.Point(734, 72);
            this.cbEstable.Name = "cbEstable";
            this.cbEstable.Size = new System.Drawing.Size(77, 21);
            this.cbEstable.TabIndex = 14;
            this.cbEstable.Text = "Estable";
            this.cbEstable.UseVisualStyleBackColor = true;
            this.cbEstable.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 617);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(665, 26);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(18, 20);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conectarToolStripMenuItem
            // 
            this.conectarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem1,
            this.desconectarToolStripMenuItem});
            this.conectarToolStripMenuItem.Name = "conectarToolStripMenuItem";
            this.conectarToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.conectarToolStripMenuItem.Text = "Balanza";
            // 
            // conectarToolStripMenuItem1
            // 
            this.conectarToolStripMenuItem1.Name = "conectarToolStripMenuItem1";
            this.conectarToolStripMenuItem1.Size = new System.Drawing.Size(174, 26);
            this.conectarToolStripMenuItem1.Text = "Conectar";
            this.conectarToolStripMenuItem1.Click += new System.EventHandler(this.ConectarToolStripMenuItem1_Click);
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            this.desconectarToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.desconectarToolStripMenuItem.Text = "Desconectar";
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.DesconectarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parámetrosToolStripMenuItem,
            this.validarConeccionBaseDeDatosToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(85, 24);
            this.toolStripMenuItem1.Text = "Opciones";
            // 
            // parámetrosToolStripMenuItem
            // 
            this.parámetrosToolStripMenuItem.Name = "parámetrosToolStripMenuItem";
            this.parámetrosToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.parámetrosToolStripMenuItem.Text = "Configurar Puerto";
            this.parámetrosToolStripMenuItem.Click += new System.EventHandler(this.ParámetrosToolStripMenuItem_Click);
            // 
            // validarConeccionBaseDeDatosToolStripMenuItem
            // 
            this.validarConeccionBaseDeDatosToolStripMenuItem.Name = "validarConeccionBaseDeDatosToolStripMenuItem";
            this.validarConeccionBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.validarConeccionBaseDeDatosToolStripMenuItem.Text = "Validar Conexión Base de Datos";
            this.validarConeccionBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.ValidarConeccionBaseDeDatosToolStripMenuItem_Click);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.BackgroundColor = System.Drawing.Color.White;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreatedDate,
            this.OriginalData,
            this.Weight,
            this.Remarks});
            this.dgData.Location = new System.Drawing.Point(20, 288);
            this.dgData.Name = "dgData";
            this.dgData.RowHeadersVisible = false;
            this.dgData.RowHeadersWidth = 51;
            this.dgData.RowTemplate.Height = 24;
            this.dgData.Size = new System.Drawing.Size(631, 259);
            this.dgData.TabIndex = 17;
            this.dgData.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgData_CellBeginEdit);
            this.dgData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgData_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Guia:";
            // 
            // lblCurrentGuia
            // 
            this.lblCurrentGuia.AutoSize = true;
            this.lblCurrentGuia.Location = new System.Drawing.Point(123, 256);
            this.lblCurrentGuia.Name = "lblCurrentGuia";
            this.lblCurrentGuia.Size = new System.Drawing.Size(138, 17);
            this.lblCurrentGuia.TabIndex = 19;
            this.lblCurrentGuia.Text = "001-000-000000000";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(598, 253);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(46, 23);
            this.btnConsultar.TabIndex = 20;
            this.btnConsultar.Text = "...";
            this.btnConsultar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 561);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 39);
            this.label3.TabIndex = 21;
            this.label3.Text = "TOTAL PESO:";
            // 
            // lblTotalPeso
            // 
            this.lblTotalPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPeso.Location = new System.Drawing.Point(359, 561);
            this.lblTotalPeso.Name = "lblTotalPeso";
            this.lblTotalPeso.Size = new System.Drawing.Size(290, 39);
            this.lblTotalPeso.TabIndex = 22;
            this.lblTotalPeso.Text = "0";
            this.lblTotalPeso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBalanza
            // 
            this.lblBalanza.AutoSize = true;
            this.lblBalanza.Location = new System.Drawing.Point(605, 40);
            this.lblBalanza.Name = "lblBalanza";
            this.lblBalanza.Size = new System.Drawing.Size(46, 17);
            this.lblBalanza.TabIndex = 23;
            this.lblBalanza.Text = "label4";
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Fecha lectura";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 120;
            // 
            // OriginalData
            // 
            this.OriginalData.DataPropertyName = "OriginalData";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OriginalData.DefaultCellStyle = dataGridViewCellStyle1;
            this.OriginalData.HeaderText = "Peso original";
            this.OriginalData.MinimumWidth = 6;
            this.OriginalData.Name = "OriginalData";
            this.OriginalData.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle2;
            this.Weight.HeaderText = "Peso";
            this.Weight.MinimumWidth = 6;
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Notas";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 643);
            this.Controls.Add(this.lblBalanza);
            this.Controls.Add(this.lblTotalPeso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblCurrentGuia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cbEstable);
            this.Controls.Add(this.gbLectura);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtRecibir);
            this.Controls.Add(this.txtEnviar);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAbrir);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLectura.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Enviar;
        private System.Windows.Forms.TextBox txtEnviar;
        private System.Windows.Forms.TextBox txtRecibir;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.GroupBox gbLectura;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.CheckBox cbEstable;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parámetrosToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentGuia;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalPeso;
        private System.Windows.Forms.ToolStripMenuItem validarConeccionBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem;
        private System.Windows.Forms.Label lblBalanza;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem desconectarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}

