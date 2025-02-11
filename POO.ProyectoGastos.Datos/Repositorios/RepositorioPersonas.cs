using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;

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

        public void Borrar(int Idpersona)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM Personas WHERE IdPersona=@IdPersona";
                conn.Execute(deleteQuery, new { IdPersona = Idpersona });
            }
        }

        public void Editar(Persona persona)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Personas SET Nombre=@Nombre, Apellido=@Apellido, IdRol=@IdRol
                            WHERE IdPersona=@IdPersona";
                conn.Execute(updateQuery, persona);
            }
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
                        " WHERE Nombre=@Nombre AND Apellido= @Apellido and IdPersona!=@IdPersona";
                    cantidad = conn.ExecuteScalar<int>(selectQuery,
                            persona);

                }
            }
            return cantidad > 0;

        }

        public List<ComboPersonasDto> GetComboPersonasDtos()
        {
            List<ComboPersonasDto> lista = new List<ComboPersonasDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT IdPersona, CONCAT(Apellido, ' ' ,Nombre) As NombreCompleto
                            FROM Personas 
                            ORDER BY Apellido";
                lista = conn.Query<ComboPersonasDto>(SelectQuery).ToList();
            }
            return lista;
        }

        public Persona GetPersonaPorId(int idPersona)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> lista = new List<Persona>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT p.IdPersona, p.Nombre, p.Apellido, r.Rol, p.IdRol
                            FROM Personas p
                            INNER JOIN Roles r ON p.IdRol = r.IdRol
                            ORDER BY Apellido";
                lista = conn.Query<Persona>(SelectQuery).ToList();
            }
            return lista;
        }
    }
}
