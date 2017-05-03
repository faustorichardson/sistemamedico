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
    public partial class frmImprimirProblemaMedico : frmBase
    {
        string cTabla = "";
        string cCampo = "";
        string cCadenaclsConexion = clsConexion.ConectionString;
        public frmImprimirProblemaMedico()
        {
            InitializeComponent();
        }

        private void frmImprimirProblemaMedico_Load(object sender, EventArgs e)
        {
            rdoImprimeCaso.Checked = true;
            //grbBuscarPor.Enabled = false;
            //cboPaciente.Enabled = false;
            //cboPaciente.DataSource = null;
            //txtCedulaPaciente.Text = "";
            //txtCedulaPaciente.Enabled = false;
            btnImprimir.Enabled = false;
        }
        private void BuscarCaso()
        {
            MySqlConnection oCnn = new MySqlConnection(cCadenaclsConexion);
            MySqlCommand oComando = new MySqlCommand();
            MySqlDataAdapter oAdaptador = new MySqlDataAdapter();
            DataTable dtPaciente = new DataTable();
            StringBuilder sbQuery = new StringBuilder();

            
            oComando = oCnn.CreateCommand();            
            oComando.Connection = oCnn;
            oCnn.Open();

            sbQuery.Clear();
            sbQuery.Append("select casomedico.idcasomedico,paciente.nombre,");
            sbQuery.Append("date_format(casomedico.fecha,'%d/%m/%Y') as fecha");
            sbQuery.Append(" from paciente");
            sbQuery.Append(" inner join casomedico on casomedico.cedula_paciente = paciente.cedula");
            sbQuery.Append(" where paciente.cedula = '" + txtCed.Text + "'");
            sbQuery.Append("");

            oComando.CommandText = sbQuery.ToString();
            oAdaptador = new MySqlDataAdapter(oComando);
            oAdaptador.Fill(dtPaciente);

            int nPaciente = dtPaciente.Rows.Count;
            if (nPaciente == 0)
            {
                MessageBox.Show("No Existe Caso Medico de Este Paciente, Favor Verificar",
                    "Sistema Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                foreach (DataRow registro in dtPaciente.Rows)
                {
                    dgvPaciente.Rows.Add(Convert.ToInt32(registro["idcasomedico"]).ToString(),
                        registro["nombre"].ToString(), registro["fecha"].ToString());
 
                }
            }
        }
        private void ImprimirCaso()
        {
            MySqlConnection oCnn = new MySqlConnection(cCadenaclsConexion);
            MySqlCommand oComando = new MySqlCommand();
            MySqlDataAdapter oAdaptador = new MySqlDataAdapter();
            DataTable dtCasomedico = new DataTable();
            StringBuilder sbQuery = new StringBuilder();
            string cWhere = "";
            string cUsuario = frmLogin.cUsuarioActual;
            string cTitulo = "";

            //1ero. Creo mi comando
            // El metodo CreateCommand Crea y devuelve un SqlCommand objeto asociado al SqlConnection .
            oComando = oCnn.CreateCommand();
            //2do. paso la cadena de coneccion al Commando
            //la propiedad Connecti Obtiene o establece el SqlConnection utiliza esta instancia del SqlCommand.
            oComando.Connection = oCnn;
            //abro la coneccion
            oCnn.Open();
            if (rdoImprimeCaso.Checked)
            {
                cWhere = " where casomedico.idcasomedico = " + txtNoCaso.Text + "";
            }
            //if (rdoPaciente.Checked)
            //{
            //    cWhere = " where paciente.id_paciente = " + cboPaciente.SelectedValue + "";
                
            //}
            if (rdoCedula.Checked)
            {
                cWhere = " where paciente.cedula = '" + txtCed.Text + "'";
            }

            sbQuery.Clear();
            sbQuery.Append("select casomedico.idcasomedico,casomedico.cedula_doctor,casomedico.cedula_paciente,");
            sbQuery.Append("casomedico.problema_descripcion,casomedico.problema_objetivo,casomedico.problema_accion,");
            sbQuery.Append("casomedico.problema_prescripcion,casomedico.fecha,");
            sbQuery.Append("doctores.doctores_cedula,doctores.doctores_nombre,");
            sbQuery.Append("doctores.doctores_apellido,doctores.doctores_rango,doctores.doctores_especialidad,");
            sbQuery.Append("paciente.cedula,paciente.rango,paciente.nombre,paciente.apellido,paciente.edad,");
            sbQuery.Append("rangos.rango_descripcion,rangos.rangoabrev,");
            sbQuery.Append("especialidades.especialidades_descripcion");
            sbQuery.Append(" from casomedico");
            sbQuery.Append(" left join doctores on doctores.doctores_cedula = casomedico.cedula_doctor");
            sbQuery.Append(" left join especialidades on especialidades.especialidades_id = doctores.doctores_especialidad");
            sbQuery.Append(" left join paciente on paciente.cedula = casomedico.cedula_paciente");
            sbQuery.Append(" left join rangos on rangos.rango_id = paciente.rango");            
            sbQuery.Append(cWhere);
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");

            oComando.CommandText = sbQuery.ToString();

            oAdaptador = new MySqlDataAdapter(oComando);
            oAdaptador.Fill(dtCasomedico);
            int nRegistro = dtCasomedico.Rows.Count;
            if (nRegistro == 0)
            {
                MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //1ero.HACEMOS LA COLECCION DE PARAMETROS

                //los campos de parametros contiene un objeto para cada campo de parametro en el informe
                ParameterFields oParametrosCR = new ParameterFields();
                //Proporciona propiedades para la recuperacion y configuracion del tipo de los parametros
                ParameterValues oParametrosValuesCR = new ParameterValues();

                //2do.CREAMOS LOS PARAMETROS
                ParameterField oUsuario = new ParameterField();
                //parametervaluetype especifica el TIPO de valor de parametro
                //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                oUsuario.ParameterValueType = ParameterValueKind.StringParameter;

                //3ero.VALORES PARA LOS PARAMETROS
                //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                //parametros de valores discretos
                ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                oUsuarioDValue.Value = cUsuario;

                //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                oUsuario.CurrentValues.Add(oUsuarioDValue);


                //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                oParametrosCR.Add(oUsuario);

                //nombre del parametro en CR (Crystal Reports)
                oParametrosCR[0].Name = "cUsuario";

                //nombre del TITULO DEL INFORME
                cTitulo = "REPORTE PROBLEMAS MEDICO";

                //6to Instanciamos nuestro REPORTE
                Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                //pasamos el nombre del TITULO del Listado
                //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                oListado.SummaryInfo.ReportTitle = cTitulo;

                Reportes.RepProblemaMedicoPaciente oReporte = new Reportes.RepProblemaMedicoPaciente();
                oReporte.SummaryInfo.ReportTitle = cTitulo;

                frmPrinter ofrmPrimter = new frmPrinter(dtCasomedico, oReporte, cTitulo);
                ofrmPrimter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                ofrmPrimter.ShowDialog();
            }
        }

        private void ImprimirCasoSeleccionado()
        {
            MySqlConnection oCnn = new MySqlConnection(cCadenaclsConexion);
            MySqlCommand oComando = new MySqlCommand();
            MySqlDataAdapter oAdaptador = new MySqlDataAdapter();
            DataTable dtCasomedico = new DataTable();
            StringBuilder sbQuery = new StringBuilder();
            string cWhere = "";
            string cUsuario = frmLogin.cUsuarioActual;
            string cTitulo = "";

            //1ero. Creo mi comando
            // El metodo CreateCommand Crea y devuelve un SqlCommand objeto asociado al SqlConnection .
            oComando = oCnn.CreateCommand();
            //2do. paso la cadena de coneccion al Commando
            //la propiedad Connecti Obtiene o establece el SqlConnection utiliza esta instancia del SqlCommand.
            oComando.Connection = oCnn;
            //abro la coneccion
            oCnn.Open();

            

            DataGridViewRow idPaciente = dgvPaciente.CurrentRow;
            sbQuery.Clear();
            sbQuery.Append("select casomedico.idcasomedico,casomedico.cedula_doctor,casomedico.cedula_paciente,");
            sbQuery.Append("casomedico.problema_descripcion,casomedico.problema_objetivo,casomedico.problema_accion,");
            sbQuery.Append("casomedico.problema_prescripcion,casomedico.fecha,");
            sbQuery.Append("doctores.doctores_cedula,doctores.doctores_nombre,");
            sbQuery.Append("doctores.doctores_apellido,doctores.doctores_rango,doctores.doctores_especialidad,");
            sbQuery.Append("paciente.cedula,paciente.rango,paciente.nombre,paciente.apellido,paciente.edad,");
            sbQuery.Append("rangos.rango_descripcion,rangos.rangoabrev,");
            sbQuery.Append("especialidades.especialidades_descripcion");
            sbQuery.Append(" from casomedico");
            sbQuery.Append(" left join doctores on doctores.doctores_cedula = casomedico.cedula_doctor");
            sbQuery.Append(" left join especialidades on especialidades.especialidades_id = doctores.doctores_especialidad");
            sbQuery.Append(" left join paciente on paciente.cedula = casomedico.cedula_paciente");
            sbQuery.Append(" left join rangos on rangos.rango_id = paciente.rango");
            sbQuery.Append(" where casomedico.idcasomedico = " + Convert.ToInt32(idPaciente.Cells["NoCaso"].Value) + "");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");

            oComando.CommandText = sbQuery.ToString();

            oAdaptador = new MySqlDataAdapter(oComando);
            oAdaptador.Fill(dtCasomedico);
            int nRegistro = dtCasomedico.Rows.Count;
            if (nRegistro == 0)
            {
                MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //1ero.HACEMOS LA COLECCION DE PARAMETROS

                //los campos de parametros contiene un objeto para cada campo de parametro en el informe
                ParameterFields oParametrosCR = new ParameterFields();
                //Proporciona propiedades para la recuperacion y configuracion del tipo de los parametros
                ParameterValues oParametrosValuesCR = new ParameterValues();

                //2do.CREAMOS LOS PARAMETROS
                ParameterField oUsuario = new ParameterField();
                //parametervaluetype especifica el TIPO de valor de parametro
                //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                oUsuario.ParameterValueType = ParameterValueKind.StringParameter;

                //3ero.VALORES PARA LOS PARAMETROS
                //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                //parametros de valores discretos
                ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                oUsuarioDValue.Value = cUsuario;

                //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                oUsuario.CurrentValues.Add(oUsuarioDValue);


                //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                oParametrosCR.Add(oUsuario);

                //nombre del parametro en CR (Crystal Reports)
                oParametrosCR[0].Name = "cUsuario";

                //nombre del TITULO DEL INFORME
                cTitulo = "REPORTE PROBLEMAS MEDICO";

                //6to Instanciamos nuestro REPORTE
                Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                //pasamos el nombre del TITULO del Listado
                //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                oListado.SummaryInfo.ReportTitle = cTitulo;

                Reportes.RepProblemaMedicoPaciente oReporte = new Reportes.RepProblemaMedicoPaciente();
                oReporte.SummaryInfo.ReportTitle = cTitulo;

                frmPrinter ofrmPrimter = new frmPrinter(dtCasomedico, oReporte, cTitulo);
                ofrmPrimter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                ofrmPrimter.ShowDialog();
            }
        }
        private void ImprimirTodos()
        {
            MySqlConnection oCnn = new MySqlConnection(cCadenaclsConexion);
            MySqlCommand oComando = new MySqlCommand();
            MySqlDataAdapter oAdaptador = new MySqlDataAdapter();
            DataTable dtCasomedico = new DataTable();
            StringBuilder sbQuery = new StringBuilder();
            string cWhere = "";
            string cUsuario = frmLogin.cUsuarioActual;
            string cTitulo = "";

            //1ero. Creo mi comando
            // El metodo CreateCommand Crea y devuelve un SqlCommand objeto asociado al SqlConnection .
            oComando = oCnn.CreateCommand();
            //2do. paso la cadena de coneccion al Commando
            //la propiedad Connecti Obtiene o establece el SqlConnection utiliza esta instancia del SqlCommand.
            oComando.Connection = oCnn;
            //abro la coneccion
            oCnn.Open();


            DataGridViewRow NombrePaciente = dgvPaciente.CurrentRow;
            sbQuery.Clear();
            sbQuery.Append("select casomedico.idcasomedico,casomedico.cedula_doctor,casomedico.cedula_paciente,");
            sbQuery.Append("casomedico.problema_descripcion,casomedico.problema_objetivo,casomedico.problema_accion,");
            sbQuery.Append("casomedico.problema_prescripcion,casomedico.fecha,");
            sbQuery.Append("doctores.doctores_cedula,doctores.doctores_nombre,");
            sbQuery.Append("doctores.doctores_apellido,doctores.doctores_rango,doctores.doctores_especialidad,");
            sbQuery.Append("paciente.cedula,paciente.rango,paciente.nombre,paciente.apellido,paciente.edad,");
            sbQuery.Append("rangos.rango_descripcion,rangos.rangoabrev,");
            sbQuery.Append("especialidades.especialidades_descripcion");
            sbQuery.Append(" from casomedico");
            sbQuery.Append(" left join doctores on doctores.doctores_cedula = casomedico.cedula_doctor");
            sbQuery.Append(" left join especialidades on especialidades.especialidades_id = doctores.doctores_especialidad");
            sbQuery.Append(" left join paciente on paciente.cedula = casomedico.cedula_paciente");
            sbQuery.Append(" left join rangos on rangos.rango_id = paciente.rango");
            sbQuery.Append(" where paciente.nombre = '" + Convert.ToString(NombrePaciente.Cells["paciente"].Value) + "'");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");
            sbQuery.Append("");

            oComando.CommandText = sbQuery.ToString();

            oAdaptador = new MySqlDataAdapter(oComando);
            oAdaptador.Fill(dtCasomedico);
            int nRegistro = dtCasomedico.Rows.Count;
            if (nRegistro == 0)
            {
                MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //1ero.HACEMOS LA COLECCION DE PARAMETROS

                //los campos de parametros contiene un objeto para cada campo de parametro en el informe
                ParameterFields oParametrosCR = new ParameterFields();
                //Proporciona propiedades para la recuperacion y configuracion del tipo de los parametros
                ParameterValues oParametrosValuesCR = new ParameterValues();

                //2do.CREAMOS LOS PARAMETROS
                ParameterField oUsuario = new ParameterField();
                //parametervaluetype especifica el TIPO de valor de parametro
                //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                oUsuario.ParameterValueType = ParameterValueKind.StringParameter;

                //3ero.VALORES PARA LOS PARAMETROS
                //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                //parametros de valores discretos
                ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                oUsuarioDValue.Value = cUsuario;

                //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                oUsuario.CurrentValues.Add(oUsuarioDValue);


                //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                oParametrosCR.Add(oUsuario);

                //nombre del parametro en CR (Crystal Reports)
                oParametrosCR[0].Name = "cUsuario";

                //nombre del TITULO DEL INFORME
                cTitulo = "REPORTE PROBLEMAS MEDICO";

                //6to Instanciamos nuestro REPORTE
                Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                //pasamos el nombre del TITULO del Listado
                //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                oListado.SummaryInfo.ReportTitle = cTitulo;

                Reportes.RepProblemaMedicoPaciente oReporte = new Reportes.RepProblemaMedicoPaciente();
                oReporte.SummaryInfo.ReportTitle = cTitulo;

                frmPrinter ofrmPrimter = new frmPrinter(dtCasomedico, oReporte, cTitulo);
                ofrmPrimter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                ofrmPrimter.ShowDialog();
            }
        }
        private void txtNoCaso_Leave(object sender, EventArgs e)
        {
           
        }

        

        private void rdoCedula_CheckedChanged(object sender, EventArgs e)
        {

            txtNoCaso.Clear();
           // rdoImprimeCaso.Checked = false;
            if (rdoCedula.Checked)
            {
                txtCed.ReadOnly = false;
                txtNoCaso.ReadOnly = true;
                
                ////cboPaciente.Enabled = false;
                ////cboPaciente.DataSource = null;
                dgvPaciente.Rows.Clear();
                txtCed.Focus();
            }
            else
            {
                txtCed.ReadOnly = true;
                //cboPaciente.Enabled = false;
 
            }
        }

        private void rdoImprimeCaso_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoImprimeCaso.Checked)
            {
                txtNoCaso.ReadOnly = false;
                //grbBuscarPor.Enabled = false;
                //cboPaciente.Enabled = false;
                //cboPaciente.DataSource = null;
                txtCed.Text = "";
                txtCed.ReadOnly = true;
                //rdoPaciente.Checked = false;
                //rdoCedula.Checked = false;
                dgvPaciente.Rows.Clear();
                txtNoCaso.Focus();
            }
        }

       

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboPaciente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BuscarCaso();
        }
               

        private void mnuReImprimirSel_Click(object sender, EventArgs e)
        {
            ImprimirCasoSeleccionado();
        }

        private void mnuImprimirListado_Click(object sender, EventArgs e)
        {
            ImprimirTodos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            rdoImprimeCaso.Checked = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string captura = txtCed.Text;
            if (rdoImprimeCaso.Checked)
            {
                if (txtNoCaso.Text != "")
                {
                    ImprimirCaso();
                }
            }

            if (rdoCedula.Checked)
            {
                if (txtCed.TextLength != 13) { }
                else
                {
                    ImprimirCaso();
                }
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCed_Leave(object sender, EventArgs e)
        {
            //txtCed.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //string cCedula = txtCed.Text;
            //if (cCedula.Length < 13)
            //{
            //    MessageBox.Show("Cedula Incompleta, Favor Verificar", "Sistema Medico",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btnImprimir.Enabled = false;
            //}
            //else
            //{
            //    btnImprimir.Enabled = true;
            //}  
        }

        private void txtNoCaso_Validated(object sender, EventArgs e)
        {
           

        }

        private void txtCed_MaskChanged(object sender, EventArgs e)
        
        {

            
        }

        private void txtNoCaso_Validating(object sender, CancelEventArgs e)
        {

        }

        private void rdoCedula_Click(object sender, EventArgs e)
        {
            //txtNoCaso.
        }

        private void txtCed_Validated(object sender, EventArgs e)
        {
            //txtCed.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string cCedula = txtCed.Text;
            if (cCedula.Length < 13)
            {
                MessageBox.Show("Cedula Incompleta, Favor Verificar", "Sistema Medico",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnImprimir.Enabled = false;
            }
            else
            {
                btnImprimir.Enabled = true;
            }  
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (rdoCedula.Checked)
            {
                //txtCed.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string cCedula = txtCed.Text;
                if (cCedula.Length < 13)
                {
                    MessageBox.Show("Cedula Incompleta, Favor Verificar", "Sistema Medico", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    BuscarCaso();
                }

            }
        }

        private void txtNoCaso_TextChanged(object sender, EventArgs e)
        {
            if (txtNoCaso.Text != "")
            {
                btnImprimir.Enabled = true;
            }
            else
            {
                btnImprimir.Enabled = false;
            }
        }

        private void txtCed_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        }

        private void txtCed_Click(object sender, EventArgs e)
        {
            txtCed.Text = "";
        }

       

      
        

        //private void cboPaciente_SelectionChangeCommitted_1(object sender, EventArgs e)
        //{

        //}

       
        
       
        

       
    }
}
