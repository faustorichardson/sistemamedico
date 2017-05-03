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
    public partial class frmAntecedentesPersonales : frmBase
    {
        string cModo = "Inicio";
        string cclsConexion = clsConexion.ConectionString;
        public frmAntecedentesPersonales()
        {
            InitializeComponent();
        }

        private void frmAntecedentesPersonales_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            cModo = "Inicio";
            this.Botones();
            llenarComboRango();
            llenarComboSN();
            llenarComboDepto();
            chkDependiente.Checked = false;
            DependenciaMilitar();
        }

        private void DependenciaMilitar()
        {
            if (chkDependiente.Checked == true)
            {
                txtCedulaMilitar.Enabled = true;
                btnBuscarMilitar.Enabled = true;
            }
            else
            {
                txtCedulaMilitar.Enabled = false;
                btnBuscarMilitar.Enabled = false;
            }
        }

        private void llenarComboDepto()
        {
            // Step 1 
            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyclsConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT coddepart, nomdepart FROM "+
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
            cmbDepartamento.DisplayMember = "nomdepart".Trim();
            cmbDepartamento.DataSource = MyDataTable;

            // Step 7
            MyclsConexion.Close();
        }

        private void llenarComboSN()
        {
            // Step 1 
            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyclsConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT codsec, nomsec FROM seccionaval ORDER BY nomsec ASC", MyclsConexion);

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
            cmbSeccionNaval.DisplayMember = "nomsec".Trim();
            cmbSeccionNaval.DataSource = MyDataTable;

            // Step 7
            MyclsConexion.Close();
        }

        private void llenarComboRango()
        {
            // Step 1 
            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyclsConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT rango_id, rango_descripcion FROM rangos ORDER BY rango_id ASC", MyclsConexion);

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

        private void Limpiar()
        {
            txtID.Clear();
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            rbMasculino.Checked = true;
            txtNacimiento.Clear();
            txtAlimentacion.Clear();
            txtCondicionesPsicologicas.Clear();
            txtSexualidad.Clear();
            txtOperaciones.Clear();
            txtIntoleranciaMedicinal.Clear();
            txtSaludPadres.Clear();
            txtSaludHermanos.Clear();
            txtSaludEsposaHijos.Clear();
            txtSaludFamiliarGeneral.Clear();
            txtCedulaMilitar.Clear();
            chkDependiente.Checked = false;
            txtCedula.Focus();            
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
                MyCommand.CommandText = "SELECT count(*) FROM paciente";

                // Step 4 - Open connection
                MyclsConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);                

                // Step 5 - Close the connection
                MyclsConexion.Close();
            }
            catch (MySqlException MyEx)
            {
                MessageBox.Show(MyEx.Message);
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
                    this.btnImprimir.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    txtID.ReadOnly = true;
                    cmbRango.Enabled = false;
                    txtNombre.ReadOnly = true;
                    txtApellido.ReadOnly = true;
                    txtEdad.ReadOnly = true;
                    rbMasculino.Enabled = false;
                    rbFemenino.Enabled = false;
                    txtNacimiento.Enabled = false;
                    txtAlimentacion.Enabled = false;
                    txtCondicionesPsicologicas.Enabled = false;
                    txtSexualidad.Enabled = false;
                    txtOperaciones.Enabled = false;
                    txtIntoleranciaMedicinal.Enabled = false;
                    txtSaludPadres.Enabled = false;
                    txtSaludHermanos.Enabled = false;
                    txtSaludEsposaHijos.Enabled = false;
                    txtSaludFamiliarGeneral.Enabled = false;
                    txtFechaRegistro.Enabled = false;
                    txtFechaUpdate.Enabled = false;
                    cmbDepartamento.Enabled = false;
                    cmbSeccionNaval.Enabled = false;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    txtID.ReadOnly = true;
                    cmbRango.Enabled = true;
                    this.txtNombre.ReadOnly = false;
                    this.txtApellido.ReadOnly = false;                    
                    this.txtEdad.ReadOnly = false;
                    rbMasculino.Enabled = true;
                    rbFemenino.Enabled = true;
                    txtNacimiento.Enabled = true;
                    txtAlimentacion.Enabled = true;
                    txtCondicionesPsicologicas.Enabled = true;
                    txtSexualidad.Enabled = true;
                    txtOperaciones.Enabled = true;
                    txtIntoleranciaMedicinal.Enabled = true;
                    txtSaludPadres.Enabled = true;
                    txtSaludHermanos.Enabled = true;
                    txtSaludEsposaHijos.Enabled = true;
                    txtSaludFamiliarGeneral.Enabled = true;
                    txtFechaRegistro.Enabled = true;
                    txtFechaUpdate.Enabled = false;
                    cmbDepartamento.Enabled = true;
                    cmbSeccionNaval.Enabled = true;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    txtID.ReadOnly = true;
                    cmbRango.Enabled = false;
                    txtNombre.ReadOnly = true;
                    txtApellido.ReadOnly = true;
                    txtEdad.ReadOnly = true;
                    rbMasculino.Enabled = false;
                    rbFemenino.Enabled = false;
                    txtNacimiento.Enabled = false;
                    txtAlimentacion.Enabled = false;
                    txtCondicionesPsicologicas.Enabled = false;
                    txtSexualidad.Enabled = false;
                    txtOperaciones.Enabled = false;
                    txtIntoleranciaMedicinal.Enabled = false;
                    txtSaludPadres.Enabled = false;
                    txtSaludHermanos.Enabled = false;
                    txtSaludEsposaHijos.Enabled = false;
                    txtSaludFamiliarGeneral.Enabled = false;
                    txtFechaRegistro.Enabled = false;
                    txtFechaUpdate.Enabled = false;
                    cmbDepartamento.Enabled = false;
                    cmbSeccionNaval.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    txtID.ReadOnly = true;
                    cmbRango.Enabled = true;
                    txtNombre.ReadOnly = false;
                    txtApellido.ReadOnly = false;
                    txtEdad.ReadOnly = false;
                    rbMasculino.Enabled = true;
                    rbFemenino.Enabled = true;
                    txtNacimiento.Enabled = true;
                    txtAlimentacion.Enabled = true;
                    txtCondicionesPsicologicas.Enabled = true;
                    txtSexualidad.Enabled = true;
                    txtOperaciones.Enabled = true;
                    txtIntoleranciaMedicinal.Enabled = true;
                    txtSaludPadres.Enabled = true;
                    txtSaludHermanos.Enabled = true;
                    txtSaludEsposaHijos.Enabled = true;
                    txtSaludFamiliarGeneral.Enabled = true;                    
                    txtFechaRegistro.Enabled = true;
                    txtFechaUpdate.Enabled = false;
                    cmbDepartamento.Enabled = true;
                    cmbSeccionNaval.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    //this.btnImprimir.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    txtID.ReadOnly = true;
                    cmbRango.Enabled = false;
                    txtNombre.ReadOnly = true;
                    txtApellido.ReadOnly = true;
                    txtEdad.ReadOnly = true;
                    rbMasculino.Enabled = false;
                    rbFemenino.Enabled = false;
                    txtNacimiento.Enabled = false;
                    txtAlimentacion.Enabled = false;
                    txtCondicionesPsicologicas.Enabled = false;
                    txtSexualidad.Enabled = false;
                    txtOperaciones.Enabled = false;
                    txtIntoleranciaMedicinal.Enabled = false;
                    txtSaludPadres.Enabled = false;
                    txtSaludHermanos.Enabled = false;
                    txtSaludEsposaHijos.Enabled = false;
                    txtSaludFamiliarGeneral.Enabled = false;
                    txtFechaRegistro.Enabled = false;
                    txtFechaUpdate.Enabled = false;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    break;

                default:
                    break;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            frmBuscarPaciente ofrmBuscarPaciente = new frmBuscarPaciente();
            ofrmBuscarPaciente.ShowDialog();
            string cCodigo = ofrmBuscarPaciente.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedula.Text = Convert.ToString(cCodigo).Trim();

            }

            if (txtCedula.Text == "")
            {
                MessageBox.Show("No se permiten busquedas con el campo cedula vacio...");
                txtCedula.Focus();
            }
            else
            {
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    MyCommand.CommandText = "SELECT id_paciente, cedula, rango, nombre, apellido, edad, sexo, dato_nacimiento, " +
                        "dato_alimentacion, dato_condicionespsicologicas, dato_sexualidad, dato_operaciones, " +
                        "dato_intoleranciamedicinal, dato_saludpadres, dato_saludhermanos, dato_saludesposahijos, " + 
                        "dato_saludfamiliargeneral, fecharegistro, fechaupdate, fechanac, seccionaval, departamento, cedulamilitar FROM paciente " +
                        "WHERE cedula = " + "'" + txtCedula.Text + "'" + "";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtID.Text = MyReader["id_paciente"].ToString();
                            cmbRango.SelectedValue = MyReader["rango"].ToString();
                            txtNombre.Text = MyReader["nombre"].ToString().Trim();
                            txtApellido.Text = MyReader["apellido"].ToString().Trim();                            
                            string sexo = MyReader["sexo"].ToString();
                            if (sexo == "M")
                            {
                                rbMasculino.Checked = true;
                            }
                            else
                            {
                                rbFemenino.Checked = true;
                            }
                            txtNacimiento.Text = MyReader["dato_nacimiento"].ToString();
                            txtAlimentacion.Text = MyReader["dato_alimentacion"].ToString();
                            txtCondicionesPsicologicas.Text = MyReader["dato_condicionespsicologicas"].ToString();
                            txtSexualidad.Text = MyReader["dato_sexualidad"].ToString();
                            txtOperaciones.Text = MyReader["dato_operaciones"].ToString();
                            txtIntoleranciaMedicinal.Text = MyReader["dato_intoleranciamedicinal"].ToString();
                            txtSaludPadres.Text = MyReader["dato_saludpadres"].ToString();
                            txtSaludHermanos.Text = MyReader["dato_saludhermanos"].ToString();
                            txtSaludEsposaHijos.Text = MyReader["dato_saludesposahijos"].ToString();
                            txtSaludFamiliarGeneral.Text = MyReader["dato_saludfamiliargeneral"].ToString();
                            txtFechaRegistro.Value = Convert.ToDateTime(MyReader["fecharegistro"]);
                            txtFechaUpdate.Value = Convert.ToDateTime(MyReader["fechaupdate"]);
                            cmbDepartamento.SelectedValue = MyReader["departamento"].ToString();
                            cmbSeccionNaval.SelectedValue = MyReader["seccionaval"].ToString();
                            txtCedulaMilitar.Text = MyReader["cedulamilitar"].ToString();

                            // Calcula Edad
                           // txtEdad.Text = MyReader["edad"].ToString();
                            txtEdad.Text = clsProcesos.CalculaEdad(Convert.ToDateTime(MyReader["fechanac"])).ToString("N");

                        }

                        this.cModo = "Buscar";
                        this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...");
                        this.cModo = "Nuevo";
                        this.Botones();
                        //this.Limpiar();
                        //this.txtCedula.Focus();
                        txtNombre.Focus();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            this.Limpiar();
            cModo = "Nuevo";
            this.Botones();
            this.ProximoCodigo();            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cModo == "Nuevo")
            {
                if (txtCedula.Text == "")
                {
                    MessageBox.Show("Para grabar no se permite la CEDULA en blanco....");
                    txtCedula.Focus();
                }
                else if (txtNombre.Text == "")
                {
                    MessageBox.Show("Para grabar no se permite el NOMBRE en blanco...");
                    txtNombre.Focus();
                }
                else if (txtApellido.Text == "")
                {
                    MessageBox.Show("Para grabar no se permite el APELLIDO en blanco...");
                    txtApellido.Focus();
                }
                else if (txtEdad.Text == "")
                {
                    MessageBox.Show("Para grabar no se permite la EDAD en blanco...");
                    txtEdad.Focus();
                }

                try
                {
                    //Verificando si la cedula existe. Si NO existe que grabe el registro.
                    // Step 1 - Connecting to the database
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - Creating the Command
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - Command SQL Statement
                    MyCommand.CommandText = "SELECT count(*) FROM paciente WHERE cedula = " + "'" + txtCedula.Text + "'" + "";

                    // Step 4 - Opening the connection
                    MyclsConexion.Open();

                    // Step 5 - Executing the Command then passing the result to the variable myResult                    
                    Int32 myResult = Convert.ToInt32(MyCommand.ExecuteScalar());

                    // Step 6 - Closing the connection
                    MyclsConexion.Close();

                    if (myResult > 0)
                    {
                        // Si encuentra resultados
                        MessageBox.Show("Esta CEDULA ya existe, por favor hacer una BUSQUEDA...");
                        this.Limpiar();
                        cModo = "Inicio";
                        this.Botones();
                        txtCedula.Focus();
                    }
                    else
                    {
                        // En caso de que la cedula no exista
                        try
                        {
                            // Step 1 - Connecting to the database
                            //MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                            // Step 2 - Crear el comando de ejecucion
                            MySqlCommand myCommand = MyclsConexion.CreateCommand();

                            // Step 3 - Comando a ejecutar                        
                            myCommand.CommandText = "INSERT INTO paciente(cedula, rango, nombre, apellido, edad, sexo, departamento, seccionaval, " +
                                "dato_nacimiento, dato_alimentacion, dato_condicionespsicologicas, dato_sexualidad, dato_operaciones, " +
                                "dato_intoleranciamedicinal, dato_saludpadres, dato_saludhermanos, dato_saludesposahijos, dato_saludfamiliargeneral, " +
                                "fecharegistro, fechaupdate, cedulamilitar) VALUES(@cedula, @rango, @nombre, @apellido, @edad, @sexo, @departamento, " +
                                "@sn, @dato_nacimiento, @dato_alimentacion, " +
                                "@dato_condicionespsicologicas, @dato_sexualidad, @dato_operaciones, @dato_intoleranciamedicinal, @dato_saludpadres, " +
                                "@dato_saludhermanos, @dato_saludesposahijos, @dato_saludfamiliargeneral, @fecharegistro, @fechaupdate, @cedulamilitar)";
                            myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                            myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                            myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                            myCommand.Parameters.AddWithValue("@apellido", txtApellido.Text);
                            myCommand.Parameters.AddWithValue("@edad", txtEdad.Text);
                            if (rbMasculino.Checked)
                            {
                                myCommand.Parameters.AddWithValue("@sexo", "M");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@sexo", "F");
                            }
                            myCommand.Parameters.AddWithValue("@departamento", cmbDepartamento.SelectedValue);
                            myCommand.Parameters.AddWithValue("@sn", cmbSeccionNaval.SelectedValue);
                            myCommand.Parameters.AddWithValue("@dato_nacimiento", txtNacimiento.Text);
                            myCommand.Parameters.AddWithValue("@dato_alimentacion", txtAlimentacion.Text);
                            myCommand.Parameters.AddWithValue("@dato_condicionespsicologicas", txtCondicionesPsicologicas.Text);
                            myCommand.Parameters.AddWithValue("@dato_sexualidad", txtSexualidad.Text);
                            myCommand.Parameters.AddWithValue("@dato_operaciones", txtOperaciones.Text);
                            myCommand.Parameters.AddWithValue("@dato_intoleranciamedicinal", txtIntoleranciaMedicinal.Text);
                            myCommand.Parameters.AddWithValue("@dato_saludpadres", txtSaludPadres.Text);
                            myCommand.Parameters.AddWithValue("@dato_saludhermanos", txtSaludHermanos.Text);
                            myCommand.Parameters.AddWithValue("@dato_saludesposahijos", txtSaludEsposaHijos.Text);
                            myCommand.Parameters.AddWithValue("@dato_saludfamiliargeneral", txtSaludFamiliarGeneral.Text);
                            myCommand.Parameters.AddWithValue("@fecharegistro", txtFechaRegistro.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            myCommand.Parameters.AddWithValue("@fechaupdate", txtFechaUpdate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            myCommand.Parameters.AddWithValue("@cedulamilitar", txtCedulaMilitar.Text);

                            // Step 4 - Opening the connection
                            MyclsConexion.Open();

                            // Step 5 - Executing the query
                            myCommand.ExecuteNonQuery();

                            // Step 6 - Closing the connection
                            MyclsConexion.Close();

                            MessageBox.Show("Informacion guardada satisfactoriamente...");
                        }
                        catch (MySqlException myEx)
                        {
                            MessageBox.Show(myEx.Message);
                        }

                        this.Limpiar();
                        cModo = "Inicio";
                        this.Botones();

                    }

                }
                catch (MySqlException myEx)
                {
                    MessageBox.Show(myEx.Message);
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
                        myCommand.CommandText = "UPDATE paciente SET cedula = @cedula, rango = @rango, nombre = @nombre, " +
                            "apellido = @apellido, edad = @edad, sexo = @sexo, departamento = @departamento, seccionaval = @sn, " +
                            "dato_nacimiento = @dato_nacimiento, dato_alimentacion = @dato_alimentacion, dato_condicionespsicologicas = @dato_condicionespsicologicas, " +
                            "dato_sexualidad = @dato_sexualidad, dato_operaciones = @dato_operaciones, dato_intoleranciamedicinal = @dato_intoleranciamedicinal, " +
                            "dato_saludpadres = @dato_saludpadres, dato_saludhermanos = @dato_saludhermanos, dato_saludesposahijos = @dato_saludesposahijos, " +
                            "dato_saludfamiliargeneral = @dato_saludfamiliargeneral, fecharegistro = @fecharegistro, fechaupdate = @fechaupdate, " +
                            "cedulamilitar = @cedulamilitar "+
                            "WHERE id_paciente = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@apellido", txtApellido.Text);
                        myCommand.Parameters.AddWithValue("@edad", txtEdad.Text);
                        if (rbMasculino.Checked)
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "M");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "F");
                        }
                        myCommand.Parameters.AddWithValue("@departamento", cmbDepartamento.SelectedValue);
                        myCommand.Parameters.AddWithValue("@sn", cmbSeccionNaval.SelectedValue);
                        myCommand.Parameters.AddWithValue("@dato_nacimiento", txtNacimiento.Text);
                        myCommand.Parameters.AddWithValue("@dato_alimentacion", txtAlimentacion.Text);
                        myCommand.Parameters.AddWithValue("@dato_condicionespsicologicas", txtCondicionesPsicologicas.Text);
                        myCommand.Parameters.AddWithValue("@dato_sexualidad", txtSexualidad.Text);
                        myCommand.Parameters.AddWithValue("@dato_operaciones", txtOperaciones.Text);
                        myCommand.Parameters.AddWithValue("@dato_intoleranciamedicinal", txtIntoleranciaMedicinal.Text);
                        myCommand.Parameters.AddWithValue("@dato_saludpadres", txtSaludPadres.Text);
                        myCommand.Parameters.AddWithValue("@dato_saludhermanos", txtSaludHermanos.Text);
                        myCommand.Parameters.AddWithValue("@dato_saludesposahijos", txtSaludEsposaHijos.Text);
                        myCommand.Parameters.AddWithValue("@dato_saludfamiliargeneral", txtSaludFamiliarGeneral.Text);
                        myCommand.Parameters.AddWithValue("@fecharegistro", txtFechaRegistro.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        myCommand.Parameters.AddWithValue("@fechaupdate", txtFechaActual.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        myCommand.Parameters.AddWithValue("@cedulamilitar", txtCedulaMilitar.Text);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Gestion de Plantaciones v1.0", MessageBoxButtons.YesNo,
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cTitulo = "";
            string cUsuario = frmLogin.cUsuarioActual; ;
            if (txtCedula.Text == "" || txtID.Text =="")
            {
                MessageBox.Show("El Campo Cedulo o ID no Debe Estar en Blanco, Favor Verificar", "Sistema Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    StringBuilder sbQuery = new StringBuilder();
                    MySqlConnection oMiclsConexion = new MySqlConnection(cclsConexion);
                    MySqlCommand oComando = new MySqlCommand();
                    MySqlDataAdapter oAdaptador = new MySqlDataAdapter();
                    DataTable dtPaciente = new DataTable();

                    oMiclsConexion.Open();
                    oComando = oMiclsConexion.CreateCommand();
                    oComando.Connection = oMiclsConexion;

                    sbQuery.Clear();
                    sbQuery.Append("SELECT paciente.id_paciente,paciente.cedula,paciente.nombre,");
                    sbQuery.Append("paciente.apellido,paciente.edad,paciente.sexo,paciente.dato_nacimiento,");
                    sbQuery.Append("paciente.dato_alimentacion, paciente.dato_condicionespsicologicas, ");
                    sbQuery.Append("paciente.dato_sexualidad, paciente.dato_operaciones, ");
                    sbQuery.Append("paciente.dato_intoleranciamedicinal, paciente.dato_saludpadres, ");
                    sbQuery.Append("paciente.dato_saludhermanos, paciente.dato_saludesposahijos,");
                    sbQuery.Append("paciente.dato_saludfamiliargeneral, paciente.fecharegistro, paciente.fechaupdate,");
                    sbQuery.Append("rangos.rango_descripcion");
                    sbQuery.Append(" from paciente");
                    sbQuery.Append(" inner join rangos on rangos.rango_id = paciente.rango");
                    sbQuery.Append(" where paciente.id_paciente = " + txtID.Text + "");
                    //sbQuery.Append("");
                    //sbQuery.Append("");
                    //sbQuery.Append("");


                    oComando.CommandText = sbQuery.ToString();
                    oAdaptador = new MySqlDataAdapter(oComando);
                    oAdaptador.Fill(dtPaciente);
                    //oComando.Dispose();
                    //oMiclsConexion.Close();

                    int nRegistros = dtPaciente.Rows.Count;
                    if (nRegistros == 0)
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
                        cTitulo = "ANTECEDENTES PERSONALES";

                        //6to Instanciamos nuestro REPORTE
                        
                        Reportes.RepAntecedentes oRepAntecedente = new Reportes.RepAntecedentes();
                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        oRepAntecedente.SummaryInfo.ReportTitle = cTitulo;

                        frmPrinter oFrmPrinter = new frmPrinter(dtPaciente, oRepAntecedente, cTitulo);
                        oFrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                        oFrmPrinter.ShowDialog();

                    }
                }
                catch (Exception myEx)
                {
                    //MessageBox.Show(myEx.Message);
                    //throw;
                }
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCedula_Validating(object sender, CancelEventArgs e)
        {
            if (cModo != "Nuevo" || cModo != "Inicio")
            {
                if (txtCedula.MaskFull == false)
                {
                    MessageBox.Show("No se permiten busquedas con el campo cedula vacio...");
                    txtCedula.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        // Step 1 - clsConexion
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - creating the command object
                        MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                        // Step 3 - creating the commandtext
                        MyCommand.CommandText = "SELECT id_paciente, cedula, rango, nombre, apellido, edad, sexo, dato_nacimiento, " +
                            "dato_alimentacion, dato_condicionespsicologicas, dato_sexualidad, dato_operaciones, " +
                            "dato_intoleranciamedicinal, dato_saludpadres, dato_saludhermanos, dato_saludesposahijos, " +
                            "dato_saludfamiliargeneral, fecharegistro, fechaupdate FROM paciente " +
                            "WHERE cedula = " + "'" + txtCedula.Text + "'" + "";

                        // Step 4 - connection open
                        MyclsConexion.Open();

                        // Step 5 - Creating the DataReader                    
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();

                        // Step 6 - Verifying if Reader has rows
                        if (MyReader.HasRows)
                        {
                            while (MyReader.Read())
                            {
                                txtID.Text = MyReader["id_paciente"].ToString();
                                cmbRango.SelectedValue = MyReader["rango"].ToString();
                                txtNombre.Text = MyReader["nombre"].ToString();
                                txtApellido.Text = MyReader["apellido"].ToString();
                                txtEdad.Text = MyReader["edad"].ToString();
                                string sexo = MyReader["sexo"].ToString();
                                if (sexo == "M")
                                {
                                    rbMasculino.Checked = true;
                                }
                                else
                                {
                                    rbFemenino.Checked = true;
                                }
                                txtNacimiento.Text = MyReader["dato_nacimiento"].ToString();
                                txtAlimentacion.Text = MyReader["dato_alimentacion"].ToString();
                                txtCondicionesPsicologicas.Text = MyReader["dato_condicionespsicologicas"].ToString();
                                txtSexualidad.Text = MyReader["dato_sexualidad"].ToString();
                                txtOperaciones.Text = MyReader["dato_operaciones"].ToString();
                                txtIntoleranciaMedicinal.Text = MyReader["dato_intoleranciamedicinal"].ToString();
                                txtSaludPadres.Text = MyReader["dato_saludpadres"].ToString();
                                txtSaludHermanos.Text = MyReader["dato_saludhermanos"].ToString();
                                txtSaludEsposaHijos.Text = MyReader["dato_saludesposahijos"].ToString();
                                txtSaludFamiliarGeneral.Text = MyReader["dato_saludfamiliargeneral"].ToString();
                                txtFechaRegistro.Value = Convert.ToDateTime(MyReader["fecharegistro"]);
                                txtFechaUpdate.Value = Convert.ToDateTime(MyReader["fechaupdate"]);
                            }

                            this.cModo = "Buscar";
                            this.Botones();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros con esta cedula...");
                            this.cModo = "Inicio";
                            this.Botones();
                            this.Limpiar();
                            this.txtCedula.Focus();
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
        }

        private void btnBuscarMilitar_Click(object sender, EventArgs e)
        {
            frmBuscarPaciente ofrmBuscarPaciente = new frmBuscarPaciente();
            ofrmBuscarPaciente.ShowDialog();
            string cCodigo = ofrmBuscarPaciente.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedulaMilitar.Text = Convert.ToString(cCodigo).Trim();
            }

        }

        private void chkDependiente_CheckedChanged(object sender, EventArgs e)
        {
            DependenciaMilitar();
        }

            
       }



    }

