using POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosTiposDeVencimientos
    {
        List<ComboTiposDeVencimientosDto> GetTiposDeVencimientos();
    }
}
