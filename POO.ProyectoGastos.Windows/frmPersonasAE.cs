using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.Combos;
using System;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmPersonasAE : Form
    {
        private IServiciosPersonas servicio;
        //private IServiciosRoles _serviciosRoles;
        public frmPersonasAE(ServiciosPersonas servicioPersona)
        {
            InitializeComponent();
            servicio = servicioPersona;
        }

        private Persona persona;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelpers.CargarComboRoles(ref comboRol);
            if (persona != null)
            {
                esEdicion = true;
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                comboRol.SelectedIndex = persona.IdRol;
            }
        }
        public Persona GetPersona()
        {
            return persona;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (persona == null)
                {
                    persona = new Persona();
                }
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                persona.IdRol = (int)comboRol.SelectedValue;
                try
                {
                    if (!servicio.Existe(persona))
                    {
                        servicio.Guardar(persona);
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
                            persona = null;
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
                        persona = null;
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
            txtNombre.Clear();
            txtApellido.Clear();
            comboRol.SelectedIndex = 0;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Debe ingresar un nombre");

            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Debe ingresar un Apellido");

            }

            return valido;

        }

        public void SetPersona(Persona persona)
        {
            this.persona = persona;
        }
    }
}
