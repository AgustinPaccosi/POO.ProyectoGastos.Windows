using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.Combos;
using System;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmDetallesFondosComunAE : Form
    {
        private IServiciosDetallesFondosComunes _serviciosFondo;
        private DetalleFondoComun detalleFondo;
        //private bool esEdicion = false;

        public frmDetallesFondosComunAE(ServiciosDetallesFondosComunes _ServiciosFondo)
        {
            InitializeComponent();
            _serviciosFondo = _ServiciosFondo;
            CombosHelpers.CargarComboPersonas(ref CboPersonas);

        }
        public void SetEmpresasNegocio(DetalleFondoComun detalle)
        {
            this.detalleFondo = detalle;
        }

        public DetalleFondoComun GetDetalleFondo()
        {
            return detalleFondo;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (detalleFondo == null)
                {
                    detalleFondo = new DetalleFondoComun();
                }
                try
                {
                    if (!_serviciosFondo.Existe(detalleFondo))
                    {
                        _serviciosFondo.Guardar(detalleFondo);
                        //if (!esEdicion)

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
                        InicializarControles();

                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado, Borre el anterior y actualizar",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //empresaNegocio = null;
                    }

                }
                catch (Exception)
                {

                    InicializarControles();
                }

            }
        }
        private void InicializarControles()
        {
            txtcantidad.Clear();
            CboPersonas.SelectedIndex = 0;
        }

        private bool ValidarDatos()
        {
            bool valido = true;

            if ((int)CboPersonas.SelectedValue == 0)
            {
                valido = false;
                errorProvider1.SetError(CboPersonas, "Debe Elegir una Persona");

            }
            if (string.IsNullOrEmpty(txtcantidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtcantidad, "Debe ingresar un Numero");

            }
            return valido;
        }
    }
}
