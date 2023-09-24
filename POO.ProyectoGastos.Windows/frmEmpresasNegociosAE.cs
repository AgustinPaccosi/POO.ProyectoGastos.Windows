using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmEmpresasNegociosAE : Form
    {
        public frmEmpresasNegociosAE(ServiciosEmpresasNegocios _ServiciosEmpresas)
        {
            InitializeComponent();
        }

        internal EmpresasNegocios GetEmpresasNegocio()
        {
            throw new NotImplementedException();
        }

        internal void SetEmpresasNegocio(EmpresasNegocios empresa)
        {
            throw new NotImplementedException();
        }
    }
}
