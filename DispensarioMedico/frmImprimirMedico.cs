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
    public partial class frmImprimirMedico : frmBase
    {
        string cTabla = "";
        string cCampo = "";
        string cclsConexion = clsConexion.ConectionString;
        

        public frmImprimirMedico()
        {
            InitializeComponent();
        }

        private void frmImprimirMedico_Load(object sender, EventArgs e)
        {

        }

        private void rdoTodos_CheckedChanged(object sender, EventArgs e)
        {
            grbSeleccionarpor.Enabled = false;
            cmbRango.DataSource = null;
            cmbEspecialidad.DataSource = null;
        }

        private void rdoSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            grbSeleccionarpor.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkRango_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRango.Checked)
            {
                cTabla = "rangos";
                cmbRango.DataSource = clsProcesos.DatosGeneral(cTabla);
                cmbRango.DisplayMember = "rangoabrev";
                cmbRango.ValueMember = "rango_id";

            }
            else
            {
                cmbRango.DataSource = null;
            }
        }

        private void chkEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEspecialidad.Checked)
            {
                cTabla = "especialidades";
                cmbEspecialidad.DataSource = clsProcesos.DatosGeneral(cTabla);
                cmbEspecialidad.DisplayMember = "especialidades_descripcion";
                cmbEspecialidad.ValueMember = "especialidades_id";

            }
            else
            {
                cmbEspecialidad.DataSource = null;
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            MySqlConnection oCnn = new MySqlConnection(cclsConexion);
            MySqlCommand oComando = new MySqlCommand();
            MySqlDataAdapter oAdaptador = new MySqlDataAdapter();
            StringBuilder sbQuery = new StringBuilder();
            string cWhere = " where 1 = 1";
            string cUsuario = frmLogin.cUsuarioActual;
            string cTitulo = "";
            try
            {
                oCnn.Open();
                oComando = oCnn.CreateCommand();
                oComando.Connection = oCnn;

                if (rdoSeleccionar.Checked)
                {
                    if (chkM.Checked)
                    {
                        cWhere = cWhere + " and doctores.doctores_sexo = 'M'";
                    }
                    if (chkF.Checked)
                    {
                        cWhere = cWhere + " and doctores.doctores_sexo = 'F'";
                    }
                    if (chkRango.Checked)
                    {
                        cWhere = cWhere + " and doctores.doctores_rango = " + cmbRango.SelectedValue + "";
                    }
                    if (chkEspecialidad.Checked)
                    {
                        cWhere = cWhere + " and doctores.doctores_especialidad = " + cmbEspecialidad.SelectedValue + "";
                    }

                    sbQuery.Clear();
                    sbQuery.Append("select upper(doctores.doctores_rango) as doctores_rango,upper(doctores.doctores_cedula) as doctores_cedula,");
                    sbQuery.Append("upper(doctores.doctores_nombre) as doctores_nombre,upper(doctores.doctores_apellido) as doctores_apellido,");
                    sbQuery.Append("upper(rangos.rangoabrev) as rangoabrev,upper(especialidades.especialidades_descripcion) as especialidades_descripcion");
                    sbQuery.Append(" from doctores");
                    sbQuery.Append(" left join rangos on rangos.rango_id = doctores.doctores_rango");
                    sbQuery.Append(" left join especialidades on especialidades.especialidades_id = doctores.doctores_especialidad");
                    sbQuery.Append(cWhere);
                    //sbQuery.Append(" order by doctores.doctores_rango");
                }
                if (rdoTodos.Checked)
                {
                    sbQuery.Clear();
                    sbQuery.Append("select upper(doctores.doctores_rango) as doctores_rango,upper(doctores.doctores_cedula) as doctores_cedula,");
                    sbQuery.Append("upper(doctores.doctores_nombre) as doctores_nombre,upper(doctores.doctores_apellido) as doctores_apellido,");
                    sbQuery.Append("upper(rangos.rangoabrev) as rangoabrev,upper(especialidades.especialidades_descripcion) as especialidades_descripcion");
                    sbQuery.Append(" from doctores");
                    sbQuery.Append(" left join rangos on rangos.rango_id = doctores.doctores_rango");
                    sbQuery.Append(" left join especialidades on especialidades.especialidades_id = doctores.doctores_especialidad");
                    sbQuery.Append(" order by rangos.orden");
 
                }

                oComando.CommandText = sbQuery.ToString();
                oAdaptador = new MySqlDataAdapter(oComando);
                DataTable dtDoctores = new DataTable();
                oAdaptador.Fill(dtDoctores);
                oCnn.Close();
                int nRegistro = dtDoctores.Rows.Count;
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
                    cTitulo = "REPORTE ESTADISTICO DE MEDICOS";

                    //6to Instanciamos nuestro REPORTE
                    Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    oListado.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtDoctores, oListado, cTitulo);
                    //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                    ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                    ofrmPrinter.ShowDialog();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                return;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
       
    }
}
