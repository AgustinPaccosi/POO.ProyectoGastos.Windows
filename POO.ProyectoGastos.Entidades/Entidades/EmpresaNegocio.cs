using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class EmpresaNegocio: ICloneable
    {
        public int IdEmpNeg { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
