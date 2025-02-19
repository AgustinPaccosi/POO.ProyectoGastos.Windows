using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.GridHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows
{
    public partial class frmEmpresasNegocios : Form
    {
        public frmEmpresasNegocios()
        {
            InitializeComponent();
            _serviciosEmpresasNegocios = new ServiciosEmpresasNegocios();
        }
        private readonly ServiciosEmpresasNegocios _serviciosEmpresasNegocios;
        private List<EmpresaNegocio> listaEmpresas;
        private void frmEmpresasNegocios_Load(object sender, EventArgs e)
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
            listaEmpresas = _serviciosEmpresasNegocios.GetEmpresasNegocios();
            foreach (var empresa in listaEmpresas)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, empresa);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmEmpresasNegociosAE frm = new frmEmpresasNegociosAE(_serviciosEmpresasNegocios);
            DialogResult dr = frm.ShowDialog(this);
            MostrarDatosEnGrilla();

        }

        private void tsbBorrar_Click_1(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            EmpresaNegocio empresa = (EmpresaNegocio)r.Tag;
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
                MostrarDatosEnGrilla();

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Contains("FK_") ? "ESTA RELACIONADO" : ex.Message;

                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                //MessageBox.Show(ex.Message, "Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            EmpresaNegocio empresa = (EmpresaNegocio)r.Tag;
            EmpresaNegocio empresaCopia = (EmpresaNegocio)empresa.Clone();
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            HabilitarBotones();
            MostrarDatosEnGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            tsbBuscar.Text = "";
            DeshabilitarBotones();
        }

        private void DeshabilitarBotones()
        {
            tsbBorrar.Enabled = false;
            tsbEditar.Enabled = false;
            tsbNuevo.Enabled = false;
        }
        private void HabilitarBotones()
        {
            tsbBorrar.Enabled = true;
            tsbEditar.Enabled = true;
            tsbNuevo.Enabled = true;
        }

        private void tsbBuscar_Leave(object sender, EventArgs e)
        {
            tsbBuscar.Text = "Buscar";
        }
        private void BuscarCliente(List<EmpresaNegocio> empresa, string texto)
        {
            var listaFiltrada = empresa;
            if (texto.Length != 0)
            {
                Func<EmpresaNegocio, bool> condicion = c => c.Nombre.ToUpper().Contains(texto.ToUpper()) || c.Nombre.ToUpper().Contains(texto.ToUpper());
                listaFiltrada = empresa.Where(condicion).ToList();
            }
            GridHelper.MostrarDatosEnGrilla<EmpresaNegocio>(dgvDatos, listaFiltrada);
        }

        private void tsbBuscar_TextChanged(object sender, EventArgs e)
        {
            var texto = tsbBuscar.Text;
            BuscarCliente(listaEmpresas, texto);

        }
    }
}
