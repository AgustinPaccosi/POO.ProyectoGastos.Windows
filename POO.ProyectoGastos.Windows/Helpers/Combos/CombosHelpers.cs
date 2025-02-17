using POO.ProyectoGastos.Entidades;
using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
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
        public static void CargarComboPersonas(ref ComboBox combo)
        {
            IServiciosPersonas serviciosPersonas = new ServiciosPersonas();
            var lista = serviciosPersonas.GetComboPersonasDtos();
            var defaultPersona = new ComboPersonasDto()
            {
                IdPersona = 0,
                NombreCompleto = "Seleccione Persona"
            };
            lista.Insert(0, defaultPersona);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreCompleto";
            combo.ValueMember = "IdPersona";
            combo.SelectedIndex = 0;

        }

        public static void CargarcomboTarjetas(ref ComboBox combo, int IdPersona)
        {
            IServiciosDatosTarjetas Servicios = new ServiciosDatosTarjetas();
            var lista = Servicios.GetDatosFiltrados(IdPersona);
            var defaultTarjeta = new DatosTarjetasDto()
            {
                IdTarjeta = 0,
                Numero = "Seleccione Tarjeta"
            };
            lista.Insert(0, defaultTarjeta);
            combo.DataSource = lista;
            combo.DisplayMember = "Numero";
            combo.ValueMember = "IdTarjeta";
            combo.SelectedIndex = 0;

        }
        public static void CargarComboTipoDeGastos(ref ComboBox combo)
        {
            IServiciosTiposGastos servicios = new ServiciosTiposGastos();
            var lista = servicios.GetTiposGastos();
            var defaultTipoDeGasto = new ComboTiposGastosDto()
            {
                IdTipoGasto = 0,
                TipoGasto = "Seleccione Tipo De Gasto"
            };
            lista.Insert(0, defaultTipoDeGasto);
            combo.DataSource = lista;
            combo.DisplayMember = "TipoGasto";
            combo.ValueMember = "IdTipoGasto";
            combo.SelectedIndex = 0;

        }
        public static void CargarComboEmpresaNegocio(ref ComboBox combo)
        {
            IServiciosEmpresasNegocios servicios = new ServiciosEmpresasNegocios();
            var lista = servicios.GetEmpresasNegocios();
            var defaultEmpresa = new EmpresaNegocio()
            {
                IdEmpNeg = 0,
                Nombre = "Seleccione Empresa"
            };
            lista.Insert(0, defaultEmpresa);
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdEmpNeg";
            combo.SelectedIndex = 0;

        }
        //public static void CargarComboEmpresaNegocio(ref ComboBox combo)
        //{
        //    IServiciosEmpresasNegocios servicios = new ServiciosEmpresasNegocios();
        //    var lista = servicios.GetEmpresasNegocios();
        //    var defaultEmpresa = new EmpresaNegocio()
        //    {
        //        IdEmpNeg = 0,
        //        Nombre = "Seleccione Empresa"
        //    };
        //    lista.Insert(0, defaultEmpresa);
        //    combo.DataSource = lista;
        //    combo.DisplayMember = "IdEmpNeg";
        //    combo.ValueMember = "Nombre";
        //    combo.SelectedIndex = 0;

        //}
        public static void CargarComboFormasPago(ref ComboBox combo)
        {
            IServiciosFormasPagos servicios = new ServiciosFormasPagos();
            var lista = servicios.GetFormasPagos();
            var defaultFormaPago = new FormasPagos()
            {
                IdFormaPago = 0,
                FormaPago = "Seleccione La Forma de Pago"
            };
            lista.Insert(0, defaultFormaPago);
            combo.DataSource = lista;
            combo.DisplayMember = "FormaPago";
            combo.ValueMember = "IdFormaPago";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboFondoComun(ref ComboBox combo)
        {

            IServiciosFondosComunes servicios = new ServiciosFondosComunes();
            var lista = servicios.GetFondoComunDtos()//.Max(c => c.IdFondoComun);
                                 .Select(f => new
                                 {
                                     IdF = f.IdFondoComun,
                                     FechaTexto = string.Concat(f.Fecha.ToString("MMMM").ToUpper(), " ", f.Fecha.Year.ToString()) // Convierte la fecha en nombre de mes
                                 })
                                 .ToList();
            //var fondo=servicios.
            combo.DataSource = lista;
            combo.DisplayMember = "FechaTexto"; // Mostrar el mes en el ComboBox
            combo.ValueMember = "IdF";
        }

        public static void CargarComboVacio(ref ComboBox combo,string info)
        {
            var defaultItem = new
            {
                Id = 0,
                Descripcion = info
            };

            combo.DataSource = new[] { defaultItem };
            combo.DisplayMember = "Descripcion";
            combo.ValueMember = "Id";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboGastoFijo(ref ComboBox combo)
        {
            IServiciosGastosFijos servicios = new ServiciosGastosFijos();
            var lista = servicios.GetGastosFijos();
            var defaultgastoFijo = new GastosFijosDto()
            {
                IdGastoFijo = 0,
                Nombre = "Seleccione El Gasto Fijo"
            };
            lista.Insert(0, defaultgastoFijo);
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdGastoFijo";
            combo.SelectedIndex = 0;

        }





        //TODO Tabla Año
    }
}
