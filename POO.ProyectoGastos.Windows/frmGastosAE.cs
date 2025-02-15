using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
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
        //private FondoComun fondo;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelpers.CargarComboTiposGastos(ref comboTipoDeGasto);
            CombosHelpers.CargarComboPersonas(ref comboPersonas);
            CombosHelpers.CargarComboEmpresaNegocio(ref comboEmpresa);
            CombosHelpers.CargarComboFormasPago(ref comboFormaDePago);
            comboFondoComun.Enabled= false;
            comboNumTarje.Enabled= false;
            if (gastoHogar!=null)
            {
                esEdicion = true;
                dateTimePicker1.Value = gastoHogar.Fecha.Date;
                comboPersonas.SelectedValue = gastoHogar.IdPersona;
                comboTipoDeGasto.SelectedValue = gastoHogar.IdTipoGasto;
                textDetalle.Text = gastoHogar.Detalle;
                textImporte.Text = gastoHogar.Valor.ToString();
                comboFormaDePago.SelectedValue = gastoHogar.IdFormaPago;
                //comboFormaDePago_SelectedIndexChanged(null, null);
            }
            //comboGastoFijo.Enabled= false;

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (gastoHogar == null)
                {
                    gastoHogar = new GastoHogar();

                }
                gastoHogar.Fecha= dateTimePicker1.Value.Date;
                gastoHogar.Valor=decimal.Parse(textImporte.Text);
                gastoHogar.Detalle=textDetalle.Text;
                //gastoHogar.IdGastoFijo = null;
                gastoHogar.TiposGastosDto = (ComboTiposGastosDto)comboTipoDeGasto.SelectedItem ;
                gastoHogar.IdTipoGasto=(int)comboTipoDeGasto.SelectedValue;
                gastoHogar.IdFormaPago= (int)comboFormaDePago.SelectedValue;
                gastoHogar.IdPersona = (int)comboPersonas.SelectedValue;
                if (checkPagado.Checked)
                {
                    gastoHogar.Pagado = true;
                }
                else
                {
                    gastoHogar.Pagado = false;

                }
                if (comboFormaDePago.SelectedIndex == 1)
                {
                    gastoHogar.IdFondoComun = (int)comboFondoComun.SelectedValue;
                }
                if ((int)comboFormaDePago.SelectedValue == 2 ||  (int)comboFormaDePago.SelectedValue == 3)
                {
                    gastoHogar.IdTarjeta = (int)comboNumTarje.SelectedValue;
                }
                if (comboEmpresa.SelectedIndex!=0)
                {
                    gastoHogar.IdEmpNeg = (int)comboEmpresa.SelectedValue;
                }
                try
                {
                    if (!servicio.Existe(gastoHogar))
                    {
                        servicio.Guardar(gastoHogar);
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
                            gastoHogar = null;
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
                        gastoHogar = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
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
            if (string.IsNullOrEmpty(textDetalle.Text))
            {
                valido = false;
                errorProvider1.SetError(textDetalle, "Debe ingresar un detalle");

            }
            if (comboPersonas.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboPersonas, "Elija una persona");
            }
            if (comboTipoDeGasto.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboTipoDeGasto, "Elija un TIPO DE GASTO");
            }
            if (comboFormaDePago.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboFormaDePago, "Elija una FORMA DE PAGO");
            }
            if (comboFondoComun.SelectedIndex == 0 && (int)comboFormaDePago.SelectedValue!=1)
            {
                valido = false;
                errorProvider1.SetError(comboFondoComun, "Elija un FONDO COMUN");
            }
            if ((comboNumTarje.SelectedIndex == 0 && (int)comboFormaDePago.SelectedValue == 2) || (comboNumTarje.SelectedIndex == 0 && (int)comboFormaDePago.SelectedValue == 3))
            {
                valido = false;
                errorProvider1.SetError(comboNumTarje, "Elija una Tarjeta");
            }
            return valido;
        }
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
            if (checkGastoFijo.Checked)
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
                        CombosHelpers.CargarComboVacio(ref comboNumTarje, " ");
                        break;
                    case 2:
                        comboNumTarje.Enabled = true;
                        comboFondoComun.Enabled = false;
                        CombosHelpers.CargarComboVacio(ref comboFondoComun,"");
                        CombosHelpers.CargarComboVacio(ref comboNumTarje, "Primero: Seleccione Persona");
                        break;
                    case 3:
                        comboNumTarje.Enabled = true;
                        comboFondoComun.Enabled = false;
                        CombosHelpers.CargarComboVacio(ref comboFondoComun, "");
                        CombosHelpers.CargarComboVacio(ref comboNumTarje, "Primero: Seleccione Persona");

                        break;
                    case 4:
                        comboNumTarje.Enabled = false;
                        comboFondoComun.Enabled = false;
                        CombosHelpers.CargarComboVacio(ref comboFondoComun, "");
                        CombosHelpers.CargarComboVacio(ref comboNumTarje, "");
                        break;
                    case 5:
                        comboNumTarje.Enabled = false;
                        comboFondoComun.Enabled = false;
                        CombosHelpers.CargarComboVacio(ref comboFondoComun, "");
                        CombosHelpers.CargarComboVacio(ref comboNumTarje, "");
                        break;
                }
            }
            else {
                comboNumTarje.Enabled = false;
                comboFondoComun.Enabled = false;
                CombosHelpers.CargarComboVacio(ref comboFondoComun, "");
                CombosHelpers.CargarComboVacio(ref comboNumTarje, "");
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

        public void SetGasto(GastoHogar gasto)
        {
            this.gastoHogar= gasto;
        }

        public GastoHogar GetGasto()
        {
            return gastoHogar;
        }
    }
}
