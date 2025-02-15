using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosGastosFijos : IServiciosGastosFijos
    {
        private readonly IRepositorioGastosFijos _repositorioGastosFijos;

        public ServiciosGastosFijos()
        {
            _repositorioGastosFijos = new RepositorioGastoFijo();
        }

        public void Borrar(int IdGasto)
        {
            try
            {
                _repositorioGastosFijos.Borrar(IdGasto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(GastosFijos gastosFijos)
        {
            try
            {
                return _repositorioGastosFijos.Existe(gastosFijos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GastosFijosDto> GetGastosFijos()
        {
            try
            {
                return _repositorioGastosFijos.GetGastosFijos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(GastosFijos gastosFijos)
        {
            try
            {
                if (gastosFijos.IdGastoFijo == 0)
                {
                    _repositorioGastosFijos.Agregar(gastosFijos);
                }
                else
                {
                    _repositorioGastosFijos.Editar(gastosFijos);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
