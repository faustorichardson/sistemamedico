using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.Common;
using System.Diagnostics;
using VFPToolkit;
using System.IO;


namespace DispensarioMedico
{
    public partial class frmBackUp : frmBase
    {
        String cCadenaclsConexion = clsConexion.ConectionString;
        string cSecuencia = "";
        string cFecha = "";
        string cHora = "";
        string cDirectorio = "";
        StringBuilder sbQuery = new StringBuilder();

        public frmBackUp()
        {
            InitializeComponent();
        }

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            lblEsperaBackUp.Text = "";
            lblEsperaRestaurar.Text = "";
            cmdAceptar.Enabled = false;
            lblEsperaBackUp.Visible = false;
            lblEsperaRestaurar.Visible = false;
            lblNombreArc.Visible = false;
            lblUbicacion.Visible = false;
            porcentaje.Visible = false;
            lblPorcentaje.Visible = false;
            Proximo();
          
        }
        private void BackUp()
        {
            MySqlTransaction oTransaccion = null;
            MySqlConnection oCnn = new MySqlConnection();
            MySqlCommand oCmd = new MySqlCommand();

            try
            {
                oCnn.ConnectionString = clsConexion.ConectionString;
                oCmd = oCnn.CreateCommand();
                oCmd.Connection = oCnn;

                MySqlBackup oMiBackUp = new MySqlBackup(oCmd);
                SaveFileDialog oGuardarArchivo = new SaveFileDialog();
                oGuardarArchivo.InitialDirectory = Application.StartupPath;
                DialogResult oResultado = oGuardarArchivo.ShowDialog();
                string file = oGuardarArchivo.FileName + ".sql";

                if (oResultado == DialogResult.OK)
                {
                    oCnn.Open();
                    oTransaccion = oCnn.BeginTransaction();
                    oCmd.Transaction = oTransaccion;

                    oMiBackUp.ExportToFile(file);

                    lblEsperaBackUp.Visible = true;
                    lblEsperaBackUp.Text = "Espere Mientras se Completa el BackUp";
                    lblNombreArc.Visible = true;
                    lblNombreArc.Text = System.IO.Path.GetFileName(oGuardarArchivo.FileName);
                    lblUbicacion.Visible = true;
                    lblUbicacion.Text = System.IO.Path.GetDirectoryName(oGuardarArchivo.FileName);

                    timer1.Start();
                    oCnn.Close();
                    pbProgreso.Maximum = 100;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Backup", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                clsExceptionLog.AgregarError(ex);
                oTransaccion.Rollback();
                return;
            }
            oCnn.Close();
        }

        private void RestaurarBackUp()
        {
            MySqlTransaction oTransaccion = null;
            MySqlConnection oCnn = new MySqlConnection();
            MySqlCommand oCmd = new MySqlCommand();
           //oCnn.Close();

            try
            {
                oCnn.ConnectionString = clsConexion.ConectionString;
                oCmd = oCnn.CreateCommand();
                oCmd.Connection = oCnn;
                oCnn.Open();
                oTransaccion = oCnn.BeginTransaction();
                oCmd.Transaction = oTransaccion;

                MySqlBackup oImportarBackUp = new MySqlBackup(oCmd);

                OpenFileDialog oAbrir = new OpenFileDialog();
                //SaveFileDialog oAbrir = new SaveFileDialog();
                DialogResult Resultado = oAbrir.ShowDialog();
                string File = oAbrir.FileName;

                if (Resultado == DialogResult.OK)
                {

                    //oCnn.Open();
                    oImportarBackUp.ImportFromFile(File);

                    lblEsperaRestaurar.Visible = true;
                    lblEsperaRestaurar.Text = "Espere Mientras se Restaura el BackUp";
                    lblNombreArc.Visible = true;
                    lblNombreArc.Text = System.IO.Path.GetFileName(oAbrir.FileName);
                    lblUbicacion.Visible = true;
                    lblUbicacion.Text = System.IO.Path.GetDirectoryName(oAbrir.FileName);

                    timer2.Start();
                    oCnn.Close();
                    PbProgreso2.Maximum = 100;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Backup", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);

                oTransaccion.Rollback();
                return;
            }
            oCnn.Close();
        }
        private void Proximo()
        {
            
            MySqlConnection oCnn = new MySqlConnection(cCadenaclsConexion);
            MySqlCommand oComando = new MySqlCommand();
            oComando = oCnn.CreateCommand();
            sbQuery.Clear();
            sbQuery.Append("SELECT count(*) FROM backup");
            oComando.CommandText = sbQuery.ToString();
            oCnn.Open();
            int nCodigo;
            nCodigo = Convert.ToInt32(oComando.ExecuteScalar());
            nCodigo = nCodigo + 1;
            cSecuencia = nCodigo.ToString();
            oCnn.Close();
            ////clsManejoBackUp oclsBackUp = new clsManejoBackUp(this.cCadenaclsConexion);
            //DataSet dsBackup = new DataSet();
            ////dsBackup = oclsBackUp.Proximo();
            //if (dsBackup.Tables[0].Rows.Count > 0)
            //{
            //    dsBackup.Tables[0].TableName = "backup";
            //    foreach (DataRow registro in dsBackup.Tables[0].Rows)
            //    {
            //        if (registro["proximo"] == null || registro["proximo"] == "")
            //        {
            //            cSecuencia = VFPToolkit.strings.PadL(cSecuencia, 3, Convert.ToChar(cCero));
            //        }
            //        else
            //        {
            //            cSecuencia = cSecuencia = VFPToolkit.strings.PadL(registro["proximo"].ToString(),
            //                3, Convert.ToChar(cCero));
            //        }

            //    }

            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbProgreso.Value <= pbProgreso.Maximum)
            {
                pbProgreso.Value = pbProgreso.Value + 2;
                porcentaje.Visible = true;
                porcentaje.Text = pbProgreso.Value.ToString() + "%";
                cmdAceptar.Enabled = true;
                if (pbProgreso.Value == 100)
                {
                    lblEsperaBackUp.Text = "BackUp Completado Satisfactoriamente, Presione ACEPTAR";
                    cmdSalir.Enabled = false;

                }
            }
            pbProgreso.Increment(2);

           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (PbProgreso2.Value <= PbProgreso2.Maximum)
            {
                PbProgreso2.Value = PbProgreso2.Value + 2;
                lblPorcentaje.Visible = true;
                lblPorcentaje.Text = PbProgreso2.Value.ToString() + "%";
                cmdAceptar.Enabled = false;
                if (PbProgreso2.Value == 100)
                {
                    lblEsperaRestaurar.Text = "BackUp Restaurado Satisfactoriamente";
                    cmdSalir.Enabled = true;

                }
            }
            PbProgreso2.Increment(2);
        }
        private void cmdBackUp_Click(object sender, EventArgs e)
        {
            SaveFileDialog oGuardarArchivo = new SaveFileDialog();
            //copiaseguridad();
            BackUp();
            //lblNombreArc.Text = oGuardarArchivo.FileName;
            // lblUbicacion.Text = oGuardarArchivo.
        }

        private void cmdRestaurar_Click(object sender, EventArgs e)
        {
            
            RestaurarBackUp();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pbProgreso.Value = 0;
            porcentaje.Visible = false;
            lblEsperaBackUp.Visible = false;
            cmdAceptar.Enabled = false;
            lblNombreArc.Visible = false;
            lblUbicacion.Visible = false;
            string cFecha = DateTime.Now.ToShortDateString();
            //string cCero = "0";
            //string cAno = dates.Year(cFecha).ToString();
            //string cMes = VFPToolkit.strings.PadL(dates.Month(cFecha).ToString(), 2, Convert.ToChar(cCero));
            //string cDia = VFPToolkit.strings.PadL(dates.Day(cFecha).ToString(), 2, Convert.ToChar(cCero));
            cHora = DateTime.Now.ToShortTimeString();
            //string fecha = " '" + cAno + "/" + cMes + "/" + cDia + " '";
           
            //FrmMenInicio ofrmmeninicio = new FrmMenInicio();
            frmLogin ofrmLogin = new frmLogin();
            string usuario = frmLogin.cUsuarioActual;
            try
            {
                MySqlConnection oCnn = new MySqlConnection(cCadenaclsConexion);
                MySqlCommand oComando = new MySqlCommand();
                oComando = oCnn.CreateCommand();
                sbQuery.Clear();
                sbQuery.Append("insert into backup(secuencia,fecha,hora,destino,usuario)");
                sbQuery.Append(" values(@secuencia,@fecha,@hora,@destino,@usuario)");
                sbQuery.Append("");
                sbQuery.Append("");
                oComando.Parameters.AddWithValue("@secuencia", cSecuencia);
                oComando.Parameters.AddWithValue("@fecha",Convert.ToDateTime(cFecha));
                oComando.Parameters.AddWithValue("@hora", cHora);
                oComando.Parameters.AddWithValue("@destino", lblUbicacion.Text);
                oComando.Parameters.AddWithValue("@usuario", usuario);
                oComando.CommandText = sbQuery.ToString();


                oCnn.Open();
                MySqlTransaction myTranSact = oCnn.BeginTransaction();

                oComando.Transaction = myTranSact;
                int nResultado = oComando.ExecuteNonQuery();

                //clsManejoBackUp oclsBackUp = new clsManejoBackUp(this.cCadenaclsConexion);
                //if (Convert.ToBoolean(oclsBackUp.Agregar(Convert.ToInt32(cSecuencia), Convert.ToDateTime(fecha), cHora, lblUbicacion.Text, usuario)))
                if (nResultado > 0)
                {
                    myTranSact.Commit();
                    MessageBox.Show("BackUp Guardado Satisfactoriamente!!", "Sistema ReaSanto v1.0",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdSalir.Enabled = true;
                    cmdAceptar.Enabled = false;
                    oCnn.Close();
                }
                else
                {
                    myTranSact.Rollback();
                    MessageBox.Show("No se pudo guardar El Backup...");
                }
                oCnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Proximo();
            cmdAceptar.Enabled = false;
           
        }

        private void cmdHistorial_Click(object sender, EventArgs e)
        {
            frmHistorialBackups ofrmHistorialBackUp = new frmHistorialBackups();
            ofrmHistorialBackUp.ShowDialog();
        }

        
    }
}
