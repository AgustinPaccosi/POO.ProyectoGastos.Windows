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
            throw new NotImplementedException();
        }

        public bool Existe(GastoHogar gastoHogar)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
