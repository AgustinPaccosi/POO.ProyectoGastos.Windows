using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
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
    public partial class frmDetallesFondosComunes : Form
    {
        private readonly ServiciosDetallesFondosComunes _servicioDetalles;
        private List<DetalleFondoComunDto> listaDetallesFondo;
        private FondoComunDto fondo;

        public frmDetallesFondosComunes()
        {
            InitializeComponent();
            _servicioDetalles = new ServiciosDetallesFondosComunes();
        }

        public void SetFondo(FondoComunDto fondo)
        {
            this.fondo = fondo;
        }

        private void frmDetallesFondosComunes_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarDatosEnGrilla(fondo.IdFondoComun);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla(int idFondo)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            listaDetallesFondo = _servicioDetalles.GetDetallesFondoComun(idFondo);

            foreach (var detalle in listaDetallesFondo)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, detalle);
                GridHelper.AgregarFila(dgvDatos, r);
            }

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
