using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using VFPToolkit;


namespace DispensarioMedico
{
    public partial class frmMovInventarioTMP : frmBase
    {

        string cCadenaclsConexion = clsConexion.ConectionString;
        string cModo = "Inicio";
        // para manejo en los datagrid ED del combo  cboCodigo 
        DataGridViewComboBoxEditingControl dgvCombo;


        public frmMovInventarioTMP()
        {
            InitializeComponent();
        }

        private void frmMovInventarioTMP_Load(object sender, EventArgs e)
        {
            string cTabla = "";
            string campo = "";

            cTabla = "T_mov";
            cboT_mov.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboT_mov.DisplayMember = "t_mov";
            cboT_mov.ValueMember = "codigo";
            cboT_mov.SelectedIndex = 0;
            campo = "t_mov";
            cboT_mov.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboT_mov.AutoCompleteMode = AutoCompleteMode.None;
            cboT_mov.AutoCompleteSource = AutoCompleteSource.ListItems;

            cTabla = "MAlmacen";
            cboAlmacen.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboAlmacen.DisplayMember = "almacen";
            cboAlmacen.ValueMember = "codigo";
            cboAlmacen.SelectedIndex = 0;
            campo = "Almacen";
            cboAlmacen.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboAlmacen.AutoCompleteMode = AutoCompleteMode.None;
            cboAlmacen.AutoCompleteSource = AutoCompleteSource.ListItems;

            cTabla = "rangos";
            cmbRangoPaciente.DataSource = clsProcesos.DatosGeneral(cTabla);
            cmbRangoPaciente.DisplayMember = "rango_descripcion";
            cmbRangoPaciente.ValueMember = "rango_id";
            cmbRangoPaciente.SelectedIndex = -1;
            campo = "rango_descripcion";
            cmbRangoPaciente.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cmbRangoPaciente.AutoCompleteMode = AutoCompleteMode.None;
            cmbRangoPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbRangoMedico.DataSource = clsProcesos.DatosGeneral(cTabla);
            cmbRangoMedico.DisplayMember = "rango_descripcion";
            cmbRangoMedico.ValueMember = "rango_id";
            cmbRangoMedico.SelectedIndex = -1;
            campo = "rango_descripcion";
             cmbRangoMedico.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
             cmbRangoMedico.AutoCompleteMode = AutoCompleteMode.None;
            cmbRangoMedico.AutoCompleteSource = AutoCompleteSource.ListItems;              
            
            grdDetalle.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //  grdDetalle.Columns[0].HeaderCell.Style.ForeColor = DataGridViewContentAlignment.MiddleCenter;
            // grdDetalle.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   

            // Initialize basic DataGridView properties.
            //  grdDetalle.Dock = DockStyle.Fill;
            grdDetalle.BackgroundColor = Color.LightGray;
            grdDetalle.BorderStyle = BorderStyle.Fixed3D;

            // Set property values appropriate for read-only display and   ' limited interactivity. 
            grdDetalle.AllowUserToAddRows = true;
            grdDetalle.AllowUserToDeleteRows = false;
            grdDetalle.AllowUserToOrderColumns = true;
            grdDetalle.ReadOnly = false;
            grdDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdDetalle.MultiSelect = false;
            grdDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grdDetalle.AllowUserToResizeColumns = false;
            grdDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grdDetalle.AllowUserToResizeRows = false;
            grdDetalle.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Set the selection background color for all the cells.
            grdDetalle.DefaultCellStyle.SelectionBackColor = Color.White;
            grdDetalle.DefaultCellStyle.SelectionForeColor = Color.Blue;

            this.grdDetalle.AutoGenerateColumns = false;
            // formato de columnas, no esta funcionando
            grdDetalle.Columns["Costo"].DefaultCellStyle.Format = "#,###,###,##0.00;-#,###,###,##0.00";
            grdDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "#,###,###,##0.00;-#,###,###,##0.00";
            // grdDetalle.Columns["Fec_Fab"].DefaultCellStyle.Format = "ddd dd MMM yy";


            // Alineacion
            grdDetalle.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // grdDetalle.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Agrego registro en Blanco
            //  grdDetalle.Rows.Add();


            //llenar el cboCodigo cod_pro del Grid
            DataTable dtCatalogo = new DataTable();


            MySql.Data.MySqlClient.MySqlConnection objCon = new MySql.Data.MySqlClient.MySqlConnection();
            objCon.ConnectionString = cCadenaclsConexion;
            objCon.Open();

            string Query = "SELECT cod_pro,des_pro,status,cant_exist from mproduct order by cod_pro";
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
            //oCnn.Open();
            MySqlCommand comando = new MySqlCommand(Query, objCon);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

            dtCatalogo.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adaptador.Fill(dtCatalogo);
            //oCnn.Close();
            //dsCatalogo.Tables.Add(dtCatalogo); //Para agregar un datatable a un dataset.
            //dsCatalogo.Tables[0].TableName = "catalogo";
            //cboCodigo.DataSource = dtCatalogo;
            //cboCodigo.DisplayMember = "Cod_pro";
            //cboCodigo.ValueMember = "Cod_pro";

            /*
        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        grdDetalle.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows. 
        ' The value for alternating rows overrides the value for all rows. 
        grdDetalle.RowsDefaultCellStyle.BackColor = Color.LightGray
        grdDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

        ' Set the row and column header styles.
        grdDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        grdDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        grdDetalle.RowHeadersDefaultCellStyle.BackColor = Color.Black

        ' Set the Format properties
        grdDetalle.Columns("Cost").DefaultCellStyle.Format = "$#,##0.00;-$#,##0.00"
        grdDetalle.Columns("Cost").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
        grdDetalle.Columns("Cost").DefaultCellStyle.Padding = New Padding(0, 0, 16, 0)

        grdDetalle.Columns("Date").DefaultCellStyle.Format = "ddd dd MMM yy"
        grdDetalle.Columns("Date").DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)

        ' Specify a larger font for the "Ratings" column. 
        Dim font As New Font( _
            grdDetalle.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold)
        Try
            grdDetalle.Columns("Rating").DefaultCellStyle.Font = font
        Finally
            font.Dispose()
        End Try

    End Sub

    ' Changes the foreground color of cells in the "Ratings" column 
    ' depending on the number of stars. 
    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles grdDetalle.CellFormatting

        If e.ColumnIndex = grdDetalle.Columns("Rating").Index _
            AndAlso e.Value IsNot Nothing Then

            Select Case e.Value.ToString().Length
                Case 1
                    e.CellStyle.SelectionForeColor = Color.Red
                    e.CellStyle.ForeColor = Color.Red
                Case 2
                    e.CellStyle.SelectionForeColor = Color.Yellow
                    e.CellStyle.ForeColor = Color.Yellow
                Case 3
                    e.CellStyle.SelectionForeColor = Color.Green
                    e.CellStyle.ForeColor = Color.Green
                Case 4
                    e.CellStyle.SelectionForeColor = Color.Blue
                    e.CellStyle.ForeColor = Color.Blue
            End Select

        End If

    End Sub

    ' Creates the columns and loads the data.
    Private Sub PopulateDataGridView()

        ' Set the column header names.
        grdDetalle.ColumnCount = 5
        grdDetalle.Columns(0).Name = "Recipe"
        grdDetalle.Columns(1).Name = "Category"
        grdDetalle.Columns(2).Name = "Date"
        grdDetalle.Columns(3).Name = "Cost"
        grdDetalle.Columns(4).Name = "Rating"

        ' Populate the rows.
        Dim row1() As Object = {"Meatloaf", "Main Dish", _
            Now.AddDays(-10), 0.666, "*"}
        Dim row2() As Object = {"Key Lime Pie", "Dessert", _
            Now.AddDays(-10), 6.6666, "****"}
        Dim row3() As Object = {"Orange-Salsa Pork Chops", "Main Dish", _
            Now.AddDays(-10), 55.555, "****"}
        Dim row4() As Object = {"Black Bean and Rice Salad", "Salad", _
            Now.AddDays(-10), -444.44, "****"}
        Dim row5() As Object = {"Chocolate Cheesecake", "Dessert", _
            Now.AddDays(-10), -222, "***"}
        Dim row6() As Object = {"Black Bean Dip", "Appetizer", _
            Now.AddDays(-10), 333, "***"}

        ' Add the rows to the DataGridView.
        Dim rows() As Object = {row1, row2, row3, row4, row5, row6}
        Dim rowArray As Object()
        For Each rowArray In rows
            grdDetalle.Rows.Add(rowArray)
        Next rowArray

        ' Adjust the row heights so that all content is visible.
        grdDetalle.AutoResizeRows( _
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
            */

            this.Iniciar();
        }

