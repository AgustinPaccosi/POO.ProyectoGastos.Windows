using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
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
            frmDetallesFondosComunAE frm= new frmDetallesFondosComunAE(_servicioDetalles);
            frm.SetFondoComun(fondo);
            DialogResult dr = frm.ShowDialog(this);
            MostrarDatosEnGrilla(fondo.IdFondoComun);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            DetalleFondoComunDto detalleFondo = (DetalleFondoComunDto)r.Tag;
            if (detalleFondo.IdPersona == null)
            {
                MessageBox.Show(@"No se puede Borrar el Registro ya que es el resto del 
                    mes anterior ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                _servicioDetalles.Borrar(detalleFondo.IdFondoComun, detalleFondo.IdPersona ?? 0);

            }
            //else
            //{
            //    var idPersona = detalleFondo.IdPersona;
            //    if (idPersona == null)
            //    {
            //        idPersona = 0;
            //        _servicioDetalles.Borrar(detalleFondo.IdFondoComun, idPersona?? 0);

            //    }
            //}

            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                //_servicioDetalles.Borrar(fondo.IdFondoComun, fondo.IdPersona)
                GridHelper.QuitarFila(dgvDatos, r);
                //lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatosEnGrilla(fondo.IdFondoComun);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla(fondo.IdFondoComun);
        }
    }
}
