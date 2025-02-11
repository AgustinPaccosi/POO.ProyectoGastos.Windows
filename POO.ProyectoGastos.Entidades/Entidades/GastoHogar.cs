using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class GastoHogar
    {
        public int IdGasto { get; set; }
        public  DateTime Fecha { get; set; }
        public decimal Valor { get; set;}
        public int IdTipoGasto { get; set; }   
        public int IdEmpNeg { get; set; }
        public int IdPersona { get; set; }
        public int IdFondoComun { get; set;}
        public int IdGastoFijo { get; set;}
        public int IdFormaPago { get;set; }
        public int IdDatosTarjeta { get; set; }
        public string Detalle { get; set; }
        public bool Pagado { get; set; }
    }
}
