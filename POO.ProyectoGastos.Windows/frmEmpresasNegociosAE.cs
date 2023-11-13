using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
using System;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmEmpresasNegociosAE : Form
    {
        private IServiciosEmpresasNegocios _serviciosEmpresasNegocios;
        private EmpresaNegocio empresaNegocio;
        private bool esEdicion = false;
        public frmEmpresasNegociosAE(ServiciosEmpresasNegocios _ServiciosEmpresas)
        {
            InitializeComponent();
            _serviciosEmpresasNegocios = _ServiciosEmpresas;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (empresaNegocio != null)
            {
                esEdicion = true;
                txtNombre.Text = empresaNegocio.Nombre;
                txtDireccion.Text = empresaNegocio.Direccion;
                txtTelefono.Text = empresaNegocio.Telefono;
            }
        }
        public EmpresaNegocio GetEmpresasNegocio()
        {
            return empresaNegocio;
        }

        public void SetEmpresasNegocio(EmpresaNegocio empresa)
        {
            this.empresaNegocio = empresa;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (empresaNegocio == null)
                {
                    empresaNegocio = new EmpresaNegocio();
                }
                empresaNegocio.Nombre = txtNombre.Text;
                empresaNegocio.Direccion = txtDireccion.Text;
                empresaNegocio.Telefono = txtTelefono.Text;
                try
                {
                    if (!_serviciosEmpresasNegocios.Existe(empresaNegocio))
                    {
                        _serviciosEmpresasNegocios.Guardar(empresaNegocio);
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
                            empresaNegocio = null;
                            InicializarControles();
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
                        empresaNegocio = null;
                    }

                }
                catch (Exception)
                {

                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();

                }
            }
        }

        private void InicializarControles()
        {
            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Debe ingresar un nombre");

            }

            return valido;

        }

    }
}
