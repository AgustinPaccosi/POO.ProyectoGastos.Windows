using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioGastosFijos
    {
        void Agregar(GastosFijos gastoFijo);
        void Borrar(int IdGasto);
        bool Existe(GastosFijos gastoFijo);
        void Editar(GastosFijos gastoFijo);
        List<GastosFijosDto> GetGastosFijos();
        //int GetCantidad();
        GastosFijos GetGastoFijoPorId(int id);

    }
}
