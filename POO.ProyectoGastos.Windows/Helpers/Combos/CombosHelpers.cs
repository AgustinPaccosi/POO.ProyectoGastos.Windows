using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using POO.ProyectoGastos.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows.Helpers.Combos
{
    public class CombosHelpers
    {
        public static void CargarComboRoles(ref ComboBox combo)
        {
            IServiciosRoles serviciosRoles = new ServiciosRoles(); 
            var lista = serviciosRoles.GetRoles();
            var defaultRol = new ComboRolDto()
            {
                IdRol = 0,
                Rol = "Seleccione Rol"
            };
            lista.Insert(0, defaultRol);
            combo.DataSource = lista;
            combo.DisplayMember = "Rol";
            combo.ValueMember = "IdRol";
            combo.SelectedIndex = 0;

        }
    }
}
