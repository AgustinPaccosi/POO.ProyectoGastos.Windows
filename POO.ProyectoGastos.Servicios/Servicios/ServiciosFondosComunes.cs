using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosFondosComunes : IServiciosFondosComunes
    {
        private readonly IRepositorioFondosComunes _repositorioFondosComunes;
        public ServiciosFondosComunes()
        {
            _repositorioFondosComunes = new RepositorioFondosComunes();
        }
        public void Borrar(int idFondo)
        {
            try
            {
                _repositorioFondosComunes.Borrar(idFondo);
            }
            catch (Exception)
            {

                throw;
            }      
        }

        public bool CreacionFondoAutomatico()
        {
            try
            {
                return _repositorioFondosComunes.CreacionFondoAutomatico();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteFUltimoMes()
        {
            try
            {
                return _repositorioFondosComunes.ExisteUltimoMes();
            }
            catch (Exception)
            {

                throw;
            }      
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<FondoComunDto> GetFondoComunDtos()
        {
            try
            {
                return _repositorioFondosComunes.GetFondoComunDtos();
            }
            catch (Exception)
            {

                throw;
            }      
        }

        public void Guardar(FondoComun fondo)
        {
            try
            {
                if (fondo.IdFondoComun == 0)
                {
                    _repositorioFondosComunes.Agregar(fondo);

                }
                else
                {
                    _repositorioFondosComunes.Editar(fondo);
                }
            }
            catch (Exception)
            {

                throw;
            }       
         }
    }
}
