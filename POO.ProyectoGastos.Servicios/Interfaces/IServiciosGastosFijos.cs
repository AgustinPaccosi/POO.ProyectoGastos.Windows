using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosGastosFijos
    {
        void Guardar(GastosFijos gastosFijos);
        void Borrar(int IdGasto);
        bool Existe(GastosFijos gastosFijos);
        //void Editar(int IdGasto);
        //int GetCantidad();
        List<GastosFijosDto> GetGastosFijos();
    }
}
