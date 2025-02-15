using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class GastoHogar:ICloneable
    {
        public int IdGasto { get; set; }
        public  DateTime Fecha { get; set; }
        public decimal Valor { get; set;}
        public int IdTipoGasto { get; set; }
        public ComboTiposGastosDto TiposGastosDto { get; set; }
        public int? IdEmpNeg { get; set; }
        public EmpresaNegocio EmpresaNegocio { get; set; }
        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
        public int? IdFondoComun { get; set;}
        public FondoComun FondoComun { get; set; }

        public int? IdGastoFijo { get; set;}

        public int IdFormaPago { get;set; }
        public int? IdTarjeta { get; set; }
        public string Detalle { get; set; }
        public bool Pagado { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
