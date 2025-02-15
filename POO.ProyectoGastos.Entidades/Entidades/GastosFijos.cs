using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class GastosFijos
    {
        public int IdGastoFijo { get; set; }
        public string Nombre { get; set; }
        public DateTime Vencimiento { get; set; }
        public decimal MontoPagar { get; set; }
        public int IdTipoGasto { get; set; }
        public int IdTipoDeVencimiento { get; set; }

    }
}
