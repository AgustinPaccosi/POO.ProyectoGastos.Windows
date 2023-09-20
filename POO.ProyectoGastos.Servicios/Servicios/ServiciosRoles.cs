using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosRoles : IServiciosRoles
    {
        private readonly IRepositorioRoles _repositorioRoles;

        public ServiciosRoles()
        {
            _repositorioRoles = new RepositorioRoles();
        }
        public List<ComboRolDto> GetRoles()
        {
			try
			{
				return _repositorioRoles.GetRoles();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
