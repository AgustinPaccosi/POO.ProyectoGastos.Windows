using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioDetalleFondosComunes : IRepositorioDetalleFondosComunes
    {
        private readonly string cadenaConexion;

        public RepositorioDetalleFondosComunes()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(DetalleFondoComun fondo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {

                string insertQuery = @"INSERT INTO [Personas/FondosComunes] 
                        (IdFondoComun, IdPersona, Monto, Fecha)
                        VALUES (@IdFondoComun , @IdPersona , @Monto, GETDATE())";
                try
                {
                    conn.Execute(insertQuery, fondo);
                }
                catch (SqlException ex)
                {
                    // Manejo de la excepción: imprime el mensaje de error detallado
                    Console.WriteLine("Error al insertar: " + ex.Message);
                }
            }
        }

        public void Borrar(int IdFondoComun, int IdPersona)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM [Personas/FondosComunes] 
                     WHERE IdFondoComun=@IdFondoComun and IdPersona=@IdPersona and MONTH(Fecha) = MONTH(GETDATE()) ";
                conn.Execute(deleteQuery, new { IdFondoComun = IdFondoComun, IdPersona= IdPersona });
            }
        }

        //public void Editar(DetalleFondoComun fondoPersona)
        //{

        //    throw new NotImplementedException();
        //}

        public bool Existe(DetalleFondoComun detalleFondo)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM [Personas/FondosComunes] 
                        WHERE IdFondoComun = @IdFondoComun AND IdPersona = @IdPersona and MONTH(Fecha) = MONTH(GETDATE());";

                cantidad = conn.ExecuteScalar<int>(selectQuery, new { detalleFondo.IdFondoComun, detalleFondo.IdPersona });
            }
            return cantidad > 0;
        }

        public List<DetalleFondoComunDto> GetDetalleFondoComunDtos(int idFondo)
        {
            List<DetalleFondoComunDto> lista = new List<DetalleFondoComunDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"Select Pf.IdFondoComun, Pf.IdPersona,
                            CASE 
                                WHEN Pf.IdPersona IS NOT NULL THEN CONCAT(P.Apellido, ', ', P.Nombre)
                                ELSE 'Resto Del Mes Anterior'
                            END AS NombreCompleto,
                            F.Fecha As FechaDeCreacion,
                            Pf.Monto, pf.Fecha As FechaDeAporte
                            from [Personas/FondosComunes] pf
                            LEFT Join Personas P ON P.IdPersona=pf.IdPersona
                            inner Join FondosComunes F On F.IdFondoComun= pf.IdFondoComun
                            where pf.IdFondoComun=@idFondo";
                lista = conn.Query<DetalleFondoComunDto>(SelectQuery, new { idFondo }).ToList();
            }
            return lista;
        }
    }
}
