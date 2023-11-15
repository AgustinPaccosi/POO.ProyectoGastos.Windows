using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosDetallesFondosComunes
    {
        void Guardar(DetalleFondoComun detalleFondo);
        void Borrar(int IdDetalleFondo);
        bool Existe(DetalleFondoComun detalleFondo);
        List<DetalleFondoComunDto> GetDetallesFondoComun(int idFondo);

    }
}
