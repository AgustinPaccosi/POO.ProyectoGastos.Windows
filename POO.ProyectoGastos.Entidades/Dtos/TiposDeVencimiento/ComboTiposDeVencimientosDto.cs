using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento
{
    public class ComboTiposDeVencimientosDto:ICloneable
    {
        public int IdTipoDeVencimiento { get; set; }
        public string TipoDeVencimiento { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
