using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
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
    public partial class frmDatosTarjetas : Form
    {
        public frmDatosTarjetas()
        {
            InitializeComponent();
            _serviciosDatosTarjetas = new ServiciosDatosTarjetas();
        }
        private readonly ServiciosDatosTarjetas _serviciosDatosTarjetas;
        private List<DatosTarjetasDto> listaTarjetas;

        private void frmDatosTarjetas_Load(object sender, EventArgs e)
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
            listaTarjetas = _serviciosDatosTarjetas.GetDatos();

            foreach (var datos in listaTarjetas)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, datos);
                GridHelper.AgregarFila(dgvDatos, r);
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmDatosTarjetasAE frm = new frmDatosTarjetasAE(_serviciosDatosTarjetas);
            DialogResult dr = frm.ShowDialog(this);
            MostrarDatosEnGrilla();

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            DatosTarjetasDto datos = (DatosTarjetasDto)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _serviciosDatosTarjetas.Borrar(datos.IdTarjeta);
                GridHelper.QuitarFila(dgvDatos, r);
                //lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Contains("FK_") ? "ESTA RELACIONADO" : ex.Message;

                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                //MessageBox.Show(ex.Message, "Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla();

        }
    }
}
