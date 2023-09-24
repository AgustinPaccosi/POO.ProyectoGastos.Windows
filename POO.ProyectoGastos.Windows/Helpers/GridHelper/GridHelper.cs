using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows.Helpers.GridHelper
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Persona persona:
                    r.Cells[0].Value=persona.Nombre;
                    r.Cells[1].Value = persona.Apellido;
                    r.Cells[2].Value = persona.Rol;
                    break;
                case EmpresasNegocios empresa:
                    r.Cells[0].Value = empresa.Nombre;
                    r.Cells[1].Value = $"{empresa.Direccion}, {empresa.Telefono}";
                    break;
            }
            r.Tag = obj;

        }
    }
}
