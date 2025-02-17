using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosTiposGastos : IServiciosTiposGastos
    {
       private readonly IRepositorioTiposGastos _repositoriotiposGastos;

        public ServiciosTiposGastos()
        {
            _repositoriotiposGastos = new RepositorioTiposGastos();
        }

        public ComboTiposGastosDto GetTiposGastosPorId(int IdTipoGasto)
        {
            try
            {
                return _repositoriotiposGastos.GetTiposGastosPorId(IdTipoGasto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComboTiposGastosDto> GetTiposGastos()
        {
			try
			{
                return _repositoriotiposGastos.GetTiposGastos();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
