using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DispensarioMedico
{
    public partial class frmHistorialBackups : frmBase
    {
        String cCadenaclsConexion = clsConexion.ConectionString;
        string cModo = "";
        int nUltimo = 0;
        int nUlti = 0;

        public frmHistorialBackups()
        {
            InitializeComponent();
        }

        private void frmHistorialBackups_Load(object sender, EventArgs e)
        {
            txtHora.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtDestino.ReadOnly = true;
            txtUsuario.ReadOnly = true;
            cModo = "Inicio";
            Botones();
        }
        private bool ValidaVacio()
        {
            bool lRetorno = false;
            if (this.txtSecuencia.Text != "")
            {
                lRetorno = true;
            }
            else
            {
                lRetorno = false;
                MessageBox.Show("Debe Introducir un Numero de Error!!", "Sistema ReaSanto v1.0",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return lRetorno;
        }
        public void Botones()
        {

            switch (cModo)
            {

                case "Inicio":

                    this.cmdBuscar.Enabled = true;
                    this.cmdCancelar.Enabled = false;
                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = false;
                    this.cmdAnterior.Enabled = false;
                    this.cmdSiguiente.Enabled = false;
                    this.cmdUltimo.Enabled = true;
                    txtSecuencia.Focus();
                    break;

                case "Cancelar":

                    this.cmdBuscar.Enabled = false;
                    this.cmdCancelar.Enabled = false;

                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = false;
                    this.cmdAnterior.Enabled = false;
                    this.cmdSiguiente.Enabled = false;
                    this.cmdUltimo.Enabled = true;
                    break;
                case "Buscar":

                    this.cmdBuscar.Enabled = true;
                    this.cmdCancelar.Enabled = true;

                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = false;
                    this.cmdAnterior.Enabled = false;
                    this.cmdSiguiente.Enabled = false;
                    this.cmdUltimo.Enabled = true;
                    break;

                case "Primero":

                    this.cmdBuscar.Enabled = true;
                    this.cmdCancelar.Enabled = true;
                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = false;
                    this.cmdAnterior.Enabled = false;
                    this.cmdSiguiente.Enabled = true;
                    this.cmdUltimo.Enabled = true;
                    break;

                case "Ultimo":

                    this.cmdBuscar.Enabled = true;
                    this.cmdCancelar.Enabled = true;
                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = true;
                    this.cmdAnterior.Enabled = true;
                    this.cmdSiguiente.Enabled = false;
                    this.cmdUltimo.Enabled = false;
                    break;

                case "Siguiente":

                    this.cmdBuscar.Enabled = true;
                    this.cmdCancelar.Enabled = true;
                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = true;
                    this.cmdAnterior.Enabled = true;
                    this.cmdSiguiente.Enabled = true;
                    this.cmdUltimo.Enabled = true;
                    break;

                case "Anterior":

                    this.cmdBuscar.Enabled = true;
                    this.cmdCancelar.Enabled = true;
                    this.cmdPrinter.Enabled = true;
                    this.cmdSalir.Enabled = true;
                    this.cmdPrimero.Enabled = false;
                    this.cmdAnterior.Enabled = false;
                    this.cmdSiguiente.Enabled = true;
                    this.cmdUltimo.Enabled = true;
                    break;

            }
        }
        private void Ejecutar()
        {
            //if (txtSecuencia.Text == "")
            //{
            //    txtSecuencia.Text = "1";
            //}
            StringBuilder sbQuery = new StringBuilder();
            //if (txtSecuencia.Text == "")
            //{
            //    MessageBox.Show("Debe Especificar la Secuencia!!", "Sistema ReaSanto v1.0",
            //                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            sbQuery.Append("select secuencia,usuario,destino,date_format(fecha,'%d/%m/%Y') as fecha,");
            sbQuery.Append("hora from backup where secuencia = '" + txtSecuencia.Text + "'");

            //clsManejoBackUp oclsmanejobackups = new clsManejoBackUp(this.cCadenaclsConexion);
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataReader oLector;
            oCnn.Open();
            oLector = oCmd.ExecuteReader();
            if (oLector.Read())
            {
                txtDestino.Text = oLector.GetString("destino");
                txtFecha.Text = Convert.ToDateTime(oLector.GetString("fecha")).ToLongDateString();
                txtHora.Text = oLector.GetString("hora");
                txtSecuencia.Text = oLector.GetString("secuencia");
                txtUsuario.Text = oLector.GetString("usuario");
            }
            //else
            //{
            //   txtSecuencia.Text = UltimoRegistro();
            //    MessageBox.Show("Fin de los Registros", "Sistema ReaSanto v1.0", MessageBoxButtons.OK,
            //  MessageBoxIcon.Question);
            //}
            oCnn.Close();
            //}



        }
        private string UltimoRegistro()
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("select max(secuencia) as secuencia from backup");
                sbQuery.Append("");
                sbQuery.Append("");
                MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
                MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
                MySqlDataReader oLector;
                oCnn.Open();
                oLector = oCmd.ExecuteReader();
                oLector.Read();
                
                return oLector.GetString("secuencia").ToString();

                oCnn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Backup", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                return "";
            }
        }

        private string PrimerRegistro()
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("select min(secuencia) as secuencia from backup");
                sbQuery.Append("");
                sbQuery.Append("");
                MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
                MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
                MySqlDataReader oLector;
                oCnn.Open();
                oLector = oCmd.ExecuteReader();
                oLector.Read();
               
                return oLector.GetString("secuencia").ToString();
                oCnn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Backup", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                return "";
            }

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (txtSecuencia.Text == "")
            {
                //frmBuscarBackUp ofrmbuscaBackup = new frmBuscarBackUp(this.cCadenaclsConexion);
                //ofrmbuscaBackup.ShowDialog();
                //txtSecuencia.Text = ofrmbuscaBackup.cBuscaBackup;
                frmBuscarBackups ofrmBuscaBackup = new frmBuscarBackups();
                ofrmBuscaBackup.ShowDialog();
                txtSecuencia.Text = ofrmBuscaBackup.cBuscaBackup;

                Ejecutar();
            }
            if (txtSecuencia.Text != "")
            {
                //if (Convert.ToInt32(txtSecuencia.Text) == Convert.ToInt32(PrimerRegistro()))
                if (Convert.ToInt32(txtSecuencia.Text) == 1)
                {
                    cModo = "Primero";
                }
                else if (Convert.ToInt32(txtSecuencia.Text) == Convert.ToInt32(UltimoRegistro()))
                {
                    cModo = "Ultimo";
                }
                //if ((txtSecuencia.Text != PrimerRegistro()) || (txtSecuencia.Text != UltimoRegistro()))
                else
                {
                    cModo = "Siguiente";
                }
                Botones();

            }
            Ejecutar();
                 
        }

        private void cmdPrimero_Click(object sender, EventArgs e)
        {
            txtSecuencia.Text = PrimerRegistro();
            Ejecutar();
            //ActivaDesactivaBotones();
            cModo = "Primero";
            Botones();
            
        }

        private void cmdAnterior_Click(object sender, EventArgs e)
        {
            if (ValidaVacio())
            {

                int Numero = Convert.ToInt32(txtSecuencia.Text);
                int Baja = Numero - 1;
                txtSecuencia.Text = Baja.ToString();
                if (Baja == 0)
                {
                    txtSecuencia.Text = "1";

                }
                if (Convert.ToInt32(txtSecuencia.Text) == 1)
                {
                    cModo = "Anterior";
                }
                else
                {
                    cModo = "Siguiente";
                }
                Ejecutar();
                //ActivaDesactivaBotones();

                Botones();
            }
        }

        private void cmdSiguiente_Click(object sender, EventArgs e)
        {
            if (ValidaVacio())
            {
                //    if (Convert.ToUInt32(txtSecuencia.Text) < Convert.ToUInt32(UltimoRegistro()))
                //    {
                //nUltimo = Convert.ToInt32(UltimoRegistro());
                nUlti = Convert.ToInt32(UltimoRegistro());
                if (Convert.ToInt32(txtSecuencia.Text) < nUlti)
                {
                    int Numero = Convert.ToInt32(txtSecuencia.Text);
                    int Suma = Numero + 1;
                    txtSecuencia.Text = Suma.ToString();

                    Ejecutar();
                    if (Convert.ToInt32(txtSecuencia.Text) == nUltimo)
                    {
                        cModo = "Ultimo";

                    }
                    else
                    {
                        cModo = "Siguiente";
                    }
                    Botones();
                }
                //ActivaDesactivaBotones();

                //}
                else
                {
                    MessageBox.Show("Final de los Resgistros!!", "Sistema ReaSanto v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }
        }

        private void cmdUltimo_Click(object sender, EventArgs e)
        {
            txtSecuencia.Text = UltimoRegistro();
            Ejecutar();
            cModo = "Ultimo";
            Botones();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            txtDestino.Clear();
            txtFecha.Clear();
            txtHora.Clear();
            txtSecuencia.Clear();
            txtUsuario.Clear();
            cModo = "Inicio";
            Botones();
        }

        private void cmdPrinter_Click(object sender, EventArgs e)
        {
            //frmImprimeBackUps ofrmImprimeBackups = new frmImprimeBackUps(this.cCadenaclsConexion);
            //ofrmImprimeBackups.ShowDialog();
            frmImprimeBackUps ofrmImprimeBackup = new frmImprimeBackUps();
            ofrmImprimeBackup.ShowDialog();
        }
    }
}
