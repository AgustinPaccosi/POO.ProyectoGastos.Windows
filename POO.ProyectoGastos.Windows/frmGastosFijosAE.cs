using POO.ProyectoGastos.Entidades.Dtos;
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
            CombosHelpers.CargarComboTiposDeVencimiento(ref ComboTipoDeVencimiento);
            CombosHelpers.CargarComboTipoDeGastos(ref comboTipoDeGasto);
            if (gastoFijo!=null)
            {
                esEdicion = true;
                dateTimePicker1.Value = gastoFijo.Vencimiento.Date;
                comboTipoDeGasto.SelectedValue = gastoFijo.IdTipoGasto;
                ComboTipoDeVencimiento.SelectedValue = gastoFijo.IdTipoDeVencimiento;
                textImporte.Text = gastoFijo.MontoPagar.ToString();
                textNombre.Text=gastoFijo.Nombre.ToString();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (gastoFijo ==null)
            {
                gastoFijo = new GastosFijos();
            }
            gastoFijo.Vencimiento = dateTimePicker1.Value.Date;
            gastoFijo.MontoPagar = decimal.Parse(textImporte.Text);
            gastoFijo.IdTipoDeVencimiento = (int)ComboTipoDeVencimiento.SelectedValue;
            gastoFijo.IdTipoGasto= (int)comboTipoDeGasto.SelectedValue;
            gastoFijo.Nombre = textNombre.Text;
            try
            {
                if (!servicio.Existe(gastoFijo))
                {
                    servicio.Guardar(gastoFijo);
                    if (!esEdicion)
                    {
                        MessageBox.Show("Registro agregado",
                            "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                            "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;

                        }
                        gastoFijo = null;
                        //InicializarControles();
                    }
                    else
                    {
                        MessageBox.Show("Registro editado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;

                    }
                }
                else
                {
                    MessageBox.Show("Registro duplicado",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gastoFijo = null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(textImporte.Text) || !decimal.TryParse(textImporte.Text, out _))
            {
                valido = false;
                errorProvider1.SetError(textImporte, "Debe ingresar un Importe numerico VALIDO");

            }
            if (string.IsNullOrEmpty(textNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(textNombre, "Debe ingresar un Nombre");

            }
            if (comboTipoDeGasto.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboTipoDeGasto, "Elija un TIPO DE GASTO");
            }
            if (ComboTipoDeVencimiento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboTipoDeVencimiento, "Elija un Tipo De Vencimiento");
            }
            
            return valido;
        }

        public void SetGastoFijo(GastosFijos gasto)
        {
            this.gastoFijo = gasto;
        }

        public GastosFijos GetGastoFijo()
        {
            return gastoFijo;
        }
    }
}
