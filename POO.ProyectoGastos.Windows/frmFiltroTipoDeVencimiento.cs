using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento;
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
    public partial class frmFiltroTipoDeVencimiento : Form
    {
        public frmFiltroTipoDeVencimiento()
        {
            InitializeComponent();
            servicio = new ServiciosTiposDeVencimientos();
        }
        ComboTiposDeVencimientosDto tipoDeVencimiento = new ComboTiposDeVencimientosDto();

        private IServiciosTiposDeVencimientos servicio;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoDeVencimiento = servicio.GetTiposDeVencimientosPorId((int)comboTipoDeVencimiento.SelectedValue);
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (comboTipoDeVencimiento.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboTipoDeVencimiento, "Elija Una Persona");
                valido = false;
            }
            return valido;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFiltroTipoDeVencimiento_Load(object sender, EventArgs e)
        {
            CombosHelpers.CargarComboTiposDeVencimiento(ref comboTipoDeVencimiento);

        }

        public ComboTiposDeVencimientosDto GetTipoDeVencimiento()
        {
            return tipoDeVencimiento;
        }
    }
}
