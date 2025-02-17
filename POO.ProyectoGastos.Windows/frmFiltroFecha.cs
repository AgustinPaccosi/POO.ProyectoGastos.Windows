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
    public partial class frmFiltroFecha : Form
    {
        public frmFiltroFecha()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dateTimePicker2.Value = DateTime.Now.Date;
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);

        }
        DateTime fechaInicio;
        DateTime fechaFin;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                fechaInicio= dateTimePicker1.Value.Date;
                fechaFin= dateTimePicker2.Value.Date;
                DialogResult= DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido= true;
            if (dateTimePicker2.Value==dateTimePicker1.Value)
            {
                valido= false;
                errorProvider1.SetError(dateTimePicker1, "No puede ser el mismo Dia");
                errorProvider1.SetError(dateTimePicker2, "No puede ser el mismo Dia");
            }
            if (dateTimePicker1.Value>DateTime.Now.Date || dateTimePicker2.Value > DateTime.Now.Date)
            {
                valido = false;
                errorProvider1.SetError(dateTimePicker1, "No puede ser futura");
                errorProvider1.SetError(dateTimePicker2, "No puede ser futura");

            }
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                valido = false;
                errorProvider1.SetError(dateTimePicker1, "Ficha Inicio menor a Fecha Fin");
                errorProvider1.SetError(dateTimePicker2, "Ficha Inicio menor a Fecha Fin");

            }
            return valido;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public DateTime GetFechaInicio()
        {
            return fechaInicio;
        }

        public DateTime GetFechaFin()
        {
            return fechaFin;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);
        }
    }
}
