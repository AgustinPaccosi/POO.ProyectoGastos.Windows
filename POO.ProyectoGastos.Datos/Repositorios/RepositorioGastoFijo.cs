using Dapper;
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
                string insertQuery = @"INSERT INTO dbo.GastosFijos (Nombre, Vencimiento, 
                    MontoPagar, IdTipoGasto, IdTipoDeVencimiento)  
                    VALUES (@Nombre, @Vencimiento, @MontoPagar, 
                    @IdTipoGasto, @IdTipoDeVencimiento); 
                    SELECT SCOPE_IDENTITY();";

                int id = conn.QuerySingle<int>(insertQuery, gastoFijo);
                gastoFijo.IdGastoFijo = id;

            }
        }

        public void Borrar(int IdGasto)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM GastosFijos WHERE IdGastoFijo=@IdGastoFijo";
                conn.Execute(deleteQuery, new { IdGasto = IdGasto });
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

        public GastosFijos GetGastoFijoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<GastosFijosDto> GetGastosFijos()
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
