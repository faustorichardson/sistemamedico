namespace DispensarioMedico
{
    partial class frmRepArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepArticulos));
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdBuscarArticulos = new System.Windows.Forms.Button();
            this.cboArticulos = new System.Windows.Forms.ComboBox();
            this.chkArticulos = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSubfamilia = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkFamilia = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboSubCategoria = new System.Windows.Forms.ComboBox();
            this.cboFamilia = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkInventario = new System.Windows.Forms.CheckBox();
            this.chkExistencia = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(260, 22);
            this.lblTituloForm.Text = "Listado de Articulos y Servicios";
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(329, 258);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(120, 62);
            this.cmdImprimir.TabIndex = 106;
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
            this.cmdSalir.Location = new System.Drawing.Point(447, 258);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(123, 62);
            this.cmdSalir.TabIndex = 105;
            this.cmdSalir.Text = "&Salida";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdBuscarArticulos
            // 
            this.cmdBuscarArticulos.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscarArticulos.Image")));
            this.cmdBuscarArticulos.Location = new System.Drawing.Point(457, 62);
            this.cmdBuscarArticulos.Name = "cmdBuscarArticulos";
            this.cmdBuscarArticulos.Size = new System.Drawing.Size(60, 30);
            this.cmdBuscarArticulos.TabIndex = 104;
            this.cmdBuscarArticulos.UseVisualStyleBackColor = true;
            this.cmdBuscarArticulos.Click += new System.EventHandler(this.cmdBuscarArticulos_Click);
            // 
            // cboArticulos
            // 
            this.cboArticulos.FormattingEnabled = true;
            this.cboArticulos.Location = new System.Drawing.Point(192, 68);
            this.cboArticulos.Name = "cboArticulos";
            this.cboArticulos.Size = new System.Drawing.Size(267, 21);
            this.cboArticulos.TabIndex = 103;
            // 
            // chkArticulos
            // 
            // 
            // 
            // 
            this.chkArticulos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkArticulos.Location = new System.Drawing.Point(36, 67);
            this.chkArticulos.Name = "chkArticulos";
            this.chkArticulos.Size = new System.Drawing.Size(150, 23);
            this.chkArticulos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkArticulos.TabIndex = 102;
            this.chkArticulos.Text = "Todos los Articulos";
            // 
            // chkSubfamilia
            // 
            // 
            // 
            // 
            this.chkSubfamilia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSubfamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubfamilia.Location = new System.Drawing.Point(36, 118);
            this.chkSubfamilia.Name = "chkSubfamilia";
            this.chkSubfamilia.Size = new System.Drawing.Size(169, 23);
            this.chkSubfamilia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSubfamilia.TabIndex = 101;
            this.chkSubfamilia.Text = "Todos las subfamilias";
            // 
            // chkFamilia
            // 
            // 
            // 
            // 
            this.chkFamilia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFamilia.Location = new System.Drawing.Point(36, 92);
            this.chkFamilia.Name = "chkFamilia";
            this.chkFamilia.Size = new System.Drawing.Size(148, 23);
            this.chkFamilia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkFamilia.TabIndex = 98;
            this.chkFamilia.Text = "Todas las Familias";
            // 
            // cboSubCategoria
            // 
            this.cboSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubCategoria.FormattingEnabled = true;
            this.cboSubCategoria.Location = new System.Drawing.Point(192, 120);
            this.cboSubCategoria.Name = "cboSubCategoria";
            this.cboSubCategoria.Size = new System.Drawing.Size(197, 21);
            this.cboSubCategoria.TabIndex = 108;
            // 
            // cboFamilia
            // 
            this.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.Location = new System.Drawing.Point(192, 94);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(197, 21);
            this.cboFamilia.TabIndex = 107;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(389, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 30);
            this.button1.TabIndex = 109;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(389, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 30);
            this.button2.TabIndex = 110;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chkInventario
            // 
            this.chkInventario.AutoSize = true;
            this.chkInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInventario.Location = new System.Drawing.Point(73, 165);
            this.chkInventario.Name = "chkInventario";
            this.chkInventario.Size = new System.Drawing.Size(234, 21);
            this.chkInventario.TabIndex = 111;
            this.chkInventario.Text = "Solo Articulos Inventariables";
            this.chkInventario.UseVisualStyleBackColor = true;
            // 
            // chkExistencia
            // 
            this.chkExistencia.AutoSize = true;
            this.chkExistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExistencia.Location = new System.Drawing.Point(73, 188);
            this.chkExistencia.Name = "chkExistencia";
            this.chkExistencia.Size = new System.Drawing.Size(236, 21);
            this.chkExistencia.TabIndex = 112;
            this.chkExistencia.Text = "Solo Articulos con Exsitencia";
            this.chkExistencia.UseVisualStyleBackColor = true;
            // 
            // frmRepArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdSalir;
            this.ClientSize = new System.Drawing.Size(581, 330);
            this.Controls.Add(this.chkExistencia);
            this.Controls.Add(this.chkInventario);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboSubCategoria);
            this.Controls.Add(this.cboFamilia);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdBuscarArticulos);
            this.Controls.Add(this.cboArticulos);
            this.Controls.Add(this.chkArticulos);
            this.Controls.Add(this.chkSubfamilia);
            this.Controls.Add(this.chkFamilia);
            this.Name = "frmRepArticulos";
            this.Text = "Listado de Articulos y Servicios";
            this.Load += new System.EventHandler(this.frmRepArticulos_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.chkFamilia, 0);
            this.Controls.SetChildIndex(this.chkSubfamilia, 0);
            this.Controls.SetChildIndex(this.chkArticulos, 0);
            this.Controls.SetChildIndex(this.cboArticulos, 0);
            this.Controls.SetChildIndex(this.cmdBuscarArticulos, 0);
            this.Controls.SetChildIndex(this.cmdSalir, 0);
            this.Controls.SetChildIndex(this.cmdImprimir, 0);
            this.Controls.SetChildIndex(this.cboFamilia, 0);
            this.Controls.SetChildIndex(this.cboSubCategoria, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.chkInventario, 0);
            this.Controls.SetChildIndex(this.chkExistencia, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdBuscarArticulos;
        private System.Windows.Forms.ComboBox cboArticulos;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkArticulos;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSubfamilia;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkFamilia;
        private System.Windows.Forms.ComboBox cboSubCategoria;
        private System.Windows.Forms.ComboBox cboFamilia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkInventario;
        private System.Windows.Forms.CheckBox chkExistencia;
    }
}