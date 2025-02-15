using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
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
    public partial class frmGastosFijosAE : Form
    {
        private IServiciosGastosFijos servicio;
        public frmGastosFijosAE(ServiciosGastosFijos serviciosGastosFijos)
        {
            InitializeComponent();
            servicio = serviciosGastosFijos;
        }
        private GastosFijos gastoFijo;
        private bool esEdicion;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

    }
}
