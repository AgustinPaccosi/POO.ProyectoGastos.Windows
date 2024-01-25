using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioFondosComunes : IRepositorioFondosComunes
    {
        private readonly string cadenaConexion;
        public RepositorioFondosComunes()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(FondoComun fondo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                
                string insertQuery = @"INSERT INTO FondosComunes (Fecha, Monto, RestoFinMes)
                        VALUES(@Fecha, @Monto, @RestoFinMes); 
                        SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, fondo);
                fondo.IdFondoComun = id;
            }
        }

        public void Borrar(int IdFondoComun)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM FondosComunes 
                     WHERE IdFondoComun=@IdFondoComun";
                conn.Execute(deleteQuery, new { IdFondoComun = IdFondoComun });
            }
        }

        public void Editar(FondoComun fondo)
        {
            throw new NotImplementedException();

        }

        public bool ExisteUltimoMes()
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM FondosComunes
                               WHERE MONTH(Fecha) = MONTH(GETDATE())";

                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad > 0;
        }
        public bool CreacionFondoAutomatico()
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                // Obtén el mes y año actuales
                DateTime fechaActual = DateTime.Now;

                // Crea el objeto FondoComun con los valores predeterminados
                var nuevoFondo = new FondoComun
                {
                    Fecha = fechaActual,
                    Monto = 0,  // Puedes ajustar este valor según tus necesidades
                    RestoFinMes = 0  // Puedes ajustar este valor según tus necesidades
                };

                // Inserta el nuevo fondo en la base de datos
                string insertQuery = @"INSERT INTO FondosComunes (Fecha, Monto, RestoFinMes)
                               VALUES(@Fecha, @Monto, @RestoFinMes); 
                               SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, nuevoFondo);
                nuevoFondo.IdFondoComun = id;
            }

            return true;  // Puedes ajustar el valor de retorno según tus necesidades
        }
        //public bool Existe(FondoComun fondo)
        //{
        //    var cantidad = 0;
        //    using (var conn = new SqlConnection(cadenaConexion))
        //    {
        //        string selectQuery;
        //        if (fondo.IdFondoComun == 0)
        //        {
        //            selectQuery = @"SELECT COUNT(*) FROM FondosComunes
        //                WHERE MONTH(Fecha) = MONTH(GETDATE())";
        //            cantidad = conn.ExecuteScalar<int>(selectQuery, fondo);
        //        }
        //        //else
        //        //{
        //        //    selectQuery = @"SELECT COUNT(*) FROM FondosComunes
        //        //        WHERE Fecha = @Fecha AND IdFondoComun!=@IdFondoComun";
        //        //    cantidad = conn.ExecuteScalar<int>(selectQuery,
        //        //            fondo);

        //        //}
        //    }
        //    return cantidad > 0;
        //}

        public List<FondoComunDto> GetFondoComunDtos()
        {
            List<FondoComunDto> lista = new List<FondoComunDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT IdFondoComun, Fecha, Monto, ISNULL(RestoFinMes, 0) AS RestoFinMes
                            FROM FondosComunes 
                            ORDER BY Fecha DESC";
                lista = conn.Query<FondoComunDto>(SelectQuery).ToList();
            }
            return lista;
        }
        //sELECT * FROM FondosComunes order by Fecha desc
        //        SELECT
        //    [IdFondoComun],
        //    [Fecha],
        //    [Monto],
        //    ISNULL([RestoFinMes], 0) AS RestoFinMes
        //FROM
        //    [dbo].[FondosComunes]
        //        ORDER BY
        //    [Fecha] DESC
        //GO

        public List<FondoComun> GetFondos()
        {
            throw new NotImplementedException();
        }
    }
}
