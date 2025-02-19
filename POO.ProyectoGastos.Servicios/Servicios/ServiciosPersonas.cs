﻿using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
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
            try
            {
                _repositorioPersonas.Borrar(idPersona);
            }
            catch (Exception)
            {

                throw;
            }
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

        public List<ComboPersonasDto> GetComboPersonasDtos()
        {
            try
            {
                return _repositorioPersonas.GetComboPersonasDtos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Persona GetPersonaPorId(int id)
        {
            try
            {
                return _repositorioPersonas.GetPersonaPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
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
