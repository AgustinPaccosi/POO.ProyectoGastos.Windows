using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class GastosHogar
    {
        public int IdGasto { get; set; }
        public  DateTime Fecha { get; set; }
        public decimal Valor { get; set;}
        public string TipoGasto { get; set; }   
        public string EmpNeg { get; set; }
        public string Persona { get; set; }
        public string FondoComun { get; set;}
        public string GastoFijo { get; set;}
        public string FormasPago { get;set; }

    }
}
