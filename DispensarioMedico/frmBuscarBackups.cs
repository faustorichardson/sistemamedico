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
    public partial class frmBuscarBackups : frmBase
    {
        String cCadenaclsConexion = clsConexion.ConectionString;
        string cTabla = "";
        string campo = "";
        public string cBuscaBackup = "";

        public frmBuscarBackups()
        {
            InitializeComponent();
        }

        private void frmBuscarBackups_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Text = DateTime.Now.ToLongDateString();
            dtpFechaFinal.Text = DateTime.Now.ToLongDateString();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            string cCero = "0";
            string cAno = dates.Year(dtpFechaInicial.Value).ToString();
            string cMes = VFPToolkit.strings.PadL(dates.Month(dtpFechaInicial.Value).ToString(), 2, Convert.ToChar(cCero));
            string cDia = VFPToolkit.strings.PadL(dates.Day(dtpFechaInicial.Value).ToString(), 2, Convert.ToChar(cCero));
            string cFechaInicial = cAno + "/" + cMes + "/" + cDia;
            cAno = dates.Year(dtpFechaFinal.Value).ToString();
            cMes = VFPToolkit.strings.PadL(dates.Month(dtpFechaFinal.Value).ToString(), 2, Convert.ToChar(cCero));
            cDia = VFPToolkit.strings.PadL(dates.Day(dtpFechaFinal.Value).ToString(), 2, Convert.ToChar(cCero));
            string cFechaFinal = cAno + "/" + cMes + "/" + cDia;

            StringBuilder sbQuery = new StringBuilder();
            if (rdbUsuario.Checked)
            {
                sbQuery.Append("select secuencia,usuario,destino,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("hora from backup where usuario = '" + cboUsuario.SelectedValue + "'");
            }
            if (rdbFecha.Checked)
            {
                sbQuery.Append("select secuencia,usuario,destino,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("hora from backup where fecha between '" + cFechaInicial + "' and '" + cFechaFinal + "'");

            }
            if (rdbUsuarioFecha.Checked)
            {
                sbQuery.Append("select secuencia,usuario,destino,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("hora from backup where usuario = '" + cboUsuario.SelectedValue + "' and");
                sbQuery.Append(" fecha between '" + cFechaInicial + "' and '" + cFechaFinal + "'");

            }

            MySqlConnection oCnn = new MySqlConnection(this.cCadenaclsConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataAdapter oAdaptador = new MySqlDataAdapter(oCmd);
            DataSet dsBuscaBackup = new DataSet();
            oAdaptador.Fill(dsBuscaBackup, "backup");
            int nRegistro = dsBuscaBackup.Tables[0].Rows.Count;

            if (nRegistro > 0)
            {
                dgvBuscar.DataSource = dsBuscaBackup;
                dgvBuscar.DataMember = "backup";
                dgvBuscar.Columns[2].Width = 250;

            }
        }

        private void dgvBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nPos = 0;
            int nTodo = dgvBuscar.GetCellCount(DataGridViewElementStates.Selected);
            if (nTodo > 0)
            {
                int nFila = this.dgvBuscar.SelectedCells[nPos].RowIndex;
                int nCol = this.dgvBuscar.SelectedCells[nPos].ColumnIndex;
                cBuscaBackup = Convert.ToString(dgvBuscar[nCol, nFila].Value);
                cBuscaBackup = Convert.ToString(dgvBuscar[0, nFila].Value);

            }
            dgvBuscar.Visible = true;
            this.Close();
        }


    }
}
