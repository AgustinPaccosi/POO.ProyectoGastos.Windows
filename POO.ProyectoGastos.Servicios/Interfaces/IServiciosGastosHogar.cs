using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosGastosHogar
    {
        void Guardar(GastoHogar gastoHogar);
        void Borrar(int IdGasto);
        bool Existe(GastoHogar gastoHogar);
        //void Editar(int IdGasto);
        int GetCantidad();
        List<GastosHogarDto> GetGastosHogar();
        //List<ComboPersonasDto> GetComboPersonasDtos();
        GastoHogar GetGastoHogarPorId(int id);
    }
}
