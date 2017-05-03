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
    public partial class frmReimprimeTR : frmBase
    {
        DataSet  dsMovBan2 = new DataSet();
        DataTable dtDatos = new DataTable();

        public frmReimprimeTR()
        {
            InitializeComponent();
        }

        private void frmReimprimeTR_Load(object sender, EventArgs e)
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
        }

        private void txtNo_Docum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNo_Docum_Validating(object sender, CancelEventArgs e)
        {
            if (txtNo_Docum.Text.Trim()== "")
            {               
                    MessageBox.Show("Debe digitar el numero de la transaccion!!", "Reimpresion de Transacción", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    CursorDefault();
                    this.Limpiar();
                    return;                
            }

            try
            {
                string cTipoDoc = this.cboT_mov.SelectedValue.ToString().Trim();
                int nNoDoc = Convert.ToInt32(txtNo_Docum.Text);
                //   DataTable dtInvent = Procesos.DatosGeneral("invent"," where no_docum = " + nNoDoc.ToString() + " and tipo_mov = " + cTipoDoc, " order by secuencia");

                string cCero = "0";

                // Inicio clsConexion y transacccion            
                MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
                MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
                MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
                DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
                StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:

                this.Cursor = Cursors.WaitCursor;
                oCnn.ConnectionString = clsConexion.ConectionString;
                string cWhere = " and no_docum = " + nNoDoc.ToString() + " and tipo_mov = " + cTipoDoc ;
                
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

                // visualizo datos paciente
                DataRow DR;
                DR = dsMovBan2.Tables[0].Rows[0];
                //                if (Convert.ToDecimal(DR["Cant_exist"]) < Convert.ToDecimal(registro.Cells["Cantidad"].Value))
                txtCedula.Text = DR["Cedula"].ToString();
                txtApellido.Text = DR["Apellido"].ToString();
                txtNombre.Text = DR["Nombre"].ToString();
                cmbRangoPaciente.SelectedValue = Convert.ToInt32(DR["rango"]);
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

        private void CursorDefault()
        {
            Cursor.Current = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.UseWaitCursor = false;
            Application.UseWaitCursor = false;
        }

        private void Limpiar()
        {
            txtCedula.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            cmbRangoPaciente.SelectedValue = -1;
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                if ( this.txtNo_Docum.Text == "")
                {
                    MessageBox.Show("Debe digitar el numero de la transaccion!!", "Reimpresion de Transacción", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    CursorDefault();
                    this.Limpiar();
                    return;
                }

                if (dsMovBan2.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No hay información para mostrar, favor verificar", "Reimpresion de Transacción", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    CursorDefault();
                    this.Limpiar();
                    return;
                }
                                        
                // Parametros de Fecha para visualizar en el Reporte CR
                DateTime dFechaInicial = DateTime.Now;
                DateTime dFechaFinal = DateTime.Now;

                String cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "Reimpresion de la Transaccion Numero " + txtNo_Docum.Text.Trim() + ", del Tipo "+ cboT_mov.SelectedText.Trim();

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

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNo_Docum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cboT_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNo_Docum.Text = "";
        }

        
        
        }
    
}