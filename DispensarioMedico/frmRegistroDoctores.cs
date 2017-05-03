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
    public partial class frmRegistroDoctores : frmBase
    {
        // 12-01-2014 Revisado Luis A. Turbi
        // Agregue form de Busqueda


        string cModo = "Inicio";

        public frmRegistroDoctores()
        {
            InitializeComponent();
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistroDoctores_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            cModo = "Inicio";
            this.Botones();
            FillComboRango();
            FillComboEspecialidad();
        }

        private void FillComboRango()
        {
            // Step 1 
            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyclsConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT rango_id, rango_descripcion FROM rangos ORDER BY orden", MyclsConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("rango_id", typeof(int));
            MyDataTable.Columns.Add("rango_descripcion", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbRango.ValueMember = "rango_id";
            cmbRango.DisplayMember = "rango_descripcion";
            cmbRango.DataSource = MyDataTable;

            // Step 7
            MyclsConexion.Close();

        }

        private void FillComboEspecialidad()
        {
            // Step 1 
            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyclsConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT especialidades_id, especialidades_descripcion " +
                "FROM especialidades", MyclsConexion);

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

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtEdad.Clear();
            this.txtExequatur.Clear();
            this.rbSexoMasculino.Checked = true;
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
                    this.txtID.ReadOnly = true;
                    this.txtCedula.ReadOnly = false;
                    this.cmbRango.Enabled = false;
                    this.txtNombre.ReadOnly = true;
                    this.txtApellido.ReadOnly = true;
                    this.txtEdad.ReadOnly = true;
                    this.rbSexoMasculino.Enabled = false;
                    this.rbSexoFemenino.Enabled = false;
                    this.txtExequatur.ReadOnly = true;
                    this.cmbEspecialidad.Enabled = false;
                    this.txtCedula.Focus();
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtID.ReadOnly = true;
                    this.txtCedula.ReadOnly = false;
                    this.cmbRango.Enabled = true;
                    this.txtNombre.ReadOnly = false;
                    this.txtApellido.ReadOnly = false;
                    this.txtEdad.ReadOnly = false;
                    this.rbSexoMasculino.Enabled = true;
                    this.rbSexoFemenino.Enabled = true;
                    this.txtExequatur.ReadOnly = false;
                    this.cmbEspecialidad.Enabled = true;
                    this.txtCedula.Focus();
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtID.ReadOnly = true;
                    this.txtCedula.ReadOnly = true;
                    this.cmbRango.Enabled = false;
                    this.txtNombre.ReadOnly = true;
                    this.txtApellido.ReadOnly = true;
                    this.txtEdad.ReadOnly = true;
                    this.rbSexoMasculino.Enabled = false;
                    this.rbSexoFemenino.Enabled = false;
                    this.txtExequatur.ReadOnly = true;
                    this.cmbEspecialidad.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.txtID.ReadOnly = true;
                    this.txtCedula.ReadOnly = true;
                    this.cmbRango.Enabled = true;
                    this.txtNombre.ReadOnly = false;
                    this.txtApellido.ReadOnly = false;
                    this.txtEdad.ReadOnly = false;
                    this.rbSexoMasculino.Enabled = true;
                    this.rbSexoFemenino.Enabled = true;
                    this.txtExequatur.ReadOnly = false;
                    this.cmbEspecialidad.Enabled = true;
                    this.cmbRango.Focus();
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.txtID.ReadOnly = true;
                    this.txtCedula.ReadOnly = false;
                    this.cmbRango.Enabled = false;
                    this.txtNombre.ReadOnly = true;
                    this.txtApellido.ReadOnly = true;
                    this.txtEdad.ReadOnly = true;
                    this.rbSexoMasculino.Enabled = false;
                    this.rbSexoFemenino.Enabled = false;
                    this.txtExequatur.ReadOnly = true;
                    this.cmbEspecialidad.Enabled = false;
                    this.txtCedula.Focus();
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
                MySqlConnection MyclsConexion = new MySqlConnection("Server=localhost;Database=mdeg_dispensariomedico;Uid=root;Pwd=*010405;");

                // Step 2 - Create command
                MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                // Step 3 - Set the commanndtext property
                MyCommand.CommandText = "SELECT count(*) FROM doctores";

                // Step 4 - Open connection
                MyclsConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);
                txtCedula.Focus();

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
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCedula.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtCedula.Focus();
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
                        myCommand.CommandText = "INSERT INTO doctores(doctores_cedula, doctores_rango, " +
                            "doctores_nombre, doctores_apellido, doctores_edad, doctores_sexo, doctores_exequatur, " +
                            "doctores_especialidad)" +
                            " values(@cedula, @rango, @nombre, @apellido, @edad, @sexo, @exequatur, @especialidad)";
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@apellido", txtApellido.Text);
                        myCommand.Parameters.AddWithValue("@edad", txtEdad.Text);
                        if (rbSexoMasculino.Checked)
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "M");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "F");
                        }
                        myCommand.Parameters.AddWithValue("@exequatur", txtExequatur.Text);
                        myCommand.Parameters.AddWithValue("@especialidad", cmbEspecialidad.SelectedValue);

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
                        MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = myclsConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "UPDATE doctores SET doctores_cedula = @cedula, " +
                            "doctores_rango = @rango, doctores_nombre = @nombre, doctores_apellido = @apellido, " +
                            "doctores_edad = @edad, doctores_sexo = @sexo, doctores_exequatur = @exequatur, " +
                            "doctores_especialidad = @especialidad" +
                            " WHERE doctores_id = "+ txtID.Text +"";
                        //myCommand.Parameters.AddWithValue("@id", txtID.Text);
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@apellido", txtApellido.Text);
                        myCommand.Parameters.AddWithValue("@edad", txtEdad.Text);
                        if (rbSexoMasculino.Checked)
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "M");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "F");
                        }
                        myCommand.Parameters.AddWithValue("@exequatur", txtExequatur.Text);
                        myCommand.Parameters.AddWithValue("@especialidad", cmbEspecialidad.SelectedValue);

                        // Step 4 - Opening the connection
                        myclsConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection                        
                        myclsConexion.Close();

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Dispensario Medico - A.R.D. v1.0", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        this.btnGrabar_Click(sender, e);
                        break;
                }
            }

            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarDoctor ofrmBuscarDoctor = new frmBuscarDoctor();
            ofrmBuscarDoctor.ShowDialog();
            string cCodigo = ofrmBuscarDoctor.cCodigo;

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
                    MyCommand.CommandText = "SELECT * from vdoctores WHERE doctores_cedula = '" + txtCedula.Text.Trim() + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtID.Text = MyReader["doctores_id"].ToString();
                            cmbRango.SelectedValue = MyReader["doctores_rango"].ToString();
                            txtNombre.Text = MyReader["doctores_nombre"].ToString();
                            txtApellido.Text = MyReader["doctores_apellido"].ToString();
                            txtEdad.Text = MyReader["doctores_edad"].ToString();
                            string sexo = MyReader["doctores_sexo"].ToString();

                            // Calcula Edad
                            // txtEdad.Text = MyReader["edad"].ToString();
                            txtEdad.Text = clsProcesos.CalculaEdad(Convert.ToDateTime(MyReader["fechanac"])).ToString("N");
                          
                            if (sexo == "M")
                            {
                                rbSexoMasculino.Select();
                            }
                            else
                            {
                                rbSexoFemenino.Select();
                            }
                            txtExequatur.Text = MyReader["doctores_exequatur"].ToString();
                            cmbEspecialidad.SelectedValue = Convert.ToInt32(MyReader["doctores_especialidad"].ToString());

                            // Calcula Edad
                            // txtEdad.Text = MyReader["edad"].ToString();
                            txtEdad.Text = clsProcesos.CalculaEdad(Convert.ToDateTime(MyReader["fechanac"])).ToString("N");
                            /*
                            if (this.imgFoto.ImageLocation == null || this.imgFoto.ImageLocation == "")
                            {
                                if(File.Exists(@MyReader["rutafoto"].ToString()))
                                {
                                this.imgFoto.ImageLocation = @MyReader["rutafoto"].ToString();
                                }
                            }
                            if (this.imgFoto.Image == null)
                            {
                                // valor por defecto
                                //this.imgFoto.Image = System.Drawing.Image.FromFile(@this.Icon);
                              //  this.imgFoto.Image = System.Drawing.Image.FromFile(@MyReader["rutafoto"].ToString());
                            }*/
                        }
                        this.cModo = "Buscar";
                        this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...", "SysHospitalARD v1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtCedula.Focus();
                        this.cModo = "Inicio";
                        this.Botones();
                        this.Limpiar();
                        this.txtID.Focus();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimirMedico ofrmImprimir = new frmImprimirMedico();
            ofrmImprimir.ShowDialog();
        }

    }
}
