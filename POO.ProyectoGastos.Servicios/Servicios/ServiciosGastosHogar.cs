using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosGastosHogar : IServiciosGastosHogar
    {
        private readonly IRepositorioGastosHogar _repositorioGastosHogar;
        public ServiciosGastosHogar()
        {
            _repositorioGastosHogar = new RepositorioGastosHogar();
        }

        public void Borrar(int IdGasto)
        {
            try
            {
                _repositorioGastosHogar.Borrar(IdGasto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(int IdGasto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(GastoHogar gastoHogar)
        {
            try
            {
                return _repositorioGastosHogar.Existe(gastoHogar);
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

        public List<GastosHogarDto> GetGastosHogar()
        {
            try
            {
                return _repositorioGastosHogar.GetGastosHogar();
            }
            catch (Exception)
            {

                throw;
            }        }

        public void Guardar(GastoHogar gastoHogar)
        {
            try
            {
                if (gastoHogar.IdGasto == 0)
                {
                    _repositorioGastosHogar.Agregar(gastoHogar);
                }
                else
                {
                    _repositorioGastosHogar.Editar(gastoHogar);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
