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

namespace DispensarioMedico
{
    public partial class frmProblemaMedicoRegistro : frmBase
    {

        string cModo = "Inicio";

        public frmProblemaMedicoRegistro()
        {
            InitializeComponent();
        }

        private void frmProblemaMedicoRegistro_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
            this.fillComboRangoDoctor();
            this.fillComboRangoPaciente();
            this.fillComboEspecialidad();
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

        private void Limpiar()
        {
            txtRegistro.Clear();
            txtCedulaDoctor.Clear();
            txtNombreDoctor.Clear();
            txtApellidoDoctor.Clear();
            txtCedulaPaciente.Clear();
            txtNombreDoctor.Clear();
            txtApellidoDoctor.Clear();
            txtEdadPaciente.Clear();
            txtDescripcion.Clear();
            txtObjetivo.Clear();
            txtPlanAccion.Clear();
            txtPrescripcion.Clear();            
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
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtRegistro.Enabled = true;
                    this.txtFecha.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtObjetivo.Enabled = false;
                    txtPlanAccion.Enabled = false;
                    txtPrescripcion.Enabled = false;
                    txtRegistro.Focus();
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnBuscarDoctor.Enabled = true;
                    this.btnBuscarPaciente.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtRegistro.Enabled = false;
                    this.txtFecha.Enabled = true;
                    txtDescripcion.Enabled = true;
                    txtObjetivo.Enabled = true;
                    txtPlanAccion.Enabled = true;
                    txtPrescripcion.Enabled = true;
                    txtCedulaDoctor.Focus();
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtRegistro.Enabled = false;
                    this.txtFecha.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtObjetivo.Enabled = false;
                    txtPlanAccion.Enabled = false;
                    txtPrescripcion.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnBuscarDoctor.Enabled = true;
                    this.btnBuscarPaciente.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtRegistro.Enabled = false;
                    this.txtFecha.Enabled = true;
                    txtDescripcion.Enabled = true;
                    txtObjetivo.Enabled = true;
                    txtPlanAccion.Enabled = true;
                    txtPrescripcion.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtRegistro.Enabled = true;
                    this.txtFecha.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtObjetivo.Enabled = false;
                    txtPlanAccion.Enabled = false;
                    txtPrescripcion.Enabled = false;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtRegistro.Enabled = false;
                    this.txtFecha.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtObjetivo.Enabled = false;
                    txtPlanAccion.Enabled = false;
                    txtPrescripcion.Enabled = false;
                    break;

                default:
                    break;
            }
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
                MyCommand.CommandText = "SELECT count(*) FROM casomedico";

                // Step 4 - Open connection
                MyclsConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtRegistro.Text = Convert.ToString(codigo);
                
