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
    public partial class frmCitaMedica : frmBase
    {
        string cModo = "Inicio";

        public frmCitaMedica()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCitaMedica_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
            this.fillComboRangoDoctor();
            this.fillComboRangoPaciente();
            this.fillComboEspecialidad();
            this.fillComboDepartamento();
            this.fillComboSeccionNaval();
            this.fillComboReferimiento();
            this.txtIdLicencia.Focus();
        }

        private void fillComboReferimiento()
        {
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
                cmbReferimiento.ValueMember = "departamento_id";
                cmbReferimiento.DisplayMember = "departamento_descripcion";
                cmbReferimiento.DataSource = MyDataTable;

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
                MySqlCommand MyCommand = new MySqlCommand("SELECT coddepart, nomdepart FROM dependencias", MyclsConexion);

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
                MyCommand.Dispose();
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
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    txtCedulaDoctor.Enabled = false;
                    txtCedulaPaciente.Enabled = false;
                    txtFechaCita.Enabled = false;
                    cmbReferimiento.Enabled = false;
                    txtIdLicencia.Enabled = true;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.btnBuscarDoctor.Enabled = true;
                    this.btnBuscarPaciente.Enabled = true;
                    txtCedulaDoctor.Enabled = true;
                    txtCedulaPaciente.Enabled = true;
                    txtFechaCita.Enabled = true;
                    cmbReferimiento.Enabled = true;
                    txtIdLicencia.Enabled = false;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    txtCedulaDoctor.Enabled = false;
                    txtCedulaPaciente.Enabled = false;
                    txtFechaCita.Enabled = false;
                    cmbReferimiento.Enabled = false;
                    txtIdLicencia.Enabled = true;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.btnBuscarDoctor.Enabled = true;
                    this.btnBuscarPaciente.Enabled = true;
                    txtCedulaDoctor.Enabled = true;
                    txtCedulaPaciente.Enabled = true;
                    txtFechaCita.Enabled = true;
                    cmbReferimiento.Enabled = true;
                    txtIdLicencia.Enabled = false;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnBuscarDoctor.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    txtCedulaDoctor.Enabled = false;
                    txtCedulaPaciente.Enabled = false;
                    txtFechaCita.Enabled = false;
                    cmbReferimiento.Enabled = false;
                    txtIdLicencia.Enabled = true;
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
                MyCommand.CommandText = "SELECT count(*) FROM cita";

                // Step 4 - Open connection
                MyclsConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtIdLicencia.Text = Convert.ToString(codigo);
                txtCedulaDoctor.Focus();

                // Step 5 - Close the connection
                MyclsConexion.Close();
            }
            catch (MySqlException MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void Limpiar()
        {
            txtIdLicencia.Clear();
            txtCedulaDoctor.Clear();
            txtCedulaPaciente.Clear();
            txtNombreDoctor.Clear();
            txtApellidoDoctor.Clear();
            txtNombreDoctor.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            this.Limpiar();
            cModo = "Nuevo";
            this.Botones();
            this.ProximoCodigo();            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCedulaDoctor.Text == "")
            {
                MessageBox.Show("No puede grabar registro sin digitar cedula del doctor...");
                txtCedulaDoctor.Focus();
            }
            else if (txtCedulaPaciente.Text == "")
            {
                MessageBox.Show("No puede grabar registro sin digitar cedula paciente...");
                txtCedulaPaciente.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    try
                    {
                        // Step 1 - Creating the connection
                        MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);
                        //MySqlTransaction omyTransact = new MySqlTransaction();

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = myclsConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText =
                            "INSERT INTO cita(fecha, ceduladoctor, cedulapaciente, fechacita, referimiento)" +
                            " values(@fecha, @ceduladoctor, @cedulapaciente, @fechacita, @referimiento)";
                        myCommand.Parameters.AddWithValue("@fecha", txtFecha.Value.ToString("yyyy-MM-dd"));
                        myCommand.Parameters.AddWithValue("@ceduladoctor", txtCedulaDoctor.Text);
                        myCommand.Parameters.AddWithValue("@cedulapaciente", txtCedulaPaciente.Text);
                        myCommand.Parameters.AddWithValue("@fechacita", txtFechaCita.Value.ToString("yyyy-MM-dd"));                    
                        myCommand.Parameters.AddWithValue("@referimiento", cmbReferimiento.SelectedValue);

                        // Step 4  - Abro la clsConexion
                        myclsConexion.Open();

                        // Step 5 - Ejecuto el query
                        int numberOfRows = myCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            MessageBox.Show("Informacion Registrada Satisfactoriamente...");
                        }
                        else
                        {
                            MessageBox.Show("Informacion no fue registrada...");
                        }

                        // Step 6 - Cierro clsConexion
                        myclsConexion.Close();
                        
                    }
                    catch (Exception myEx)
                    {
                        MessageBox.Show(myEx.Message);                        
                    }
                    
                }
                else
                {
                    // Step 1 - Creating the connection
                    MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - Crear el comando de ejecucion
                    MySqlCommand myCommand = myclsConexion.CreateCommand();

                    // Step 3 - Comando a ejecutar
                    myCommand.CommandText =
                        "UPDATE cita set fecha = @fecha, ceduladoctor = @ceduladoctor, cedulapaciente = cedulapaciente, "+
                        "fechacita = @fechacita, referimiento = @referimiento WHERE idcita ="+ txtIdLicencia.Text +"";
                    myCommand.Parameters.AddWithValue("@fecha", txtFecha.Value.ToString("yyyy-MM-dd"));
                    myCommand.Parameters.AddWithValue("@ceduladoctor", txtCedulaDoctor.Text);
                    myCommand.Parameters.AddWithValue("@cedulapaciente", txtCedulaPaciente.Text);
                    myCommand.Parameters.AddWithValue("@fechacita", txtFechaCita.Value.ToString("yyyy-MM-dd"));                    
                    myCommand.Parameters.AddWithValue("@referimiento", cmbReferimiento.SelectedValue);

                    // Step 4  - Abro la clsConexion
                    myclsConexion.Open();

                    // Step 5 - Ejecuto el query
                    int numberOfRows = myCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        MessageBox.Show("Informacion Actualizada Satisfactoriamente...");
                    }
                    else
                    {
                        MessageBox.Show("Informacion no fue actualizada...");
                    }

                    // Step 6 - Cierro clsConexion
                    myclsConexion.Close();
                }

                this.Limpiar();
                cModo = "Inicio";
                this.Botones();
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdLicencia.Text == "")
            {
                MessageBox.Show("No se permiten busquedas con No.Caso en blanco...");
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
                    MyCommand.CommandText = "SELECT fecha, ceduladoctor, cedulapaciente, fechacita, referimiento " +
                        "FROM cita WHERE idcita = " + txtIdLicencia.Text + "";

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
                            txtCedulaDoctor.Text = MyReader["ceduladoctor"].ToString();
                            txtCedulaPaciente.Text = MyReader["cedulapaciente"].ToString();
                            txtFechaCita.Value = Convert.ToDateTime(MyReader["fechacita"]);
                            cmbReferimiento.SelectedValue = MyReader["referimiento"].ToString();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmPrintCitasMedicas ofrmPrintCitasMedicas = new frmPrintCitasMedicas();
            ofrmPrintCitasMedicas.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtCedulaDoctor.Text != "" && txtCedulaPaciente.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Dispensario Medico v1.0", MessageBoxButtons.YesNo,
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
                    MyCommand.CommandText = "SELECT rango, nombre, apellido, edad, seccionaval, departamento " +
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
                            txtNombrePaciente.Text += " ";
                            txtNombrePaciente.Text += MyReader["apellido"].ToString();
                            cmbDepartamento.SelectedValue = MyReader["departamento"].ToString();
                            cmbSeccionNaval.SelectedValue = MyReader["seccionaval"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.txtCedulaPaciente.Clear();
                        this.txtNombrePaciente.Clear();
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
    }
}
