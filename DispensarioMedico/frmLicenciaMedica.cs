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
    public partial class frmLicenciaMedica : frmBase
    {
        string cModo = "Inicio";

        public frmLicenciaMedica()
        {
            InitializeComponent();
        }

        private void botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtIdLicencia.Enabled = true;
                    this.txtCedulaDoctor.Enabled = false;
                    this.txtCedulaPaciente.Enabled = false;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtIdLicencia.Enabled = false;
                    this.txtCedulaDoctor.Enabled = true;
                    this.txtCedulaPaciente.Enabled = true;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtIdLicencia.Enabled = false;
                    this.txtCedulaDoctor.Enabled = false;
                    this.txtCedulaPaciente.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtIdLicencia.Enabled = false;
                    this.txtCedulaDoctor.Enabled = true;
                    this.txtCedulaPaciente.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtIdLicencia.Enabled = true;
                    this.txtCedulaDoctor.Enabled = false;
                    this.txtCedulaPaciente.Enabled = false;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtIdLicencia.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarDoctor_Click(object sender, EventArgs e)
        {
            frmBuscarDoctor ofrmBuscarDoctor = new frmBuscarDoctor();
            ofrmBuscarDoctor.ShowDialog();
            string cCodigo = ofrmBuscarDoctor.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedulaDoctor.Text = Convert.ToString(cCodigo).Trim();
            }
            
            if (txtCedulaDoctor.Text != "")
            {
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    MyCommand.CommandText = "SELECT doctores_rango, doctores_especialidad, doctores_nombre, doctores_apellido " +
                        "FROM doctores WHERE doctores_cedula =" + "'" + txtCedulaDoctor.Text + "'" + "";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            cmbRangoDoctor.SelectedValue = MyReader["doctores_rango"].ToString();
                            cmbEspecialidad.SelectedValue = MyReader["doctores_especialidad"].ToString();
                            txtNombreDoctor.Text = MyReader["doctores_nombre"].ToString();
                            txtApellidoDoctor.Text = MyReader["doctores_apellido"].ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.txtCedulaDoctor.Clear();
                        this.txtNombreDoctor.Clear();
                        this.txtApellidoDoctor.Clear();
                        this.txtCedulaDoctor.Focus();
                    }

                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception myEx)
                {
                    MessageBox.Show(myEx.Message);
                }
            }
        }

        private void frmLicenciaMedica_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.botones();
            this.fillComboRangoDoctor();
            this.fillComboRangoPaciente();
            this.fillComboEspecialidad();
            this.fillComboDepartamento();
            this.fillComboSeccionNaval();
            this.txtCedulaDoctor.Focus();
        }

        private void fillComboEspecialidad()
        {
            try
            {
                // Step 1 
                MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyclsConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT especialidades_id, especialidades_descripcion FROM especialidades", MyclsConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("especialidades_id", typeof(int));
                MyDataTable.Columns.Add("especialidades_descripcion", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6                                
                cmbEspecialidad.ValueMember = "especialidades_id";
                cmbEspecialidad.DisplayMember = "especialidades_descripcion";
                cmbEspecialidad.DataSource = MyDataTable;

                // Step 7
                MyclsConexion.Close();
                MyCommand.Dispose();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }

        private void fillComboRangoPaciente()
        {
            try
            {
                // Step 1 
                MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyclsConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT rango_id, rango_descripcion FROM rangos", MyclsConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("rango_id", typeof(int));
                MyDataTable.Columns.Add("rango_descripcion", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6                
                cmbRangoPaciente.ValueMember = "rango_id";
                cmbRangoPaciente.DisplayMember = "rango_descripcion";
                cmbRangoPaciente.DataSource = MyDataTable;

                // Step 7
                MyclsConexion.Close();
                MyCommand.Dispose();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }

        private void fillComboRangoDoctor()
        {
            try
            {
                // Step 1 
                MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyclsConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT rango_id, rango_descripcion FROM rangos", MyclsConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("rango_id", typeof(int));
                MyDataTable.Columns.Add("rango_descripcion", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbRangoDoctor.ValueMember = "rango_id";
                cmbRangoDoctor.DisplayMember = "rango_descripcion";
                cmbRangoDoctor.DataSource = MyDataTable;

                // Step 7
                MyclsConexion.Close();
                MyCommand.Dispose();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }


        private void fillComboDepartamento()
        {
            try
            {
                // Step 1 
                MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyclsConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT coddepart, nomdepart FROM " +
                    "dependencias ORDER BY nomdepart ASC", MyclsConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("coddepart", typeof(string));
                MyDataTable.Columns.Add("nomdepart", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbDepartamento.ValueMember = "coddepart";
                cmbDepartamento.DisplayMember = "nomdepart";
                cmbDepartamento.DataSource = MyDataTable;

                // Step 7
                MyclsConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }

        private void fillComboSeccionNaval()
        {
            try
            {
                // Step 1 
                MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyclsConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT codsec, nomsec FROM seccionaval", MyclsConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("codsec", typeof(int));
                MyDataTable.Columns.Add("nomsec", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbSeccionNaval.ValueMember = "codsec";
                cmbSeccionNaval.DisplayMember = "nomsec";
                cmbSeccionNaval.DataSource = MyDataTable;

                // Step 7
                MyclsConexion.Close();
                MyCommand.Dispose();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }

        private void Limpiar()
        {
            txtIdLicencia.Clear();
            txtCedulaDoctor.Clear();
            txtNombreDoctor.Clear();
            txtApellidoDoctor.Clear();
            txtCedulaPaciente.Clear();
            txtNombrePaciente.Clear();            
            txtRazonLicencia.Clear();            
        }

        private void ProximoCodigo()
        {
            try
            {
                // Step 1 - Connection stablished
                MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Create command
                MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                // Step 3 - Set the commanndtext property
                MyCommand.CommandText = "SELECT count(*) FROM licenciasmedicas";

                // Step 4 - Open connection
                MyclsConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtIdLicencia.Text = Convert.ToString(codigo);

                // Step 5 - Close the connection
                MyclsConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Nuevo";
            this.botones();
            this.ProximoCodigo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.botones();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCedulaDoctor.Text == "")
            {
                MessageBox.Show("No se permite guardar sin cedula doctor...");
                txtCedulaDoctor.Focus();
            }
            else if (txtCedulaPaciente.Text == "")
            {
                MessageBox.Show("No se permite guardar sin cedula paciente...");
                txtCedulaPaciente.Focus();
            }
            else if (txtRazonLicencia.Text == "")
            {
                MessageBox.Show("No se permite guardar sin descripcion del problema...");
                txtRazonLicencia.Focus();
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
                        myCommand.CommandText = "INSERT INTO licenciasmedicas(cedulapaciente, rango, fecha, " +
                            "dependencia, seccionaval, ceduladoctor, razonlicencia, departamento, rangodoctor) " +
                            "values(@paciente, @rango, @fecha, @dependencia, @seccionaval, @doctor, @razonlicencia, @departamento, @rangodoctor)";
                        myCommand.Parameters.AddWithValue("@paciente", txtCedulaPaciente.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRangoPaciente.SelectedValue);
                        myCommand.Parameters.AddWithValue("@fecha", txtFecha.Value.ToString("yyyy-MM-dd"));
                        myCommand.Parameters.AddWithValue("@dependencia", cmbDepartamento.SelectedValue);
                        myCommand.Parameters.AddWithValue("@seccionaval", cmbSeccionNaval.SelectedValue);
                        myCommand.Parameters.AddWithValue("@doctor", txtCedulaDoctor.Text);                                                
                        myCommand.Parameters.AddWithValue("@razonlicencia", txtRazonLicencia.Text);
                        myCommand.Parameters.AddWithValue("@departamento", cmbEspecialidad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@rangodoctor", cmbRangoDoctor.SelectedValue);

                        // Step 4 - Opening the connection
                        MyclsConexion.Open();
                        MySqlTransaction myTranSact = MyclsConexion.BeginTransaction();

                        // Step 5 - Executing the query
                        myCommand.Transaction = myTranSact;
                        int nResultado = myCommand.ExecuteNonQuery();

                        if (nResultado > 0)
                        {
                            myTranSact.Commit();
                            MessageBox.Show("Informacion Guardada Satisfactoriamente...");
                            imprimeLicenciaMedica();
                        }
                        else
                        {
                            myTranSact.Rollback();
                            MessageBox.Show("No se pudo guardar la informacion...");
                        }

                        // Step 6 - Closing the connection
                        MyclsConexion.Close();
                        myCommand.Dispose();

                    }
                    catch (Exception myEx)
                    {
                        MessageBox.Show(myEx.Message);
                    }
                }
                else // en caso de que cModo = "Guardar"
                {
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyclsConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar                        
                        myCommand.CommandText = "UPDATE licenciasmedicas SET fecha = @fecha, ceduladoctor = @doctor, " +
                            "cedulapaciente = @paciente, razonlicencia = @razonlicencia, dependencia = @dependencia, " +
                            "seccionaval = @seccionaval, departamento = @departamento, rango = @rango, " +
                            "rangodoctor = @rangodoctor WHERE idlicencia = " + txtIdLicencia.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", txtFecha.Value.ToString("yyyy-MM-dd"));
                        myCommand.Parameters.AddWithValue("@doctor", txtCedulaDoctor.Text);
                        myCommand.Parameters.AddWithValue("@paciente", txtCedulaPaciente.Text);
                        myCommand.Parameters.AddWithValue("@razonlicencia", txtRazonLicencia.Text);
                        myCommand.Parameters.AddWithValue("@dependencia", cmbDepartamento.SelectedValue);
                        myCommand.Parameters.AddWithValue("@seccionaval", cmbSeccionNaval.SelectedValue);
                        myCommand.Parameters.AddWithValue("@departamento", cmbEspecialidad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@rango", cmbRangoPaciente.SelectedValue);
                        myCommand.Parameters.AddWithValue("@rangodoctor", cmbRangoDoctor.SelectedValue);

                        // Step 4 - Opening the connection
                        MyclsConexion.Open();
                        MySqlTransaction myTranSact = MyclsConexion.BeginTransaction();

                        // Step 5 - Executing the query
                        myCommand.Transaction = myTranSact;
                        int nResultado = myCommand.ExecuteNonQuery();

                        if (nResultado > 0)
                        {
                            myTranSact.Commit();
                            MessageBox.Show("Informacion Actualizada Satisfactoriamente...");
                            imprimeLicenciaMedica();
                        }
                        else
                        {
                            myTranSact.Rollback();
                            MessageBox.Show("No se pudo actualizar la informacion...");
                        }

                        // Step 6 - Closing the connection
                        MyclsConexion.Close();
                        myCommand.Dispose();
                    }
                    catch (Exception myEx)
                    {
                        MessageBox.Show(myEx.Message);
                    }
                }

                this.cModo = "Inicio";
                this.botones();
                this.Limpiar();
            }
        }

        private void imprimeLicenciaMedica()
        {            
            DialogResult Result =
            MessageBox.Show("Imprima Licencia Medica" + System.Environment.NewLine + "Desea Imprimir Licencia Medica", "Sistema Gestion de Plantaciones v1.0", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            switch (Result)
            {
                case DialogResult.Yes:
                    GenerarReporte();
                    break;
            }         
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {            

            if (txtIdLicencia.Text == "")
            {
                MessageBox.Show("No se permiten busquedas con No. Licencia en blanco...");
                txtIdLicencia.Focus();
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
                    MyCommand.CommandText = "SELECT idlicencia, cedulapaciente, rango, fecha, seccionaval, dependencia, " +
                        "ceduladoctor, razonlicencia FROM licenciasmedicas WHERE idlicencia = " + txtIdLicencia.Text + "";

                    // Step 4
                    MyclsConexion.Open();

                    // Step 5
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {                            
                            txtFecha.Value = Convert.ToDateTime(MyReader["fecha"]);
                            txtCedulaDoctor.Text = MyReader["ceduladoctor"].ToString();
                            txtCedulaPaciente.Text = MyReader["cedulapaciente"].ToString();
                            txtRazonLicencia.Text = MyReader["razonlicencia"].ToString();
                        }

                        this.cModo = "Buscar";
                        this.botones();
                        // Llamo la funciones que llenan el doctor y el paciente
                        if (txtCedulaDoctor.Text != "")
                        {
                            btnBuscarDoctor_Click(sender, e);
                        }
                        if (txtCedulaPaciente.Text != "")
                        {
                            btnBuscarPaciente_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.cModo = "Inicio";
                        this.botones();
                        this.Limpiar();
                        this.txtIdLicencia.Focus();
                    }

                    // Step 7
                    MyclsConexion.Close();
                    MyCommand.Dispose();
                    MyReader.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            frmBuscarPaciente ofrmBuscarPaciente = new frmBuscarPaciente();
            ofrmBuscarPaciente.ShowDialog();
            string cCodigo = ofrmBuscarPaciente.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedulaPaciente.Text = Convert.ToString(cCodigo).Trim();

            }
            
            if (txtCedulaPaciente.Text != "")
            {
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    MyCommand.CommandText = "SELECT rango, nombre, apellido, seccionaval, departamento " +
                        "FROM paciente WHERE cedula =" + "'" + txtCedulaPaciente.Text + "'" + "";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows                    
                    string cNombreCompleto = "";

                    if (MyReader.HasRows)
                    {                                                
                        while (MyReader.Read())
                        {
                            cmbRangoPaciente.SelectedValue = MyReader["rango"].ToString();                                                        
                            txtNombrePaciente.Text = MyReader["nombre"].ToString();
                            cNombreCompleto = MyReader["nombre"].ToString();
                            cNombreCompleto += " ";
                            cNombreCompleto += MyReader["apellido"].ToString();
                            txtNombrePaciente.Text = cNombreCompleto;
                            cmbSeccionNaval.SelectedValue = MyReader["seccionaval"].ToString();
                            cmbDepartamento.SelectedValue = MyReader["departamento"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.txtCedulaPaciente.Clear();
                        this.txtNombrePaciente.Clear();
                    }

                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception myEx)
                {
                    MessageBox.Show(myEx.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtIdLicencia.Text != "" && txtCedulaDoctor.Text != "" && txtCedulaPaciente.Text != "" && txtRazonLicencia.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistemas Pacientes Dispensario Medico V1.0", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        btnGrabar_Click(sender, e);
                        break;
                }
            }

            this.Limpiar();
            this.cModo = "Inicio";
            this.botones();        
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            if (txtCedulaDoctor.Text == "")
            {
                MessageBox.Show("No se permite generar una Licencia Medica sin cedula del Doctor...");
                txtCedulaDoctor.Focus();
            }
            else if (txtCedulaPaciente.Text == "")
            {
                MessageBox.Show("No se permite generar una Licencia Medica sin cedula del Paciente...");
                txtCedulaPaciente.Focus();
            }
            else if (txtRazonLicencia.Text == "")
            {
                MessageBox.Show("No se permite generar una Licencia Medica sin la Razon descrita...");
                txtRazonLicencia.Focus();
            }
            else
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
                int cCodigo = Convert.ToInt32(txtIdLicencia.Text);

                try
                {
                    // Abro clsConexion
                    myclsConexion.Open();
                    // Creo comando
                    myCommand = myclsConexion.CreateCommand();
                    // Adhiero el comando a la clsConexion
                    myCommand.Connection = myclsConexion;
                    // Filtros de la busqueda
                    int cCodigoImprimir = Convert.ToInt32(txtIdLicencia.Text);
                    cWhere = cWhere + " AND idlicencia =" + cCodigoImprimir + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT licenciasmedicas.cedulapaciente, upper(rangos.rango_descripcion) as rangopaciente,");
                    sbQuery.Append(" concat(paciente.nombre,' ', paciente.apellido) as nombrepaciente, licenciasmedicas.fecha, ");
                    sbQuery.Append(" licenciasmedicas.razonlicencia, dependencias.nomdepart, seccionaval.nomsec,");
                    sbQuery.Append(" concat(rtrim(doctores.doctores_nombre),' ', ltrim(doctores.doctores_apellido)) as nombredoctor,");
                    sbQuery.Append(" rangos.rangoabrev as rangodoctor, especialidades.especialidades_descripcion as doctorespecialidad,");
                    sbQuery.Append(" licenciasmedicas.idlicencia ");
                    sbQuery.Append(" FROM licenciasmedicas");
                    sbQuery.Append(" INNER JOIN paciente ON paciente.cedula = licenciasmedicas.cedulapaciente");
                    sbQuery.Append(" INNER JOIN dependencias ON dependencias.coddepart = licenciasmedicas.dependencia");
                    sbQuery.Append(" INNER JOIN seccionaval ON seccionaval.codsec = licenciasmedicas.seccionaval");
                    sbQuery.Append(" INNER JOIN doctores ON doctores.doctores_cedula = licenciasmedicas.ceduladoctor");
                    sbQuery.Append(" INNER JOIN rangos ON rangos.rango_id = doctores.doctores_rango");
                    sbQuery.Append(" INNER JOIN especialidades ON especialidades.especialidades_id = doctores.doctores_especialidad");
                    sbQuery.Append(cWhere);

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtLicenciasMedicas = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtLicenciasMedicas);
                    // Cierro el objeto clsConexion
                    myclsConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtLicenciasMedicas.Rows.Count;
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
                        cTitulo = "LICENCIA MEDICA";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        Reportes.rptLicenciaMedica orptLicenciaMedica = new Reportes.rptLicenciaMedica();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;

                        orptLicenciaMedica.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtLicenciasMedicas, orptLicenciaMedica, cTitulo);

                        //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                        ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                        ofrmPrinter.ShowDialog();
                    }


                }
                catch (Exception myEx)
                {
                    MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    clsExceptionLog.LogError(myEx, false);
                    return;
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            frmPrintLicenciasMedicas ofrmPrintLicenciasMedicas = new frmPrintLicenciasMedicas();
            ofrmPrintLicenciasMedicas.Show();
        }
    }
}
