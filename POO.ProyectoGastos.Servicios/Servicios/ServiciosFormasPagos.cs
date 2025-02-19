using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosFormasPagos : IServiciosFormasPagos
    {
        private readonly IRepositorioFormasPagos repositorioFormasPagos;
        public ServiciosFormasPagos()
        {
            repositorioFormasPagos=new RepositorioFormasPago();
        }
        public List<FormasPagos> GetFormasPagos()
        {
            try
            {
                return repositorioFormasPagos.GetFormasPagos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FormasPagos GetFormasPagosPorId(int id)
        {
            try
            {
                return repositorioFormasPagos.GetFormasPagosPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
