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
            this.cmdImprimirCaso = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNoCaso = new System.Windows.Forms.TextBox();
            this.rdoImprimeCaso = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdoBuscarCaso = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(183, 22);
            this.lblTituloForm.Text = "Imprimir Caso Medico";
            // 
            // cmdImprimirCaso
            // 
            this.cmdImprimirCaso.Location = new System.Drawing.Point(637, 111);
            this.cmdImprimirCaso.Name = "cmdImprimirCaso";
            this.cmdImprimirCaso.Size = new System.Drawing.Size(78, 23);
            this.cmdImprimirCaso.TabIndex = 1;
            this.cmdImprimirCaso.Text = "Imprimir Caso";
            this.cmdImprimirCaso.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.rdoBuscarCaso);
            this.groupBox1.Controls.Add(this.txtNoCaso);
            this.groupBox1.Controls.Add(this.rdoImprimeCaso);
            this.groupBox1.Location = new System.Drawing.Point(37, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(604, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "No. Caso:";
            // 
            // txtNoCaso
            // 
            this.txtNoCaso.Enabled = false;
            this.txtNoCaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoCaso.Location = new System.Drawing.Point(69, 34);
            this.txtNoCaso.Name = "txtNoCaso";
            this.txtNoCaso.Size = new System.Drawing.Size(60, 22);
            this.txtNoCaso.TabIndex = 34;
            // 
            // rdoImprimeCaso
            // 
            this.rdoImprimeCaso.AutoSize = true;
            this.rdoImprimeCaso.Location = new System.Drawing.Point(68, 13);
            this.rdoImprimeCaso.Name = "rdoImprimeCaso";
            this.rdoImprimeCaso.Size = new System.Drawing.Size(87, 17);
            this.rdoImprimeCaso.TabIndex = 4;
            this.rdoImprimeCaso.TabStop = true;
            this.rdoImprimeCaso.Text = "Imprimir Caso";
            this.rdoImprimeCaso.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(408, 265);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rdoBuscarCaso
            // 
            this.rdoBuscarCaso.AutoSize = true;
            this.rdoBuscarCaso.Location = new System.Drawing.Point(161, 13);
            this.rdoBuscarCaso.Name = "rdoBuscarCaso";
            this.rdoBuscarCaso.Size = new System.Drawing.Size(85, 17);
            this.rdoBuscarCaso.TabIndex = 6;
            this.rdoBuscarCaso.TabStop = true;
            this.rdoBuscarCaso.Text = "radioButton3";
            this.rdoBuscarCaso.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(462, 176);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 17);
            this.radioButton4.TabIndex = 7;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // frmImprimirProblemaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 547);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.cmdImprimirCaso);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImprimirProblemaMedico";
            this.Text = "frmImprimirProblemaMedico";
            // this.Load += new System.EventHandler(this.frmImprimirProblemaMedico_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.radioButton2, 0);
            this.Controls.SetChildIndex(this.cmdImprimirCaso, 0);
            this.Controls.SetChildIndex(this.radioButton4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdImprimirCaso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNoCaso;
        private System.Windows.Forms.RadioButton rdoImprimeCaso;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rdoBuscarCaso;
        private System.Windows.Forms.RadioButton radioButton4;
    }
}