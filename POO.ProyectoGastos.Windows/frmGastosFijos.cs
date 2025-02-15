using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
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
            frmGastosFijosAE frm=new frmGastosFijosAE(servicio);
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
            GastosFijosDto gastoFijo = (GastosFijosDto)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                servicio.Borrar(gastoFijo.IdGastoFijo);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            GastosFijosDto gastoFijodto = (GastosFijosDto)r.Tag;
            GastosFijosDto gastoFijoCopia = (GastosFijosDto)gastoFijodto.Clone();
            GastosFijos gasto = servicio.GetGastoFijoPorId(gastoFijodto.IdGastoFijo);
            try
            {
                frmGastosFijosAE frm = new frmGastosFijosAE(servicio) { Text = "Editar Gasto Fijo" };
                frm.SetGastoFijo(gasto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, gastoFijoCopia);

                    return;
                }
                gasto = frm.GetGastoFijo();
                //gastoFijodto.TipoGasto=gasto.
                if (gastoFijodto != null)
                {
                    GridHelper.SetearFila(r, gastoFijodto);

                }
                else
                {
                    GridHelper.SetearFila(r, gastoFijoCopia);

                }
            }
            catch (Exception ex)
            {

                GridHelper.SetearFila(r, gastoFijoCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