                // Step 5 - Close the connection
                MyclsConexion.Close();
            } catch(Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Nuevo";
            this.Botones();
            this.ProximoCodigo();
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
            else if (txtDescripcion.Text == "")
            {
                MessageBox.Show("No se permite guardar sin descripcion del problema...");
                txtDescripcion.Focus();
            }
            else if (txtObjetivo.Text == "")
            {
                MessageBox.Show("No se permite guardar sin objetivos a llevar a cabo...");
                txtObjetivo.Focus();
            }
            else if (txtPlanAccion.Text == "")
            {
                MessageBox.Show("No se permite guardar sin plan de accion ejecutado...");
                txtPlanAccion.Focus();
            }
            else if (txtPrescripcion.Text == "")
            {
                MessageBox.Show("No se permite guardar sin informacion prescripcion...");
                txtPrescripcion.Focus();
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
                        myCommand.CommandText = "INSERT INTO casomedico(fecha, cedula_doctor, cedula_paciente, " +
                            "problema_descripcion, problema_objetivo, problema_accion, problema_prescripcion, rango) " + 
                            "values(@fecha, @doctor, @paciente, @descripcion, @objetivo, @accion, @prescripcion, @rango)";
                        myCommand.Parameters.AddWithValue("@fecha", txtFecha.Value.ToString("yyyy-MM-dd"));                        
                        myCommand.Parameters.AddWithValue("@doctor", txtCedulaDoctor.Text);
                        myCommand.Parameters.AddWithValue("@paciente", txtCedulaPaciente.Text);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        myCommand.Parameters.AddWithValue("@objetivo", txtObjetivo.Text);
                        myCommand.Parameters.AddWithValue("@accion", txtPlanAccion.Text);
                        myCommand.Parameters.AddWithValue("@prescripcion", txtPrescripcion.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRangoPaciente.SelectedValue);

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
                        myCommand.CommandText = "UPDATE casomedico SET fecha = @fecha, cedula_doctor = @doctor, " +
                            "cedula_paciente = @paciente, problema_descripcion = @descripcion, problema_objetivo = @objetivo, "+
                            "problema_accion = @accion, problema_prescripcion = @prescripcion, rango = @rango WHERE " +
                            "idcasomedico = "+ txtRegistro.Text +"";
                        myCommand.Parameters.AddWithValue("@fecha", txtFecha.Value.ToString("yyyy-MM-dd"));
                        myCommand.Parameters.AddWithValue("@doctor", txtCedulaDoctor.Text);
                        myCommand.Parameters.AddWithValue("@paciente", txtCedulaPaciente.Text);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        myCommand.Parameters.AddWithValue("@objetivo", txtObjetivo.Text);
                        myCommand.Parameters.AddWithValue("@accion", txtPlanAccion.Text);
                        myCommand.Parameters.AddWithValue("@prescripcion", txtPrescripcion.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRangoPaciente.SelectedValue);

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
                this.Botones();
                this.Limpiar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtRegistro.Text == "")
            {
                MessageBox.Show("No se permiten busquedas con No.Caso en blanco...");
                txtRegistro.Focus();
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
                    MyCommand.CommandText = "SELECT idcasomedico, cedula_doctor, cedula_paciente, problema_descripcion, "+
                        "problema_objetivo, problema_accion, problema_prescripcion, fecha FROM casomedico "+
                        "WHERE idcasomedico = " + txtRegistro.Text + "";

                    // Step 4
                    MyclsConexion.Open();

                    // Step 5
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            //txtRegistro.Text = MyReader["idcasomedico"].ToString();
                            txtFecha.Value = Convert.ToDateTime(MyReader["fecha"]);
                            txtCedulaDoctor.Text = MyReader["cedula_doctor"].ToString();
                            txtCedulaPaciente.Text = MyReader["cedula_paciente"].ToString();
                            txtDescripcion.Text = MyReader["problema_descripcion"].ToString();
                            txtObjetivo.Text = MyReader["problema_objetivo"].ToString();
                            txtPlanAccion.Text = MyReader["problema_accion"].ToString();
                            txtPrescripcion.Text = MyReader["problema_prescripcion"].ToString();
                        }

                        this.cModo = "Buscar";
                        this.Botones();
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
                        this.Botones();
                        this.Limpiar();
                        this.txtRegistro.Focus();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimirProblemaMedico ofrmImprimirProblemaMed = new frmImprimirProblemaMedico();
            ofrmImprimirProblemaMed.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtRegistro.Text != "" && txtCedulaDoctor.Text != "" && txtCedulaPaciente.Text != "" && txtDescripcion.Text != "")
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
            this.Botones();
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
                    MyCommand.CommandText = "SELECT doctores_rango, doctores_especialidad, doctores_nombre, doctores_apellido "+
                        "FROM doctores WHERE doctores_cedula ="+"'"+ txtCedulaDoctor.Text +"'"+"";

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
                    MyCommand.CommandText = "SELECT rango, nombre, apellido, fechanac " +
                        "FROM paciente WHERE cedula =" + "'" + txtCedulaPaciente.Text + "'" + "";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            cmbRangoPaciente.SelectedValue = MyReader["rango"].ToString();                                                        
                            txtNombrePaciente.Text = MyReader["nombre"].ToString();
                            txtApellidoPaciente.Text = MyReader["apellido"].ToString();
                           // txtEdadPaciente.Text = MyReader["edad"].ToString();

                            // Calcula Edad
                            // txtEdad.Text = MyReader["edad"].ToString();
                            txtEdadPaciente.Text = clsProcesos.CalculaEdad(Convert.ToDateTime(MyReader["fechanac"])).ToString("N");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.txtCedulaPaciente.Clear();
                        this.txtNombrePaciente.Clear();
                        this.txtApellidoPaciente.Clear();                        
                        this.txtEdadPaciente.Clear();
                        this.txtCedulaPaciente.Focus();
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

        private void txtCedulaDoctor_Validated(object sender, EventArgs e)
        {
            if (txtCedulaDoctor.TextLength == 13)
            {
                btnBuscarDoctor.Enabled = true;
            }
        }
    }
}
