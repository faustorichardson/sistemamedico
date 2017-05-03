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
    public partial class frmImprimeBackUps : frmBase
    {
        String cCadenaclsConexion = clsConexion.ConectionString;
        string cTabla = "";
        string campo = "";

        public frmImprimeBackUps()
        {
            InitializeComponent();
        }

        private void frmImprimeBackUps_Load(object sender, EventArgs e)
        {
            cTabla = "gsisoft.errors";
            string query = "SELECT usuario FROM mae_usua order by usuario";
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
            MySqlCommand comando = new MySqlCommand(query, oCnn);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds, cTabla);
            grbSelPor.Visible = false;

            cboUsuario.DataSource = ds.Tables[0].DefaultView;
            //cboUsuario.DisplayMember = "usuario";
            cboUsuario.ValueMember = "usuario";
            cboUsuario.SelectedIndex = -1;
            rdbFecha.Checked = true;
        }

        private void rdbTodo_CheckedChanged(object sender, EventArgs e)
        {
            grbSelPor.Visible = false;
        }

        private void rdbSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            grbSelPor.Visible = true;
            grbUsuario.Visible = true;
            grbFechas.Visible = true;
            rdbUsuaFecha.Visible = true;
            //cboUsuario.DataSource = Procesos.DatosGeneral("Usuarios");

        }

        private void rdbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            grbFechas.Visible = false;
            grbUsuario.Visible = true;
        }

        private void rdbFecha_CheckedChanged(object sender, EventArgs e)
        {
            grbUsuario.Visible = false;
            grbFechas.Visible = true;
        }

        private void rdbUsuaFecha_CheckedChanged(object sender, EventArgs e)
        {
            grbUsuario.Visible = true;
            grbFechas.Visible = true;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            StringBuilder sbQuery = new StringBuilder();
            string cTitulo = "";
            sbQuery.Append("");
            string cCero = "0";
            string cAno = dates.Year(dtFechaInicial.Value).ToString();
            string cMes = VFPToolkit.strings.PadL(dates.Month(dtFechaInicial.Value).ToString(), 2, Convert.ToChar(cCero));
            string cDia = VFPToolkit.strings.PadL(dates.Day(dtFechaInicial.Value).ToString(), 2, Convert.ToChar(cCero));
            string cFechaInicial = cAno + "-" + cMes + "-" + cDia;
            string cFechaInicialFormato = cDia + "/" + cMes + "/" + cAno;
            cAno = dates.Year(dtFechaFinal.Value).ToString();
            cMes = VFPToolkit.strings.PadL(dates.Month(dtFechaFinal.Value).ToString(), 2, Convert.ToChar(cCero));
            cDia = VFPToolkit.strings.PadL(dates.Day(dtFechaFinal.Value).ToString(), 2, Convert.ToChar(cCero));
            string cFechaFinal = cAno + "-" + cMes + "-" + cDia;
            string cFechaFinalFormato = cDia + "/" + cMes + "/" + cAno;
            if (rdbTodo.Checked)
            {
                cTitulo = "Listado General de Historial de BackUps";
                sbQuery.Clear();
                sbQuery.Append("select secuencia,date_format(fecha,'%d/%m/%Y') as fecha,hora,destino,usuario");
                sbQuery.Append(" from backup");
                //sbQuery.Append(" where empre_mo.cod_empre = " + FrmAcceso.iempresa + "");

            }
            if (rdbSeleccionar.Checked)
            {
                if (rdbFecha.Checked)
                {
                    cTitulo = "Listado General de Historial de BackUps desde Fecha " + cFechaInicialFormato + " Hasta " + cFechaFinalFormato + "";
                    sbQuery.Clear();
                    sbQuery.Append("select secuencia,date_format(fecha,'%d/%m/%Y') as fecha,hora,destino,usuario");
                    sbQuery.Append(" from backup");
                    sbQuery.Append(" where fecha between '" + cFechaInicial + "' and '" + cFechaFinal + "'");
                }
            }
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(oCmd);
            DataTable dt = new DataTable();
            Adaptador.Fill(dt);
            int nRegistros = dt.Rows.Count;
            string Titulo = "Listado Historial BackUps";
            if (nRegistros > 0)
            {
                //Reportes.rptBackUp2 orptBackUp = new Reportes.rptBackUp2();
                //orptBackUp.SummaryInfo.ReportTitle = cTitulo;
                //frmPrinter ofrmPrinter = new frmPrinter(dt, orptBackUp, Titulo);
                //ofrmPrinter.ShowDialog();
                Reportes.RptBackup orptBackup = new Reportes.RptBackup();
                orptBackup.SummaryInfo.ReportTitle = cTitulo;
                frmPrinter ofrmPrinter = new frmPrinter(dt, orptBackup, Titulo);
                ofrmPrinter.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Hay Datos Para Mostrar", "Sistema ReaSanto v1.0",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            oCnn.Close();
        }
    }
}
