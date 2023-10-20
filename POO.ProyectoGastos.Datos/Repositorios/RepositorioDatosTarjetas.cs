using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
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
        public void Agregar(DatosTarjetas datos)
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

        public bool Existe(DatosTarjetas datos)
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

        public List<DatosTarjetas> GetDatosTarjetas()
        {
            List<DatosTarjetas> lista = new List<DatosTarjetas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT IdTarjetas, Numero, IdPersona
                            FROM DatosTarjetas 
                            ORDER BY Numero";
                lista = conn.Query<DatosTarjetas>(SelectQuery).ToList();
            }

            return lista;
        }
    }
}
