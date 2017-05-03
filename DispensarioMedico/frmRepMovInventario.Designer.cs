namespace DispensarioMedico
{
    partial class frmRepMovInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepMovInventario));
            this.label7 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbRangoPaciente = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkMiembros = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.cboT_mov = new System.Windows.Forms.ComboBox();
            this.chkT_Mov = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkEntradaSalida = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEntradaSalida = new System.Windows.Forms.ComboBox();
            this.chkArticulos = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboArticulos = new System.Windows.Forms.ComboBox();
            this.cmdBuscarArticulos = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(290, 22);
            this.lblTituloForm.Text = "Reporte Movimientos de Inventario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(71, 74);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(215, 20);
            this.dtpHasta.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(71, 53);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(215, 20);
            this.dtpDesde.TabIndex = 28;
            // 
            // cmbRangoPaciente
            // 
            this.cmbRangoPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRangoPaciente.Enabled = false;
            this.cmbRangoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRangoPaciente.ForeColor = System.Drawing.Color.Red;
            this.cmbRangoPaciente.FormattingEnabled = true;
            this.cmbRangoPaciente.Location = new System.Drawing.Point(108, 172);
            this.cmbRangoPaciente.Name = "cmbRangoPaciente";
            this.cmbRangoPaciente.Size = new System.Drawing.Size(251, 21);
            this.cmbRangoPaciente.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(44, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "Rango:";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.Red;
            this.txtApellido.Location = new System.Drawing.Point(108, 214);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(293, 20);
            this.txtApellido.TabIndex = 39;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Red;
            this.txtNombre.Location = new System.Drawing.Point(108, 193);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(293, 20);
            this.txtNombre.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "Apellido(s):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Nombre(s):";
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEmpleado.Image")));
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(220, 143);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(60, 30);
            this.btnBuscarEmpleado.TabIndex = 41;
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(108, 145);
            this.txtCedula.Mask = "###-#######-#";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(116, 22);
            this.txtCedula.TabIndex = 37;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            this.txtCedula.Validating += new System.ComponentModel.CancelEventHandler(this.txtCedula_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Cédula";
            // 
            // chkMiembros
            // 
            // 
            // 
            // 
            this.chkMiembros.BackgroundStyle.Class = "";
            this.chkMiembros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkMiembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMiembros.Location = new System.Drawing.Point(92, 117);
            this.chkMiembros.Name = "chkMiembros";
            this.chkMiembros.Size = new System.Drawing.Size(170, 23);
            this.chkMiembros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkMiembros.TabIndex = 46;
            this.chkMiembros.Text = "Todos los Miembros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Tipo Movimientos";
            // 
            // cboT_mov
            // 
            this.cboT_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboT_mov.FormattingEnabled = true;
            this.cboT_mov.Location = new System.Drawing.Point(122, 347);
            this.cboT_mov.Name = "cboT_mov";
            this.cboT_mov.Size = new System.Drawing.Size(251, 21);
            this.cboT_mov.TabIndex = 47;
            // 
            // chkT_Mov
            // 
            // 
            // 
            // 
            this.chkT_Mov.BackgroundStyle.Class = "";
            this.chkT_Mov.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkT_Mov.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkT_Mov.Location = new System.Drawing.Point(18, 323);
            this.chkT_Mov.Name = "chkT_Mov";
            this.chkT_Mov.Size = new System.Drawing.Size(243, 23);
            this.chkT_Mov.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkT_Mov.TabIndex = 49;
            this.chkT_Mov.Text = "Todos los Tipos de Movimientos";
            // 
            // chkEntradaSalida
            // 
            // 
            // 
            // 
            this.chkEntradaSalida.BackgroundStyle.Class = "";
            this.chkEntradaSalida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEntradaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEntradaSalida.Location = new System.Drawing.Point(18, 392);
            this.chkEntradaSalida.Name = "chkEntradaSalida";
            this.chkEntradaSalida.Size = new System.Drawing.Size(219, 23);
            this.chkEntradaSalida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEntradaSalida.TabIndex = 52;
            this.chkEntradaSalida.Text = "Todos los Tipos Transacciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tipo Transaccion";
            // 
            // cboEntradaSalida
            // 
            this.cboEntradaSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntradaSalida.FormattingEnabled = true;
            this.cboEntradaSalida.Items.AddRange(new object[] {
            "Entradas",
            "Salidas"});
            this.cboEntradaSalida.Location = new System.Drawing.Point(125, 414);
            this.cboEntradaSalida.Name = "cboEntradaSalida";
            this.cboEntradaSalida.Size = new System.Drawing.Size(121, 21);
            this.cboEntradaSalida.TabIndex = 50;
            // 
            // chkArticulos
            // 
            // 
            // 
            // 
            this.chkArticulos.BackgroundStyle.Class = "";
            this.chkArticulos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkArticulos.Location = new System.Drawing.Point(18, 269);
            this.chkArticulos.Name = "chkArticulos";
            this.chkArticulos.Size = new System.Drawing.Size(150, 23);
            this.chkArticulos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkArticulos.TabIndex = 53;
            this.chkArticulos.Text = "Todos los Articulos";
            // 
            // cboArticulos
            // 
            this.cboArticulos.FormattingEnabled = true;
            this.cboArticulos.Location = new System.Drawing.Point(18, 296);
            this.cboArticulos.Name = "cboArticulos";
            this.cboArticulos.Size = new System.Drawing.Size(267, 21);
            this.cboArticulos.TabIndex = 54;
            // 
            // cmdBuscarArticulos
            // 
            this.cmdBuscarArticulos.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscarArticulos.Image")));
            this.cmdBuscarArticulos.Location = new System.Drawing.Point(279, 290);
            this.cmdBuscarArticulos.Name = "cmdBuscarArticulos";
            this.cmdBuscarArticulos.Size = new System.Drawing.Size(60, 30);
            this.cmdBuscarArticulos.TabIndex = 55;
            this.cmdBuscarArticulos.UseVisualStyleBackColor = true;
            this.cmdBuscarArticulos.Click += new System.EventHandler(this.cmdBuscarArticulos_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(483, 305);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(120, 62);
            this.cmdImprimir.TabIndex = 95;
            this.cmdImprimir.Text = "  &Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(482, 367);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(123, 62);
            this.cmdSalir.TabIndex = 94;
            this.cmdSalir.Text = "&Salida";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // frmRepMovInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdSalir;
            this.ClientSize = new System.Drawing.Size(643, 442);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdBuscarArticulos);
            this.Controls.Add(this.cboArticulos);
            this.Controls.Add(this.chkArticulos);
            this.Controls.Add(this.chkEntradaSalida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEntradaSalida);
            this.Controls.Add(this.chkT_Mov);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboT_mov);
            this.Controls.Add(this.chkMiembros);
            this.Controls.Add(this.cmbRangoPaciente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDesde);
            this.Name = "frmRepMovInventario";
            this.Text = "Reporte Movimientos de Inventario";
            this.Load += new System.EventHandler(this.frmRepMovInventario_Load);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpHasta, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCedula, 0);
            this.Controls.SetChildIndex(this.btnBuscarEmpleado, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.txtApellido, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cmbRangoPaciente, 0);
            this.Controls.SetChildIndex(this.chkMiembros, 0);
            this.Controls.SetChildIndex(this.cboT_mov, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.chkT_Mov, 0);
            this.Controls.SetChildIndex(this.cboEntradaSalida, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkEntradaSalida, 0);
            this.Controls.SetChildIndex(this.chkArticulos, 0);
            this.Controls.SetChildIndex(this.cboArticulos, 0);
            this.Controls.SetChildIndex(this.cmdBuscarArticulos, 0);
            this.Controls.SetChildIndex(this.cmdSalir, 0);
            this.Controls.SetChildIndex(this.cmdImprimir, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ComboBox cmbRangoPaciente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkMiembros;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEntradaSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboT_mov;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkT_Mov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEntradaSalida;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkArticulos;
        private System.Windows.Forms.ComboBox cboArticulos;
        private System.Windows.Forms.Button cmdBuscarArticulos;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdSalir;
    }
}