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
                if (!_servicioFondos.ExisteFUltimoMes())
                {
                    if (_servicioFondos.CreacionFondoAutomatico())
                    {
                        MessageBox.Show("Actualización Exitosa", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if (_servicioFondos.CreacionFondoAutomatico())
                    //{
                    //    MessageBox.Show("Actualización Exitosa", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
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
                return;

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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFondosComunesAE frm=new frmFondosComunesAE(_servicioFondos);
            DialogResult dr= frm.ShowDialog(this);
            MostrarDatosEnGrilla();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            FondoComunDto fondo = (FondoComunDto)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicioFondos.Borrar(fondo.IdFondoComun);
                GridHelper.QuitarFila(dgvDatos, r);
                //lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla();
        }
    }
}
