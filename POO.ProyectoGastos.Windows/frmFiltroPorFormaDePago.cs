using POO.ProyectoGastos.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.Combos;
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
    public partial class frmFiltroPorFormaDePago : Form
    {
        public frmFiltroPorFormaDePago()
        {
            InitializeComponent();
            servicios = new ServiciosFormasPagos();
        }
        private IServiciosFormasPagos servicios;
        FormasPagos formaDePago=new FormasPagos();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                formaDePago = servicios.GetFormasPagosPorId((int)comboFormaPago.SelectedValue);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (comboFormaPago.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(comboFormaPago, "Debe seleccionar una Forma De pago");
            }
            return valido;
        }

        private void frmFiltroPorFormaDePago_Load(object sender, EventArgs e)
        {
            CombosHelpers.CargarComboFormasPago(ref comboFormaPago);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public FormasPagos GetTipoFormaDePago()
        {
            return formaDePago;
        }
    }
}
