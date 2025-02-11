using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.GridHelper;
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
    public partial class frmGastos : Form
    {
        private readonly ServiciosGastosHogar _servicioGastosHogar;
        private List<GastosHogarDto> listaGastosHogar;

        public frmGastos()
        {
            InitializeComponent();
            _servicioGastosHogar = new ServiciosGastosHogar();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Gastos_Load(object sender, EventArgs e)
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
            listaGastosHogar = _servicioGastosHogar.GetGastosHogar();

            foreach (var gastoHogar in listaGastosHogar)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, gastoHogar);
                GridHelper.AgregarFila(dgvDatos, r);
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
