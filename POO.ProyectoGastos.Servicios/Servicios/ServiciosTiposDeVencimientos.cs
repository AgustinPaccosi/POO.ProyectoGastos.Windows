using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosTiposDeVencimientos : IServiciosTiposDeVencimientos
    {
        private readonly IRepositorioTiposDeVencimientos _repositorioTiposDeVencimientos;

        public ServiciosTiposDeVencimientos()
        {
            _repositorioTiposDeVencimientos = new RepositorioTiposDeVencimientos();
        }

        public List<ComboTiposDeVencimientosDto> GetTiposDeVencimientos()
        {
            try
            {
                return _repositorioTiposDeVencimientos.GetTiposDeVencimientos();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
