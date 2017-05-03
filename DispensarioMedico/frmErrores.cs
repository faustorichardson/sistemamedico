using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using VFPToolkit;


namespace DispensarioMedico
{
    public partial class frmErrores : frmBase
    {
        string cCadenaConexion = clsConexion.ConectionString;
        public String cModo = "Inicio";
        int nUltimo = 0;

        public frmErrores()
        {
            InitializeComponent();
        }

        private void frmErrores_Load(object sender, EventArgs e)
        {
            txtCodigoFuente.ReadOnly = true;
            txtCompania.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtHora.ReadOnly = true;
            txtLinea.ReadOnly = true;
            txtMensajeError.ReadOnly = true;
            txtPrograma.ReadOnly = true;
            txtUsuario.ReadOnly = true;

            nUltimo = Convert.ToInt32(UltimoRegistro());
            cModo = "Inicio";
            Botones();

        }
        private void Limpiar()
        {
            txtNoError.Clear();
            txtCodigoFuente.Clear();
            txtCompania.Clear();
            txtFecha.Clear();
            txtHora.Clear();
            txtLinea.Clear();
            txtMensajeError.Clear();
            txtPrograma.Clear();
            txtUsuario.Clear();

        }
        private bool ValidaVacio()
        {
            bool lRetorno = false;
            if (this.txtNoError.Text != "")
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

        private void Valida_Keypress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                //    MessageBox.Show("No se Permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = false;

            }
            else if (char.IsSeparator(e.KeyChar))
            {
                //MessageBox.Show("No se Permiten Espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                //MessageBox.Show("No se Permiten Caracteres Especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (!(char.IsNumber(e.KeyChar)) && (!(char.IsControl(e.KeyChar)) &&
                (e.KeyChar != (char)Keys.Back)))
            {

                e.Handled = true;

            }


        }
        private void Ejecutar()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select secuencia,linea,usuario,cia,time(fecha) as hora,date_format(fecha,'%d/%m/%Y') as fecha,");
            sbQuery.Append("message,programa");
            sbQuery.Append(" from errors");
            sbQuery.Append(" where secuencia = '" + txtNoError.Text + "'");
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataReader Lector;
            oCnn.Open();
            Lector = oCmd.ExecuteReader();
            if (Lector.Read())
            {
                txtNoError.Text = Lector.GetString("secuencia");
                txtCompania.Text = Convert.ToString(Lector.GetDecimal("cia"));
                //txtFecha.Text = Convert.ToString(registro["fecha"]);
                txtFecha.Text = Convert.ToDateTime(Lector.GetString("fecha")).ToLongDateString();
                txtHora.Text = Lector.GetString("hora");
                txtLinea.Text = Lector.GetString("linea"); ;
                txtUsuario.Text = Lector.GetString("usuario"); ;
                txtPrograma.Text = Lector.GetString("programa"); ;
                txtMensajeError.Text = Lector.GetString("message"); ;

            }
            oCnn.Close();

        }


        private string UltimoRegistro()
        {

            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select max(secuencia) as secuencia from errors");
            sbQuery.Append("");
            sbQuery.Append("");
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataReader oLector;
            oCnn.Open();
            oLector = oCmd.ExecuteReader();
            oLector.Read();

            return oLector.GetString("secuencia");
            oCnn.Close();
        }
        private string PrimerRegistro()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select min(secuencia) as secuencia from errors");

            MySqlConnection oCnn = new MySqlConnection(this.cCadenaConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataReader oLector;
            oCnn.Open();
            oLector = oCmd.ExecuteReader();
            oLector.Read();

            return oLector.GetString("secuencia");
            oCnn.Close();

        }

        private void cmdSiguiente_Click(object sender, EventArgs e)
        {
            if (ValidaVacio())
            {
                if (Convert.ToInt32(txtNoError.Text) < nUltimo)
                {
                    int Numero = Convert.ToInt32(txtNoError.Text);
                    int Subir = Numero + 1;
                    txtNoError.Text = Convert.ToString(Subir);

                    Ejecutar();
                    if (Convert.ToInt32(txtNoError.Text) == nUltimo)
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

        private void cmdAnterior_Click(object sender, EventArgs e)
        {
            if (ValidaVacio())
            {
                int Numero = Convert.ToInt32(txtNoError.Text);
                int Baja = Numero - 1;
                txtNoError.Text = Convert.ToString(Baja);

                if (Baja == 0)
                {
                    txtNoError.Text = "1";

                }
                if (Convert.ToInt32(txtNoError.Text) == 1)
                {
                    cModo = "Anterior";
                }
                else
                {
                    cModo = "Siguiente";
                }
                Ejecutar();
                Botones();
            }
            
        }

        private void cmdUltimo_Click(object sender, EventArgs e)
        {
            txtNoError.Text = UltimoRegistro();
            Ejecutar();
            cModo = "Ultimo";
            Botones();
        }

        private void cmdPrimero_Click(object sender, EventArgs e)
        {
            txtNoError.Text = PrimerRegistro();
            Ejecutar();
            //ActivaDesactivaBotones();
            cModo = "Primero";
            Botones();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            cModo = "Inicio";
            Botones();
        }

        private void cmdPrinter_Click(object sender, EventArgs e)
        {
            frmImprimirErrores ofrmImprimeErrores = new frmImprimirErrores();
            ofrmImprimeErrores.ShowDialog();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (txtNoError.Text == "")
            {
                frmBuscarErrores ofrmBuscarErrores = new frmBuscarErrores();
                ofrmBuscarErrores.ShowDialog();
                txtNoError.Text = ofrmBuscarErrores.cBuscaErrores;


            }
            if (txtNoError.Text != "")
            {
                //if (Convert.ToInt32(txtSecuencia.Text) == Convert.ToInt32(PrimerRegistro()))
                if (Convert.ToInt16(txtNoError.Text) == 1)
                {
                    cModo = "Primero";
                }
                else if (Convert.ToInt32(txtNoError.Text) == Convert.ToInt32(UltimoRegistro()))
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
    }
}
