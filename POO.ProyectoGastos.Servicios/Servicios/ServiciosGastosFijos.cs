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

        public int GetCantidad(int? IdTipoDeVencimiento, int? IdTipoGasto)
        {
            try
            {
                return _repositorioGastosFijos.GetCantidad(IdTipoDeVencimiento, IdTipoGasto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GastosFijos GetGastoFijoPorId(int id)
        {
            try
            {
                return _repositorioGastosFijos.GetGastoFijoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GastosFijosDto> GetGastosFijos(int reguistrosPorPagina, int paginaActual, int? IdTipoDeVencimiento, int? IdTipoGasto)
        {
            try
            {
                return _repositorioGastosFijos.GetGastosFijos(reguistrosPorPagina, paginaActual, IdTipoDeVencimiento, IdTipoGasto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GastosFijosDto> GetGastosFijosCombo()
        {
            try
            {
                return _repositorioGastosFijos.GetGastosFijosCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<GastosFijosDto> GetGastosFijos(int reguistrosPorPagina, int paginaActual, int? IdTipoDeVencimiento, int? IdTipoGasto)
        //{
        //    throw new NotImplementedException();
        //}

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
