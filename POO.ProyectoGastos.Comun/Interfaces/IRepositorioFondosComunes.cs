using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System.Collections.Generic;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioFondosComunes
    {
        void Agregar(FondoComun fondo);
        void Borrar(int idFondo);
        void Editar(FondoComun fondo);
        bool ExisteUltimoMes();
        bool Existe(FondoComun fondo);
        bool CreacionFondoAutomatico();
        List<FondoComun> GetFondos();
        List<FondoComunDto> GetFondoComunDtos();
    }
}
