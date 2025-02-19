using Microsoft.Win32;
using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.Forms;
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
            serviciosTiposGastos = new ServiciosTiposGastos();
            serviciosTiposDeVencimientos = new ServiciosTiposDeVencimientos();
        }
        private readonly ServiciosGastosFijos servicio;
        private readonly ServiciosTiposGastos serviciosTiposGastos;
        private readonly ServiciosTiposDeVencimientos serviciosTiposDeVencimientos;
        private List<GastosFijosDto> lista;
        string texto = "";
        int paginaActual=1;
        int registrosPorPaginas = 4;
        int registros = 0;
        int paginas = 0;
        int? IdTipoDeVencimiento;
        int? IdTipoGasto;
        
        private void GastosFijos_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarDatos();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatos()
        {
            registros = servicio.GetCantidad(IdTipoDeVencimiento, IdTipoGasto);
            paginas = FormHelpers.CalcularPaginas(registros, registrosPorPaginas);

            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            lista = servicio.GetGastosFijos(registrosPorPaginas, paginaActual,IdTipoDeVencimiento,IdTipoGasto);
            foreach (var gasto in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, gasto);
                GridHelper.AgregarFila(dgvDatos, r);
            }
            lblPaginaActual.Text = paginaActual.ToString();
            lblRegistros.Text=registros.ToString();
            lblPaginas.Text=paginas.ToString();
            HabilitarBotones();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmGastosFijosAE frm=new frmGastosFijosAE(servicio);
            DialogResult dr= frm.ShowDialog(this);
            MostrarDatos();
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
                MostrarDatos();
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
                gastoFijodto.Nombre = gasto.Nombre;
                gastoFijodto.TipoGasto = serviciosTiposGastos.GetTiposGastosPorId(gasto.IdTipoGasto).TipoGasto;
                gastoFijodto.Vencimiento = gasto.Vencimiento;
                gastoFijodto.MontoPagar = gasto.MontoPagar;
                gastoFijodto.TipoDeVencimiento = serviciosTiposDeVencimientos.GetTiposDeVencimientosPorId(gasto.IdTipoDeVencimiento).TipoDeVencimiento;

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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            IdTipoDeVencimiento = null;
            IdTipoGasto = null;
            paginaActual = 1;
            MostrarDatos();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarDatosEnGrilla();
            if (IdTipoDeVencimiento!=null || IdTipoGasto !=null)
            {
                DeshabilitarBotones();

            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarDatosEnGrilla();
            if (IdTipoDeVencimiento != null || IdTipoGasto != null)
            {
                DeshabilitarBotones();

            }

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            MostrarDatosEnGrilla();
            if (IdTipoDeVencimiento != null || IdTipoGasto != null)
            {
                DeshabilitarBotones();

            }

        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarDatosEnGrilla();
            if (IdTipoDeVencimiento != null || IdTipoGasto != null)
            {
                DeshabilitarBotones();

            }

        }

        private void tipoDeGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroTipoGasto frm = new frmFiltroTipoGasto();

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var tipoGasto = frm.GetTipoDegasto();
            IdTipoGasto = tipoGasto.IdTipoGasto;
            MostrarDatos();
            DeshabilitarBotones();

        }
        private void HabilitarBotones()
        {
            tsbNuevo.Enabled = true;
            tsbEditar.Enabled = true;
            tsbBorrar.Enabled = true;
            tsbBuscar.Enabled = true;
            tsbBuscar.BackColor = SystemColors.Window;
            tsbCerrar.Enabled = true;

        }

        private void DeshabilitarBotones()
        {
            tsbNuevo.Enabled = false;
            tsbEditar.Enabled = false;
            tsbBorrar.Enabled = false;
            tsbBuscar.Enabled = false;
            tsbBuscar.BackColor = SystemColors.GrayText;
            tsbCerrar.Enabled = false;

        }

        private void tipoDeVencimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroTipoDeVencimiento frm = new frmFiltroTipoDeVencimiento();

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var tipoDeVencimiento = frm.GetTipoDeVencimiento();
            IdTipoDeVencimiento = tipoDeVencimiento.IdTipoDeVencimiento;
            MostrarDatos();
            DeshabilitarBotones();

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
