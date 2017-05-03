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
    public partial class frmBuscarErrores : frmBase
    {
        String cCadenaConexion = clsConexion.ConectionString;
        string cTabla = "";
        string campo = "";
        public string cBuscaErrores = "";

        public frmBuscarErrores()
        {
            InitializeComponent();
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
                sbQuery.Append("select secuencia,message,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("hora from gsisoft.errors where usuario = '" + cboUsuario.SelectedValue + "'");
            }
            if (rdbFecha.Checked)
            {
                sbQuery.Append("select secuencia,message,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("hora from gsisoft.errors where fecha between '" + cFechaInicial + "' and '" + cFechaFinal + "'");

            }
            if (rdbUsuarioFecha.Checked)
            {
                sbQuery.Append("select secuencia,message,date_format(fecha,'%d/%m/%Y') as fecha,");
                sbQuery.Append("hora from gsisoft.errors where usuario = '" + cboUsuario.SelectedValue + "' and");
                sbQuery.Append(" fecha between '" + cFechaInicial + "' and '" + cFechaFinal + "'");

            }

            MySqlConnection oCnn = new MySqlConnection(this.cCadenaConexion);
            MySqlCommand oCmd = new MySqlCommand(sbQuery.ToString(), oCnn);
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(oCmd);
            DataSet dsBuscarErrores = new DataSet();
            Adaptador.Fill(dsBuscarErrores, "errors");
            int nRegistro = dsBuscarErrores.Tables[0].Rows.Count;
            if (nRegistro > 0)
            {
                dgvBuscar.DataSource = dsBuscarErrores;
                dgvBuscar.DataMember = "errors";
                dgvBuscar.Columns[0].Width = 50;
                dgvBuscar.Columns[1].Width = 250;
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
                cBuscaErrores = Convert.ToString(dgvBuscar[nCol, nFila].Value);
                cBuscaErrores = Convert.ToString(dgvBuscar[0, nFila].Value);

            }
            dgvBuscar.Visible = true;
            this.Close();
        }
    }
}
