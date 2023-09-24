using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioTiposGastos
    {
        List<ComboTiposGastosDto> GetTiposGastos();
    }
}
