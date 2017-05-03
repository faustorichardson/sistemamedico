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
    public partial class frmRepArticulos : frmBase
    {

        public frmRepArticulos()
        {
            InitializeComponent();
        }

        private void frmRepArticulos_Load(object sender, EventArgs e)
        {
            string cTabla;
            string campo;

            cTabla = "mproduct";
            cboArticulos.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboArticulos.DisplayMember = "des_pro";
            cboArticulos.ValueMember = "cod_pro";
            cboArticulos.SelectedIndex = 0;
            campo = "des_pro";
            cboArticulos.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboArticulos.AutoCompleteMode = AutoCompleteMode.None;
            cboArticulos.AutoCompleteSource = AutoCompleteSource.ListItems;

            cTabla = "catego";
            cboFamilia.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboFamilia.DisplayMember = "catego";
            cboFamilia.ValueMember = "cod_cat";
            cboFamilia.SelectedIndex = 0;
            campo = "catego";
            cboFamilia.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboFamilia.AutoCompleteMode = AutoCompleteMode.None;
            cboFamilia.AutoCompleteSource = AutoCompleteSource.ListItems;


            cTabla = "subcatego";
            cboSubCategoria.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboSubCategoria.DisplayMember = "descrip";
            cboSubCategoria.ValueMember = "tipo_pro";
            cboSubCategoria.SelectedIndex = 0;
            campo = "descrip";
            cboSubCategoria.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboSubCategoria.AutoCompleteMode = AutoCompleteMode.None;
            cboSubCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;


            chkArticulos.Checked = true;
            chkInventario.Checked = false;
            chkSubfamilia.Checked = true;
            chkExistencia.Checked = false;
            chkFamilia.Checked = true;

            this.cboFamilia.SelectedIndex = 0;
            this.cboArticulos.SelectedIndex = 0;
            this.cboSubCategoria.SelectedIndex = 0;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            string cCero = "0";
            string cAno = dates.Year(DateTime.Now).ToString();
            string cMes = VFPToolkit.strings.PadL(dates.Month(DateTime.Now).ToString(), 2, Convert.ToChar(cCero));
            string cDia = VFPToolkit.strings.PadL(dates.Day(DateTime.Now).ToString(), 2, Convert.ToChar(cCero));
            string cFechaInicial = "" + cAno + "/" + cMes + "/" + cDia + "";
            cAno = dates.Year(DateTime.Now).ToString();
            cMes = VFPToolkit.strings.PadL(dates.Month(DateTime.Now).ToString(), 2, Convert.ToChar(cCero));
            cDia = VFPToolkit.strings.PadL(dates.Day(DateTime.Now).ToString(), 2, Convert.ToChar(cCero));
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
                string cWhere = " and  1=1 ";
                
                //Articulos
                if (this.chkArticulos.Checked == false)
                {
                    cWhere = cWhere + " AND trim(mproduct.cod_pro) = '" + this.cboArticulos.SelectedValue.ToString().Trim() + "'";
                }

                // Exsitencia
                if (this.chkExistencia.Checked == false)
                {
                    cWhere = cWhere + " AND  mproduct.cant_exist > 0 ";
                }

                // Inventariable
                if (this.chkInventario.Checked == false)
                {

                    cWhere = cWhere + " AND mproduct.inventario = 1 ";                    

                }
                
                // familia
                if (this.chkFamilia.Checked == false)
                {
                    cWhere = cWhere + " AND trim(mproduct.cod_cat) = '" + this.cboFamilia.SelectedValue.ToString().Trim() + "'";
                }

                // subfamilia
                if (this.chkSubfamilia.Checked == false)
                {
                    cWhere = cWhere + " AND trim(mproduct.tipo_pro) = '" + this.cboFamilia.SelectedValue.ToString().Trim() + "'";
                }

                oCnn.Open();
                cmdExec = oCnn.CreateCommand();
                cmdExec.Connection = oCnn;
                cmdExec.CommandTimeout = 0; // para consultas largas

                sbQuery.Clear();
                sbQuery.Append("select mproduct.*,   ");
                sbQuery.Append("config.empresa, config.direccion, config.dependencia,config.telefono1,config.telefono2,config.fax,config.rnc, ");
                sbQuery.Append("config.email, config.website, config.jefe,config.rango_jefe,config.rango_dir,config.director,config.logobmp ");
                sbQuery.Append(" from mproduct, config   ");
                sbQuery.Append(" where 1=1 ");
                sbQuery.Append(cWhere);
                sbQuery.Append("  order by des_pro  ");
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
                DateTime dFechaInicial = Convert.ToDateTime(DateTime.Now);
                DateTime dFechaFinal = Convert.ToDateTime(DateTime.Now);

                String cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "Listado de Articulos y Existencia ";

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

                Reportes.rptArticulos oReporte = new Reportes.rptArticulos();
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

       
    }
}
