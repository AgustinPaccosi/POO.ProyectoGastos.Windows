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
    public partial class frmFiltroPersona : Form
    {
        public frmFiltroPersona()
        {
            servicioPersona = new ServiciosPersonas();
            InitializeComponent();
        }
        Persona persona=new Persona();

        private IServiciosPersonas servicioPersona;
        

        private void frmFiltroPersona_Load(object sender, EventArgs e)
        {
            CombosHelpers.CargarComboPersonas(ref comboPersona);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                persona = servicioPersona.GetPersonaPorId((int)comboPersona.SelectedValue);
                DialogResult=DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (comboPersona.SelectedIndex==0)
            {
                errorProvider1.SetError(comboPersona, "Elija Una Persona");
                valido = false;
            }
            return valido;
        }

        public Persona GetPersona()
        {
            return persona;
        }
    }
}
