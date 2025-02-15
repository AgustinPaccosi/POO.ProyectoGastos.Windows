using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
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
                    selectQuery = @"SELECT COUNT(*) FROM Gastos WHERE IdGasto = !@IdGasto 
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

        public List<GastosHogarDto> GetGastosHogar()
        {
            List<GastosHogarDto> lista=new List<GastosHogarDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"	Select IdGasto, CAST(g.fecha AS DATE) AS Fecha, g.Valor, tg.TipoGasto, CONCAT(P.Nombre, ' ', P.Apellido) AS Persona, G.Detalle from Gastos G
	                Inner Join TiposGastos TG on tg.IdTipoGasto=G.IdTipoGasto
	                Inner Join Personas P on P.IdPersona=G.IdPersona
                    Order By Fecha desc";
                lista = conn.Query<GastosHogarDto>(selectquery).ToList();
            }
            return lista;

        }

    }
}
