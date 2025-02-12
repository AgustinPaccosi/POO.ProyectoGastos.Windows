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
    public partial class frmGastosAE : Form
    {
        private IServiciosGastosHogar servicio;
        public frmGastosAE(ServiciosGastosHogar serviciosGastos)
        {
            InitializeComponent();
            servicio = serviciosGastos;
        }

        private GastoHogar gastoHogar;
        private bool esEdicion = false;

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
        //private bool ValidarDatos()
        //{
        //    bool valido = true;
        //    if (string.IsNullOrEmpty(txtNombre.Text))
        //    {
        //        valido = false;
        //        errorProvider1.SetError(txtNombre, "Debe ingresar un nombre");

        //    }
        //    if (string.IsNullOrEmpty(txtApellido.Text))
        //    {
        //        valido = false;
        //        errorProvider1.SetError(txtApellido, "Debe ingresar un Apellido");

        //    }

        //    return valido;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
