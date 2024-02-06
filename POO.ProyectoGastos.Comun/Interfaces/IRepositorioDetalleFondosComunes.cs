using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioDetalleFondosComunes
    {
        void Agregar(DetalleFondoComun fondoPersona);
        void Borrar(int idFondo, int idPersona);
        //void Editar(DetalleFondoComun fondoPersona);
        bool Existe(DetalleFondoComun fondoPersona);
        List<DetalleFondoComunDto> GetDetalleFondoComunDtos(int idFondo);

    }
}
