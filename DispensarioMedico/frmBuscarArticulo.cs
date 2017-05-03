using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispensarioMedico
{
    public partial class frmBuscarArticulo : frmBase
    {
        public string cCodigo = "";
        public frmBuscarArticulo()
        {
            InitializeComponent();
        }

        private void frmBuscarArticulo_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscar_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBuscar_Validated(object sender, EventArgs e)
        {
             if (this.txtBuscar.Text != "")
            {                                                             
               // Version Consulta sin Store Procedure, solo string de consulta
               // Version Consulta con Store Procedure parametrizado
               string cBuscar = "'%" + this.txtBuscar.Text.Trim().ToUpper() + "%'";
               DataTable  dtCatalogo= clsProcesos.DatosGeneral("mproduct", " where des_pro  like " + cBuscar, " order by Des_pro ");

                if (dtCatalogo.Rows.Count > 0)
                {
                    // borro las lineas del grid y datatable
                    this.grdCatalogo.Rows.Clear();                    
                    // Mostrar los datos del datatable en el grid
                    foreach (DataRow registro in dtCatalogo.Rows)
                    {                        
                        this.grdCatalogo.Rows.Add(registro["cod_pro"], registro["des_pro"], registro["Cant_Exist"]);
                    }
                }
                else
                {
                    MessageBox.Show("No hubo coincidencia, favor intente de nuevo!!", "Sistema Medico ARD v1.0",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.cCodigo = "";
            this.Close();        
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            int nPos = 0;
            int nTodo = this.grdCatalogo.GetCellCount(DataGridViewElementStates.Selected);
            if (nTodo > 0)
            {
                int nFila = this.grdCatalogo.SelectedCells[nPos].RowIndex;
                int nCol = this.grdCatalogo.SelectedCells[nPos].ColumnIndex;
                this.cCodigo = Convert.ToString(grdCatalogo[nCol, nFila].Value);

                // forzo la primera columna para el codigo 
                this.cCodigo = Convert.ToString(grdCatalogo[0, nFila].Value);
            }
            this.grdCatalogo.Visible = true;
            this.Close();
        }

        private void grdCatalogo_DoubleClick(object sender, EventArgs e)
        {
            int nPos = 0;
            int nTodo = this.grdCatalogo.GetCellCount(DataGridViewElementStates.Selected);
            if (nTodo > 0)
            {
                int nFila = this.grdCatalogo.SelectedCells[nPos].RowIndex;
                int nCol = this.grdCatalogo.SelectedCells[nPos].ColumnIndex;
                this.cCodigo = Convert.ToString(grdCatalogo[nCol, nFila].Value);

                // forzo la primera columna para el codigo 
                this.cCodigo = Convert.ToString(grdCatalogo[0, nFila].Value);
            }
            this.grdCatalogo.Visible = true;
            this.Close();
        }

        


    }
}