        private void Iniciar()
        {
            this.cModo = "Inicio";
            this.Limpiar();
            this.Botones();
            CursorDefault();

        } // Iniciar()

        private void Limpiar()
        {

            // Inicializo controles
            this.grdDetalle.Rows.Clear();

            this.txtApellido.Text = "";
            this.txtCedula.Text = "";
            this.txtCedulaMedico.Text = "";
            this.txtConcepto.Text = "";
            this.txtReferencia.Text = "";
            this.txtNombre.Clear();
            this.txtSecuencia.Clear();

            //txtVidaUtil.Text = "0";

            //cboEmpleado.SelectedIndex = 0;

            this.imgFoto.ImageLocation = "";
            this.imgFoto.Image = null;            
            this.imgFoto.ImageLocation = Application.StartupPath + "\\LogoARD.png";

            clsProcesos oPreceso = new clsProcesos();
            oPreceso.LimpiarTextBox(this);
            // oPreceso.LimpiarControles(this); // depurar error al grabar
            this.cboAlmacen.SelectedIndex = -1;
            this.cboEntradaSalida.SelectedIndex = -1;
            this.cboT_mov.SelectedIndex = -1;
            this.cmbRangoMedico.SelectedIndex = -1;
            this.cmbRangoPaciente.SelectedIndex = -1;

            this.chkAfectaCosto.Checked = false;

            this.dtpFecha.Value = VFPToolkit.dates.DateTime();
            this.dtpFechaDigitada.Value = VFPToolkit.dates.DateTime();
        } // fin Limpiapr     


        private void Botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.Enabled = true;
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnBuscarEmpleado.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.CursorDefault();
                    this.grdDetalle.Focus();
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnBuscarEmpleado.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.grdDetalle.Focus();
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnBuscarEmpleado.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnBuscarEmpleado.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnBuscarEmpleado.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnBuscarEmpleado.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    break;

