namespace DispensarioMedico
{
    partial class frmBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackUp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblEsperaRestaurar = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmdRestaurar = new DevComponents.DotNetBar.ButtonX();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.PbProgreso2 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdHistorial = new DevComponents.DotNetBar.ButtonX();
            this.porcentaje = new System.Windows.Forms.Label();
            this.lblEsperaBackUp = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmdBackUp = new DevComponents.DotNetBar.ButtonX();
            this.grbProgreso = new System.Windows.Forms.GroupBox();
            this.pbProgreso = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoDiscoDuro = new System.Windows.Forms.RadioButton();
            this.rdoDispositivoExt = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblNombreArc = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lvProximoB = new System.Windows.Forms.ListView();
            this.lvDescripcion = new System.Windows.Forms.ListView();
            this.lvUbicacionB = new System.Windows.Forms.ListView();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lvStatus = new System.Windows.Forms.ListView();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVeces = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkBackup = new System.Windows.Forms.CheckBox();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.grbProgreso.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 553);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Location = new System.Drawing.Point(5, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 528);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupBox2);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(734, 502);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.Lime;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = -90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdSalir);
            this.groupBox2.Controls.Add(this.cmdAceptar);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 494);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(387, 451);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(95, 42);
            this.cmdSalir.TabIndex = 55;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.UseVisualStyleBackColor = true;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(281, 451);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(95, 42);
            this.cmdAceptar.TabIndex = 54;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblPorcentaje);
            this.groupBox5.Controls.Add(this.lblEsperaRestaurar);
            this.groupBox5.Controls.Add(this.groupPanel2);
            this.groupBox5.Controls.Add(this.groupBox11);
            this.groupBox5.Location = new System.Drawing.Point(6, 297);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(713, 148);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(331, 62);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(13, 13);
            this.lblPorcentaje.TabIndex = 15;
            this.lblPorcentaje.Text = "..";
            // 
            // lblEsperaRestaurar
            // 
            this.lblEsperaRestaurar.AutoSize = true;
            this.lblEsperaRestaurar.Location = new System.Drawing.Point(208, 122);
            this.lblEsperaRestaurar.Name = "lblEsperaRestaurar";
            this.lblEsperaRestaurar.Size = new System.Drawing.Size(35, 13);
            this.lblEsperaRestaurar.TabIndex = 14;
            this.lblEsperaRestaurar.Text = "label2";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cmdRestaurar);
            this.groupPanel2.Location = new System.Drawing.Point(208, 5);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(370, 53);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.CustomizeBackground2;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 13;
            // 
            // cmdRestaurar
            // 
            this.cmdRestaurar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cmdRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.cmdRestaurar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.cmdRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRestaurar.Location = new System.Drawing.Point(5, 3);
            this.cmdRestaurar.Name = "cmdRestaurar";
            this.cmdRestaurar.Size = new System.Drawing.Size(356, 42);
            this.cmdRestaurar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmdRestaurar.TabIndex = 56;
            this.cmdRestaurar.Text = "Restaurar";
            this.cmdRestaurar.Click += new System.EventHandler(this.cmdRestaurar_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.PbProgreso2);
            this.groupBox11.Location = new System.Drawing.Point(6, 78);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(701, 39);
            this.groupBox11.TabIndex = 12;
            this.groupBox11.TabStop = false;
            // 
            // PbProgreso2
            // 
            // 
            // 
            // 
            this.PbProgreso2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PbProgreso2.Location = new System.Drawing.Point(8, 11);
            this.PbProgreso2.Name = "PbProgreso2";
            this.PbProgreso2.Size = new System.Drawing.Size(684, 23);
            this.PbProgreso2.TabIndex = 47;
            this.PbProgreso2.Text = "pb";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cmdHistorial);
            this.groupBox4.Controls.Add(this.porcentaje);
            this.groupBox4.Controls.Add(this.lblEsperaBackUp);
            this.groupBox4.Controls.Add(this.groupPanel1);
            this.groupBox4.Controls.Add(this.grbProgreso);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(6, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(713, 157);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "BackUp de la Base de Datos Actual";
            // 
            // cmdHistorial
            // 
            this.cmdHistorial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cmdHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmdHistorial.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.cmdHistorial.Location = new System.Drawing.Point(612, 16);
            this.cmdHistorial.Name = "cmdHistorial";
            this.cmdHistorial.Size = new System.Drawing.Size(57, 53);
            this.cmdHistorial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmdHistorial.TabIndex = 15;
            this.cmdHistorial.Text = "Historial\r\nBackUps";
            this.cmdHistorial.Click += new System.EventHandler(this.cmdHistorial_Click);
            // 
            // porcentaje
            // 
            this.porcentaje.AutoSize = true;
            this.porcentaje.Location = new System.Drawing.Point(331, 75);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(35, 13);
            this.porcentaje.TabIndex = 14;
            this.porcentaje.Text = "label1";
            // 
            // lblEsperaBackUp
            // 
            this.lblEsperaBackUp.AutoSize = true;
            this.lblEsperaBackUp.Location = new System.Drawing.Point(231, 130);
            this.lblEsperaBackUp.Name = "lblEsperaBackUp";
            this.lblEsperaBackUp.Size = new System.Drawing.Size(35, 13);
            this.lblEsperaBackUp.TabIndex = 13;
            this.lblEsperaBackUp.Text = "label1";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cmdBackUp);
            this.groupPanel1.Location = new System.Drawing.Point(208, 16);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(370, 53);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 12;
            // 
            // cmdBackUp
            // 
            this.cmdBackUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cmdBackUp.BackColor = System.Drawing.Color.Transparent;
            this.cmdBackUp.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.cmdBackUp.Location = new System.Drawing.Point(5, 3);
            this.cmdBackUp.Name = "cmdBackUp";
            this.cmdBackUp.Size = new System.Drawing.Size(356, 42);
            this.cmdBackUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmdBackUp.TabIndex = 56;
            this.cmdBackUp.Text = "Inicia BackUP";
            this.cmdBackUp.Click += new System.EventHandler(this.cmdBackUp_Click);
            // 
            // grbProgreso
            // 
            this.grbProgreso.Controls.Add(this.pbProgreso);
            this.grbProgreso.Location = new System.Drawing.Point(6, 89);
            this.grbProgreso.Name = "grbProgreso";
            this.grbProgreso.Size = new System.Drawing.Size(701, 39);
            this.grbProgreso.TabIndex = 11;
            this.grbProgreso.TabStop = false;
            // 
            // pbProgreso
            // 
            // 
            // 
            // 
            this.pbProgreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pbProgreso.Location = new System.Drawing.Point(8, 11);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.Size = new System.Drawing.Size(684, 23);
            this.pbProgreso.TabIndex = 47;
            this.pbProgreso.Text = "progressBarX1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoDiscoDuro);
            this.groupBox6.Controls.Add(this.rdoDispositivoExt);
            this.groupBox6.Location = new System.Drawing.Point(17, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(136, 52);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Guardar En";
            // 
            // rdoDiscoDuro
            // 
            this.rdoDiscoDuro.AutoSize = true;
            this.rdoDiscoDuro.Location = new System.Drawing.Point(6, 16);
            this.rdoDiscoDuro.Name = "rdoDiscoDuro";
            this.rdoDiscoDuro.Size = new System.Drawing.Size(78, 17);
            this.rdoDiscoDuro.TabIndex = 2;
            this.rdoDiscoDuro.TabStop = true;
            this.rdoDiscoDuro.Text = "Disco Duro";
            this.rdoDiscoDuro.UseVisualStyleBackColor = true;
            // 
            // rdoDispositivoExt
            // 
            this.rdoDispositivoExt.AutoSize = true;
            this.rdoDispositivoExt.Location = new System.Drawing.Point(5, 31);
            this.rdoDispositivoExt.Name = "rdoDispositivoExt";
            this.rdoDispositivoExt.Size = new System.Drawing.Size(119, 17);
            this.rdoDispositivoExt.TabIndex = 6;
            this.rdoDispositivoExt.TabStop = true;
            this.rdoDispositivoExt.Text = "Dispositivo Extraible";
            this.rdoDispositivoExt.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.lblUbicacion);
            this.groupBox3.Controls.Add(this.lblNombreArc);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(713, 125);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Company";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 93);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(239, 75);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(41, 13);
            this.lblUbicacion.TabIndex = 16;
            this.lblUbicacion.Text = "label10";
            // 
            // lblNombreArc
            // 
            this.lblNombreArc.AutoSize = true;
            this.lblNombreArc.Location = new System.Drawing.Point(238, 60);
            this.lblNombreArc.Name = "lblNombreArc";
            this.lblNombreArc.Size = new System.Drawing.Size(35, 13);
            this.lblNombreArc.TabIndex = 15;
            this.lblNombreArc.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Ubicacion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nombre del Archivo:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(192, 8);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(402, 48);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(365, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Usted esta a Punto de hacer una Copia de Seguridad de su Base de Datos.\r\nUse REST" +
                "AURAR Para Recuperar la Copia de Sguridad.";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabItem1.BackColor2 = System.Drawing.Color.Lime;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "BackUp";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.groupBox8);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(734, 502);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Location = new System.Drawing.Point(4, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(726, 449);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button5);
            this.groupBox10.Controls.Add(this.button4);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.button3);
            this.groupBox10.Controls.Add(this.lvProximoB);
            this.groupBox10.Controls.Add(this.lvDescripcion);
            this.groupBox10.Controls.Add(this.lvUbicacionB);
            this.groupBox10.Controls.Add(this.textBox7);
            this.groupBox10.Controls.Add(this.textBox6);
            this.groupBox10.Controls.Add(this.textBox5);
            this.groupBox10.Controls.Add(this.textBox4);
            this.groupBox10.Controls.Add(this.lvStatus);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Location = new System.Drawing.Point(6, 125);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(714, 309);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Horario de Backup";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(436, 241);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Borrar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(319, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Editar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(543, 42);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Proximo BackUp";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(402, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(219, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Ubicacion BackUp";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(87, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Descripcion";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(210, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Nuevo";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lvProximoB
            // 
            this.lvProximoB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvProximoB.Location = new System.Drawing.Point(512, 61);
            this.lvProximoB.Name = "lvProximoB";
            this.lvProximoB.Size = new System.Drawing.Size(157, 174);
            this.lvProximoB.TabIndex = 9;
            this.lvProximoB.UseCompatibleStateImageBehavior = false;
            // 
            // lvDescripcion
            // 
            this.lvDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvDescripcion.Location = new System.Drawing.Point(37, 61);
            this.lvDescripcion.Name = "lvDescripcion";
            this.lvDescripcion.Size = new System.Drawing.Size(156, 174);
            this.lvDescripcion.TabIndex = 8;
            this.lvDescripcion.UseCompatibleStateImageBehavior = false;
            // 
            // lvUbicacionB
            // 
            this.lvUbicacionB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvUbicacionB.Location = new System.Drawing.Point(194, 61);
            this.lvUbicacionB.Name = "lvUbicacionB";
            this.lvUbicacionB.Size = new System.Drawing.Size(158, 174);
            this.lvUbicacionB.TabIndex = 7;
            this.lvUbicacionB.UseCompatibleStateImageBehavior = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox7.Location = new System.Drawing.Point(512, 39);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(157, 20);
            this.textBox7.TabIndex = 6;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox6.Location = new System.Drawing.Point(354, 40);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(157, 20);
            this.textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox5.Location = new System.Drawing.Point(195, 40);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(157, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox4.Location = new System.Drawing.Point(37, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(157, 20);
            this.textBox4.TabIndex = 2;
            // 
            // lvStatus
            // 
            this.lvStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvStatus.Location = new System.Drawing.Point(353, 61);
            this.lvStatus.Name = "lvStatus";
            this.lvStatus.Size = new System.Drawing.Size(158, 174);
            this.lvStatus.TabIndex = 1;
            this.lvStatus.UseCompatibleStateImageBehavior = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(163, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(355, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Click en Nuevo para Programar un Backup Periodico de la base de Datos\r\n";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.txtVeces);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.chkBackup);
            this.groupBox9.Location = new System.Drawing.Point(6, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(714, 100);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "BackUp Automatico";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(99, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(387, 26);
            this.label12.TabIndex = 3;
            this.label12.Text = "El Archivo se Guardara en la Carpeta de Backup Automatico Que Se Encuentra \r\nen e" +
                "l Directorio.";
            // 
            // txtVeces
            // 
            this.txtVeces.Location = new System.Drawing.Point(378, 31);
            this.txtVeces.Name = "txtVeces";
            this.txtVeces.Size = new System.Drawing.Size(42, 20);
            this.txtVeces.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(426, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Veces";
            // 
            // chkBackup
            // 
            this.chkBackup.AutoSize = true;
            this.chkBackup.Location = new System.Drawing.Point(103, 33);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new System.Drawing.Size(253, 17);
            this.chkBackup.TabIndex = 0;
            this.chkBackup.Text = "Backup Automatico al Cerrar todos los Archivos.\r\n";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Horario BackUp";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 600);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBackUp";
            this.Text = "frmBackUp";
            this.Load += new System.EventHandler(this.frmBackUp_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.grbProgreso.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblEsperaRestaurar;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX cmdRestaurar;
        private System.Windows.Forms.GroupBox groupBox11;
        private DevComponents.DotNetBar.Controls.ProgressBarX PbProgreso2;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevComponents.DotNetBar.ButtonX cmdHistorial;
        private System.Windows.Forms.Label porcentaje;
        private System.Windows.Forms.Label lblEsperaBackUp;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX cmdBackUp;
        private System.Windows.Forms.GroupBox grbProgreso;
        private DevComponents.DotNetBar.Controls.ProgressBarX pbProgreso;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoDiscoDuro;
        private System.Windows.Forms.RadioButton rdoDispositivoExt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblNombreArc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lvProximoB;
        private System.Windows.Forms.ListView lvDescripcion;
        private System.Windows.Forms.ListView lvUbicacionB;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ListView lvStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVeces;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkBackup;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer2;

    }
}