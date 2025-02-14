using POO.ProyectoGastos.Entidades;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioFormasPagos
    {

        List<FormasPagos> GetFormasPagos();

    }
}
