using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
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
            frmGastosAE frm = new frmGastosAE(_servicioGastosHogar);
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
            //Persona persona = (Persona)r.Tag;
            GastosHogarDto gastoHogar = (GastosHogarDto)r.Tag;

            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicioGastosHogar.Borrar(gastoHogar.IdGasto);
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
            GastosHogarDto gastodto = (GastosHogarDto)r.Tag;
            GastosHogarDto gastodtoCopia = (GastosHogarDto)gastodto.Clone();
            //Persona personaCopia = (Persona)persona.Clone();
            GastoHogar gasto = _servicioGastosHogar.GetGastoHogarPorId(gastodto.IdGasto);
            //gastoDtoCopia
            
            try
            {
                frmGastosAE frm = new frmGastosAE(_servicioGastosHogar) { Text = "Editar Gasto" };
                frm.SetGasto(gasto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, gastodtoCopia);

                    return;
                }
                gasto = frm.GetGasto();
                if (gasto != null)
                {
                    GridHelper.SetearFila(r, gastodto);

                }
                else
                {
                    GridHelper.SetearFila(r, gastodtoCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, gastodtoCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            MostrarDatosEnGrilla();

        }
    }
}
