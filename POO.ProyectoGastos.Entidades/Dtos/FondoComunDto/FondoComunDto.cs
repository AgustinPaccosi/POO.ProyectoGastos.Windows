using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Dtos.FondoComunDto
{
    public class FondoComunDto
    {
        public int IdFondoComun { get; set; }
        public DateTime fecha { get; set; }
        public double Monto { get; set; }
        public double RestoFinMes { get; set; }

    }
}
