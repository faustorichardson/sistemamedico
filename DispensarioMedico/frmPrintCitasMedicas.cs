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
using CrystalDecisions.VSDesigner;
using CrystalDecisions.Web;
using CrystalDecisions.Windows;
using System.Drawing.Imaging;
using System.IO;
using VFPToolkit;

namespace DispensarioMedico
{
    public partial class frmPrintCitasMedicas : frmBase
    {        

        public frmPrintCitasMedicas()
        {
            InitializeComponent();
        }

        private void frmPrintCitasMedicas_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            txtCedula.Enabled = false;
            cmbEspecialidad.Enabled = false;
            fechaDesde.Focus();
        }

        private void Limpiar()
        {
            txtCedula.Clear();
            cmbEspecialidad.ResetText();
        }

        private void rbDoctor_CheckedChanged(object sender, EventArgs e)
        {
            cmbEspecialidad.Enabled = false;
            cmbEspecialidad.ResetText();
            txtCedula.Enabled = true;
            txtCedula.Focus();
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtCedula.Enabled = false;
            cmbEspecialidad.Enabled = false;
            txtCedula.Clear();
            cmbEspecialidad.ResetText();
        }

        private void rbEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            txtCedula.Enabled = false;
            cmbEspecialidad.Enabled = true;
            fillComboEspecialidad();
        }

        private void fillComboEspecialidad(){
            try
            {
                // Step 1 
	            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyclsConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT departamento_id, departamento_descripcion FROM departamentos ORDER BY departamento_descripcion ASC", MyclsConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("departamento_id", typeof(int));
                MyDataTable.Columns.Add("departamento_descripcion", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbEspecialidad.ValueMember = "departamento_id";
                cmbEspecialidad.DisplayMember = "departamento_descripcion";
                cmbEspecialidad.DataSource = MyDataTable;

                // Step 7
                MyclsConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);                
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //clsConexion a la base de datos
            MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);            
            // Creando el command que ejecutare
            MySqlCommand myCommand = new MySqlCommand();
            // Creando el Data Adapter
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            // Creando el String Builder
            StringBuilder sbQuery = new StringBuilder();            
            // Otras variables del entorno
            string cWhere = " WHERE 1 = 1";
            string cUsuario = frmLogin.cUsuarioActual;
            string cTitulo = "";

            try
            {
                // Abro clsConexion
                myclsConexion.Open();
                // Creo comando
                myCommand = myclsConexion.CreateCommand();
                // Adhiero el comando a la clsConexion
                myCommand.Connection = myclsConexion;
                // Filtros de la busqueda
                if (rbTodos.Checked)
                {
                    string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND fechacita >= "+"'"+ fechadesde +"'" +" AND fechacita <= "+"'"+ fechahasta +"'"+"";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT cita.idcita,cita.fechacita,cita.cedulapaciente,upper(CONCAT(rTRIM(paciente.nombre),' ',LTRIM(paciente.apellido))) as paciente,");
                    sbQuery.Append(" doctores.doctores_cedula,upper(CONCAT(rTRIM(doctores.doctores_nombre),' ',LTRIM(doctores.doctores_apellido))) as doctor,departamentos.departamento_descripcion");
                    sbQuery.Append(" FROM cita ");
                    sbQuery.Append(" INNER JOIN paciente ON paciente.cedula = cita.cedulapaciente");
                    sbQuery.Append(" INNER JOIN doctores ON doctores.doctores_cedula = cita.ceduladoctor");
                    sbQuery.Append(" INNER JOIN departamentos ON departamentos.departamento_id = cita.referimiento");
                    sbQuery.Append(cWhere);
                }
                else if (rbDoctor.Checked)
                {
                    string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                    cWhere = cWhere + " AND ceduladoctor = " +"'"+ txtCedula.Text +"'"+"";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT cita.idcita,cita.fechacita,cita.cedulapaciente,upper(CONCAT(rtrim(paciente.nombre),' ',ltrim(paciente.apellido))) as paciente,");
                    sbQuery.Append(" doctores.doctores_cedula,upper(CONCAT(rTRIM(doctores.doctores_nombre),' ',ltrim(doctores.doctores_apellido))) as doctor,departamentos.departamento_descripcion");
                    sbQuery.Append(" FROM cita ");
                    sbQuery.Append(" INNER JOIN paciente ON paciente.cedula = cita.cedulapaciente");
                    sbQuery.Append(" INNER JOIN doctores ON doctores.doctores_cedula = cita.ceduladoctor");
                    sbQuery.Append(" INNER JOIN departamentos ON departamentos.departamento_id = cita.referimiento");
                    sbQuery.Append(cWhere);
                }
                else if (rbEspecialidad.Checked)
                {
                    string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");                    
                    string varEspecialidad = (cmbEspecialidad.SelectedValue).ToString();
                    cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                    cWhere = cWhere + " AND referimiento = " + varEspecialidad +"";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT cita.idcita,cita.fechacita,cita.cedulapaciente,upper(CONCAT(rtrim(paciente.nombre),' ',ltrim(paciente.apellido))) as paciente,");
                    sbQuery.Append(" doctores.doctores_cedula,upper(CONCAT(rtrim(doctores.doctores_nombre),' ',ltrim(doctores.doctores_apellido))) as doctor,departamentos.departamento_descripcion");
                    sbQuery.Append(" FROM cita ");
                    sbQuery.Append(" INNER JOIN paciente ON paciente.cedula = cita.cedulapaciente");
                    sbQuery.Append(" INNER JOIN doctores ON doctores.doctores_cedula = cita.ceduladoctor");
                    sbQuery.Append(" INNER JOIN departamentos ON departamentos.departamento_id = cita.referimiento");
                    sbQuery.Append(cWhere);
                }

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtCita = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtCita);
                // Cierro el objeto clsConexion
                myclsConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtCita.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Dispensario Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "REPORTE DE CITAS MEDICAS";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    Reportes.rptCitas orptCitas = new Reportes.rptCitas();
                    
                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                   // oListado.SummaryInfo.ReportTitle = cTitulo;

                    orptCitas.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtCita, orptCitas, cTitulo);
                    
                    //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                    ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                    ofrmPrinter.ShowDialog();
                }


            }
            catch (Exception myEx)
            {
                MessageBox.Show("Error : " +  myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(myEx, false);
                return;
            }
        }

    }
}
