namespace DispensarioMedico
{
    partial class frmMovInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grboxBotones = new System.Windows.Forms.GroupBox();
            this.cboEntradaSalida = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboT_mov = new System.Windows.Forms.ComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSecuencia = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaDigitada = new System.Windows.Forms.DateTimePicker();
            this.chkAfectaCosto = new System.Windows.Forms.CheckBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.grdDetalle = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboCodigo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmdBuscarItem = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.Des_Pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fec_Ven = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.mnuColgante = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcInsertar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcModfificar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcGrabar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.opcCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcPegar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcCortar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.Fec_fab = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.cmbRangoPaciente = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dataGridViewButtonXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cmbRangoMedico = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtApellidoMedico = new System.Windows.Forms.TextBox();
            this.txtNombreMedico = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBuscarMedico = new System.Windows.Forms.Button();
            this.txtCedulaMedico = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).BeginInit();
            this.mnuColgante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(220, 22);
            this.lblTituloForm.Text = "Movimientos de Inventario";
            // 
            // grboxBotones
            // 
            this.grboxBotones.Location = new System.Drawing.Point(779, 252);
            this.grboxBotones.Name = "grboxBotones";
            this.grboxBotones.Size = new System.Drawing.Size(116, 321);
            this.grboxBotones.TabIndex = 10;
            this.grboxBotones.TabStop = false;
            // 
            // cboEntradaSalida
            // 
            this.cboEntradaSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntradaSalida.FormattingEnabled = true;
            this.cboEntradaSalida.Items.AddRange(new object[] {
            "Entrada",
            "Salida"});
            this.cboEntradaSalida.Location = new System.Drawing.Point(111, 39);
            this.cboEntradaSalida.Name = "cboEntradaSalida";
            this.cboEntradaSalida.Size = new System.Drawing.Size(121, 21);
            this.cboEntradaSalida.TabIndex = 0;
            this.cboEntradaSalida.SelectedIndexChanged += new System.EventHandler(this.cboEntradaSalida_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tipo Movimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tipo Transaccion";
            // 
            // cboT_mov
            // 
            this.cboT_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboT_mov.Enabled = false;
            this.cboT_mov.FormattingEnabled = true;
            this.cboT_mov.Location = new System.Drawing.Point(112, 61);
            this.cboT_mov.Name = "cboT_mov";
            this.cboT_mov.Size = new System.Drawing.Size(210, 21);
            this.cboT_mov.TabIndex = 1;
            this.cboT_mov.SelectedIndexChanged += new System.EventHandler(this.cboT_mov_SelectedIndexChanged);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.Location = new System.Drawing.Point(53, 87);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(55, 13);
            this.lblAlmacen.TabIndex = 16;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(111, 83);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(211, 21);
            this.cboAlmacen.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(390, 45);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(215, 20);
            this.dtpFecha.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fecha Tr";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(441, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Secuencia";
            // 
            // txtSecuencia
            // 
            this.txtSecuencia.ForeColor = System.Drawing.Color.Red;
            this.txtSecuencia.Location = new System.Drawing.Point(509, 103);
            this.txtSecuencia.Mask = "999999";
            this.txtSecuencia.Name = "txtSecuencia";
            this.txtSecuencia.ReadOnly = true;
            this.txtSecuencia.Size = new System.Drawing.Size(101, 20);
            this.txtSecuencia.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(441, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Referencia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(510, 124);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(100, 20);
            this.txtReferencia.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Cargar Miembro:";
            // 
            // txtCedula
            // 
            this.txtCedula.Enabled = false;
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(111, 110);
            this.txtCedula.Mask = "###-#######-#";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(116, 22);
            this.txtCedula.TabIndex = 5;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            this.txtCedula.Validating += new System.ComponentModel.CancelEventHandler(this.txtCedula_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(332, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Digitada";
            // 
            // dtpFechaDigitada
            // 
            this.dtpFechaDigitada.Enabled = false;
            this.dtpFechaDigitada.Location = new System.Drawing.Point(390, 66);
            this.dtpFechaDigitada.Name = "dtpFechaDigitada";
            this.dtpFechaDigitada.Size = new System.Drawing.Size(215, 20);
            this.dtpFechaDigitada.TabIndex = 26;
            // 
            // chkAfectaCosto
            // 
            this.chkAfectaCosto.AutoSize = true;
            this.chkAfectaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAfectaCosto.Location = new System.Drawing.Point(467, 155);
            this.chkAfectaCosto.Name = "chkAfectaCosto";
            this.chkAfectaCosto.Size = new System.Drawing.Size(143, 17);
            this.chkAfectaCosto.TabIndex = 28;
            this.chkAfectaCosto.Text = "Promedio Ponderado";
            this.chkAfectaCosto.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.Red;
            this.txtApellido.Location = new System.Drawing.Point(111, 177);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(293, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Red;
            this.txtNombre.Location = new System.Drawing.Point(111, 156);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(293, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Apellido(s):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Nombre(s):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "Notas";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Enabled = false;
            this.txtConcepto.Location = new System.Drawing.Point(65, 293);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(687, 35);
            this.txtConcepto.TabIndex = 8;
            // 
            // grdDetalle
            // 
            this.grdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboCodigo,
            this.cmdBuscarItem,
            this.Des_Pro,
            this.Cantidad,
            this.Costo,
            this.Lote,
            this.Fec_Ven,
            this.Fec_fab});
            this.grdDetalle.ContextMenuStrip = this.mnuColgante;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDetalle.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdDetalle.Enabled = false;
            this.grdDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdDetalle.Location = new System.Drawing.Point(9, 329);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.Size = new System.Drawing.Size(745, 224);
            this.grdDetalle.TabIndex = 9;
            this.grdDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDetalle_CellEndEdit);
            this.grdDetalle.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDetalle_CellLeave);
            this.grdDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdDetalle_CellValidating);
            this.grdDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdDetalle_DataError);
            this.grdDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdDetalle_EditingControlShowing);
            // 
            // cboCodigo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cboCodigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.cboCodigo.HeaderText = "Codigo";
            this.cboCodigo.Name = "cboCodigo";
            this.cboCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cboCodigo.Width = 75;
            // 
            // cmdBuscarItem
            // 
            this.cmdBuscarItem.DisabledImage = ((System.Drawing.Image)(resources.GetObject("cmdBuscarItem.DisabledImage")));
            this.cmdBuscarItem.HeaderText = "";
            this.cmdBuscarItem.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscarItem.Image")));
            this.cmdBuscarItem.Name = "cmdBuscarItem";
            this.cmdBuscarItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmdBuscarItem.Text = null;
            this.cmdBuscarItem.ToolTipText = "Busqueda avanzada de Articulos";
            this.cmdBuscarItem.Width = 20;
            this.cmdBuscarItem.Click += new System.EventHandler<System.EventArgs>(this.cmdBuscarItem_Click);
            // 
            // Des_Pro
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = null;
            this.Des_Pro.DefaultCellStyle = dataGridViewCellStyle2;
            this.Des_Pro.HeaderText = "Descripción";
            this.Des_Pro.Name = "Des_Pro";
            this.Des_Pro.ReadOnly = true;
            this.Des_Pro.Width = 200;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 75;
            // 
            // Costo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.Width = 75;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.Width = 75;
            // 
            // Fec_Ven
            // 
            this.Fec_Ven.ContextMenuStrip = this.mnuColgante;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Fec_Ven.DefaultCellStyle = dataGridViewCellStyle5;
            this.Fec_Ven.HeaderText = "Fec Vencimiento";
            this.Fec_Ven.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.Fec_Ven.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Fec_Ven.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Fec_Ven.MonthCalendar.BackgroundStyle.Class = "";
            this.Fec_Ven.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.Fec_Ven.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.Fec_Ven.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Fec_Ven.MonthCalendar.DisplayMonth = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.Fec_Ven.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.Fec_Ven.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.Fec_Ven.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Fec_Ven.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.Fec_Ven.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Fec_Ven.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.Fec_Ven.Name = "Fec_Ven";
            this.Fec_Ven.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fec_Ven.Width = 90;
            // 
            // mnuColgante
            // 
            this.mnuColgante.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcInsertar,
            this.opcModfificar,
            this.opcEliminar,
            this.opcGrabar,
            this.opcImprimir,
            this.toolStripSeparator1,
            this.opcCopiar,
            this.opcPegar,
            this.opcCortar,
            this.opcSelectAll});
            this.mnuColgante.Name = "mnuColgante";
            this.mnuColgante.Size = new System.Drawing.Size(160, 208);
            // 
            // opcInsertar
            // 
            this.opcInsertar.Image = ((System.Drawing.Image)(resources.GetObject("opcInsertar.Image")));
            this.opcInsertar.Name = "opcInsertar";
            this.opcInsertar.Size = new System.Drawing.Size(159, 22);
            this.opcInsertar.Text = "&Insertar";
            // 
            // opcModfificar
            // 
            this.opcModfificar.Image = ((System.Drawing.Image)(resources.GetObject("opcModfificar.Image")));
            this.opcModfificar.Name = "opcModfificar";
            this.opcModfificar.Size = new System.Drawing.Size(159, 22);
            this.opcModfificar.Text = "&Modifcar";
            // 
            // opcEliminar
            // 
            this.opcEliminar.Image = ((System.Drawing.Image)(resources.GetObject("opcEliminar.Image")));
            this.opcEliminar.Name = "opcEliminar";
            this.opcEliminar.Size = new System.Drawing.Size(159, 22);
            this.opcEliminar.Text = "&Eliminar";
            this.opcEliminar.Click += new System.EventHandler(this.opcEliminar_Click);
            // 
            // opcGrabar
            // 
            this.opcGrabar.Image = ((System.Drawing.Image)(resources.GetObject("opcGrabar.Image")));
            this.opcGrabar.Name = "opcGrabar";
            this.opcGrabar.Size = new System.Drawing.Size(159, 22);
            this.opcGrabar.Text = "&Grabar";
            // 
            // opcImprimir
            // 
            this.opcImprimir.Image = ((System.Drawing.Image)(resources.GetObject("opcImprimir.Image")));
            this.opcImprimir.Name = "opcImprimir";
            this.opcImprimir.Size = new System.Drawing.Size(159, 22);
            this.opcImprimir.Text = "Im&primir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // opcCopiar
            // 
            this.opcCopiar.Image = ((System.Drawing.Image)(resources.GetObject("opcCopiar.Image")));
            this.opcCopiar.Name = "opcCopiar";
            this.opcCopiar.Size = new System.Drawing.Size(159, 22);
            this.opcCopiar.Text = "&Copiar";
            // 
            // opcPegar
            // 
            this.opcPegar.Image = ((System.Drawing.Image)(resources.GetObject("opcPegar.Image")));
            this.opcPegar.Name = "opcPegar";
            this.opcPegar.Size = new System.Drawing.Size(159, 22);
            this.opcPegar.Text = "Peg&ar";
            // 
            // opcCortar
            // 
            this.opcCortar.Image = ((System.Drawing.Image)(resources.GetObject("opcCortar.Image")));
            this.opcCortar.Name = "opcCortar";
            this.opcCortar.Size = new System.Drawing.Size(159, 22);
            this.opcCortar.Text = "Cor&tar";
            // 
            // opcSelectAll
            // 
            this.opcSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("opcSelectAll.Image")));
            this.opcSelectAll.Name = "opcSelectAll";
            this.opcSelectAll.Size = new System.Drawing.Size(159, 22);
            this.opcSelectAll.Text = "&Selecionar Todo";
            // 
            // Fec_fab
            // 
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.Fec_fab.DefaultCellStyle = dataGridViewCellStyle6;
            this.Fec_fab.HeaderText = "Fec Fabricación";
            this.Fec_fab.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.Fec_fab.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Fec_fab.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Fec_fab.MonthCalendar.BackgroundStyle.Class = "";
            this.Fec_fab.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.Fec_fab.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.Fec_fab.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Fec_fab.MonthCalendar.DisplayMonth = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.Fec_fab.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.Fec_fab.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.Fec_fab.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Fec_fab.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.Fec_fab.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Fec_fab.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.Fec_fab.Name = "Fec_fab";
            this.Fec_fab.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fec_fab.Width = 90;
            // 
            // cmbRangoPaciente
            // 
            this.cmbRangoPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRangoPaciente.Enabled = false;
            this.cmbRangoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRangoPaciente.ForeColor = System.Drawing.Color.Red;
            this.cmbRangoPaciente.FormattingEnabled = true;
            this.cmbRangoPaciente.Location = new System.Drawing.Point(111, 134);
            this.cmbRangoPaciente.Name = "cmbRangoPaciente";
            this.cmbRangoPaciente.Size = new System.Drawing.Size(251, 21);
            this.cmbRangoPaciente.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(50, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "Rango:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(642, 555);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(110, 20);
            this.txtImporte.TabIndex = 37;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(786, 522);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 45);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dataGridViewButtonXColumn1
            // 
            this.dataGridViewButtonXColumn1.DisabledImage = ((System.Drawing.Image)(resources.GetObject("dataGridViewButtonXColumn1.DisabledImage")));
            this.dataGridViewButtonXColumn1.HeaderText = "";
            this.dataGridViewButtonXColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewButtonXColumn1.Image")));
            this.dataGridViewButtonXColumn1.Name = "dataGridViewButtonXColumn1";
            this.dataGridViewButtonXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonXColumn1.Text = null;
            this.dataGridViewButtonXColumn1.ToolTipText = "Busqueda avanzada de Articulos";
            this.dataGridViewButtonXColumn1.Width = 20;
            // 
            // imgFoto
            // 
            this.imgFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgFoto.Enabled = false;
            this.imgFoto.Image = ((System.Drawing.Image)(resources.GetObject("imgFoto.Image")));
            this.imgFoto.Location = new System.Drawing.Point(633, 2);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(268, 253);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 33;
            this.imgFoto.TabStop = false;
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEmpleado.Image")));
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(224, 105);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(60, 30);
            this.btnBuscarEmpleado.TabIndex = 25;
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(786, 391);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(104, 45);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Reimprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(786, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 45);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(786, 434);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(104, 45);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "   Anular";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = ((System.Drawing.Image)(resources.GetObject("btnListar.Image")));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(786, 348);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(104, 45);
            this.btnListar.TabIndex = 2;
            this.btnListar.Text = "Listado";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(786, 308);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(104, 45);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(786, 265);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(104, 45);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "  Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cmbRangoMedico
            // 
            this.cmbRangoMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRangoMedico.Enabled = false;
            this.cmbRangoMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRangoMedico.ForeColor = System.Drawing.Color.Red;
            this.cmbRangoMedico.FormattingEnabled = true;
            this.cmbRangoMedico.Location = new System.Drawing.Point(111, 229);
            this.cmbRangoMedico.Name = "cmbRangoMedico";
            this.cmbRangoMedico.Size = new System.Drawing.Size(251, 21);
            this.cmbRangoMedico.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(50, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "Rango:";
            // 
            // txtApellidoMedico
            // 
            this.txtApellidoMedico.Enabled = false;
            this.txtApellidoMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoMedico.ForeColor = System.Drawing.Color.Red;
            this.txtApellidoMedico.Location = new System.Drawing.Point(111, 271);
            this.txtApellidoMedico.Name = "txtApellidoMedico";
            this.txtApellidoMedico.ReadOnly = true;
            this.txtApellidoMedico.Size = new System.Drawing.Size(293, 20);
            this.txtApellidoMedico.TabIndex = 40;
            // 
            // txtNombreMedico
            // 
            this.txtNombreMedico.Enabled = false;
            this.txtNombreMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreMedico.ForeColor = System.Drawing.Color.Red;
            this.txtNombreMedico.Location = new System.Drawing.Point(111, 250);
            this.txtNombreMedico.Name = "txtNombreMedico";
            this.txtNombreMedico.ReadOnly = true;
            this.txtNombreMedico.Size = new System.Drawing.Size(293, 20);
            this.txtNombreMedico.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 44;
            this.label13.Text = "Apellido(s):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 252);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 16);
            this.label14.TabIndex = 43;
            this.label14.Text = "Nombre(s):";
            // 
            // btnBuscarMedico
            // 
            this.btnBuscarMedico.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarMedico.Image")));
            this.btnBuscarMedico.Location = new System.Drawing.Point(224, 200);
            this.btnBuscarMedico.Name = "btnBuscarMedico";
            this.btnBuscarMedico.Size = new System.Drawing.Size(60, 30);
            this.btnBuscarMedico.TabIndex = 42;
            this.btnBuscarMedico.UseVisualStyleBackColor = true;
            this.btnBuscarMedico.Click += new System.EventHandler(this.btnBuscarMedico_Click);
            // 
            // txtCedulaMedico
            // 
            this.txtCedulaMedico.Enabled = false;
            this.txtCedulaMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedulaMedico.Location = new System.Drawing.Point(111, 205);
            this.txtCedulaMedico.Mask = "###-#######-#";
            this.txtCedulaMedico.Name = "txtCedulaMedico";
            this.txtCedulaMedico.Size = new System.Drawing.Size(116, 22);
            this.txtCedulaMedico.TabIndex = 38;
            this.txtCedulaMedico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedulaMedico_KeyPress);
            this.txtCedulaMedico.Validating += new System.ComponentModel.CancelEventHandler(this.txtCedulaMedico_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Medico Autoriza:";
            // 
            // frmMovInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(904, 579);
            this.Controls.Add(this.cmbRangoMedico);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtApellidoMedico);
            this.Controls.Add(this.txtNombreMedico);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnBuscarMedico);
            this.Controls.Add(this.txtCedulaMedico);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cmbRangoPaciente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grdDetalle);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.imgFoto);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkAfectaCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpFechaDigitada);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSecuencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cboAlmacen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboT_mov);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEntradaSalida);
            this.Controls.Add(this.grboxBotones);
            this.Name = "frmMovInventario";
            this.Text = "Movimientos de Inventario";
            this.Load += new System.EventHandler(this.frmMovInventario_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.grboxBotones, 0);
            this.Controls.SetChildIndex(this.cboEntradaSalida, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboT_mov, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboAlmacen, 0);
            this.Controls.SetChildIndex(this.lblAlmacen, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtSecuencia, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtReferencia, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCedula, 0);
            this.Controls.SetChildIndex(this.btnBuscarEmpleado, 0);
            this.Controls.SetChildIndex(this.dtpFechaDigitada, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.chkAfectaCosto, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.txtApellido, 0);
            this.Controls.SetChildIndex(this.imgFoto, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.txtConcepto, 0);
            this.Controls.SetChildIndex(this.btnListar, 0);
            this.Controls.SetChildIndex(this.grdDetalle, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cmbRangoPaciente, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.txtImporte, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtCedulaMedico, 0);
            this.Controls.SetChildIndex(this.btnBuscarMedico, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtNombreMedico, 0);
            this.Controls.SetChildIndex(this.txtApellidoMedico, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.cmbRangoMedico, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).EndInit();
            this.mnuColgante.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.GroupBox grboxBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ComboBox cboEntradaSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboT_mov;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtSecuencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaDigitada;
        private System.Windows.Forms.CheckBox chkAfectaCosto;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox imgFoto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtConcepto;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdDetalle;
        private System.Windows.Forms.ComboBox cmbRangoPaciente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ContextMenuStrip mnuColgante;
        private System.Windows.Forms.ToolStripMenuItem opcInsertar;
        private System.Windows.Forms.ToolStripMenuItem opcModfificar;
        private System.Windows.Forms.ToolStripMenuItem opcEliminar;
        private System.Windows.Forms.ToolStripMenuItem opcGrabar;
        private System.Windows.Forms.ToolStripMenuItem opcImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem opcCopiar;
        private System.Windows.Forms.ToolStripMenuItem opcPegar;
        private System.Windows.Forms.ToolStripMenuItem opcCortar;
        private System.Windows.Forms.ToolStripMenuItem opcSelectAll;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboCodigo;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn cmdBuscarItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Des_Pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Fec_Ven;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Fec_fab;
        private System.Windows.Forms.TextBox txtImporte;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dataGridViewButtonXColumn1;
        private System.Windows.Forms.ComboBox cmbRangoMedico;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtApellidoMedico;
        private System.Windows.Forms.TextBox txtNombreMedico;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnBuscarMedico;
        private System.Windows.Forms.MaskedTextBox txtCedulaMedico;
        private System.Windows.Forms.Label label15;
    }
}