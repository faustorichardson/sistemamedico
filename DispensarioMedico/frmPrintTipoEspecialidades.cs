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

namespace DispensarioMedico
{
    public partial class frmPrintTipoEspecialidades : frmBase
    {
        public frmPrintTipoEspecialidades()
        {
            InitializeComponent();
        }

        private void frmPrintTipoEspecialidades_Load(object sender, EventArgs e)
        {
            realizarImpresion();
        }

        private void realizarImpresion()
        {
            MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
            MySqlCommand myCommand = myclsConexion.CreateCommand();
            DataTable myDatos = new DataTable();
            StringBuilder sbQuery = new StringBuilder();

            try
            {
                myclsConexion.Open();
                sbQuery.Append("SELECT id_tipoespecialidad, descripcion_tipoespecialidad");
                sbQuery.Append(" FROM especialidades_tipo");
                myCommand.CommandText = sbQuery.ToString();
                myDataAdapter = new MySqlDataAdapter(myCommand);
                myDataAdapter.Fill(myDatos);
                int nRegistros = myDatos.Rows.Count;

                if (nRegistros == 0)
                {
                    MessageBox.Show("No hay información para mostrar, favor verificar", "Mostrando Listado Tipo Especialidades", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                    return;
                }

                ReportDocument crReport = new ReportDocument();
               // crReport.Load = (Application.StartupPath "\rptTipoEspecialidad.rpt"());

            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
            }

        }
    }
}
