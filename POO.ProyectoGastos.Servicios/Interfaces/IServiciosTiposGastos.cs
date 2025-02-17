using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosTiposGastos
    {
        List<ComboTiposGastosDto> GetTiposGastos();
        ComboTiposGastosDto GetTiposGastosPorId(int IdTipoGasto);
    }
}
