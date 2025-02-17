using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using POO.ProyectoGastos.Entidades.Entidades;
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
    public partial class frmFiltroTipoGasto : Form
    {
        public frmFiltroTipoGasto()
        {
            InitializeComponent();
            servicio=new ServiciosTiposGastos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoGasto = servicio.GetTiposGastosPorId((int)comboTipoDeGasto.SelectedValue);
                DialogResult = DialogResult.OK;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        ComboTiposGastosDto tipoGasto = new ComboTiposGastosDto();

        private IServiciosTiposGastos servicio;





        private bool ValidarDatos()
        {
            bool valido = true;
            if (comboTipoDeGasto.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboTipoDeGasto, "Elija Una Persona");
                valido = false;
            }
            return valido;
        }

        public ComboTiposGastosDto GetTipoDegasto()
        {
            return tipoGasto;
        }

        private void frmFiltroTipoGasto_Load(object sender, EventArgs e)
        {
            CombosHelpers.CargarComboTipoDeGastos(ref comboTipoDeGasto);
        }
    }
}