                default:
                    break;
            }

        }

        private void CursorDefault()
        {
            Cursor.Current = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.UseWaitCursor = false;
            Application.UseWaitCursor = false;
        }

        // Cancela Cambios y Reseta el Formulario
        private void Cancelar()
        {
            this.cModo = "Cancelar";
            this.Limpiar();
            //    Procesos oPreceso = new Procesos();
            //   oPreceso.AbilitarDesabilitarControles(this, false);
            this.NoEditar();
            grdDetalle.Enabled = false;
            txtConcepto.Enabled = false;
            this.cModo = "Inicio";
            this.Botones();
        }

        // Editar()
        private void Editar()
        {
            //  this.Enabled = true;            
            cboAlmacen.Enabled = true;
            cboEntradaSalida.Enabled = true;
            cboT_mov.Enabled = true;

            cmbRangoPaciente.Enabled = false;

            txtCedula.Enabled = true;
            txtConcepto.Enabled = true;
            txtReferencia.Enabled = true;

            this.chkAfectaCosto.Enabled = true;
            this.dtpFecha.Enabled = true;
            this.dtpFechaDigitada.Enabled = true;

            btnBuscarEmpleado.Enabled = true;
            grboxBotones.Enabled = true;

            foreach (Control oControls in this.Controls)
            {
                oControls.Enabled = true;
            }

            /*
            // Create an instance of a form and assign it the currently active form.
            Form currentForm = Form.ActiveForm;
            // Loop through all the controls on the active form.
            for (int i = 0; i < currentForm.Controls.Count; i++)
            {
                // Enabled each control in the active form's control collection.              
                currentForm.Controls[i].Enabled = true;
            }
             
             */

            // Controles de solo lectura permanentes o excepciones
            cmbRangoPaciente.Enabled = false;
            cmbRangoMedico.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtNombreMedico.Enabled = false;
            txtApellidoMedico.Enabled = false;

        }  // Editar

        // NoEditar()
        private void NoEditar()
        {
            string cNombreControl;
            foreach (Control oControls in this.Controls)
            {
                if (oControls is Button)
                {

                }
                else
                {
                    oControls.Enabled = false;
                    cNombreControl = oControls.Name;
                }
            }

            cboAlmacen.Enabled = false;
            cboEntradaSalida.Enabled = false;
            cboT_mov.Enabled = false;
            cmbRangoPaciente.Enabled = false;

            txtApellido.ReadOnly = true;
            txtCedula.Enabled = false;
            txtConcepto.Enabled = false;
            txtNombre.ReadOnly = true;
            txtReferencia.Enabled = false;

            this.chkAfectaCosto.Enabled = false;
            this.dtpFecha.Enabled = false;
            this.dtpFechaDigitada.Enabled = false;

            btnBuscarEmpleado.Enabled = false;
            grboxBotones.Enabled = true;

        }  // NoEditar()

        // Realiza busqueda Avanzada de los Articulos
        private void BuscarItem()
        {
            DataGridViewRow row = grdDetalle.CurrentRow;
            DataGridViewComboBoxCell cell = row.Cells["cboCodigo"] as DataGridViewComboBoxCell;

            frmBuscarArticulo ofrmBuscarCatalogo = new frmBuscarArticulo();
            ofrmBuscarCatalogo.ShowDialog();
            string cCodigo = ofrmBuscarCatalogo.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo de la centa en la cedlda del grid                          
                cell.Value = Convert.ToString(cCodigo).Trim();

                DataSet dsDatos = new DataSet();
                DataTable dtCatalogo = clsProcesos.DatosGeneral("mproduct", " where trim(cod_pro) = '" + cCodigo.Trim() + "' ", " order by cod_pro ");
                dsDatos.Tables.Add(dtCatalogo);
                if (dsDatos.Tables[0].Rows.Count > 0)
                {
                    DataGridViewTextBoxCell cell2 = row.Cells["Des_pro"] as DataGridViewTextBoxCell;
                    // Mostrar el nombre de la cuenta en el grid
                    foreach (DataRow registro in dsDatos.Tables[0].Rows)
                    {
                        cell2.Value = (registro["des_pro"]);
                    }
                } //  if (dsDatos.Tables[0].Rows.Count > 0)

            }
        }

        // valida antes de grabar 
        private bool ValidaForm()
        {
            bool lRetorno = false;

            this.CalculoTotal();
            try
            {
                // if (txtCedula.Text == "")
                if (txtCedula.MaskFull == false || txtCedulaMedico.MaskFull == false)
                {
                    MessageBox.Show("Formato de Cedula incorrecto, favor verificar!! ", "Sistema SysHospitalARD v1.0",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //  MessageBox.Show("No se permiten busquedas con el campo cedula vacio...");
                //  txtCedula.Focus();

                if (cboAlmacen.SelectedValue.ToString() == "" || cboAlmacen.SelectedValue == null)
                {
                    MessageBox.Show("No puede grabar con datos en blanco, Indique el almacen!! ", "Sistema SysHospitalARD v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (this.txtReferencia.Text.Trim() =="")
                {
                    txtReferencia.Text = txtSecuencia.Text;
                }


                // SelectValue Genera error en combos llenados manualmente
                //if (cboEntradaSalida.SelectedValue == "" || cboEntradaSalida.SelectedValue == null)
                if (cboEntradaSalida.SelectedItem.ToString() == "" || cboEntradaSalida.SelectedItem == null)
                {
                    MessageBox.Show("No puede grabar con datos en blanco, Indique Salida o Entrada de Mercancias!! ", "Sistema SysHospitalARD v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (cboT_mov.SelectedValue == "" || cboT_mov.SelectedValue == null)
                {
                    MessageBox.Show("No puede grabar con datos en blanco, Indique el Tipo de Documento y/o Movimiento!! ", "Sistema SysHospitalARD v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }                              

                // txtNotas.Text == "" 
                if (txtCedula.Text == "" || txtSecuencia.Text == "" || txtReferencia.Text == "" || txtConcepto.Text == "")
                {
                    MessageBox.Show("No puede grabar con datos en blanco!! ", "Sistema SysHospitalARD v1.0",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (grdDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("No puede grabar movimientos sin indicar detalle de Articulos!! ", "Sistema SysHospitalARD v1.0",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                this.CursorDefault();
                return false;
            }
            return true;

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        // Inserta y graba un registro nuevo
        private void Grabar()
        {
            DialogResult oRpt;
            oRpt = MessageBox.Show("Esta seguro de grabar este registro?", "Sistema SysHospitalARD v1.0",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oRpt != DialogResult.Yes) { return; }
            string cCero = "0";
            string cValues = "";
            int nSecuencia = 0;
            int nRegistros = 0;
            string cConsultaSQL;
            string cUsuario = frmLogin.cUsuarioActual;
            DataTable dtExistencia = new DataTable();
            string cCod_Pro = "";

            // Inicio clsConexion y transacccion            
            MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
            MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
            MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
            DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
            StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:
            MySqlTransaction oTransaccion = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                oCnn.ConnectionString = cCadenaclsConexion;
                oCnn.Open();
                oTransaccion = oCnn.BeginTransaction();

                cmdExec = oCnn.CreateCommand();
                cmdExec.Connection = oCnn;
                cmdExec.CommandTimeout = 0; // para consultas largas
                cmdExec.Transaction = oTransaccion;

                // Busco la proxima secuencia para el tipo de movimiento
                this.txtSecuencia.Clear();
                cConsultaSQL = "select secuencia from t_mov where codigo = " + this.cboT_mov.SelectedValue.ToString().Trim();
                // temporal
                VFPToolkit.strings.StrToFile(cConsultaSQL.Trim(), @"consulta.sql", true);
                cmdExec.CommandText = cConsultaSQL.Trim();
                this.txtSecuencia.Text = (Convert.ToInt32(cmdExec.ExecuteScalar()) + 1).ToString();

                if (Convert.ToUInt32(this.txtSecuencia.Text) == 0)
                {
                    this.CursorDefault();
                    MessageBox.Show("No se pudo actualizar el tipo de moviento, favor verificar datos!!", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    oTransaccion.Rollback();
                    return;
                }

                if (Convert.ToUInt32(this.txtReferencia.Text) == 0 || this.txtReferencia.Text.Trim() == "")
                {
                    this.txtReferencia.Text = this.txtSecuencia.Text;
                }

                // Incremento secuencia T_mov
                this.txtSecuencia.Text = Convert.ToString(Convert.ToInt32(txtSecuencia.Text)).Trim();
                sbQuery.Clear();
                sbQuery.Append(" update t_mov set secuencia = " + this.txtSecuencia.Text + "  where codigo = " + this.cboT_mov.SelectedValue.ToString().Trim());

                // temporal
                VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                cmdExec.CommandText = sbQuery.ToString();
                nRegistros = cmdExec.ExecuteNonQuery();
                if (nRegistros == 0)
                {
                    this.CursorDefault();
                    MessageBox.Show("No se pudo actualizar el tipo de moviento, favor verificar datos!!", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    oTransaccion.Rollback();
                    return;
                }

                // Ingreso  Detalle
                // Busco el Total                         
                foreach (DataGridViewRow registro in grdDetalle.Rows)
                {
                    if (Convert.ToString(registro.Cells["cboCodigo"].Value) != "") // Si no esta en blanco el codigo de la cuenta
                    {
                        cCod_Pro = Convert.ToString(registro.Cells["cboCodigo"].Value).Trim();

                        if (Convert.ToDecimal(registro.Cells["Cantidad"].Value) == 0) // || Convert.ToDecimal(registro.Cells["Costo"].Value) == 0
                        {
                            MessageBox.Show("El Costo o la Cantidad no pueden ser cero, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            oTransaccion.Rollback();
                            oCnn.Close();
                            this.CursorDefault();
                            return;
                        }

                        // Si es salida
                        if (this.cboEntradaSalida.SelectedItem == "Salida")
                        {
                            // Valido Existencia
                            dtExistencia = clsProcesos.DatosGeneral("mproduct", " where cod_pro = '" + cCod_Pro + "'", " Order by Cod_pro");
                            if (dtExistencia.Rows.Count > 0)
                            {
                                DataRow DR;
                                DR = dtExistencia.Rows[0];
                                if (Convert.ToDecimal(DR["Cant_exist"]) < Convert.ToDecimal(registro.Cells["Cantidad"].Value))
                                {
                                    MessageBox.Show("La Cantidad excede la existencia de " + Convert.ToDecimal(DR["Cant_exist"]).ToString("N") + " para el  producto " 
                                         + Convert.ToString(DR["Cant_exist"]).Trim() + ", Favor verificar!!",
                                        "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    oTransaccion.Rollback();
                                    oCnn.Close();
                                    this.CursorDefault();
                                    return;
                                }
                            }
                            dtExistencia.Clear();
                            registro.Cells["Cantidad"].Value = Convert.ToString(Convert.ToDecimal(registro.Cells["Cantidad"].Value) * -1);
                        }
                        else
                        {
                            txtCedula.Text = "999-9999999-9"; // Administracion
                        }


                        // inserto en Invent
                        nSecuencia = nSecuencia + 1;
                        cValues = " VALUES ('" + Convert.ToString(registro.Cells["cboCodigo"].Value) + "','" + dtpFecha.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                        Convert.ToInt32(cboT_mov.SelectedValue.ToString()) + "','" + txtSecuencia.Text.Trim() + "','" + txtReferencia.Text + "','" +
                        Convert.ToDecimal(registro.Cells["Cantidad"].Value) + "','" + Convert.ToDecimal(registro.Cells["Costo"].Value) + "','" +
                        Convert.ToInt32(cboAlmacen.SelectedValue) + "','" + Convert.ToString(registro.Cells["Lote"].Value) + "','" +
                        txtConcepto.Text.Trim() + "','" + cUsuario + "','" + Convert.ToDateTime(registro.Cells["Fec_Fab"].Value).ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                        Convert.ToDateTime(registro.Cells["Fec_Ven"].Value).ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtCedula.Text.Trim() + "','" + txtCedulaMedico.Text.Trim() + "') ";

                        sbQuery.Clear();
                        sbQuery.Append("INSERT INTO invent(cod_1,fecha,tipo_mov,no_docum,ord_comp,cantidad,valor,almacen,lote,nota,usuario,fecfab,fecven,cedula,medico) ");
                        sbQuery.Append(cValues);

                        // temporal
                        VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                        cmdExec.CommandText = sbQuery.ToString();
                        nRegistros = cmdExec.ExecuteNonQuery();
                        if (nRegistros == 0)
                        {
                            MessageBox.Show("No se actualizaron los datos del detalle de la Transaccion, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            oTransaccion.Rollback();
                            oCnn.Close();
                            this.CursorDefault();
                            return;
                        }

                        // Actualizo Stock en mproduct
                        sbQuery.Clear();
                        sbQuery.Append("update mproduct set cant_exist = cant_exist + " + Convert.ToDecimal(registro.Cells["Cantidad"].Value).ToString() + ", ");
                        sbQuery.Append(" almacen1 = almacen1 + " + Convert.ToDecimal(registro.Cells["Cantidad"].Value).ToString());

                        // temporal
                        VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                        cmdExec.CommandText = sbQuery.ToString();
                        nRegistros = cmdExec.ExecuteNonQuery();
                        if (nRegistros == 0)
                        {
                            MessageBox.Show("No se actualizaron los datos del detalle de la Transaccion, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            oTransaccion.Rollback();
                            oCnn.Close();
                            this.CursorDefault();
                            return;
                        }


                    }  // if (Convert.ToString(row.Cells["cboCodigo"].Value) != "")
                } // foreach (DataGridViewRow row in grdDetalle.Rows)



                // Confirmo Transaccion y actualizo BD
                // Imprimo documento
                // Limpio form                                                         
                oTransaccion.Commit();
                oRpt = MessageBox.Show("Transaccion grabada con exito!!. Desea Imprimirla?", "Sistema SysHospitalARD v1.0",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oRpt == DialogResult.Yes)
                {
                    ImprimirTransaccion(Convert.ToInt32(cboT_mov.SelectedValue.ToString()),Convert.ToInt32(txtSecuencia.Text.Trim()));                      
                }
                this.Limpiar();
                this.NoEditar();
                cModo = "Inicio";
                this.Botones();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            finally
            {
            }


        }  //  Grabar()

         private void ImprimirTransaccion(int nTipoDoc,int nNo_docum )
         {
             
             try
             {
                 string cTipoDoc = nTipoDoc.ToString().Trim();
                 int nNoDoc = nNo_docum;
                 //   DataTable dtInvent = Procesos.DatosGeneral("invent"," where no_docum = " + nNoDoc.ToString() + " and tipo_mov = " + cTipoDoc, " order by secuencia");

                 string cCero = "0";
                 DataSet dsMovBan2 = new DataSet();

                 // Inicio clsConexion y transacccion            
                 MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
                 MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
                 MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
                 DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
                 StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:

                 this.Cursor = Cursors.WaitCursor;
                 oCnn.ConnectionString = clsConexion.ConectionString;
                 string cWhere = " and no_docum = " + nNoDoc.ToString() + " and tipo_mov = " + cTipoDoc;

                 oCnn.Open();
                 cmdExec = oCnn.CreateCommand();
                 cmdExec.Connection = oCnn;
                 cmdExec.CommandTimeout = 0; // para consultas largas

                 sbQuery.Clear();
                 sbQuery.Append("select invent.*, T_mov.t_mov, mproduct.des_pro,  ");
                 sbQuery.Append("paciente.id_paciente,paciente.nombre,paciente.apellido,paciente.rango,");
                 sbQuery.Append("rangos.RangoAbrev,vdoctores.doctores_cedula,vdoctores.doctores_nombre,vdoctores.doctores_apellido,vdoctores.rangoabrev as rangodoc, ");
                 sbQuery.Append("config.empresa, config.direccion, config.dependencia,config.telefono1,config.telefono2,config.fax,config.rnc, ");
                 sbQuery.Append("config.email, config.website, config.jefe,config.rango_jefe,config.rango_dir,config.director,config.logobmp ");
                 sbQuery.Append("FROM invent,paciente,config,T_mov, mproduct,rangos,vdoctores");
                 sbQuery.Append(" WHERE invent.tipo_mov = t_mov.codigo ");
                 sbQuery.Append(" and trim(invent.cod_1) = trim(mproduct.cod_pro) ");
                 sbQuery.Append(" and invent.cedula = paciente.cedula ");
                 sbQuery.Append(" and paciente.rango = rangos.rango_id ");
                 sbQuery.Append(" and invent.medico = vdoctores.doctores_cedula ");
                 sbQuery.Append(cWhere);
                 sbQuery.Append(" group by invent.fecha,invent.secuencia ");

                 // temporal
                 VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                 cmdExec.CommandText = sbQuery.ToString();

                 daDatos = new MySqlDataAdapter(cmdExec);
                 dsMovBan2.Clear();
                 daDatos.Fill(dsMovBan2);
                 int nRegistros = dsMovBan2.Tables[0].Rows.Count;
                 if (nRegistros == 0)
                 {
                     MessageBox.Show("No hay información para mostrar, favor verificar", "Reimpresion de Transacción", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                     CursorDefault();
                     this.Limpiar();
                     return;
                 }
                oCnn.Close();
                 

                 // Parametros de Fecha para visualizar en el Reporte CR
                 DateTime dFechaInicial = DateTime.Now;
                 DateTime dFechaFinal = DateTime.Now;

                 String cUsuario = frmLogin.cUsuarioActual;
                 string cTitulo = "Reimpresion de la Transaccion Numero " + txtSecuencia.Text.Trim() + ", del Tipo " + cboT_mov.SelectedText.Trim();

                 // Colecciones
                 ParameterFields oParametrosCR = new ParameterFields();
                 ParameterValues oParametrosValuesCR = new ParameterValues();

                 // parametros
                 ParameterField oFechaInicial = new ParameterField();
                 ParameterField oFechaFinal = new ParameterField();
                 ParameterField oUsuario = new ParameterField();
                 ParameterField oTitulo = new ParameterField();
                 oFechaInicial.ParameterValueType = ParameterValueKind.DateParameter;
                 oFechaFinal.ParameterValueType = ParameterValueKind.DateParameter;
                 oUsuario.ParameterValueType = ParameterValueKind.StringParameter;
                 oTitulo.ParameterValueType = ParameterValueKind.StringParameter;

                 // Valores para los prametros
                 ParameterDiscreteValue oFechaInicialDValue = new ParameterDiscreteValue();
                 ParameterDiscreteValue oFechaFinalDValue = new ParameterDiscreteValue();
                 ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                 ParameterDiscreteValue oTituloDValue = new ParameterDiscreteValue();
                 oFechaInicialDValue.Value = dFechaInicial;
                 oFechaFinalDValue.Value = dFechaFinal;
                 oUsuarioDValue.Value = cUsuario;
                 oTituloDValue.Value = cTitulo;

                 // Agrego los valores a los parametros
                 oFechaInicial.CurrentValues.Add(oFechaInicialDValue);
                 oFechaFinal.CurrentValues.Add(oFechaFinalDValue);
                 oUsuario.CurrentValues.Add(oUsuarioDValue);
                 oTitulo.CurrentValues.Add(oTituloDValue);

                 // Agrego los parametros a la coleccion
                 oParametrosCR.Clear();
                 oParametrosCR.Add(oTitulo);
                 oParametrosCR.Add(oUsuario);
                 oParametrosCR.Add(oFechaInicial);
                 oParametrosCR.Add(oFechaFinal);

                 // Nombre del Parametro en CR
                 oParametrosCR[0].Name = "cTitulo";
                 oParametrosCR[1].Name = "cUsuario";
                 oParametrosCR[2].Name = "dFechaInicial";
                 oParametrosCR[3].Name = "dFechaFinal";

                 // oReporte.DataDefinition.ParameterFields("@dFechaInicial").ApplyCurrentValues(oParametrosCR[0]);
                 // oReporte.DataDefinition.ParameterFields("@dFechaFinal").ApplyCurrentValues(oParametrosCR[1]);

                 Reportes.rptReimprimeTR oReporte = new Reportes.rptReimprimeTR();
                 frmPrinter ofrmPrinter = new frmPrinter(dsMovBan2.Tables[0], oReporte, cTitulo);
                 ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                 ofrmPrinter.ShowDialog();
                 CursorDefault();
             }
             catch (MySqlException ex)
             {

                 MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                 clsExceptionLog.LogError(ex, false);
                 this.CursorDefault();
                 return;
             }
             catch (Exception ex)
             {

                 MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                 clsExceptionLog.LogError(ex, false);
                 //    oTransaccion.Connection.State =  ConnectionState. 

                 this.CursorDefault();
                 return;
             }
         }

        private void CalculoTotal()
        {
            try
            {
                decimal nTotal = 0;


                foreach (DataGridViewRow Row in grdDetalle.Rows)
                {
                    if (Convert.ToDecimal(Row.Cells["Cantidad"].Value) > 0)
                    {
                        nTotal += (Convert.ToDecimal(Row.Cells["Cantidad"].Value) * Convert.ToDecimal(Row.Cells["Costo"].Value));
                    }

                    txtImporte.Text = Convert.ToDecimal(nTotal).ToString("C");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cModo = "Nuevo";
            this.Limpiar();
            this.Editar();
            this.Botones();
            cboAlmacen.SelectedIndex = 0;
            cboEntradaSalida.SelectedIndex = 0;
            cboT_mov.SelectedIndex = 0;

            // this.grdDetalle.Rows.Add();
            this.grdDetalle.Focus();
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarPaciente ofrmBuscarPaciente = new frmBuscarPaciente();
            ofrmBuscarPaciente.ShowDialog();
            string cCodigo = ofrmBuscarPaciente.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedula.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT id_paciente, cedula, rango, nombre, apellido, edad, sexo, dato_nacimiento, " +
                        "dato_alimentacion, dato_condicionespsicologicas, dato_sexualidad, dato_operaciones, " +
                        "dato_intoleranciamedicinal, dato_saludpadres, dato_saludhermanos, dato_saludesposahijos, " +
                        "dato_saludfamiliargeneral, fecharegistro, fechaupdate,rutafoto FROM paciente " +
                        "WHERE cedula = " + "'" + txtCedula.Text + "'" + "";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            // txtID.Text = MyReader["id_paciente"].ToString();
                            cmbRangoPaciente.SelectedValue = Convert.ToInt32(MyReader["rango"]);
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtApellido.Text = MyReader["apellido"].ToString();

                            string cFoto = "";
                            cFoto = Application.StartupPath +  @"\fotos\"  + txtCedula.Text.Trim() + ".jpg";
                            // if (this.imgFoto.ImageLocation == null || this.imgFoto.ImageLocation == "")
                            //{
                           // if (File.Exists(Application.StartupPath + @MyReader["rutafoto"].ToString()))
                            if (File.Exists(cFoto))
                             {
                                //this.imgFoto.ImageLocation = Application.StartupPath + @MyReader["rutafoto"].ToString();
                                this.imgFoto.Image = System.Drawing.Image.FromFile(@cFoto);
                            }
                            else
                            {
                                this.imgFoto.Image = null;
                                this.imgFoto.ImageLocation = "";
                            }
                            /*
                            // }
                            if (this.imgFoto.Image == null)
                            {
                                // valor por defecto
                                //this.imgFoto.Image = System.Drawing.Image.FromFile(@this.Icon);
                                //  this.imgFoto.Image = System.Drawing.Image.FromFile(@MyReader["rutafoto"].ToString());

                                if (File.Exists(Application.StartupPath + "\\turbimdg.bmp"))
                                {
                                    this.imgFoto.ImageLocation = Application.StartupPath + "\\turbimdg.bmp";
                                }
                                else
                                {
                                    this.imgFoto.Image = null;
                                    this.imgFoto.ImageLocation = "";
                                }
                            } */
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...", "SysHospitalARD v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtCedula.Focus();
                    }
                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
                /*
                if (txtCedula.Text == "")
                {
                    MessageBox.Show("No se permiten busquedas con el campo cedula vacio...");
                    txtCedula.Focus();
                }
                else
                {
                    try
                    {
                        // Step 1 - clsConexion
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - creating the command object
                        MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                        // Step 3 - creating the commandtext
                        MyCommand.CommandText = "SELECT id_paciente, cedula, rango, nombre, apellido, edad, sexo, dato_nacimiento, " +
                            "dato_alimentacion, dato_condicionespsicologicas, dato_sexualidad, dato_operaciones, " +
                            "dato_intoleranciamedicinal, dato_saludpadres, dato_saludhermanos, dato_saludesposahijos, " +
                            "dato_saludfamiliargeneral, fecharegistro, fechaupdate,rutafoto FROM paciente " +
                            "WHERE cedula = " + "'" + txtCedula.Text + "'" + "";

                        // Step 4 - connection open
                        MyclsConexion.Open();

                        // Step 5 - Creating the DataReader                    
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();

                        // Step 6 - Verifying if Reader has rows
                        if (MyReader.HasRows)
                        {
                            while (MyReader.Read())
                            {
                               // txtID.Text = MyReader["id_paciente"].ToString();
                                //cmbRango.SelectedValue = MyReader["rango"].ToString();
                                txtNombre.Text = MyReader["nombre"].ToString();
                                txtApellido.Text = MyReader["apellido"].ToString();                           
                            
                            }                       
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros con esta cedula...");
                       
                            this.txtCedula.Focus();
                        }

                        // Step 6 - Closing all
                        MyReader.Close();
                        MyCommand.Dispose();
                        MyclsConexion.Close();
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }*/
            }
        }

        private void txtCedula_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // if (txtCedula.Text == "")
            if (txtCedula.MaskFull == false)
            {
              //  MessageBox.Show("No se permiten busquedas con el campo cedula vacio...");
              //  txtCedula.Focus();
                return;
            }
            else
            {
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT id_paciente, cedula, rango, nombre, apellido, edad, sexo, dato_nacimiento, " +
                        "dato_alimentacion, dato_condicionespsicologicas, dato_sexualidad, dato_operaciones, " +
                        "dato_intoleranciamedicinal, dato_saludpadres, dato_saludhermanos, dato_saludesposahijos, " +
                        "dato_saludfamiliargeneral, fecharegistro, fechaupdate,rutafoto FROM paciente " +
                        "WHERE cedula = " + "'" + txtCedula.Text + "'" + "";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            // txtID.Text = MyReader["id_paciente"].ToString();
                            cmbRangoPaciente.SelectedValue = Convert.ToInt32(MyReader["rango"]);
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtApellido.Text = MyReader["apellido"].ToString();
                            string cFoto = "";
                            cFoto = Application.StartupPath +  @"\fotos\"  + txtCedula.Text.Trim() + ".jpg";
                            // if (this.imgFoto.ImageLocation == null || this.imgFoto.ImageLocation == "")
                            //{
                           // if (File.Exists(Application.StartupPath + @MyReader["rutafoto"].ToString()))
                            if (File.Exists(cFoto))
                            {
                                //this.imgFoto.ImageLocation = @cFoto;
                                //this.imgFoto.ImageLocation = Application.StartupPath + @MyReader["rutafoto"].ToString();
                                this.imgFoto.Image = System.Drawing.Image.FromFile(@cFoto);
                            }
                            else
                            {
                                this.imgFoto.Image = null;
                                this.imgFoto.ImageLocation = "";
                            }
                            /*
                            // }
                            if (this.imgFoto.Image == null)
                            {
                                // valor por defecto
                                //this.imgFoto.Image = System.Drawing.Image.FromFile(@this.Icon);
                                //  this.imgFoto.Image = System.Drawing.Image.FromFile(@MyReader["rutafoto"].ToString());

                                if (File.Exists(Application.StartupPath + "\\turbimdg.bmp"))
                                {
                                    this.imgFoto.ImageLocation = Application.StartupPath + "\\turbimdg.bmp";
                                }
                                else
                                {
                                    this.imgFoto.Image = null;
                                    this.imgFoto.ImageLocation = "";
                                }
                            } */
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...");
                        this.txtCedula.Focus();
                    }
                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboEntradaSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cModo == "Inicio" ||  this.cboEntradaSalida.SelectedItem == null)
                {
                    return;
                }


                ComboBox cmb = (ComboBox)sender;//objeto que dispara el evento
                string cValor = cmb.SelectedItem.ToString();

                //---- combo generado a mano genera error el selectValue, uso SelectItem
                // string cValor = cmb.SelectedValue.ToString().Trim();  // genera error
                // cboEntradaSalida.SelectedValue == null

                if (cValor == null || cValor.Trim() == "")
                {
                    return;
                }

                string cTabla = "T_mov";
                string campo = "t_mov";

                if (cValor == "Entrada")
                {
                    cboT_mov.DataSource = clsProcesos.DatosGeneral(cTabla, " WHERE Status = 'E' ", " ORDER BY Codigo");
                    cboT_mov.DisplayMember = "t_mov";
                    cboT_mov.ValueMember = "codigo";
                    // cboT_mov.SelectedIndex = 0;
                    cboT_mov.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
                    cboT_mov.AutoCompleteMode = AutoCompleteMode.None;
                    cboT_mov.AutoCompleteSource = AutoCompleteSource.ListItems;
                    txtCedula.Text = "999-9999999-9";
                    txtCedulaMedico.Text = "999-9999999-9";
                }
                else
                {
                    cboT_mov.DataSource = clsProcesos.DatosGeneral(cTabla, "  WHERE Status = 'S' ", " ORDER BY Codigo");
                    cboT_mov.DisplayMember = "t_mov";
                    cboT_mov.ValueMember = "codigo";
                    //  cboT_mov.SelectedIndex = 0;
                    cboT_mov.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
                    cboT_mov.AutoCompleteMode = AutoCompleteMode.None;
                    cboT_mov.AutoCompleteSource = AutoCompleteSource.ListItems;
                    txtCedula.Clear();
                    txtCedulaMedico.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        private void cboT_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cModo == "Inicio" || cModo == "Cancelar" || cboT_mov.SelectedItem == null)
            {
                return;
            }

            try
            {
                ComboBox cmb = (ComboBox)sender;//objeto que dispara el evento
                string cValor = cmb.SelectedValue.ToString().Trim();
                string cTabla = "T_mov";

                if (cmb.SelectedValue == null || cmb.SelectedValue.ToString().Trim() == "")
                {
                    return;
                }


                if (cValor != "")
                {
                    DataTable dtTmp = clsProcesos.DatosGeneral(cTabla, " WHERE codigo = " + cValor, " ORDER BY Codigo");
                    if (dtTmp.Rows.Count > 0)
                    {
                        // this.txtReferencia.Text = Convert.ToString(Convert.ToInt32(dtTmp.Columns["Secuencia"].ToString()) + 1);
                        DataRow DR;
                        DR = dtTmp.Rows[0];
                        this.txtSecuencia.Text = Convert.ToString(Convert.ToInt32(DR["secuencia"].ToString()) + 1);
                    }
                    else
                    {
                        this.txtSecuencia.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            return;
        }

        private void grdDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                grdDetalle.Rows[e.RowIndex].ErrorText = String.Empty;
                grdDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = Convert.ToDecimal(grdDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value);
                grdDetalle.Rows[e.RowIndex].Cells["Costo"].Value = Convert.ToDecimal(grdDetalle.Rows[e.RowIndex].Cells["Costo"].Value);

                // quita del evento del combo cuando se deja de editar la celda
                if (dgvCombo != null) dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        private void grdDetalle_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.CalculoTotal();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        private void grdDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string cColumna = grdDetalle.Columns[e.ColumnIndex].HeaderText;
            decimal newDecimal;

            switch (cColumna)
            {
                case "cboCodigo":
                    int nPos = 0;
                    int nTodo = this.grdDetalle.GetCellCount(DataGridViewElementStates.Selected);
                    if (nTodo > 0)
                    {
                        int nFila = this.grdDetalle.SelectedCells[nPos].RowIndex;
                        int nCol = this.grdDetalle.SelectedCells[nPos].ColumnIndex;
                        if (Convert.ToString(grdDetalle[nCol, nFila].Value) == "") { break; };

                        string cCodigo = Convert.ToString(grdDetalle[nCol, nFila].Value);
                        DataGridViewRow row = new DataGridViewRow();
                        DataSet dsDatos = new DataSet();
                        DataTable dtCatalogo = clsProcesos.DatosGeneral("mproduct", " where trim(cod_pro) = '" + cCodigo.Trim() + "' ", " order by cod_pro ");
                        dsDatos.Tables.Add(dtCatalogo);
                        if (dsDatos.Tables[0].Rows.Count > 0)
                        {
                            // Mostrar los datos del datatable en el grid
                            foreach (DataRow registro in dsDatos.Tables[0].Rows)
                            {
                                grdDetalle[nCol + 1, nFila].Value = (registro["des_pro"]);
                                grdDetalle[5, nFila].Value = (registro["Costo"]);
                            }
                        }
                    }
                    // Recalcula la ED.
                    this.CalculoTotal();
                    break;

                case "Descripcion":
                    // Recalcula la ED.
                    this.CalculoTotal();
                    break;
                case "Débito":
                    // Recalcula la ED.
                    this.CalculoTotal();
                    // garantizar que el usuario sólo escriba numeros positivos
                    grdDetalle.Rows[e.RowIndex].ErrorText = "";

                    // Don't try to validate the 'new row' until finished 
                    // editing since there
                    // is not any point in validating its initial value.
                    if (grdDetalle.Rows[e.RowIndex].IsNewRow) { return; }
                    if (!decimal.TryParse(e.FormattedValue.ToString(),
                        out newDecimal) || newDecimal < 0)
                    {
                        e.Cancel = true;
                        grdDetalle.Rows[e.RowIndex].ErrorText = "Debe ser un valor no negativo";
                    }
                    // Recalcula la ED.
                    this.CalculoTotal();
                    break;
                case "Crédito":

                    // garantizar que el usuario sólo escriba numeros positivos
                    grdDetalle.Rows[e.RowIndex].ErrorText = "";

                    // Don't try to validate the 'new row' until finished 
                    // editing since there
                    // is not any point in validating its initial value.
                    if (grdDetalle.Rows[e.RowIndex].IsNewRow) { return; }
                    if (!decimal.TryParse(e.FormattedValue.ToString(),
                        out newDecimal) || newDecimal < 0)
                    {
                        e.Cancel = true;
                        grdDetalle.Rows[e.RowIndex].ErrorText = "Debe ser un valor no negativo";
                    }
                    // Recalcula la ED.
                    this.CalculoTotal();
                    break;
                case "Cantidad":
                    // Si es salida
                    if (this.cboEntradaSalida.SelectedItem == "Salida")
                    {
                        // Valido Existencia
                        nPos = 0;
                        nTodo = this.grdDetalle.GetCellCount(DataGridViewElementStates.Selected);
                        if (nTodo > 0)
                        {
                            int nFila = this.grdDetalle.SelectedCells[nPos].RowIndex;
                            int nCol = this.grdDetalle.SelectedCells[nPos].ColumnIndex;
                            //   if (Convert.ToString(grdDetalle[nCol, nFila].Value) == "") { break; }; // si codigo es balnco

                            // Mostrar los datos del datatable en el grid
                            decimal nCantidad = Convert.ToDecimal(grdDetalle[3, nFila].Value);
                            string cCod_pro = Convert.ToString(grdDetalle[0, nFila].Value);
                            DataGridViewRow row = new DataGridViewRow();
                            DataSet dsDatos = new DataSet();
                            DataTable dtCatalogo = clsProcesos.DatosGeneral("mproduct", " where trim(cod_pro) = '" + cCod_pro.Trim() + "' ", " order by cod_pro ");
                            dsDatos.Tables.Add(dtCatalogo);
                            if (dsDatos.Tables[0].Rows.Count > 0)
                            {
                                // Mostrar los datos del datatable en el grid
                                foreach (DataRow registro in dsDatos.Tables[0].Rows)
                                {
                                    //  grdDetalle[nCol + 1, nFila].Value = (registro["des_pro"]);                                     
                                    if (nCantidad > Convert.ToDecimal(registro["Cant_exist"]))
                                    {
                                        MessageBox.Show("La Cantidad excede la existencia de " + Convert.ToDecimal(registro["Cant_exist"]).ToString("N") + " para el  producto " + cCod_pro + ", favor verificar",
                                            "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                            }
                        }

                    }

                    // Recalcula la ED.
                    this.CalculoTotal();
                    break;
                default:
                    // Recalcula la ED.
                    this.CalculoTotal();
                    break;
            }

            // Recalcula la ED.
            this.CalculoTotal();
        }

        private void grdDetalle_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error Actual " + anError.Context.ToString() +
                            ", Columna: " + anError.ColumnIndex.ToString() +
                            ", Linea: " + anError.RowIndex.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cambio de Celda");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("Error al dejar el control");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
                anError.ThrowException = false;
            }
        }

        private void grdDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                dgvCombo = e.Control as DataGridViewComboBoxEditingControl;
                if (dgvCombo != null)
                {
                    dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }
        }

        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;

                string cCodigo = combo.SelectedValue.ToString();
                DataSet dsDatos = new DataSet();
                DataTable dtCatalogo = clsProcesos.DatosGeneral("mproduct", " where trim(cod_pro) = '" + cCodigo.Trim() + "' ", " order by cod_pro ");
                dsDatos.Tables.Add(dtCatalogo);
                if (dsDatos.Tables[0].Rows.Count > 0)
                {
                    DataGridViewRow row = grdDetalle.CurrentRow;
                    DataGridViewTextBoxCell cell = row.Cells["Des_Pro"] as DataGridViewTextBoxCell;
                    DataGridViewTextBoxCell cell2 = row.Cells["Cantidad"] as DataGridViewTextBoxCell;
                    DataGridViewTextBoxCell cellCosto = row.Cells["Costo"] as DataGridViewTextBoxCell;

                    // Mostrar el nombre de la cuenta en el grid
                    foreach (DataRow registro in dsDatos.Tables[0].Rows)
                    {
                        cell.Value = (registro["des_pro"]);
                        // if costo o cantidad es cero
                        cellCosto.Value = (registro["Costo"]);
                        cell2.Value = "1";
                    }
                } //  if (dsDatos.Tables[0].Rows.Count > 0)
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                //oTransaccion.Rollback();
                Cursor.Current = Cursors.Default;
                return;
            }


        }

        private void opcImprimir_Click(object sender, EventArgs e)
        {

        }

        private void opcEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdDetalle.Rows.Count > 0)
                {
                    grdDetalle.Rows.Remove(grdDetalle.CurrentRow);
                }
                this.CalculoTotal();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                this.CursorDefault();
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                this.CursorDefault();
                return;
            }
            finally
            {
            }

        }

        // para que el grid pase a la otra columna y no al celda de abajo
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control DataGridView no tiene el foco, y
            // si la celda actual no está siendo editada,
            // abandonamos el procedimiento.
            //

            if ((!grdDetalle.Focused) && (!grdDetalle.IsCurrentCellInEditMode))
                return base.ProcessCmdKey(ref msg, keyData);

            // Si la tecla presionada es distinta de la tecla Enter,
            // abandonamos el procedimiento.            
            if ((keyData != Keys.Return))
                return base.ProcessCmdKey(ref msg, keyData);

            // Obtenemos la celda actual            
            DataGridViewCell cell = grdDetalle.CurrentCell;

            // Índice de la columna.            
            Int32 columnIndex = cell.ColumnIndex;

            // Índice de la fila.            
            Int32 rowIndex = cell.RowIndex;

            if (columnIndex == grdDetalle.Columns.Count - 1)
            {
                if (rowIndex == grdDetalle.Rows.Count - 1)
                {
                    // Seleccionamos la primera columna de la primera fila.                    
                    cell = grdDetalle.Rows[0].Cells[0];
                }
                else
                {
                    // Selecionamos la primera columna de la siguiente fila.                    
                    cell = grdDetalle.Rows[rowIndex + 1].Cells[0];
                }
            }
            else
            {
                // Seleccionamos la celda de la derecha de la celda actual.                
                cell = grdDetalle.Rows[rowIndex].Cells[columnIndex + 1];
            }

            // Si la celda es invisible
            if (cell.Visible == false)
            {
                if (columnIndex == grdDetalle.Columns.Count - 1 || rowIndex == grdDetalle.Rows.Count - 1)
                {   // Se coloca al principio de la linea actual
                    cell = grdDetalle.Rows[rowIndex].Cells[0];
                    grdDetalle.CurrentCell = cell;
                    return true;
                }

                // pasamos a la proxima linea
                // Selecionamos la primera columna de la siguiente fila.                    
                cell = grdDetalle.Rows[rowIndex + 1].Cells[0];
                grdDetalle.CurrentCell = cell;
                return true;
            }
            else
            {
                grdDetalle.CurrentCell = cell;
                return true;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!this.ValidaForm()) { return; }

            switch (cModo)
            {
                case "Nuevo":
                    Grabar();
                    break;

                case "Modificar":
                    //    Actualizar();
                    break;
                default:
                    break;
            }
        }

        private void cmdBuscarItem_Click(object sender, EventArgs e)
        {
            this.BuscarItem();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            frmRepMovInventario ofrmRepMovInventario = new frmRepMovInventario();
            ofrmRepMovInventario.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReimprimeTR ofrmReimprimeTR = new frmReimprimeTR();
            ofrmReimprimeTR.Show();
        }

        private void txtCedulaMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCedulaMedico_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCedula.MaskFull == false)
            {
                //  MessageBox.Show("No se permiten busquedas con el campo cedula vacio...");
                //  txtCedula.Focus();
                return;
            }
            else
            {
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT * from vdoctores WHERE doctores_cedula = '" + txtCedulaMedico.Text.Trim() + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            // txtID.Text = MyReader["id_paciente"].ToString();
                            cmbRangoMedico.SelectedValue = Convert.ToInt32(MyReader["doctores_rango"]);
                            txtNombreMedico.Text = MyReader["doctores_nombre"].ToString();
                            this.txtCedulaMedico.Text = MyReader["doctores_cedula"].ToString();
                            txtApellidoMedico.Text = MyReader["doctores_apellido"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula para le medico");
                        this.txtCedula.Focus();
                    }
                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        private void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            frmBuscarDoctor ofrmBuscarDoctor = new frmBuscarDoctor();
            ofrmBuscarDoctor.ShowDialog();
            string cCodigo = ofrmBuscarDoctor.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedulaMedico.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT * from vdoctores WHERE doctores_cedula = '" + txtCedulaMedico.Text.Trim() + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            // txtID.Text = MyReader["id_paciente"].ToString();
                            cmbRangoMedico.SelectedValue = Convert.ToInt32(MyReader["doctores_rango"]);
                            txtNombreMedico.Text = MyReader["doctores_nombre"].ToString();
                            this.txtCedulaMedico.Text = MyReader["doctores_cedula"].ToString();
                            txtApellidoMedico.Text = MyReader["doctores_apellido"].ToString();
                            /*
                            if (this.imgFoto.ImageLocation == null || this.imgFoto.ImageLocation == "")
                            {
                                if(File.Exists(@MyReader["rutafoto"].ToString()))
                                {
                                this.imgFoto.ImageLocation = @MyReader["rutafoto"].ToString();
                                }
                            }
                            if (this.imgFoto.Image == null)
                            {
                                // valor por defecto
                                //this.imgFoto.Image = System.Drawing.Image.FromFile(@this.Icon);
                              //  this.imgFoto.Image = System.Drawing.Image.FromFile(@MyReader["rutafoto"].ToString());
                            }*/
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...", "SysHospitalARD v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtCedula.Focus();
                    }
                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        
    } // public partial class
}  // Namespace
