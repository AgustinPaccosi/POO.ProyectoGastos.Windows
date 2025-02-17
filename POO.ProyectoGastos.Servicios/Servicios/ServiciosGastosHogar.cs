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

        public GastoHogar GetGastoHogarPorId(int id)
        {
            try
            {
                return _repositorioGastosHogar.GetGastoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GastosHogarDto> GetGastosHogar(int? IdPersona, int? IdTipoDeGasto, DateTime? FechaInicio, DateTime? FechaFin, bool? Pagado)
        {
            try
            {
                return _repositorioGastosHogar.GetGastosHogar(IdPersona, IdTipoDeGasto, FechaInicio, FechaFin, Pagado);
            }
            catch (Exception)
            {

                throw;
            }        }

        public decimal GetTotalGastosFondoComun()
        {
            try
            {
                return _repositorioGastosHogar.GetTotalGastosFondoComun();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal GetTotalGastosMes()
        {
            try
            {
                return _repositorioGastosHogar.GetTotalGastosMes();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public decimal Diferencia(int IdFondo)
        {
            try
            {
                return _repositorioGastosHogar.Diferencia(IdFondo);
            }
            catch (Exception)
            {

                throw;
            }

        }


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
