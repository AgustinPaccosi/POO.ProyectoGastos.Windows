using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosDetallesFondosComunes : IServiciosDetallesFondosComunes
    {
        private readonly IRepositorioDetalleFondosComunes _repositorioDetalles;
        public ServiciosDetallesFondosComunes()
        {
            _repositorioDetalles = new RepositorioDetalleFondosComunes();
        }
        public void Borrar(int IdDetalleFondo)
        {
            throw new NotImplementedException();
        }

        public bool Existe(DetalleFondoComun detalleFondo)
        {
            throw new NotImplementedException();
        }

        public List<DetalleFondoComunDto> GetDetallesFondoComun()
        {
            try
            {
                return _repositorioDetalles.GetDetalleFondoComunDtos();
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public void Guardar(DetalleFondoComun detalleFondo)
        {
            throw new NotImplementedException();
        }
    }
}
