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

    public partial class frmImprimirErrores : frmBase
    {
        String cCadenaConexion = clsConexion.ConectionString;
        string cTabla = "";
        string campo = "";

        public frmImprimirErrores()
        {
            InitializeComponent();
        }

        private void frmImprimirErrores_Load(object sender, EventArgs e)
        {
           
            //string query = "SELECT distinct usuario FROM errors order by usuario";
            //MySqlConnection oCnn = new MySqlConnection(this.cCadenaConexion);
            //MySqlCommand comando = new MySqlCommand(query, oCnn);
            //MySqlDataAdapter da = new MySqlDataAdapter(comando);
            //DataSet ds = new DataSet();
            //da.Fill(ds, cTabla);
            //grbSelPor.Visible = false;

            //cboUsuario.DataSource = ds.Tables[0].DefaultView;
            ////cboUsuario.DisplayMember = "usuario";
            //cboUsuario.ValueMember = "usuario";
            //cboUsuario.SelectedIndex = -1;
            cTabla = "usuario";
            cboUsuario.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboUsuario.DisplayMember = "nombre";
            cboUsuario.ValueMember = "nombre";
            cboUsuario.SelectedIndex = -1;
        }

        private void rdbTodo_CheckedChanged(object sender, EventArgs e)
        {
           // grbSelPor.Visible = false;
            rdbFecha.Checked = false;
            rdbUsuaFecha.Checked = false;
            rdbUsuario.Checked = false;
        }

        private void rdbSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            grbSelPor.Visible = true;
            grbUsuario.Visible = true;
            grbFechas.Visible = true;
            rdbUsuaFecha.Checked = true;
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

        private void cboUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {

            
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string FechaInicial = dtpDesFecha.Value.ToString("yyyy-MM-dd");
            string FechaFinal = dtpHasFecha.Value.ToString("yyyy-MM-dd");
            StringBuilder sbQuery = new StringBuilder();
            string miTitulo = "";
            if (rdbTodo.Checked)
            {
                miTitulo = "Listado General de Errores";
                sbQuery.Clear();
                sbQuery.Append("select secuencia,linea,usuario,cia,time(fecha) as hora,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("message,programa");
                sbQuery.Append(" from errors");
                sbQuery.Append(" order by secuencia");

            }
            if (rdbSeleccionar.Checked)
            {
                if (rdbUsuario.Checked)
                {
                    miTitulo = "Listado General de Errores Usuario " + cboUsuario.SelectedText + "";
                    sbQuery.Clear();
                    sbQuery.Append("select secuencia,linea,usuario,cia,time(fecha) as hora,date_format(fecha,'%d/%m/%Y') as fecha,");
                    sbQuery.Append("message,programa");
                    sbQuery.Append(" from errors");
                    sbQuery.Append(" where usuario = '" + cboUsuario.SelectedText + "'");
                    sbQuery.Append(" order by secuencia");
                }
                if (rdbFecha.Checked)
                {
                    miTitulo = "Listado General de Errores de Fecha " + dtpDesFecha.Value.ToString("dd-MM-yyyy") + " Hasta " + dtpHasFecha.Value.ToString("dd-MM-yyyy") + "";
                    sbQuery.Clear();
                    sbQuery.Append("select secuencia,linea,usuario,cia,time(fecha) as hora,date_format(fecha,'%d/%m/%Y') as fecha,");
                    sbQuery.Append("message,programa");
                    sbQuery.Append(" from errors");
                    sbQuery.Append(" where fecha between '" + FechaInicial + "' and '" + FechaFinal + "'");
                    sbQuery.Append(" order by secuencia");

                }
                if (rdbUsuaFecha.Checked)
                {
                    miTitulo = "Listado General de Errores Usuario " + cboUsuario.SelectedText + "desde la fecha " + dtpDesFecha.Value.ToString("dd-MM-yyyy") + " Hasta " + dtpHasFecha.Value.ToString("dd-MM-yyyy") + ""; ;
                    sbQuery.Clear();
                    sbQuery.Append("select secuencia,linea,usuario,cia,time(fecha) as hora,date_format(fecha,'%d/%m/%Y') as fecha,");
                    sbQuery.Append("message,programa");
                    sbQuery.Append(" from errors");
                    sbQuery.Append(" where fecha between '" + FechaInicial + "'and '" + FechaFinal + "'");
                    sbQuery.Append(" and usuario = '" + cboUsuario.SelectedText + "'");
                    sbQuery.Append(" order by secuencia");

                }
            }
            MySqlConnection oCnn = new MySqlConnection(this.cCadenaConexion);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand();
            oCmd = oCnn.CreateCommand();
            oCmd.Connection = oCnn;
            oCmd.CommandText = sbQuery.ToString();
            MySqlDataAdapter da = new MySqlDataAdapter(oCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            oCnn.Close();
            int nResultado = dt.Rows.Count;
            string cTitulo = miTitulo;

            if (nResultado > 0)
            {
                Reportes.rptErrores oRptErrores = new Reportes.rptErrores();
                oRptErrores.SummaryInfo.ReportTitle = cTitulo;
                frmPrinter ofrmPrinter = new frmPrinter(dt, oRptErrores, cTitulo);
                ofrmPrinter.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
