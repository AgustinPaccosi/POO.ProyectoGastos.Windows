using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Dtos.GastosHogar
{
    public class GastosHogarDto
    {
        public int IdGasto { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public string TipoGasto { get; set; }
        public string Persona { get; set; }
        public string Detalle { get; set; }


    }
}
