using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosPersonas : IServiciosPersonas
    {
        private readonly IRepositorioPersonas _repositorioPersonas;

        public ServiciosPersonas()
        {
            _repositorioPersonas= new RepositorioPersonas();
        }
        public void Borrar(int idPersona)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Persona persona)
        {
            try
            {
                return _repositorioPersonas.Existe(persona);
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

        public List<Persona> GetPersonas()
        {
            try
            {
                return _repositorioPersonas.GetPersonas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Persona persona)
        {
            try
            {
                if (persona.IdPersona == 0)
                {
                    _repositorioPersonas.Agregar(persona);
                }
                else
                {
                    _repositorioPersonas.Editar(persona);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
