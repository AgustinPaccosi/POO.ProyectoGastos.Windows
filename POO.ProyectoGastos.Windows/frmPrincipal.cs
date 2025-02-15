using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void btnGastosHgr_Click(object sender, EventArgs e)
        {
            frmGastos frm =new frmGastos();
            frm.ShowDialog(this);
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            frmPersonas frm=new frmPersonas();
            frm.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEmpresasNegocios frm=new frmEmpresasNegocios();
            frm.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmDatosTarjetas frm=new frmDatosTarjetas();
            frm.ShowDialog(this);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFondosComunes_Click(object sender, EventArgs e)
        {
            frmFondosComunes frm = new frmFondosComunes();
            frm.ShowDialog(this);
        }

        private void BtnGastosFijos_Click(object sender, EventArgs e)
        {
            frmGastosFijos frm =new frmGastosFijos();
            frm.ShowDialog(this);
        }
    }
}
