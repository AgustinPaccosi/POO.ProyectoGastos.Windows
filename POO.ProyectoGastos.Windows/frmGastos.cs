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
        private readonly ServiciosPersonas _servicioPersonas;
        private readonly ServiciosTiposGastos serviciosTiposGastos;
        private readonly ServiciosFondosComunes serviciosFondosComunes;
        int? IdPersona;
        int? IdTipoDeGasto;
        DateTime? FechaInicio;
        DateTime? FechaFin;
        bool? Pagado;

        private List<GastosHogarDto> listaGastosHogar;

        public frmGastos()
        {
            InitializeComponent();
            _servicioGastosHogar = new ServiciosGastosHogar();
            _servicioPersonas = new ServiciosPersonas();
            serviciosTiposGastos=new ServiciosTiposGastos();
            serviciosFondosComunes=new ServiciosFondosComunes();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Gastos_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarCantidades();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarCantidades()
        {
            lblFondoComun.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            lblGastosConFondo.Visible = true;
            lblResto.Visible = true;
            lblTotalGastos.Visible = true;
            lblGastosConFondo.Text = _servicioGastosHogar.GetTotalGastosFondoComun().ToString();
            lblTotalGastos.Text = _servicioGastosHogar.GetTotalGastosMes().ToString();
            lblResto.Text = _servicioGastosHogar.Diferencia((int)serviciosFondosComunes.GetFondoComunDtos().Max(c => c.IdFondoComun)).ToString();
            lblFondoComun.Text = serviciosFondosComunes.MontoEnFondoComun((int)serviciosFondosComunes.GetFondoComunDtos().Max(c => c.IdFondoComun)).ToString();

        }


        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            listaGastosHogar = _servicioGastosHogar.GetGastosHogar(IdPersona,IdTipoDeGasto,FechaInicio,FechaFin,Pagado);

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
            MostrarCantidades();
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
            MostrarCantidades();

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
                gastodto.IdGasto = gasto.IdGasto;
                gastodto.TipoGasto = serviciosTiposGastos.GetTiposGastosPorId(gasto.IdTipoGasto).TipoGasto;
                gastodto.Persona = $"{_servicioPersonas.GetPersonaPorId(gasto.IdPersona).Apellido}, {_servicioPersonas.GetPersonaPorId(gasto.IdPersona).Nombre}";
                gastodto.Fecha = gasto.Fecha;
                gastodto.Valor=gasto.Valor;
                gastodto.Detalle=gasto.Detalle;
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
            MostrarCantidades();

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            
            IdPersona = null;
            IdTipoDeGasto = null;
            FechaInicio = null;
            FechaFin = null; 
            Pagado = null;
            MostrarDatosEnGrilla();
            HabilitarBotones();
            MostrarCantidades();
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

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroPersona frm= new frmFiltroPersona();

            DialogResult dr=frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var persona = frm.GetPersona();
            IdPersona = persona.IdPersona;
            MostrarDatosEnGrilla();
            DeshabilitarBotones();
            EsconderMontos();

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

        private void tipoDeGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroTipoGasto frm = new frmFiltroTipoGasto();

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var tipoGasto = frm.GetTipoDegasto();
            IdTipoDeGasto = tipoGasto.IdTipoGasto;
            MostrarDatosEnGrilla();
            DeshabilitarBotones();
            EsconderMontos();


        }

        private void pagadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagado = true;
            MostrarDatosEnGrilla();
            DeshabilitarBotones();
            EsconderMontos();
        }

        private void ultimos30DiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroFecha frm = new frmFiltroFecha();
            DialogResult dr = frm.ShowDialog(this);
            if (dr== DialogResult.Cancel)
            {
                return;
            }
            var fechaInicio = frm.GetFechaInicio();
            var fechaFin = frm.GetFechaFin();
            FechaFin= fechaFin;
            FechaInicio= fechaInicio;
            MostrarDatosEnGrilla();
            DeshabilitarBotones();
            EsconderMontos();
        }

        private void EsconderMontos()
        {
            lblFondoComun.Visible= false;
            label1.Visible= false;
            label2.Visible= false;
            label3.Visible= false;
            label4.Visible= false; 
            label5.Visible= false;
            lblGastosConFondo.Visible= false;
            lblResto.Visible= false;
            lblTotalGastos.Visible = false;

        }
    }
}
