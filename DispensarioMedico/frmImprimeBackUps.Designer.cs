namespace DispensarioMedico
{
    partial class frmImprimeBackUps
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbSeleccionar = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.grbSelPor = new System.Windows.Forms.GroupBox();
            this.grbFechas = new System.Windows.Forms.GroupBox();
            this.lblDesFecha = new System.Windows.Forms.Label();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lblHasFecha = new System.Windows.Forms.Label();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.grbUsuario = new System.Windows.Forms.GroupBox();
            this.lblSelUsua = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.rdbUsuaFecha = new System.Windows.Forms.RadioButton();
            this.rdbUsuario = new System.Windows.Forms.RadioButton();
            this.rdbFecha = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grbSelPor.SuspendLayout();
            this.grbFechas.SuspendLayout();
            this.grbUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(143, 22);
            this.lblTituloForm.Text = "Imprimir BackUp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdCancelar);
            this.groupBox1.Controls.Add(this.cmdAceptar);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.grbSelPor);
            this.groupBox1.Location = new System.Drawing.Point(13, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 206);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(298, 167);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 21;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(217, 167);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 20;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbSeleccionar);
            this.groupBox3.Controls.Add(this.rdbTodo);
            this.groupBox3.Location = new System.Drawing.Point(12, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 67);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Imprimir";
            // 
            // rdbSeleccionar
            // 
            this.rdbSeleccionar.AutoSize = true;
            this.rdbSeleccionar.Location = new System.Drawing.Point(6, 42);
            this.rdbSeleccionar.Name = "rdbSeleccionar";
            this.rdbSeleccionar.Size = new System.Drawing.Size(81, 17);
            this.rdbSeleccionar.TabIndex = 6;
            this.rdbSeleccionar.TabStop = true;
            this.rdbSeleccionar.Text = "Seleccionar";
            this.rdbSeleccionar.UseVisualStyleBackColor = true;
            this.rdbSeleccionar.CheckedChanged += new System.EventHandler(this.rdbSeleccionar_CheckedChanged);
            // 
            // rdbTodo
            // 
            this.rdbTodo.AutoSize = true;
            this.rdbTodo.Location = new System.Drawing.Point(6, 19);
            this.rdbTodo.Name = "rdbTodo";
            this.rdbTodo.Size = new System.Drawing.Size(50, 17);
            this.rdbTodo.TabIndex = 5;
            this.rdbTodo.TabStop = true;
            this.rdbTodo.Text = "Todo";
            this.rdbTodo.UseVisualStyleBackColor = true;
            this.rdbTodo.CheckedChanged += new System.EventHandler(this.rdbTodo_CheckedChanged);
            // 
            // grbSelPor
            // 
            this.grbSelPor.Controls.Add(this.grbFechas);
            this.grbSelPor.Controls.Add(this.grbUsuario);
            this.grbSelPor.Controls.Add(this.rdbUsuaFecha);
            this.grbSelPor.Controls.Add(this.rdbUsuario);
            this.grbSelPor.Controls.Add(this.rdbFecha);
            this.grbSelPor.Location = new System.Drawing.Point(136, 17);
            this.grbSelPor.Name = "grbSelPor";
            this.grbSelPor.Size = new System.Drawing.Size(318, 144);
            this.grbSelPor.TabIndex = 18;
            this.grbSelPor.TabStop = false;
            this.grbSelPor.Text = "Seleccionar Por";
            // 
            // grbFechas
            // 
            this.grbFechas.Controls.Add(this.lblDesFecha);
            this.grbFechas.Controls.Add(this.dtFechaInicial);
            this.grbFechas.Controls.Add(this.lblHasFecha);
            this.grbFechas.Controls.Add(this.dtFechaFinal);
            this.grbFechas.Location = new System.Drawing.Point(8, 70);
            this.grbFechas.Name = "grbFechas";
            this.grbFechas.Size = new System.Drawing.Size(300, 62);
            this.grbFechas.TabIndex = 6;
            this.grbFechas.TabStop = false;
            // 
            // lblDesFecha
            // 
            this.lblDesFecha.AutoSize = true;
            this.lblDesFecha.Location = new System.Drawing.Point(12, 20);
            this.lblDesFecha.Name = "lblDesFecha";
            this.lblDesFecha.Size = new System.Drawing.Size(71, 13);
            this.lblDesFecha.TabIndex = 7;
            this.lblDesFecha.Text = "Desde Fecha";
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Location = new System.Drawing.Point(90, 14);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.dtFechaInicial.TabIndex = 2;
            // 
            // lblHasFecha
            // 
            this.lblHasFecha.AutoSize = true;
            this.lblHasFecha.Location = new System.Drawing.Point(15, 40);
            this.lblHasFecha.Name = "lblHasFecha";
            this.lblHasFecha.Size = new System.Drawing.Size(68, 13);
            this.lblHasFecha.TabIndex = 8;
            this.lblHasFecha.Text = "Hasta Fecha";
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Location = new System.Drawing.Point(90, 34);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dtFechaFinal.TabIndex = 6;
            // 
            // grbUsuario
            // 
            this.grbUsuario.Controls.Add(this.lblSelUsua);
            this.grbUsuario.Controls.Add(this.cboUsuario);
            this.grbUsuario.Location = new System.Drawing.Point(8, 30);
            this.grbUsuario.Name = "grbUsuario";
            this.grbUsuario.Size = new System.Drawing.Size(300, 40);
            this.grbUsuario.TabIndex = 7;
            this.grbUsuario.TabStop = false;
            // 
            // lblSelUsua
            // 
            this.lblSelUsua.AutoSize = true;
            this.lblSelUsua.Location = new System.Drawing.Point(15, 8);
            this.lblSelUsua.Name = "lblSelUsua";
            this.lblSelUsua.Size = new System.Drawing.Size(60, 26);
            this.lblSelUsua.TabIndex = 1;
            this.lblSelUsua.Text = "Seleccione\r\n Usurio";
            // 
            // cboUsuario
            // 
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(90, 13);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(200, 21);
            this.cboUsuario.TabIndex = 3;
            // 
            // rdbUsuaFecha
            // 
            this.rdbUsuaFecha.AutoSize = true;
            this.rdbUsuaFecha.Location = new System.Drawing.Point(190, 14);
            this.rdbUsuaFecha.Name = "rdbUsuaFecha";
            this.rdbUsuaFecha.Size = new System.Drawing.Size(102, 17);
            this.rdbUsuaFecha.TabIndex = 9;
            this.rdbUsuaFecha.TabStop = true;
            this.rdbUsuaFecha.Text = "Usuario y Fecha";
            this.rdbUsuaFecha.UseVisualStyleBackColor = true;
            this.rdbUsuaFecha.CheckedChanged += new System.EventHandler(this.rdbUsuaFecha_CheckedChanged);
            // 
            // rdbUsuario
            // 
            this.rdbUsuario.AutoSize = true;
            this.rdbUsuario.Location = new System.Drawing.Point(26, 14);
            this.rdbUsuario.Name = "rdbUsuario";
            this.rdbUsuario.Size = new System.Drawing.Size(61, 17);
            this.rdbUsuario.TabIndex = 5;
            this.rdbUsuario.TabStop = true;
            this.rdbUsuario.Text = "Usuario";
            this.rdbUsuario.UseVisualStyleBackColor = true;
            this.rdbUsuario.CheckedChanged += new System.EventHandler(this.rdbUsuario_CheckedChanged);
            // 
            // rdbFecha
            // 
            this.rdbFecha.AutoSize = true;
            this.rdbFecha.Location = new System.Drawing.Point(101, 14);
            this.rdbFecha.Name = "rdbFecha";
            this.rdbFecha.Size = new System.Drawing.Size(55, 17);
            this.rdbFecha.TabIndex = 4;
            this.rdbFecha.TabStop = true;
            this.rdbFecha.Text = "Fecha";
            this.rdbFecha.UseVisualStyleBackColor = true;
            this.rdbFecha.CheckedChanged += new System.EventHandler(this.rdbFecha_CheckedChanged);
            // 
            // frmImprimeBackUps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(485, 254);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImprimeBackUps";
            this.Text = "frmImprimeBackUps";
            this.Load += new System.EventHandler(this.frmImprimeBackUps_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbSelPor.ResumeLayout(false);
            this.grbSelPor.PerformLayout();
            this.grbFechas.ResumeLayout(false);
            this.grbFechas.PerformLayout();
            this.grbUsuario.ResumeLayout(false);
            this.grbUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbSeleccionar;
        private System.Windows.Forms.RadioButton rdbTodo;
        private System.Windows.Forms.GroupBox grbSelPor;
        private System.Windows.Forms.GroupBox grbFechas;
        private System.Windows.Forms.Label lblDesFecha;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.Label lblHasFecha;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.GroupBox grbUsuario;
        private System.Windows.Forms.Label lblSelUsua;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.RadioButton rdbUsuaFecha;
        private System.Windows.Forms.RadioButton rdbUsuario;
        private System.Windows.Forms.RadioButton rdbFecha;
    }
}