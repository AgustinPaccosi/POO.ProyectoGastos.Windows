using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.GridHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmGastosFijos : Form
    {
        public frmGastosFijos()
        {
            InitializeComponent();
            servicio=new ServiciosGastosFijos();
            
        }
        private readonly ServiciosGastosFijos servicio;
        private List<GastosFijosDto> lista;
        string texto = "";

        private void GastosFijos_Load(object sender, EventArgs e)
        {
            try
            {
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
            lista = servicio.GetGastosFijos();
            foreach (var gasto in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, gasto);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
