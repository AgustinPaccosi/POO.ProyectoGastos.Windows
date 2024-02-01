using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosFondosComunes
    {
        void Guardar(FondoComun fondo);
        void Borrar(int idFndo);
        bool ExisteFUltimoMes();
        bool CreacionFondoAutomatico();
        bool Existe(FondoComun fondo);
        int GetCantidad();
        List<FondoComunDto> GetFondoComunDtos();

    }
}
