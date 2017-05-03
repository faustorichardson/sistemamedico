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
using CrystalDecisions.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using VFPToolkit;



namespace DispensarioMedico
{
    public partial class frmArticulos : frmBase
    {
        string cCadenaclsConexion = clsConexion.ConectionString;
        string cModo = "Inicio";

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {

            string cTabla = "";
            string campo = "";

            cTabla = "catego";
            cboFamilia.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboFamilia.DisplayMember = "catego";
            cboFamilia.ValueMember = "cod_cat";
            cboFamilia.SelectedIndex = 0;
            campo = "catego";
            cboFamilia.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboFamilia.AutoCompleteMode = AutoCompleteMode.None;
            cboFamilia.AutoCompleteSource = AutoCompleteSource.ListItems;

            
            cTabla = "subcatego";
            cboSubCategoria.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboSubCategoria.DisplayMember = "descrip";
            cboSubCategoria.ValueMember = "tipo_pro";
            cboSubCategoria.SelectedIndex = 0;
            campo = "descrip";
            cboSubCategoria.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboSubCategoria.AutoCompleteMode = AutoCompleteMode.None;
            cboSubCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
        
            cTabla = "mpresen";
            cboPresentacion.DataSource = clsProcesos.DatosGeneral(cTabla);
            cboPresentacion.DisplayMember = "nompres";
            cboPresentacion.ValueMember = "codpres";
            cboPresentacion.SelectedIndex = 0;
            campo = "nompres";
            cboPresentacion.AutoCompleteCustomSource = clsProcesos.AutocompleteGeneral(campo, cTabla);
            cboPresentacion.AutoCompleteMode = AutoCompleteMode.None;
            cboPresentacion.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.Iniciar();


        }

        private void Iniciar()
        {
            this.cModo = "Inicio";
            this.Limpiar();
            this.Botones();
            CursorDefault();

        } // Iniciar()

        private void Limpiar()
        {

            // Inicializo controles       
            this.txtCod_pro.Text = "";
            this.txtCosto.Text = "0.00";
            this.txtDes_pro.Text = "";
            this.txtExistencia.Text = "0.00";
            this.txtPrecio.Text = "";
            
            //cboEmpleado.SelectedIndex = 0;

            this.imgFoto.ImageLocation = "";
            this.imgFoto.Image = null;
            this.imgFoto.ImageLocation = Application.StartupPath + "\\LogoARD.png";

            clsProcesos oPreceso = new clsProcesos();
            oPreceso.LimpiarTextBox(this);
            // oPreceso.LimpiarControles(this); // depurar error al grabar

            this.cboFamilia.SelectedIndex = -1;
            this.cboPresentacion.SelectedIndex = -1;
            this.cboSubCategoria.SelectedIndex = -1;
            
            this.chkInventariable.Checked = false;

//            this.dtpFechaDigitada.Value = VFPToolkit.dates.DateTime();
        } // fin Limpiapr     


        private void Botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.Enabled = true;
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnImprimir.Enabled = true;                    
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    this.btnBuscar.Enabled = true;   
                    this.CursorDefault();                   
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;                    
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    this.btnEditar.Enabled = false;                    
                    this.btnImprimir.Enabled = true;                   
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = false;                    
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;                   
                    this.btnImprimir.Enabled = true;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;                    
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;                   
                    this.btnImprimir.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;                    
                    this.btnEliminar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;                    
                    this.btnImprimir.Enabled = true;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = false;                    
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;                   
                    this.btnImprimir.Enabled = true;
                    this.btnEditar.Enabled = false;                    
                    break;

