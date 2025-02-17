using POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioTiposDeVencimientos
    {
        List<ComboTiposDeVencimientosDto> GetTiposDeVencimientos();
        ComboTiposDeVencimientosDto GetTiposDeVencimientosPorId(int idPorId);
    }
}
