using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioGastosHogar: IRepositorioGastosHogar
    {
        private readonly string cadenaConexion;

        public RepositorioGastosHogar()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public void Agregar(GastoHogar gastoHogar)
        {
            //List<GastosHogarDto> lista = new List<GastosHogarDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Gastos(Fecha, Valor, IdTipoGasto, IdEmpNeg, IdPersona, IdFondoComun, 
                    IdGastoFijo, IdFormaPago, IdTarjeta, Detalle, Pagado)
                    VALUES(@Fecha, @Valor, @IdTipoGasto, @IdEmpNeg, @IdPersona, @IdFondoComun, 
                    @IdGastoFijo, @IdFormaPago, @IdTarjeta, @Detalle, @Pagado); SELECT SCOPE_IDENTITY();";
                
                int id = conn.QuerySingle<int>(insertQuery, gastoHogar);
                gastoHogar.IdGasto = id;


                //lista = conn.Query<GastosHogarDto>(selectquery).ToList();
            }
            //return lista;
        }

        public void Borrar(int IdGasto)
        {

            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM Gastos WHERE IdGasto=@IdGasto";
                conn.Execute(deleteQuery, new { IdGasto = IdGasto });
            }
        }


        public void Editar(GastoHogar gastoHogar)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Gastos SET Fecha = @Fecha, 
                Valor = @Valor, IdTipoGasto = @IdTipoGasto, IdEmpNeg = @IdEmpNeg, IdPersona = @IdPersona,
                IdFondoComun = @IdFondoComun, IdGastoFijo = @IdGastoFijo, IdFormaPago = @IdFormaPago, 
                IdTarjeta = @IdTarjeta, Detalle = @Detalle, Pagado = @Pagado 
                WHERE IdGasto=@IdGasto;";
                conn.Execute(updateQuery, gastoHogar);
            }
            
        }

        public bool Existe(GastoHogar gastoHogar)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (gastoHogar.IdGasto == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Gastos WHERE  
                        Fecha = @Fecha AND IdTipoGasto = @IdTipoGasto AND IdEmpNeg = @IdEmpNeg AND
                        IdPersona = @IdPersona AND IdFondoComun = @IdFondoComun AND IdGastoFijo = @IdGastoFijo 
                        AND IdFormaPago = @IdFormaPago AND IdTarjeta = @IdTarjeta;";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, gastoHogar);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Gastos WHERE IdGasto != @IdGasto 
                        AND Fecha = @Fecha AND IdTipoGasto = @IdTipoGasto AND IdEmpNeg = @IdEmpNeg AND
                        IdPersona = @IdPersona AND IdFondoComun = @IdFondoComun AND IdGastoFijo = @IdGastoFijo
                        AND IdFormaPago = @IdFormaPago AND IdTarjeta = @IdTarjeta; ";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, gastoHogar);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public GastoHogar GetGastoPorId(int IdGasto)
        {
            GastoHogar gasto = new GastoHogar();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"SELECT IdGasto, Fecha, Valor, IdTipoGasto, IdEmpNeg, IdPersona,
                    IdFondoComun, IdGastoFijo, IdFormaPago, IdTarjeta, Detalle, Pagado FROM Gastos
                    Where IdGasto=@IdGasto ";
                gasto = conn.QuerySingleOrDefault<GastoHogar>(selectquery, new { IdGasto = IdGasto });
            }
            return gasto;

        }

        public List<GastosHogarDto> GetGastosHogar(int? IdPersona,int? IdTipoGasto, DateTime? FechaInicio,DateTime? FechaFin, bool? Pagado, int? IdFormaPago )
        {
            List<GastosHogarDto> lista=new List<GastosHogarDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                StringBuilder selectQuery = new StringBuilder();

                selectQuery.AppendLine(@"	Select IdGasto, CAST(g.fecha AS DATE) AS Fecha, g.Valor, tg.TipoGasto, 
                    CONCAT(P.Nombre, ' ', P.Apellido) AS Persona, G.Detalle, IdGastoFijo, g.Pagado, fp.FormaPago from Gastos G
	                Inner Join TiposGastos TG on tg.IdTipoGasto=G.IdTipoGasto
	                Inner Join Personas P on P.IdPersona=G.IdPersona
                    Inner Join FormasPagos fp on fp.IdFormaPago=g.IdFormaPago");
                if (IdPersona != null || IdTipoGasto != null || FechaInicio!=null||FechaFin!=null||Pagado!=null||IdFormaPago!=null)
                //if (IdPersona != null || IdTipoGasto != null ||  Pagado != null || IdFormaPago != null)
                {
                    selectQuery.AppendLine(@"Where G.IdPersona=@IdPersona or g.IdTipoGasto=@IdTipoGasto
                        or g.Fecha between CONVERT(DATE, @FechaInicio) AND CONVERT(DATE, @FechaFin) or G.Pagado=@Pagado or g.IdFormaPago=@IdFormaPago ");
                }
                selectQuery.AppendLine("Order By Fecha desc");
                var parametros = new { IdPersona, IdTipoGasto, FechaInicio, FechaFin, Pagado, IdFormaPago };
                lista = conn.Query<GastosHogarDto>(selectQuery.ToString(), parametros).ToList();
            }
            return lista;

        }

        public decimal GetTotalGastosMes()
        {
            decimal total = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"Select IsNull(Sum(Convert(numeric, Valor)),0) from Gastos Where  
                    Fecha between DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AND GETDATE() ";
                total = conn.ExecuteScalar<decimal>(selectquery);
            }
            return total;

        }

        public decimal GetTotalGastosFondoComun()
        {
            decimal total = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"Select ISNULL(Sum(Convert(numeric, Valor)),0) from Gastos Where  IdFormaPago=1 AND
                    Fecha between DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AND GETDATE() ";
                total = conn.ExecuteScalar<decimal>(selectquery);
            }
            return total;

        }
        public decimal Diferencia(int IdFondoComun)
        {
            decimal total = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"SELECT 
                                 ( 
                           (SELECT ISNULL(SUM(CONVERT(NUMERIC, Monto)),0) 
                          FROM [Personas/FondosComunes]
                             WHERE IdFondoComun = @IdFondoComun)
                         - 
                            (SELECT ISNULL(SUM(CONVERT(NUMERIC, Valor)),0) 
                        FROM Gastos 
                         WHERE IdFormaPago = 1 
                           AND Fecha BETWEEN DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AND GETDATE())
                        ) AS Diferencia;";
                total = conn.QuerySingle<decimal>(selectquery, new { IdFondoComun= IdFondoComun } );
            }
            return total;

        }

    }
}
