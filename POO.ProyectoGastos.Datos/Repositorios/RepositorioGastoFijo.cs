using Dapper;
using Microsoft.Win32;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
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
    public class RepositorioGastoFijo:IRepositorioGastosFijos
    {
        private readonly string cadenaConexion;
        public RepositorioGastoFijo()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public void Agregar(GastosFijos gastoFijo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO GastosFijos (Nombre, Vencimiento, 
                    MontoPagar, IdTipoGasto, IdTipoDeVencimiento)  
                    VALUES (@Nombre, @Vencimiento, @MontoPagar, 
                    @IdTipoGasto, @IdTipoDeVencimiento); 
                    SELECT SCOPE_IDENTITY();";

                int id = conn.QuerySingle<int>(insertQuery, gastoFijo);
                gastoFijo.IdGastoFijo = id;

            }
        }

        public void Borrar(int IdGastoFijo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM GastosFijos WHERE IdGastoFijo=@IdGastoFijo";
                conn.Execute(deleteQuery, new { IdGastoFijo = IdGastoFijo });
            }

        }

        public void Editar(GastosFijos gastoFijo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE GastosFijos 
                    SET Nombre = @Nombre, 
                    Vencimiento = @Vencimiento, 
                    MontoPagar = @MontoPagar, 
                    IdTipoGasto = @IdTipoGasto, 
                    IdTipoDeVencimiento = @IdTipoDeVencimiento
                    WHERE IdGastoFijo = @IdGastoFijo;";

                conn.Execute(updateQuery, gastoFijo);
            }
        }

        public bool Existe(GastosFijos gastoFijo)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (gastoFijo.IdGastoFijo == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM GastosFijos WHERE  
                Nombre = @Nombre AND Vencimiento = @Vencimiento AND MontoPagar = @MontoPagar AND 
                IdTipoGasto = @IdTipoGasto AND IdTipoDeVencimiento = @IdTipoDeVencimiento;";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, gastoFijo);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM GastosFijos WHERE IdGastoFijo != @IdGastoFijo 
                AND Nombre = @Nombre AND Vencimiento = @Vencimiento AND MontoPagar = @MontoPagar AND 
                IdTipoGasto = @IdTipoGasto AND IdTipoDeVencimiento = @IdTipoDeVencimiento;";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, gastoFijo);
                }
            }
            return cantidad > 0;
        }

        public GastosFijos GetGastoFijoPorId(int IdGastoFijo)
        {
            GastosFijos gasto = new GastosFijos();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"SELECT IdGastoFijo
                    ,Nombre
                     ,Vencimiento
                     ,MontoPagar
                       ,IdTipoGasto
                     ,IdTipoDeVencimiento
                    FROM GastosFijos Where IdGastoFijo=@IdGastoFijo ";
                gasto = conn.QuerySingleOrDefault<GastosFijos>(selectquery, new { IdGastoFijo = IdGastoFijo });
            }
            return gasto;

        }

        public List<GastosFijosDto> GetGastosFijos(int reguistrosPorPagina, int paginaActual, int? IdTipoDeVencimiento, int? IdTipoGasto)
        {
            List<GastosFijosDto> lista = new List<GastosFijosDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                StringBuilder selectQuery = new StringBuilder();

                selectQuery.AppendLine(@"SELECT IdGastoFijo, Nombre, Vencimiento, MontoPagar, tg.TipoGasto, tv.TipoDeVencimiento 
                               FROM dbo.GastosFijos gf
                               INNER JOIN TiposGastos tg ON tg.IdTipoGasto = gf.IdTipoGasto
                               INNER JOIN TiposDeVencimientos tv ON tv.IdTipoDeVencimiento = gf.IdTipoDeVencimiento");
                if (IdTipoDeVencimiento!=null||IdTipoGasto!=null)
                {
                    selectQuery.AppendLine("Where tv.IdTipoDeVencimiento=@IdTipoDeVencimiento or tg.IdTipoGasto=@IdTipoGasto");
                }
                selectQuery.AppendLine("ORDER BY Vencimiento DESC OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");
                var parametros = new { IdTipoDeVencimiento, IdTipoGasto, registrosSaltados = reguistrosPorPagina * (paginaActual - 1), registrosPorPagina= reguistrosPorPagina };
                lista = conn.Query<GastosFijosDto>(selectQuery.ToString(), parametros).ToList();
            }
            return lista;
        }

        public int GetCantidad(int? IdTipoDeVencimiento, int? IdTipoGasto)
        {
            int cantidad = 0;
            string selectQuery;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (IdTipoDeVencimiento == null && IdTipoGasto==null)
                {
                    selectQuery = "SELECT COUNT(*) FROM GastosFijos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (IdTipoDeVencimiento == null && IdTipoGasto != null)
                {
                    selectQuery = "SELECT COUNT(*) FROM GastosFijos WHERE IdTipoGasto=@IdTipoGasto ";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoGasto = IdTipoGasto });
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM GastosFijos WHERE IdTipoDeVencimiento=@IdTipoDeVencimiento ";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoDeVencimiento = IdTipoDeVencimiento });

                }
            }
            return cantidad;
        }

        public List<GastosFijosDto> GetGastosFijosCombo()
        {
            List<GastosFijosDto> lista = new List<GastosFijosDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdGastoFijo, Nombre, Vencimiento, MontoPagar, tg.TipoGasto, tv.TipoDeVencimiento 
                               FROM dbo.GastosFijos gf
                               INNER JOIN TiposGastos tg ON tg.IdTipoGasto = gf.IdTipoGasto
                               INNER JOIN TiposDeVencimientos tv ON tv.IdTipoDeVencimiento = gf.IdTipoDeVencimiento
                               ORDER BY Vencimiento DESC";
                lista = conn.Query<GastosFijosDto>(selectQuery).ToList();
            }
            return lista;
        }
    }
}
