using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioPersonas : IRepositorioPersonas
    {
        private readonly string cadenaConexion;
        public RepositorioPersonas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Persona persona)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = "INSERT INTO Personas (Nombre, Apellido, IdRol) VALUES(@Nombre, @Apellido, @IdRol); SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, persona);
                persona.IdPersona = id;
            }

        }

        public void Borrar(int idPersona)
        {
            throw new NotImplementedException();
        }

        public void Editar(Persona presona)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Persona persona)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (persona.IdPersona == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Personas
                        WHERE Nombre=@Nombre and Apellido= @Apellido";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, persona);
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Personas" +
                        " WHERE Nombre=@Nombre AND IdPersona!=@IdPersona";
                    cantidad = conn.ExecuteScalar<int>(selectQuery,
                            persona);

                }
            }
            return cantidad > 0;

        }

        public Persona GetPersonaPorId(int idPersona)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> lista = new List<Persona>();
            using (var conn= new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT p.IdPersona, p.Nombre, p.Apellido, r.Rol, p.IdRol
                            FROM Personas p
                            INNER JOIN Roles r ON p.IdRol = r.IdRol
                            ORDER BY Apellido";
                lista=conn.Query<Persona>(SelectQuery).ToList();
            }
            return lista;
        }
    }
}
