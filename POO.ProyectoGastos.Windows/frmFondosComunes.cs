using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Servicios.Interfaces;
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
    public partial class frmFondosComunes : Form
    {
        public frmFondosComunes()
        {
            InitializeComponent();
            _servicioFondos = new ServiciosFondosComunes();
        }
        private readonly ServiciosFondosComunes _servicioFondos;
        private List<FondoComunDto> listaFondos;

        private void frmFondosComunes_Load(object sender, EventArgs e)
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
            listaFondos = _servicioFondos.GetFondoComunDtos();

            foreach (var fondo in listaFondos)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, fondo);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }
    }
}