                default:
                    break;
            }

        }

        private void CursorDefault()
        {
            Cursor.Current = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.UseWaitCursor = false;
            Application.UseWaitCursor = false;
        }

        // Cancela Cambios y Reseta el Formulario
        private void Cancelar()
        {
            this.cModo = "Cancelar";
            this.Limpiar();
            //    Procesos oPreceso = new Procesos();
            //   oPreceso.AbilitarDesabilitarControles(this, false);
            this.NoEditar();           
            this.cModo = "Inicio";
            this.Botones();
        }

        // Editar()
        private void Editar()
        {
            //  this.Enabled = true;   
            this.txtCod_pro.Enabled = true;
            this.txtCosto.Enabled = true;
            this.txtDes_pro.Enabled = true;
            this.txtExistencia.Enabled = true;
            this.txtPrecio.Enabled = true;


            this.cboFamilia.Enabled = true;
            this.cboPresentacion.Enabled = true;
            this.cboSubCategoria.Enabled = true;

            this.chkInventariable.Enabled = true;  
            

            foreach (Control oControls in this.Controls)
            {
                oControls.Enabled = true;
            }

            /*
            // Create an instance of a form and assign it the currently active form.
            Form currentForm = Form.ActiveForm;
            // Loop through all the controls on the active form.
            for (int i = 0; i < currentForm.Controls.Count; i++)
            {
                // Enabled each control in the active form's control collection.              
                currentForm.Controls[i].Enabled = true;
            }
             
             */

            // Controles de solo lectura permanentes o excepciones
            this.txtCod_pro.Enabled = false;
            

        }  // Editar

        // NoEditar()
        private void NoEditar()
        {
            string cNombreControl;
            foreach (Control oControls in this.Controls)
            {
                if (oControls is Button)
                {

                }
                else
                {
                    oControls.Enabled = false;
                    cNombreControl = oControls.Name;
                }
            }

            this.txtCod_pro.Enabled = false;
            this.txtCosto.Enabled = false;
            this.txtDes_pro.Enabled = false;
            this.txtExistencia.Enabled = false;
            this.txtPrecio.Enabled = false;


            this.cboFamilia.Enabled = false;
            this.cboPresentacion.Enabled = false;
            this.cboSubCategoria.Enabled = false;

            this.chkInventariable.Enabled = false; ;
            grboxBotones.Enabled = true;

        }  // NoEditar()

        private void CalculoTotal()
        {

        }

        // valida antes de grabar 
        private bool ValidaForm()
        {
            bool lRetorno = false;

            this.CalculoTotal();
            try
            {
                if (this.cboFamilia.SelectedValue.ToString() == "" || cboFamilia.SelectedValue == null)
                {
                    MessageBox.Show("No puede grabar con datos en blanco, Indique la familia!! ", "Sistema SysHospitalARD v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // SelectValue Genera error en combos llenados manualmente
                //if (cboEntradaSalida.SelectedValue == "" || cboEntradaSalida.SelectedValue == null)
                if (this.cboPresentacion.SelectedItem.ToString() == "" || cboPresentacion.SelectedItem == null)
                {
                    MessageBox.Show("No puede grabar con datos en blanco, Indique la presentacion de articulos!! ", "Sistema SysHospitalARD v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (this.cboSubCategoria.SelectedValue == "" || cboSubCategoria.SelectedValue == null)
                {
                    MessageBox.Show("No puede grabar con datos en blanco, Indique el Tipo de Documento y/o Movimiento!! ", "Sistema SysHospitalARD v1.0",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // txtNotas.Text == "" 
                if (txtDes_pro.Text == "" || this.txtCod_pro.Text == "")   // || txtPrecio.Text == "" || txtCosto.Text == ""
                {
                    MessageBox.Show("No puede grabar la descripcion, del articulo en blanco!! ", "Sistema SysHospitalARD v1.0",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }                

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                this.CursorDefault();
                return false;
            }
            return true;

        }

        // Inserta y graba un registro nuevo
        private void Grabar()
        {
            DialogResult oRpt;
            oRpt = MessageBox.Show("Esta seguro de grabar este registro?", "Sistema SysHospitalARD v1.0",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oRpt != DialogResult.Yes) { return; }
            char cCero = '0';
            string cValues = "";
            int nSecuencia = 0;
            int nRegistros = 0;
            string cConsultaSQL;
            string cUsuario = frmLogin.cUsuarioActual; 
            DataTable dtExistencia = new DataTable();
            string cCod_Pro = "";

            // Inicio clsConexion y transacccion            
            MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
            MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
            MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
            DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
            StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:
            MySqlTransaction oTransaccion = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                oCnn.ConnectionString = cCadenaclsConexion;
                oCnn.Open();
                oTransaccion = oCnn.BeginTransaction();

                cmdExec = oCnn.CreateCommand();
                cmdExec.Connection = oCnn;
                cmdExec.CommandTimeout = 0; // para consultas largas
                cmdExec.Transaction = oTransaccion;

                // Busco la proxima secuencia para el tipo de movimiento
                this.txtCod_pro.Clear();
              
                DataTable dtTmp = clsProcesos.DatosGeneralEscalar("mproduct", " max(cod_pro) ");
                if (dtTmp.Rows.Count > 0)
                {
                    DataRow DR;
                    DR = dtTmp.Rows[0];
                    this.txtCod_pro.Text = Convert.ToString(Convert.ToInt32(DR["retorno"].ToString()) + 1).ToString().Trim().PadLeft(6, cCero);
                }
                else
                {
                    this.txtCod_pro.Text = "000001";
                }            
                                           

                        // inserto en MPRODUCT
                        nSecuencia = 0;
                        cValues = " VALUES ('" + txtCod_pro.Text.Trim() + "','" + txtDes_pro.Text.Trim() + "','" +
                        Convert.ToDecimal(txtCosto.Text) + "','" + Convert.ToDecimal(txtPrecio.Text.Trim()) + "','" + Convert.ToDecimal(txtPrecio.Text.Trim()) + "','" +
                        cboFamilia.SelectedValue.ToString() + "','" + cboSubCategoria.SelectedValue.ToString() + "','" +
                        this.cboPresentacion.SelectedValue.ToString() + "'," + Convert.ToUInt32(chkInventariable.Checked) + ") ";

                        sbQuery.Clear();
                        sbQuery.Append("INSERT INTO MPRODUCT(cod_PRO,DES_PRO,costo,pre_max,pre_min,cod_cat,tipo_pro,unidad,inventario) ");
                        sbQuery.Append(cValues);

                        // temporal
                        VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                        cmdExec.CommandText = sbQuery.ToString();
                        nRegistros = cmdExec.ExecuteNonQuery();
                        if (nRegistros == 0)
                        {
                            MessageBox.Show("No se insertaron los datos del Articulo, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            oTransaccion.Rollback();
                            oCnn.Close();
                            this.CursorDefault();
                            return;
                        }

                /*
                        // Actualizo Stock en mproduct
                        sbQuery.Clear();
                        sbQuery.Append("update mproduct set cant_exist = cant_exist + " + Convert.ToDecimal(registro.Cells["Cantidad"].Value).ToString() + ", ");
                        sbQuery.Append(" almacen1 = almacen1 + " + Convert.ToDecimal(registro.Cells["Cantidad"].Value).ToString());
                */
                        

                // Confirmo Transaccion y actualizo BD
                // Imprimo documento
                // Limpio form                                                         
                oTransaccion.Commit();
                 MessageBox.Show("Transaccion grabada con exito!!.", "Sistema SysHospitalARD v1.0",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Limpiar();
                this.NoEditar();
                cModo = "Inicio";
                this.Botones();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            finally
            {
            }


        }  //  Grabar()

        // Actualiza Registro
        private void Actualizar()
        {
            DialogResult oRpt;
            oRpt = MessageBox.Show("Esta seguro de grabar cambios a este registro?", "Sistema SysHospitalARD v1.0",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oRpt != DialogResult.Yes) { return; }
            char cCero = '0';
            string cValues = "";
            int nSecuencia = 0;
            int nRegistros = 0;
            string cConsultaSQL;
            string cUsuario = frmLogin.cUsuarioActual;
            DataTable dtExistencia = new DataTable();
            string cCod_Pro = "";

            // Inicio clsConexion y transacccion            
            MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
            MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
            MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
            DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
            StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:
            MySqlTransaction oTransaccion = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                oCnn.ConnectionString = cCadenaclsConexion;
                oCnn.Open();
                oTransaccion = oCnn.BeginTransaction();

                cmdExec = oCnn.CreateCommand();
                cmdExec.Connection = oCnn;
                cmdExec.CommandTimeout = 0; // para consultas largas
                cmdExec.Transaction = oTransaccion;
                                
                // Actualizo en MPRODUCT
                nSecuencia = 0;            
                sbQuery.Clear();
                sbQuery.Append("update MPRODUCT set cod_PRO = '" + txtCod_pro.Text.Trim() + "', " );
                sbQuery.Append(" des_PRO = '" + txtDes_pro.Text.Trim()  + "', " );
                sbQuery.Append(" costo = '"   + Convert.ToDecimal(txtCosto.Text) + "', " );
                sbQuery.Append(" pre_max = '" + Convert.ToDecimal(txtPrecio.Text.Trim()) + "', " );
                sbQuery.Append(" pre_min = '" + Convert.ToDecimal(txtPrecio.Text.Trim()) + "', " );
                sbQuery.Append(" cod_cat = '" + cboFamilia.SelectedValue.ToString() + "', " );
                sbQuery.Append(" tipo_pro = '" + cboSubCategoria.SelectedValue.ToString() + "', " );
                sbQuery.Append(" unidad = '" + cboPresentacion.SelectedValue.ToString() + "', " );
                sbQuery.Append(" inventario = " + Convert.ToUInt32(chkInventariable.Checked));                           
                sbQuery.Append(" where trim(mproduct.cod_pro) = '"  + txtCod_pro.Text.Trim() + "'"  );

                // temporal
                VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                cmdExec.CommandText = sbQuery.ToString();
                nRegistros = cmdExec.ExecuteNonQuery();
                if (nRegistros == 0)
                {
                    MessageBox.Show("No se actualizaron los datos del Articulo, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    oTransaccion.Rollback();
                    oCnn.Close();
                    this.CursorDefault();
                    return;
                }

                 // Confirmo Transaccion y actualizo BD
                // Imprimo documento
                // Limpio form                                                         
                oTransaccion.Commit();
                MessageBox.Show("Transaccion grabada con exito!!.", "Sistema SysHospitalARD v1.0",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Limpiar();
                this.NoEditar();
                cModo = "Inicio";
                this.Botones();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            finally
            {
            }

        }

       
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cModo = "Nuevo";
            this.Limpiar();
            this.Editar();
            this.Botones();
            this.cboFamilia.SelectedIndex = 0;
            this.cboPresentacion.SelectedIndex = 0;
            this.cboSubCategoria.SelectedIndex = 0;
            char cCero = '0';

            // this.grdDetalle.Rows.Add();
            DataTable dtTmp= clsProcesos.DatosGeneralEscalar("mproduct"," max(cod_pro) ");
            if (dtTmp.Rows.Count > 0)
            {                
                DataRow DR;
                DR = dtTmp.Rows[0];
                this.txtCod_pro.Text = Convert.ToString(Convert.ToInt32(DR["retorno"].ToString()) + 1).ToString().Trim().PadLeft(6,cCero);
            }
            else
            {
                this.txtCod_pro.Text = "000001";
            }

            this.txtDes_pro.Focus();
        }

        private void txtDes_pro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
             

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!this.ValidaForm()) { return; }

            switch (cModo)
            {
                case "Nuevo":
                    Grabar();
                    break;

                case "Modificar":
                    Actualizar();
                    break;

                case "Buscar":
                    Actualizar();
                    break;
                default:
                    break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo ofrmBuscarCatalogo = new frmBuscarArticulo();
            ofrmBuscarCatalogo.ShowDialog();
            string cCodigo = ofrmBuscarCatalogo.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo de la centa en la cedlda del grid                          
                txtCod_pro.Text = Convert.ToString(cCodigo).Trim();

                cModo = "Buscar";
                this.Limpiar();
               // this.Editar();
                this.Botones();
                char cCero = '0';

                // this.grdDetalle.Rows.Add();
                DataTable dtTmp = clsProcesos.DatosGeneral("mproduct", " where trim(cod_pro) = '" + cCodigo + "'" ," order by Cod_pro");
                if (dtTmp.Rows.Count > 0)
                {
                    DataRow DR;
                    DR = dtTmp.Rows[0];
                    this.txtCod_pro.Text = Convert.ToString(DR["cod_pro"]);
                    this.txtDes_pro.Text = Convert.ToString(DR["des_pro"]);
                    this.txtExistencia.Text = Convert.ToDecimal(DR["cant_exist"]).ToString("N");
                    this.txtPrecio.Text = Convert.ToDecimal(DR["pre_max"]).ToString("N");
                    this.txtCosto.Text = Convert.ToDecimal(DR["costo"]).ToString("N");
                    this.chkInventariable.Checked = Convert.ToBoolean(DR["costo"]);
                    this.cboFamilia.SelectedValue = Convert.ToString(DR["cod_cat"]);
                    this.cboSubCategoria.SelectedValue = Convert.ToString(DR["tipo_pro"]);
                    this.cboPresentacion.SelectedValue = Convert.ToString(DR["unidad"]);
                }               
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Editar();
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            if (this.txtPrecio.Text == "")
            {
                this.txtPrecio.Text = "0";
            }
            this.txtPrecio.Text = Convert.ToDecimal(this.txtPrecio.Text).ToString("N");
        }

        private void txtCosto_Validated(object sender, EventArgs e)
        {
            if (this.txtCosto.Text == "")
            {
                this.txtCosto.Text = "0";
            }
            this.txtCosto.Text = Convert.ToDecimal(this.txtCosto.Text).ToString("N");
        }

        private void txtExistencia_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtExistencia.Text == "")
            {
                this.txtExistencia.Text = "0";
            }
            this.txtExistencia.Text = Convert.ToDecimal(this.txtExistencia.Text).ToString("N");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult oRpt;
            oRpt = MessageBox.Show("Esta seguro de querer eliminar esta Articulo?", "Sistema SysHospitalARD v1.0",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oRpt != DialogResult.Yes) { return; }

            char cCero = '0';
            string cValues = "";
            int nSecuencia = 0;
            int nRegistros = 0;
            string cConsultaSQL;
            string cUsuario = frmLogin.cUsuarioActual;
            DataTable dtExistencia = new DataTable();
            string cCod_Pro = "";

            // Inicio clsConexion y transacccion            
            MySql.Data.MySqlClient.MySqlConnection oCnn = new MySql.Data.MySqlClient.MySqlConnection();  // Objeto de clsConexion a la base de datos
            MySql.Data.MySqlClient.MySqlDataAdapter daDatos = new MySql.Data.MySqlClient.MySqlDataAdapter(); // Objeto Adaptador para leer datos de la Base de datos
            MySql.Data.MySqlClient.MySqlCommand cmdExec = new MySql.Data.MySqlClient.MySqlCommand(); // objeto comando para ejecutar sentencias sql
            DataTable dtDatos = new DataTable(); // datatable para recibir los datos de la base de datos
            StringBuilder sbQuery = new StringBuilder(); //Iniciar el cuadro de diálogo de entretenimiento:
            MySqlTransaction oTransaccion = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                oCnn.ConnectionString = cCadenaclsConexion;
                oCnn.Open();
                oTransaccion = oCnn.BeginTransaction();

                cmdExec = oCnn.CreateCommand();
                cmdExec.Connection = oCnn;
                cmdExec.CommandTimeout = 0; // para consultas largas
                cmdExec.Transaction = oTransaccion;

                // Verifico que articulo no tenga movimeinto historico
                DataTable dtMovInventario = clsProcesos.DatosGeneral("invent", " where trim(invent.cod_1) = '" + txtCod_pro.Text.Trim() + "'", " order by secuencia");
                if (dtMovInventario.Rows.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar este Articulo, pues ya tiene movimiento historico en la BD, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    oTransaccion.Rollback();
                    oCnn.Close();
                    this.CursorDefault();
                    return;
                }

                // Actualizo en MPRODUCT
                nSecuencia = 0;
                sbQuery.Clear();
                sbQuery.Append("delete from mproduct where trim(mproduct.cod_pro) = '" + txtCod_pro.Text.Trim() + "'");               

                // temporal
                VFPToolkit.strings.StrToFile(sbQuery.ToString(), @"consulta.sql", true);
                cmdExec.CommandText = sbQuery.ToString();
                nRegistros = cmdExec.ExecuteNonQuery();
                if (nRegistros == 0)
                {
                    MessageBox.Show("No se pudo eliminar el Articulo, favor verificar", "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    oTransaccion.Rollback();
                    oCnn.Close();
                    this.CursorDefault();
                    return;
                }

                // Confirmo Transaccion y actualizo BD
                // Imprimo documento
                // Limpio form                                                         
                oTransaccion.Commit();
                MessageBox.Show("Artituclo eliminado con exito!!.", "Sistema SysHospitalARD v1.0",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Limpiar();
                this.NoEditar();
                cModo = "Inicio";
                this.Botones();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema SysHospitalARD v1.0", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState. 
                oTransaccion.Rollback();
                this.CursorDefault();
                return;
            }
            finally
            {
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRepArticulos ofrmRepArticulos = new frmRepArticulos();
            ofrmRepArticulos.Show();
        } 

    }  // Class

}   // namespace
