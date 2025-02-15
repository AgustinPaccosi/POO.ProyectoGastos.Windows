using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioDatosTarjetas : IRepositorioDatosTarjetas
    {
        private readonly string cadenaConexion;
        public RepositorioDatosTarjetas()
        {
            cadenaConexion= ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(DatoTarjeta datos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = "INSERT INTO DatosTarjetas " +
                    "(Numero, IdPersona) " +
                    "VALUES(@Numero, @IdPersona); SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, datos);
                datos.IdTarjeta = id;
            }
        }

        public void Borrar(int IdTarjeta)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM DatosTarjetas " +
                    "WHERE IdTarjeta=@IdTarjeta";
                conn.Execute(deleteQuery, new { IdTarjeta = IdTarjeta });
            }
        }

        public bool Existe(DatoTarjeta datos)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;

                selectQuery = @"SELECT COUNT(*) FROM DatosTarjetas
                        WHERE Numero=@Numero";
                cantidad = conn.ExecuteScalar<int>(selectQuery, datos);
            }
            return cantidad > 0;
        }

        public List<DatosTarjetasDto> GetDatosTarjetas()
        {
            List<DatosTarjetasDto> lista = new List<DatosTarjetasDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT D.IdTarjeta, D.Numero, CONCAT(P.Nombre, ', ',  P.Apellido) As NombreCompleto
                            FROM DatosTarjetas D
                            INNER JOIN Personas P on p.IdPersona=D.IdPersona
                            ORDER BY NombreCompleto";

//                //SELECT
//                D.IdTarjeta,
//    D.Numero,
//    CONCAT(P.Apellido, ', ', P.Nombre) AS NombreCompleto
//FROM
//    DatosTarjetas D
//INNER JOIN
//    Personas P ON P.IdPERSONA = D.IdPersona;
                lista = conn.Query<DatosTarjetasDto>(SelectQuery).ToList();
            }

            return lista;
        }

        public List<DatosTarjetasDto> GetDatosTarjetasFiltrado(int IdPersona)
        {
            List<DatosTarjetasDto> lista = new List<DatosTarjetasDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT D.IdTarjeta, D.Numero, CONCAT(P.Nombre, ', ',  P.Apellido) As NombreCompleto
                            FROM DatosTarjetas D
                            INNER JOIN Personas P on p.IdPersona=D.IdPersona
                            WHERE P.IdPersona=@IdPersona
                            ORDER BY NombreCompleto";

                lista = conn.Query<DatosTarjetasDto>(SelectQuery, new { IdPersona }).ToList();
            }

            return lista;
        }

        public DatoTarjeta GetDatoTarjetaPorId(int IdTarjeta)
        {
            DatoTarjeta dato = new DatoTarjeta();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"SELECT IdTarjeta, Numero, IdPersona FROM DatosTarjetas where IdTarjeta=@IdTarjeta;";
                dato = conn.QuerySingleOrDefault<DatoTarjeta>(selectquery, new { IdTarjeta = IdTarjeta });
            }
            return dato;

        }
    }
}
