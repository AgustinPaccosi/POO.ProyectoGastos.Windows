using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
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
    public partial class frmFondosComunesAE : Form
    {
        private IServiciosFondosComunes _serviciosfondosComunes;
        private FondoComun fondo;

        public frmFondosComunesAE(ServiciosFondosComunes _ServiciosFondosComunes)
        {
            InitializeComponent();
            _serviciosfondosComunes = _ServiciosFondosComunes;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                fondo.Monto = 0;
                fondo.RestoFinMes = 0;
                _serviciosfondosComunes.Guardar(fondo);
                MessageBox.Show("Registro agregado",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                        "Pregunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    DialogResult = DialogResult.OK;

                }

            }

        }

        private bool ValidarDatos()
        {
            var mes = CboMeses.SelectedIndex;
            var anio=cboAnio.SelectedIndex;
            fondo.Fecha = new DateTime(anio, mes, 1);
            return _serviciosfondosComunes.Existe(fondo);
        }
    }
}
