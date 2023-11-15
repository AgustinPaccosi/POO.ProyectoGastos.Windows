using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto
{
    public class DetalleFondoComunDto
    {
        public int IdFondoComun { get; set; }
        public int IdPersona { get; set; }
        public string NombreCompleto { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
