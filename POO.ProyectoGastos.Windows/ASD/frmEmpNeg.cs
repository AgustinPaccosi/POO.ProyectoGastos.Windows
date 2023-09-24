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
    public partial class frmEmpNeg : Form
    {
        public frmEmpNeg()
        {
            InitializeComponent();
            _serviciosEmpresasNegocios = new ServiciosEmpresasNegocios();
        }
        private readonly ServiciosEmpresasNegocios _serviciosEmpresasNegocios;
        private List<EmpresasNegocios> listaEmpresas;

        private void frmEmpNeg_Load(object sender, EventArgs e)
        {
            try
            {
                listaEmpresas = _serviciosEmpresasNegocios.GetEmpresasNegocios();
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
            foreach (var empresa in listaEmpresas)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, empresa);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            EmpresasNegocios empresa = (EmpresasNegocios)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _serviciosEmpresasNegocios.Borrar(empresa.IdEmpNeg);
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
            MostrarDatosEnGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            EmpresasNegocios empresa = (EmpresasNegocios)r.Tag;
            EmpresasNegocios empresaCopia = (EmpresasNegocios)empresa.Clone();
            try
            {
                frmEmpresasNegociosAE frm = new frmEmpresasNegociosAE(_serviciosEmpresasNegocios) { Text = "Editar EmpresasNegocio" };
                frm.SetEmpresasNegocio(empresa);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, empresaCopia);

                    return;
                }
                empresa = frm.GetEmpresasNegocio();
                if (empresa != null)
                {
                    GridHelper.SetearFila(r, empresa);

                }
                else
                {
                    GridHelper.SetearFila(r, empresaCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, empresaCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
