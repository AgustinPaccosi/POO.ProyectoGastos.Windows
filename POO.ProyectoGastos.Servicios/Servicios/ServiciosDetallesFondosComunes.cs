using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public void Borrar(int IdFondo, int idPersona, decimal Monto)
        {
            try
            {
                _repositorioDetalles.Borrar(IdFondo, idPersona, Monto);
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public bool Existe(DetalleFondoComun detalleFondo)
        {
            try
            {
                return _repositorioDetalles.Existe(detalleFondo);
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public List<DetalleFondoComunDto> GetDetallesFondoComun(int idFondo)
        {
            try
            {
                return _repositorioDetalles.GetDetalleFondoComunDtos(idFondo);
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public void Guardar(DetalleFondoComun detalleFondo)
        {
            try
            {
                _repositorioDetalles.Agregar(detalleFondo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
