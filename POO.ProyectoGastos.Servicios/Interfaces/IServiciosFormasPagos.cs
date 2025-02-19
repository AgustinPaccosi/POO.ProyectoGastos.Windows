using POO.ProyectoGastos.Entidades;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosFormasPagos
    {
        List<FormasPagos> GetFormasPagos();
        FormasPagos GetFormasPagosPorId(int id);
    }
}
