using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosDatosTarjetas
    {
        void Guardar(DatoTarjeta datos);
        void Borrar(int IdTarjeta);
        bool Existe(DatoTarjeta datos);
        List<DatosTarjetasDto> GetDatos();
        List<DatosTarjetasDto> GetDatosFiltrados(int IdPersona);


    }
}
