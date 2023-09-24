using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento;
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
        public static void CargarComboTiposGastos(ref ComboBox combo)
        {
            IServiciosTiposGastos serviciosTipoGasto = new ServiciosTiposGastos();
            var lista = serviciosTipoGasto.GetTiposGastos();
            var defaultTipoGasto = new ComboTiposGastosDto()
            {
                IdTipoGasto = 0,
                TipoGasto = "Seleccione Tipo de Gasto"
            };
            lista.Insert(0, defaultTipoGasto);
            combo.DataSource = lista;
            combo.DisplayMember = "TipoGasto";
            combo.ValueMember = "IdTipoGasto";
            combo.SelectedIndex = 0;

        }
        public static void CargarComboTiposDeVencimiento(ref ComboBox combo)
        {
            IServiciosTiposDeVencimientos serviciosTiposDeVencimientos = new ServiciosTiposDeVencimientos();
            var lista = serviciosTiposDeVencimientos.GetTiposDeVencimientos();
            var defaultTipoVencimiento = new ComboTiposDeVencimientosDto()
            {
                IdTipoDeVencimiento = 0,
                TipoDeVencimiento = "Seleccione Tipo de Vencimiento"
            };
            lista.Insert(0, defaultTipoVencimiento);
            combo.DataSource = lista;
            combo.DisplayMember = "TipoDeVencimiento";
            combo.ValueMember = "IdTipoDeVencimiento";
            combo.SelectedIndex = 0;

        }

        //
    }
}
