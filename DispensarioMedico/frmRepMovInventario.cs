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
    public partial class frmRepMovInventario : frmBase
    {
        public frmRepMovInventario()
        {
            InitializeComponent();
        }

        private void frmRepMovInventario_Load(object sender, EventArgs e)
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

            cTabla = "rangos";
            cmbRangoPaciente.DataSource = clsProcesos.DatosGeneral(cTabla);
            cmbRangoPaciente.DisplayMember = "rango_descripcion";
            cmbRangoPaciente.ValueMember = "rango_id";
            cmbRangoPaciente.SelectedIndex = 0;
            campo = "rango_descripcion";
            cmbRangoPaciente.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cmbRangoPaciente.AutoCompleteMode = AutoCompleteMode.None;
            cmbRangoPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

            cTabla = "mproduct";
            cboArticulos.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboArticulos.DisplayMember = "des_pro";
            cboArticulos.ValueMember = "cod_pro";
            cboArticulos.SelectedIndex = 0;
            campo = "des_pro";
            cboArticulos.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboArticulos.AutoCompleteMode = AutoCompleteMode.None;
            cboArticulos.AutoCompleteSource = AutoCompleteSource.ListItems;

            chkArticulos.Checked = true;
            chkMiembros.Checked = true;
            chkT_Mov.Checked = true;
            chkEntradaSalida.Checked = true;

            cboArticulos.SelectedIndex = 0;
            cboEntradaSalida.SelectedIndex = 0;
            cboT_mov.SelectedIndex = 0;


        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            string cCero = "0";
            string cAno = dates.Year(dtpDesde.Value).ToString();
            string cMes = VFPToolkit.strings.PadL(dates.Month(dtpDesde.Value).ToString(), 2, Convert.ToChar(cCero));
            string cDia = VFPToolkit.strings.PadL(dates.Day(dtpDesde.Value).ToString(), 2, Convert.ToChar(cCero));
            string cFechaInicial = "" + cAno + "/" + cMes + "/" + cDia + "";
            cAno = dates.Year(dtpHasta.Value).ToString();
            cMes = VFPToolkit.strings.PadL(dates.Month(dtpHasta.Value).ToString(), 2, Convert.ToChar(cCero));
            cDia = VFPToolkit.strings.PadL(dates.Day(dtpHasta.Value).ToString(), 2, Convert.ToChar(cCero));
            string cFechafinal = "" + cAno + "/" + cMes + "/" + cDia + "";

            // Inicio clsConexion y transacccion            
            MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
            MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
            MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
            DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
            StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:
            MySqlTransaction oTransaccion = null;

            this.Cursor = Cursors.WaitCursor;
            oCnn.ConnectionString = clsConexion.ConectionString;

            try
            {                
                string cWhere = " and date(invent.fecha) BETWEEN '" + cFechaInicial + "' and '" + cFechafinal + "'";                              

                //Articulos
                if ( this.chkArticulos .Checked == false)
                {
                    cWhere = cWhere + " AND trim(invent.cod_1) = '" + this.cboArticulos.SelectedValue.ToString().Trim() + "'";
                }

                //Tipo Doc
                if ( this.chkT_Mov.Checked == false)
                {
                    cWhere = cWhere + " AND trim(invent.tipo_mo) = '" + cboT_mov.SelectedValue.ToString().Trim() + "'";
                }

                //Tipo Trasac
                if (this.chkEntradaSalida.Checked == false)
                {
                    if (this.cboEntradaSalida.SelectedItem == "Entrada")
                    {
                        cWhere = cWhere + " AND invent.cantidad > 0 " ;
                    }
                    else
                    {
                        cWhere = cWhere + " AND invent.cantidad < 0 " ;
                    }

                }

                //Miembros
                if (this.chkMiembros.Checked == false)
                {
                    cWhere = cWhere + " AND trim(invent.cedula) = '" + txtCedula.Text.Trim() + "'";
                }

               
                oCnn.Open();
                cmdExec = oCnn.CreateCommand();
                cmdExec.Connection = oCnn;
                cmdExec.CommandTimeout = 0; // para consultas largas

                sbQuery.Clear();
                sbQuery.Append("select invent.*, T_mov.t_mov, mproduct.des_pro,  ");
                sbQuery.Append("paciente.id_paciente,paciente.nombre,paciente.apellido,paciente.rango,");
                sbQuery.Append("rangos.RangoAbrev,");
                sbQuery.Append("config.empresa, config.direccion, config.dependencia,config.telefono1,config.telefono2,config.fax,config.rnc, ");
                sbQuery.Append("config.email, config.website, config.jefe,config.rango_jefe,config.rango_dir,config.director,config.logobmp ");
                sbQuery.Append("FROM invent,paciente,config,T_mov, mproduct,rangos");
                sbQuery.Append(" WHERE invent.tipo_mov = t_mov.codigo ");
                sbQuery.Append(" and trim(invent.cod_1) = trim(mproduct.cod_pro) ");                
                sbQuery.Append(" and invent.cedula = paciente.cedula ");
                sbQuery.Append(" and paciente.rango = rangos.rango_id ");
                sbQuery.Append(cWhere);
                sbQuery.Append(" group by invent.fecha,invent.secuencia ");                
                

                // temporal
                VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                cmdExec.CommandText = sbQuery.ToString();

                daDatos = new MySqlDataAdapter(cmdExec);
                DataSet dsMovBan2 = new DataSet();
                daDatos.Fill(dsMovBan2);

                int nRegistros = dsMovBan2.Tables[0].Rows.Count;
                if (nRegistros == 0)
                {
                    MessageBox.Show("No hay información para mostrar, favor verificar", "Mostrando Reporte de Movimientos Bancarios", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    CursorDefault();
                    return;
                }

                oCnn.Close();

                // Parametros de Fecha para visualizar en el Reporte CR
                DateTime dFechaInicial = Convert.ToDateTime(this.dtpDesde.Value);
                DateTime dFechaFinal = Convert.ToDateTime(this.dtpHasta.Value);

                String cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "Listado de Transacciones desde " + VFPToolkit.dates.TTOD(dFechaInicial).ToString() + " hasta " + dates.TTOD(dFechaFinal).ToString();

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

                Reportes.rptMovInventario oReporte = new Reportes.rptMovInventario();
               frmPrinter ofrmPrinter = new frmPrinter(dsMovBan2.Tables[0], oReporte, cTitulo);
                ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
               ofrmPrinter.ShowDialog();
               CursorDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                CursorDefault();
                return;
            }
        }

        private void CursorDefault()
        {
            Cursor.Current = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.UseWaitCursor = false;
            Application.UseWaitCursor = false;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCedula_Validating(object sender, CancelEventArgs e)
        {
            if (txtCedula.Text == "")
            {
                MessageBox.Show("No se permiten busquedas con el campo cedula vacio...","SysHospitalARD v1.0",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

                            /*
                            if (this.imgFoto.ImageLocation == null || this.imgFoto.ImageLocation == "")
                            {
                                if (File.Exists(@MyReader["rutafoto"].ToString()))
                                {
                                    this.imgFoto.ImageLocation = @MyReader["rutafoto"].ToString();
                                }
                            }
                            if (this.imgFoto.Image == null)
                            {
                                // valor por defecto
                                //this.imgFoto.Image = System.Drawing.Image.FromFile(@this.Icon);
                                //  this.imgFoto.Image = System.Drawing.Image.FromFile(@MyReader["rutafoto"].ToString());
                            }
                             * */
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

                            /*
                            if (this.imgFoto.ImageLocation == null || this.imgFoto.ImageLocation == "")
                            {
                                if (File.Exists(@MyReader["rutafoto"].ToString()))
                                {
                                    this.imgFoto.ImageLocation = @MyReader["rutafoto"].ToString();
                                }
                            }
                            if (this.imgFoto.Image == null)
                            {
                                // valor por defecto
                                //this.imgFoto.Image = System.Drawing.Image.FromFile(@this.Icon);
                                //  this.imgFoto.Image = System.Drawing.Image.FromFile(@MyReader["rutafoto"].ToString());
                            }
                             * */
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

        private void cmdBuscarArticulos_Click(object sender, EventArgs e)
        {          

            frmBuscarArticulo ofrmBuscarCatalogo = new frmBuscarArticulo();
            ofrmBuscarCatalogo.ShowDialog();
            string cCodigo = ofrmBuscarCatalogo.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo de la centa en la cedlda del grid                          
                cboArticulos.SelectedValue = Convert.ToString(cCodigo).Trim();                
            }
        }



    }
}
