using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using VFPToolkit;

namespace DispensarioMedico
{
    public partial class frmLogin : Form
    {
        int nIntentos = 0;
        public static string cUsuarioActual = "";
        public static int nNivel = 0;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //realiza a clsConexion           
               
                string constring = DispensarioMedico.clsConexion.ConectionString; // con.conectarConta();
               MySqlConnection objCon = new MySqlConnection();
                objCon.ConnectionString = constring;

                objCon.Open();
                //consulta el usuario en la tabla usuario
                string sql;
                sql = "select * from usuario where nombre ='" + txtUsuario.Text.Trim() + "' and clave='" + txtClave.Text + "' ";
                MySqlCommand mycm = new MySqlCommand();
                mycm.Connection = objCon;
                mycm.CommandText = sql;
                MySqlDataReader myreader = mycm.ExecuteReader();
                //asigna el resultado de la cuenta encontada
                if (!myreader.HasRows)
                {
                    MessageBox.Show("Usuario o Clave Incorrecta", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset the cursor to the default for all controls.
                    Cursor.Current = Cursors.Default;
                    this.Cursor = Cursors.Default;
                    this.UseWaitCursor = false;
                    Application.UseWaitCursor = false;                    
                    //txtClave.Focus();
                    txtUsuario.Focus();
                    nIntentos++;
                    if (nIntentos >= 3)
                    {
                        MessageBox.Show("Excedió Límite de Intentos, pruebe mas tarde!!", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }
                else
                {
                    // nNivel = Convert.ToInt32(myreader.GetString(2));
                    // Reset the cursor to the default for all controls.
                    Cursor.Current = Cursors.Default;
                    this.Cursor = Cursors.Default;
                    this.UseWaitCursor = false;
                    Application.UseWaitCursor = false;

                    frmMenu ofrmMenu = new frmMenu();
                    ofrmMenu.Show();
                    this.Hide(); //esto sirve para ocultar el formulario de login
                    myreader.Read();
                    ofrmMenu.nNivel = myreader.GetInt32(4);
                    ofrmMenu.cUsuarioActual = txtUsuario.Text.Trim();
                   nNivel = myreader.GetInt32(4);
                   cUsuarioActual = txtUsuario.Text.Trim();                                   
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Acceso al Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
             //   Application.Exit();
               
                Cursor.Current = Cursors.Default;
                this.Cursor = Cursors.Default;
                this.UseWaitCursor = false;
                Application.UseWaitCursor = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Acceso al Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
               // Application.Exit();
                Cursor.Current = Cursors.Default;
                this.Cursor = Cursors.Default;
                this.UseWaitCursor = false;
                Application.UseWaitCursor = false;
            }
            
            finally
            {
            }
                         
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        
      
    }
}
