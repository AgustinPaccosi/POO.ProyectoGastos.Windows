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
    }
}
