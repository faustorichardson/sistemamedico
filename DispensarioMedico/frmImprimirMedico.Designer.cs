namespace DispensarioMedico
{
    partial class frmImprimirMedico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImprimirMedico));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbSeleccionarpor = new System.Windows.Forms.GroupBox();
            this.cmbRango = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkF = new System.Windows.Forms.CheckBox();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.chkEspecialidad = new System.Windows.Forms.CheckBox();
            this.chkRango = new System.Windows.Forms.CheckBox();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSeleccionar = new System.Windows.Forms.RadioButton();
            this.rdoTodos = new System.Windows.Forms.RadioButton();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grbSeleccionarpor.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(280, 22);
            this.lblTituloForm.Text = "Generar Reportes Datos Medicos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbSeleccionarpor);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // grbSeleccionarpor
            // 
            this.grbSeleccionarpor.Controls.Add(this.cmbRango);
            this.grbSeleccionarpor.Controls.Add(this.groupBox4);
            this.grbSeleccionarpor.Controls.Add(this.chkEspecialidad);
            this.grbSeleccionarpor.Controls.Add(this.chkRango);
            this.grbSeleccionarpor.Controls.Add(this.cmbEspecialidad);
            this.grbSeleccionarpor.Controls.Add(this.label2);
            this.grbSeleccionarpor.Controls.Add(this.label8);
            this.grbSeleccionarpor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSeleccionarpor.Location = new System.Drawing.Point(48, 55);
            this.grbSeleccionarpor.Name = "grbSeleccionarpor";
            this.grbSeleccionarpor.Size = new System.Drawing.Size(391, 116);
            this.grbSeleccionarpor.TabIndex = 30;
            this.grbSeleccionarpor.TabStop = false;
            this.grbSeleccionarpor.Text = "Seleccionar Por";
            this.grbSeleccionarpor.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cmbRango
            // 
            this.cmbRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRango.FormattingEnabled = true;
            this.cmbRango.Location = new System.Drawing.Point(95, 55);
            this.cmbRango.Name = "cmbRango";
            this.cmbRango.Size = new System.Drawing.Size(193, 21);
            this.cmbRango.TabIndex = 22;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkF);
            this.groupBox4.Controls.Add(this.chkM);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(238, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(87, 34);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sexo";
            // 
            // chkF
            // 
            this.chkF.AutoSize = true;
            this.chkF.Location = new System.Drawing.Point(48, 13);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(33, 17);
            this.chkF.TabIndex = 38;
            this.chkF.Text = "F";
            this.chkF.UseVisualStyleBackColor = true;
            // 
            // chkM
            // 
            this.chkM.AutoSize = true;
            this.chkM.Location = new System.Drawing.Point(6, 12);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(36, 17);
            this.chkM.TabIndex = 37;
            this.chkM.Text = "M";
            this.chkM.UseVisualStyleBackColor = true;
            // 
            // chkEspecialidad
            // 
            this.chkEspecialidad.AutoSize = true;
            this.chkEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEspecialidad.Location = new System.Drawing.Point(140, 20);
            this.chkEspecialidad.Name = "chkEspecialidad";
            this.chkEspecialidad.Size = new System.Drawing.Size(98, 17);
            this.chkEspecialidad.TabIndex = 33;
            this.chkEspecialidad.Text = "Especialidad";
            this.chkEspecialidad.UseVisualStyleBackColor = true;
            this.chkEspecialidad.CheckedChanged += new System.EventHandler(this.chkEspecialidad_CheckedChanged);
            // 
            // chkRango
            // 
            this.chkRango.AutoSize = true;
            this.chkRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRango.Location = new System.Drawing.Point(71, 20);
            this.chkRango.Name = "chkRango";
            this.chkRango.Size = new System.Drawing.Size(63, 17);
            this.chkRango.TabIndex = 32;
            this.chkRango.Text = "Rango";
            this.chkRango.UseVisualStyleBackColor = true;
            this.chkRango.CheckedChanged += new System.EventHandler(this.chkRango_CheckedChanged);
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(95, 83);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(238, 21);
            this.cmbEspecialidad.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rango:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Especialidad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSeleccionar);
            this.groupBox2.Controls.Add(this.rdoTodos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(127, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 40);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imprimir";
            // 
            // rdoSeleccionar
            // 
            this.rdoSeleccionar.AutoSize = true;
            this.rdoSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSeleccionar.Location = new System.Drawing.Point(111, 17);
            this.rdoSeleccionar.Name = "rdoSeleccionar";
            this.rdoSeleccionar.Size = new System.Drawing.Size(92, 17);
            this.rdoSeleccionar.TabIndex = 1;
            this.rdoSeleccionar.TabStop = true;
            this.rdoSeleccionar.Text = "Seleccionar";
            this.rdoSeleccionar.UseVisualStyleBackColor = true;
            this.rdoSeleccionar.CheckedChanged += new System.EventHandler(this.rdoSeleccionar_CheckedChanged);
            // 
            // rdoTodos
            // 
            this.rdoTodos.AutoSize = true;
            this.rdoTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTodos.Location = new System.Drawing.Point(29, 15);
            this.rdoTodos.Name = "rdoTodos";
            this.rdoTodos.Size = new System.Drawing.Size(71, 20);
            this.rdoTodos.TabIndex = 0;
            this.rdoTodos.TabStop = true;
            this.rdoTodos.Text = "Todos";
            this.rdoTodos.UseVisualStyleBackColor = true;
            this.rdoTodos.CheckedChanged += new System.EventHandler(this.rdoTodos_CheckedChanged);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(136, 262);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(95, 45);
            this.cmdImprimir.TabIndex = 3;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(262, 262);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(95, 45);
            this.cmdCancelar.TabIndex = 4;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // frmImprimirMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(503, 325);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImprimirMedico";
            this.Text = "frmImprimirMedico";
            this.Load += new System.EventHandler(this.frmImprimirMedico_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.cmdImprimir, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            this.groupBox1.ResumeLayout(false);
            this.grbSeleccionarpor.ResumeLayout(false);
            this.grbSeleccionarpor.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRango;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSeleccionar;
        private System.Windows.Forms.RadioButton rdoTodos;
        private System.Windows.Forms.GroupBox grbSeleccionarpor;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkEspecialidad;
        private System.Windows.Forms.CheckBox chkRango;
        private System.Windows.Forms.CheckBox chkM;
        private System.Windows.Forms.CheckBox chkF;
    }
}