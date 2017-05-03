namespace DispensarioMedico
{
    partial class frmImprimirProblemaMedico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImprimirProblemaMedico));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtCed = new System.Windows.Forms.MaskedTextBox();
            this.rdoCedula = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoImprimeCaso = new System.Windows.Forms.RadioButton();
            this.txtNoCaso = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPaciente = new System.Windows.Forms.DataGridView();
            this.NoCaso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuCasoMedico = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImprimirListado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReImprimirSel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCortar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPegar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeleccionarTod = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).BeginInit();
            this.mnuCasoMedico.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Location = new System.Drawing.Point(13, 6);
            this.lblTituloForm.Size = new System.Drawing.Size(183, 22);
            this.lblTituloForm.Text = "Imprimir Caso Medico";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmdBuscar);
            this.groupBox5.Controls.Add(this.txtCed);
            this.groupBox5.Controls.Add(this.rdoCedula);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.rdoImprimeCaso);
            this.groupBox5.Controls.Add(this.txtNoCaso);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(150, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(314, 79);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(256, 44);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(48, 23);
            this.cmdBuscar.TabIndex = 37;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtCed
            // 
            this.txtCed.Location = new System.Drawing.Point(170, 45);
            this.txtCed.Mask = "000-0000000-0";
            this.txtCed.Name = "txtCed";
            this.txtCed.Size = new System.Drawing.Size(83, 20);
            this.txtCed.TabIndex = 12;
            this.txtCed.MaskChanged += new System.EventHandler(this.txtCed_MaskChanged);
            this.txtCed.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtCed_MaskInputRejected);
            this.txtCed.Click += new System.EventHandler(this.txtCed_Click);
            this.txtCed.Leave += new System.EventHandler(this.txtCed_Leave);
            this.txtCed.Validated += new System.EventHandler(this.txtCed_Validated);
            // 
            // rdoCedula
            // 
            this.rdoCedula.AutoSize = true;
            this.rdoCedula.Location = new System.Drawing.Point(175, 19);
            this.rdoCedula.Name = "rdoCedula";
            this.rdoCedula.Size = new System.Drawing.Size(58, 17);
            this.rdoCedula.TabIndex = 10;
            this.rdoCedula.TabStop = true;
            this.rdoCedula.Text = "Cedula";
            this.rdoCedula.UseVisualStyleBackColor = true;
            this.rdoCedula.CheckedChanged += new System.EventHandler(this.rdoCedula_CheckedChanged);
            this.rdoCedula.Click += new System.EventHandler(this.rdoCedula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cedula:";
            // 
            // rdoImprimeCaso
            // 
            this.rdoImprimeCaso.AutoSize = true;
            this.rdoImprimeCaso.Location = new System.Drawing.Point(80, 19);
            this.rdoImprimeCaso.Name = "rdoImprimeCaso";
            this.rdoImprimeCaso.Size = new System.Drawing.Size(87, 17);
            this.rdoImprimeCaso.TabIndex = 4;
            this.rdoImprimeCaso.TabStop = true;
            this.rdoImprimeCaso.Text = "Imprimir Caso";
            this.rdoImprimeCaso.UseVisualStyleBackColor = true;
            this.rdoImprimeCaso.CheckedChanged += new System.EventHandler(this.rdoImprimeCaso_CheckedChanged);
            // 
            // txtNoCaso
            // 
            this.txtNoCaso.Location = new System.Drawing.Point(69, 44);
            this.txtNoCaso.Name = "txtNoCaso";
            this.txtNoCaso.Size = new System.Drawing.Size(44, 20);
            this.txtNoCaso.TabIndex = 36;
            this.txtNoCaso.TextChanged += new System.EventHandler(this.txtNoCaso_TextChanged);
            this.txtNoCaso.Leave += new System.EventHandler(this.txtNoCaso_Leave);
            this.txtNoCaso.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoCaso_Validating);
            this.txtNoCaso.Validated += new System.EventHandler(this.txtNoCaso_Validated);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "No. Caso:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPaciente);
            this.groupBox2.Location = new System.Drawing.Point(16, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 175);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvPaciente
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaciente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaciente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoCaso,
            this.paciente,
            this.fecha});
            this.dgvPaciente.ContextMenuStrip = this.mnuCasoMedico;
            this.dgvPaciente.Location = new System.Drawing.Point(8, 15);
            this.dgvPaciente.Name = "dgvPaciente";
            this.dgvPaciente.Size = new System.Drawing.Size(556, 150);
            this.dgvPaciente.TabIndex = 0;
            this.dgvPaciente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaciente_CellContentClick);
            // 
            // NoCaso
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NoCaso.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoCaso.HeaderText = "No. Caso";
            this.NoCaso.Name = "NoCaso";
            // 
            // paciente
            // 
            this.paciente.HeaderText = "Paciente";
            this.paciente.Name = "paciente";
            this.paciente.Width = 300;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha Visita";
            this.fecha.Name = "fecha";
            // 
            // mnuCasoMedico
            // 
            this.mnuCasoMedico.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuModificar,
            this.mnuImprimirListado,
            this.mnuReImprimirSel,
            this.toolStripMenuItem1,
            this.mnuCopiar,
            this.mnuCortar,
            this.mnuPegar,
            this.mnuSeleccionarTod});
            this.mnuCasoMedico.Name = "contextMenuStrip1";
            this.mnuCasoMedico.Size = new System.Drawing.Size(210, 164);
            // 
            // mnuModificar
            // 
            this.mnuModificar.Image = ((System.Drawing.Image)(resources.GetObject("mnuModificar.Image")));
            this.mnuModificar.Name = "mnuModificar";
            this.mnuModificar.Size = new System.Drawing.Size(209, 22);
            this.mnuModificar.Text = "&Modifcar";
            // 
            // mnuImprimirListado
            // 
            this.mnuImprimirListado.Image = ((System.Drawing.Image)(resources.GetObject("mnuImprimirListado.Image")));
            this.mnuImprimirListado.Name = "mnuImprimirListado";
            this.mnuImprimirListado.Size = new System.Drawing.Size(209, 22);
            this.mnuImprimirListado.Text = "Imprimir Todos";
            this.mnuImprimirListado.Click += new System.EventHandler(this.mnuImprimirListado_Click);
            // 
            // mnuReImprimirSel
            // 
            this.mnuReImprimirSel.Image = ((System.Drawing.Image)(resources.GetObject("mnuReImprimirSel.Image")));
            this.mnuReImprimirSel.Name = "mnuReImprimirSel";
            this.mnuReImprimirSel.Size = new System.Drawing.Size(209, 22);
            this.mnuReImprimirSel.Text = "ReIm&primir Seleccionado ";
            this.mnuReImprimirSel.Click += new System.EventHandler(this.mnuReImprimirSel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(206, 6);
            // 
            // mnuCopiar
            // 
            this.mnuCopiar.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopiar.Image")));
            this.mnuCopiar.Name = "mnuCopiar";
            this.mnuCopiar.Size = new System.Drawing.Size(209, 22);
            this.mnuCopiar.Text = "&Copiar";
            // 
            // mnuCortar
            // 
            this.mnuCortar.Image = ((System.Drawing.Image)(resources.GetObject("mnuCortar.Image")));
            this.mnuCortar.Name = "mnuCortar";
            this.mnuCortar.Size = new System.Drawing.Size(209, 22);
            this.mnuCortar.Text = "Cor&tar";
            // 
            // mnuPegar
            // 
            this.mnuPegar.Image = ((System.Drawing.Image)(resources.GetObject("mnuPegar.Image")));
            this.mnuPegar.Name = "mnuPegar";
            this.mnuPegar.Size = new System.Drawing.Size(209, 22);
            this.mnuPegar.Text = "Peg&ar";
            // 
            // mnuSeleccionarTod
            // 
            this.mnuSeleccionarTod.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeleccionarTod.Image")));
            this.mnuSeleccionarTod.Name = "mnuSeleccionarTod";
            this.mnuSeleccionarTod.Size = new System.Drawing.Size(209, 22);
            this.mnuSeleccionarTod.Text = "&Selecionar Todo";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(158, 346);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(363, 346);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(260, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 45);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmImprimirProblemaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(603, 402);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmImprimirProblemaMedico";
            this.Text = "frmImprimirProblemaMedico";
            this.Load += new System.EventHandler(this.frmImprimirProblemaMedico_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).EndInit();
            this.mnuCasoMedico.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rdoImprimeCaso;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdoCedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoCaso;
        private System.Windows.Forms.DataGridViewTextBoxColumn paciente;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNoCaso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.ContextMenuStrip mnuCasoMedico;
        private System.Windows.Forms.ToolStripMenuItem mnuModificar;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimirListado;
        private System.Windows.Forms.ToolStripMenuItem mnuReImprimirSel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiar;
        private System.Windows.Forms.ToolStripMenuItem mnuCortar;
        private System.Windows.Forms.ToolStripMenuItem mnuPegar;
        private System.Windows.Forms.ToolStripMenuItem mnuSeleccionarTod;
        private System.Windows.Forms.MaskedTextBox txtCed;
        private System.Windows.Forms.Button cmdBuscar;
    }
}