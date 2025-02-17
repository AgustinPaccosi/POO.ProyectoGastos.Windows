using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class DetalleFondoComun
    {
        public int IdFondoComun { get; set; }
        public int IdPersona { get; set; }
        public string Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
