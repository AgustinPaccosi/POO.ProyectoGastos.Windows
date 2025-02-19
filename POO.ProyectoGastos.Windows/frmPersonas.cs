using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using POO.ProyectoGastos.Windows.Helpers.GridHelper;
using System;
using System.Collections;
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
    public partial class frmPersonas : Form
    {
        public frmPersonas()
        {
            InitializeComponent();
            _servicioPersonas = new ServiciosPersonas();
        }

        private readonly ServiciosPersonas _servicioPersonas;
        private List<Persona> listaPersonas;
        string texto = "";

        private void Personas_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarDatosEnGrilla();
                BuscarCliente(listaPersonas, texto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            listaPersonas = _servicioPersonas.GetPersonas();

            foreach (var persona in listaPersonas)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, persona);
                GridHelper.AgregarFila(dgvDatos, r);
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPersonasAE frm = new frmPersonasAE(_servicioPersonas);
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
            Persona persona = (Persona)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicioPersonas.Borrar(persona.IdPersona);
                GridHelper.QuitarFila(dgvDatos, r);
                //lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message, "Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                string mensaje = ex.Message.Contains("FK_") ? "ESTA RELACIONADO" : ex.Message;

                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Persona persona = (Persona)r.Tag;
            Persona personaCopia = (Persona)persona.Clone();
            try
            {
                frmPersonasAE frm = new frmPersonasAE(_servicioPersonas) { Text = "Editar Persona" };
                frm.SetPersona(persona);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, personaCopia);

                    return;
                }
                persona = frm.GetPersona();
                if (persona != null)
                {
                    GridHelper.SetearFila(r, persona);

                }
                else
                {
                    GridHelper.SetearFila(r, personaCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, personaCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            MostrarDatosEnGrilla();

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            //HabilitarBotones();
            MostrarDatosEnGrilla();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarCliente(listaPersonas, texto);
        }
        private void BuscarCliente(List<Persona> persona, string texto)
        {
            var listaFiltrada = persona;
            if (texto.Length != 0)
            {
                Func<Persona, bool> condicion = c => c.Apellido.ToUpper().Contains(texto.ToUpper()) || c.Nombre.ToUpper().Contains(texto.ToUpper());
                listaFiltrada = persona.Where(condicion).ToList();
            }
            GridHelper.MostrarDatosEnGrilla<Persona>(dgvDatos, listaFiltrada);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
            //DeshabilitarBotones();
        }

        //private void toolStripTextBox1_Leave(object sender, EventArgs e)
        //{
        //    toolStripTextBox1.Text = "Buscar";
        //    //MostrarDatosEnGrilla();
        //}
        //private void DeshabilitarBotones()
        //{
        //    tsbBorrar.Enabled = false;
        //    tsbEditar.Enabled = false;
        //    tsbNuevo.Enabled = false;
        //}
        //private void HabilitarBotones()
        //{
        //    tsbBorrar.Enabled = true;
        //    tsbEditar.Enabled = true;
        //    tsbNuevo.Enabled = true;
        //}

    }
}

