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
    public partial class frmMenu : frmBase
    {

        public string cUsuarioActual = frmLogin.cUsuarioActual;
        public int nNivel = 0;
        public  Boolean lAgregar = false;
        public  Boolean lModificar = false;
        public  Boolean lEliminar = false;
        public  Boolean lLeer = false;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegistroDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroDoctores frmRegDoctores = new frmRegistroDoctores();
            frmRegDoctores.Show();
        }

        private void aGREGARESPECIALIDADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaestroEspecialidades frmMaeEspecialidades = new frmMaestroEspecialidades();
            frmMaeEspecialidades.Show();
        }

        private void rEGISTROTIPOESPECIALIDADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaestroTipoEspecialidad frmMaeTipEsp = new frmMaestroTipoEspecialidad();
            frmMaeTipEsp.Show();
        }

        private void aGREGARDEPARTAMENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaestroDepartamento frmMaeDep = new frmMaestroDepartamento();
            frmMaeDep.Show();
        }

        private void rECORDMEDICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAntecedentesPersonales frmAntPersPac = new frmAntecedentesPersonales();
            frmAntPersPac.Show();
        }

        private void rEGISTROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProblemaMedicoRegistro frmProMedReg = new frmProblemaMedicoRegistro();
            frmProMedReg.Show();
        }

        private void aNTECEDENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAntecedentesPersonales frmAntPersPac = new frmAntecedentesPersonales();
            frmAntPersPac.Show();
        }
        
        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdMovInventario_Click(object sender, EventArgs e)
        {
            frmMovInventario ofrmMovInventario = new frmMovInventario();
            ofrmMovInventario.Show();
        }

        private void cmdMedicos_Click(object sender, EventArgs e)
        {
            frmRegistroDoctores frmRegDoctores = new frmRegistroDoctores();
            frmRegDoctores.Show();
        }

        private void cmdDepartamentos_Click(object sender, EventArgs e)
        {
            frmMaestroDepartamento frmMaeDep = new frmMaestroDepartamento();
            frmMaeDep.Show();
        }

        private void cmdEspecialidades_Click(object sender, EventArgs e)
        {
            frmMaestroEspecialidades frmMaeEspecialidades = new frmMaestroEspecialidades();
            frmMaeEspecialidades.Show();
        }

        private void cmdPacientes_Click(object sender, EventArgs e)
        {
            frmAntecedentesPersonales frmAntPersPac = new frmAntecedentesPersonales();
            frmAntPersPac.Show();
        }

        private void cmdRegsitros_Click(object sender, EventArgs e)
        {
            frmProblemaMedicoRegistro frmProMedReg = new frmProblemaMedicoRegistro();
            frmProMedReg.Show();
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gENERARLICENCIAMEDICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenciaMedica ofrmLicenciaMedica = new frmLicenciaMedica();
            ofrmLicenciaMedica.Show();
        }

        private void rEGISTRARCITAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovInventario ofrmMovInventario = new frmMovInventario();
            ofrmMovInventario.Show();
        }

        private void rEGISTROCITAPACIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCitaMedica ofrmCitaMedica = new frmCitaMedica();
            ofrmCitaMedica.Show();
        }

        private void opcRealizarBackUpBD_Click(object sender, EventArgs e)
        {
            frmBackUp ofrmBackup = new frmBackUp();
            ofrmBackup.Show();
        }

        private void opcArticulos_Click(object sender, EventArgs e)
        {
            frmArticulos ofrmArticulo = new frmArticulos();
            ofrmArticulo.Show();
        }

        private void cmdMedicametos_Click(object sender, EventArgs e)
        {
            frmArticulos ofrmArticulo = new frmArticulos();
            ofrmArticulo.Show();
        }

        private void cmdBackUp_Click(object sender, EventArgs e)
        {
            frmBackUp ofrmBackup = new frmBackUp();
            ofrmBackup.Show();
        }

        private void lISTADOCITASDOCTORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
          frmPrintCitasMedicas ofrmPrintCitasMedicas = new frmPrintCitasMedicas();
          ofrmPrintCitasMedicas.Show();
        }

        private void lISTADOLICENCIASMEDICASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenRptLicenciasMedicas ofrmGenRptLicenciasMedicas = new frmGenRptLicenciasMedicas();
            ofrmGenRptLicenciasMedicas.Show();
        }

        private void opcAcercaDe_Click(object sender, EventArgs e)
        {
            frmAbout ofrmAbout = new frmAbout();
            ofrmAbout.Show();
        }

        private void opcVisorDeErrores_Click(object sender, EventArgs e)
        {
            frmErrores ofrmErrores = new frmErrores();
            ofrmErrores.Show();

        }

        private void cmdBackUp_Click_1(object sender, EventArgs e)
        {
            frmBackUp ofrmBackUp = new frmBackUp();
            ofrmBackUp.Show();
        }

        private void rEGISTROTIPOESPECIALIDADToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmMaestroTipoEspecialidad ofrmMaestroTipoEspecialidad = new frmMaestroTipoEspecialidad();
            ofrmMaestroTipoEspecialidad.Show();
        }

        private void cmdLabel_Click(object sender, EventArgs e)
        {
            frmMovInventarioTMP ofrmMovInventarioTMP = new frmMovInventarioTMP();
            ofrmMovInventarioTMP.Show();
        }

        private void listadoPacientesAtendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGnrRptConsultas ofrmGnrRptConsultas = new frmGnrRptConsultas();
            ofrmGnrRptConsultas.Show();
        }

        private void estadisticasDeEmergenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGnrConsultasEst ofrmGnrConsultasEst = new frmGnrConsultasEst();
            ofrmGnrConsultasEst.Show();
        }

        private void listadoDeLicenciasMedicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintLicenciasMedicas ofrmPrintLicenciasMedicas = new frmPrintLicenciasMedicas();
            ofrmPrintLicenciasMedicas.Show();
        }

        private void inventarioDeFarmacosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepMovInventario ofrmRepMovInventario = new frmRepMovInventario();
            ofrmRepMovInventario.Show();
        }

        private void cmdLicencias_Click(object sender, EventArgs e)
        {

        }

    }
}
