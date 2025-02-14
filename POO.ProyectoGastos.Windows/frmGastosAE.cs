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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelpers.CargarComboTiposGastos(ref comboTipoDeGasto);
            CombosHelpers.CargarComboPersonas(ref comboPersonas);
            CombosHelpers.CargarComboEmpresaNegocio(ref comboEmpresa);
            CombosHelpers.CargarComboFormasPago(ref comboFormaDePago);
            comboFondoComun.Enabled= false;
            comboNumTarje.Enabled= false;
            //comboGastoFijo.Enabled= false;

        }
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

        private void comboPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)comboPersonas.SelectedIndex!=0)
            {
                CombosHelpers.CargarcomboTarjetas(ref comboNumTarje, (int)comboPersonas.SelectedValue);
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboGastoFijo.Enabled=true;
            }
            else { comboGastoFijo.Enabled = false; }
        }

        private void comboFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)comboFormaDePago.SelectedIndex != 0)
            {
                switch ((int)comboFormaDePago.SelectedValue)
                {
                    case 1:
                        comboNumTarje.Enabled = false;
                        comboFondoComun.Enabled = true;
                        CombosHelpers.CargarComboFondoComun(ref comboFondoComun);
                        break;
                    case 2:
                        comboNumTarje.Enabled = true;
                        comboFondoComun.Enabled = false;
                        break;
                    case 3:
                        comboNumTarje.Enabled = true;
                        comboFondoComun.Enabled = false;
                        break;
                    case 4:
                        comboNumTarje.Enabled = false;
                        comboFondoComun.Enabled = false;
                        break;
                    case 5:
                        comboNumTarje.Enabled = false;
                        comboFondoComun.Enabled = false;
                        break;
                }

            }
            //if ((int)comboFormaDePago.SelectedValue == 1)
            //{

            //}
            //else if ((int)comboFormaDePago.SelectedValue == 2 )
            //{
            //    comboNumTarje.Enabled = true;
            //}
            //else if((int)comboFormaDePago.SelectedValue == 3)
            //{
            //    comboNumTarje.Enabled = true;
            //}
            //else 
            //{ 
            //    comboNumTarje.Enabled = false; 
            //}
        }
        
    }
}
