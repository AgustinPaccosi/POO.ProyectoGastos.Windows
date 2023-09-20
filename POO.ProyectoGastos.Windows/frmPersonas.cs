using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.GridHelper;
using System;
using System.Collections;
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
    public partial class frmPersonas : Form
    {
        public frmPersonas()
        {
            InitializeComponent();
            _servicioPersonas= new ServiciosPersonas();
        }

        private readonly ServiciosPersonas _servicioPersonas;
        private List<Persona> listaPersonas;

        private void Personas_Load(object sender, EventArgs e)
        {
            try
            {
                listaPersonas = _servicioPersonas.GetPersonas();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var persona in listaPersonas)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, persona);
                GridHelper.AgregarFila(dgvDatos, r);
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPersonasAE frm= new frmPersonasAE(_servicioPersonas);
            DialogResult dr= frm.ShowDialog(this);
            MostrarDatosEnGrilla();
        }
    }
}
