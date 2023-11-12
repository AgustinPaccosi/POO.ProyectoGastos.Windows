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
    public partial class frmDatosTarjetasAE : Form
    {
        private IServiciosDatosTarjetas _serviciosDatosTarjetas;
        private DatosTarjetas datos;

        public frmDatosTarjetasAE(ServiciosDatosTarjetas _Servicios)
        {
            InitializeComponent();
            _serviciosDatosTarjetas = _Servicios;
            CombosHelpers.CargarComboPersonas(ref ComboPersonas);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                datos = new DatosTarjetas();
                datos.Numero = txtNumero.Text;
                datos.IdPersona = (int)ComboPersonas.SelectedValue;
                try
                {

                    if (!_serviciosDatosTarjetas.Existe(datos))
                    {
                        _serviciosDatosTarjetas.Guardar(datos);
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
                        datos = null;
                        InicializarControles();

                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        datos = null;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void InicializarControles()
        {
            txtNumero.Clear();
            ComboPersonas.SelectedIndex = 0;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNumero, "Debe ingresar un Numero");

            }
            if (!txtNumero.Text.All(char.IsDigit))
            {
                valido = false;
                errorProvider1.SetError(txtNumero, "Solo se permiten caracteres numéricos");
            }
            if (txtNumero.Text.Length != 4)
            {
                valido = false;
                errorProvider1.SetError(txtNumero, "Solo los Ultimos 4 digitos");
            }
            return valido;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
