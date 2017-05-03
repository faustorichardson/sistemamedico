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

namespace DispensarioMedico
{
    public partial class frmMaestroDepartamento : frmBase
    {

        string cModo = "Inicio";

        public frmMaestroDepartamento()
        {
            InitializeComponent();
        }

        private void ProximoCodigo() 
        {
            try
            {
                // Step 1 - Connection stablished
                MySqlConnection MyclsConexion = new MySqlConnection("Server=localhost;Database=mdeg_dispensariomedico;Uid=root;Pwd=*010405;");

                // Step 2 - Create command
                MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                // Step 3 - Set the commanndtext property
                MyCommand.CommandText = "SELECT count(*) FROM departamentos";

                // Step 4 - Open connection
                MyclsConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtIDDepartamento.Text = Convert.ToString(codigo);
                txtDepartamento.Focus();

                // Step 5 - Close the connection
                MyclsConexion.Close();
            }
            catch (MySqlException MyEx)
            {
                MessageBox.Show(MyEx.Message);                
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();            
            this.txtIDDepartamento.ReadOnly = true;
            this.txtDepartamento.ReadOnly = false;
            this.txtDepartamento.Focus();
        }

        private void Limpiar()
        {
            txtDepartamento.Clear();
            txtIDDepartamento.Clear();
        }

        private void Botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    txtIDDepartamento.ReadOnly = false;
                    txtDepartamento.ReadOnly = true;
                    cmbTipo.Enabled = false;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    txtIDDepartamento.ReadOnly = true;
                    txtDepartamento.ReadOnly = false;
                    cmbTipo.Enabled = true;
                    txtDepartamento.Focus();
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    txtIDDepartamento.ReadOnly = true;
                    txtDepartamento.ReadOnly = true;
                    cmbTipo.Enabled = true;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    txtIDDepartamento.ReadOnly = true;
                    txtDepartamento.ReadOnly = false;
                    cmbTipo.Enabled = true;
                    txtDepartamento.Focus();                   
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    txtIDDepartamento.ReadOnly = false;
                    txtDepartamento.ReadOnly = true;
                    cmbTipo.Enabled = false;
                    txtIDDepartamento.Focus();                    
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    break;

                default:
                    break;
            }
        } // fin Botones

        private void frmMaestroDepartamento_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            cModo = "Inicio";
            this.Botones();
            FillComboTipoEspecialidad();
        }

        private void FillComboTipoEspecialidad()
        {
            // Step 1 
            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyclsConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id_tipoespecialidad, descripcion_tipoespecialidad FROM especialidades_tipo ORDER BY descripcion_tipoespecialidad ASC", MyclsConexion);

            // Step 4
            MySqlDataReader MyReaderEspecialidad;
            MyReaderEspecialidad = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTableEspecialidad = new DataTable();
            MyDataTableEspecialidad.Columns.Add("id_tipoespecialidad", typeof(int));
            MyDataTableEspecialidad.Columns.Add("descripcion_tipoespecialidad", typeof(string));
            MyDataTableEspecialidad.Load(MyReaderEspecialidad);

            // Step 6
            cmbTipo.ValueMember = "id_tipoespecialidad";
            cmbTipo.DisplayMember = "descripcion_tipoespecialidad";
            cmbTipo.DataSource = MyDataTableEspecialidad;

            // Step 7
            MyclsConexion.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Text != "")
            {
                DialogResult Result = MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Dispensario Medico - A.R.D. v1.0", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Grabar";
                        btnGrabar_Click(sender, e);
                        break;

                    case DialogResult.No:
                        cModo = "Inicio";
                        this.Botones();
                        this.Limpiar();
                        break;
                }

            }
            else
            {
                cModo = "Inicio";
                this.Botones();
                this.Limpiar();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (txtDepartamento.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtDepartamento.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyclsConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "INSERT INTO departamentos(departamento_descripcion, departamento_tipoespecialidad)" +
                            " values(@departamento, @tipoespecialidad)";
                        myCommand.Parameters.AddWithValue("@departamento", txtDepartamento.Text);
                        myCommand.Parameters.AddWithValue("@tipoespecialidad", cmbTipo.SelectedValue);

                        // Step 4 - Opening the connection
                        MyclsConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection
                        MyclsConexion.Close();

                        MessageBox.Show("Informacion guardada satisfactoriamente...");
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }

                }
                else
                {
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyclsConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "UPDATE departamentos SET departamento_descripcion = @departamento WHERE departamento_id= "+ txtIDDepartamento.Text +"";
                        myCommand.Parameters.AddWithValue("@departamento", txtDepartamento.Text);

                        // Step 4 - Opening the connection
                        MyclsConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection
                        MyclsConexion.Close();

                        MessageBox.Show("Informacion actualizada satisfactoriamente...");
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }

                }

                this.Limpiar();
                cModo = "Inicio";
                this.Botones();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIDDepartamento.Text == "")
            {
                MessageBox.Show("No se permiten busquedas vacias...");
                txtIDDepartamento.Focus();
            }
            else
            {
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3
                    MyCommand.CommandText = "SELECT departamento_descripcion FROM departamentos WHERE departamento_id = " + txtIDDepartamento.Text + "";

                    // Step 4
                    MyclsConexion.Open();

                    // Step 5
                    string MyText = Convert.ToString(MyCommand.ExecuteScalar());

                    // Step 6
                    this.txtDepartamento.Text = MyText;

                    // Step 7
                    MyclsConexion.Close();
                    
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }

                if (txtDepartamento.Text == "")
                {
                    MessageBox.Show("No se encontraron registros...");
                    this.cModo = "Inicio";
                    this.Botones();
                    this.Limpiar();
                    this.txtIDDepartamento.Focus();
                }
                else
                {
                    this.cModo = "Buscar";
                    this.Botones();                    
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se borra informacion...");
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
                // CREANDO EL QUERY DE CONSULTA
                //string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                //string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                //cWhere = cWhere + " AND fechacita >= "+"'"+ fechadesde +"'" +" AND fechacita <= "+"'"+ fechahasta +"'"+"";
                //cWhere = cWhere + " AND year = '" + txtYear.Text + "'";
                sbQuery.Clear();
                sbQuery.Append("SELECT departamentos.departamento_id as ID, departamentos.departamento_descripcion as Departamento,");
                sbQuery.Append(" especialidades_tipo.descripcion_tipoespecialidad as TipoEspecialidad");
                sbQuery.Append(" FROM departamentos");
                sbQuery.Append(" INNER JOIN especialidades_tipo ON departamentos.departamento_tipoespecialidad = especialidades_tipo.id_tipoespecialidad");
                sbQuery.Append(cWhere);

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();

                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);

                // Creo el objeto Data Table
                DataTable dtDepartamentos = new DataTable();

                // Lleno el data adapter
                myAdapter.Fill(dtDepartamentos);

                // Cierro el objeto clsConexion
                myclsConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtDepartamentos.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "LISTADO DE DEPARTAMENTOS POR TIPOS DE ESPECIALIDADES";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    Reportes.rptDepartamentos orptDepartamentos = new Reportes.rptDepartamentos();
                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptDepartamentos.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtDepartamentos, orptDepartamentos, cTitulo);
                    //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.                                                            
                    ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                    ofrmPrinter.ShowDialog();
                }
            }
            catch (Exception myEx)
            {
                MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                // clsExceptionLog.LogError(myEx, false);
                return;
            }        
        }        

    }
}
