using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
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

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {


            }
            var r = dgvDatos.SelectedRows[0];
            FondoComunDto fondo = (FondoComunDto)r.Tag;

            frmDetallesFondosComunes frm = new frmDetallesFondosComunes();
            frm.SetFondo(fondo);
            frm.ShowDialog(this);
            MostrarDatosEnGrilla();

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
