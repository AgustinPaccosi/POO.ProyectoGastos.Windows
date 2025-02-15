 using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioDatosTarjetas
    {
        void Agregar(DatoTarjeta datos);
        void Borrar(int IdTarjeta);
        bool Existe(DatoTarjeta datos);
        List<DatosTarjetasDto> GetDatosTarjetas();
        List<DatosTarjetasDto> GetDatosTarjetasFiltrado(int IdPersona);
        DatoTarjeta GetDatoTarjetaPorId(int id);
    }
}
