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
            List<GastosHogarDto> lista = new List<GastosHogarDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Gastos(Fecha, Valor, IdTipoGasto, IdEmpNeg, IdPersona, IdFondoComun, 
                    IdGastoFijo, IdFormaPago, IdDatosTarjeta, Detalle, Pagado)
                    VALUES(@Fecha, @Valor, @IdTipoGasto, @IdEmpNeg, @IdPersona, @IdFondoComun, 
                    @IdGastoFijo, @IdFormaPago, @IdDatosTarjeta, @Detalle, @Pagado); SELECT SCOPE_IDENTITY();";
                
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
                IdDatosTarjeta = @IdDatosTarjeta, Detalle = @Detalle, Pagado = @Pagado 
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
                        AND Fecha = @Fecha AND IdTipoGasto = @IdTipoGasto AND IdEmpNeg = @IdEmpNeg AND
                        IdPersona = @IdPersona AND IdFondoComun = @IdFondoComun AND IdGastoFijo = @IdGastoFijo 
                        AND IdFormaPago = @IdFormaPago AND IdDatosTarjeta = @IdDatosTarjeta;";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, gastoHogar);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Gastos WHERE IdGasto = !@IdGasto 
                        AND Fecha = @Fecha AND IdTipoGasto = @IdTipoGasto AND IdEmpNeg = @IdEmpNeg AND
                        IdPersona = @IdPersona AND IdFondoComun = @IdFondoComun AND IdGastoFijo = @IdGastoFijo
                        AND IdFormaPago = @IdFormaPago AND IdDatosTarjeta = @IdDatosTarjeta; ";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, gastoHogar);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<GastosHogarDto> GetGastosHogar()
        {
            List<GastosHogarDto> lista=new List<GastosHogarDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectquery = @"	Select CAST(g.fecha AS DATE) AS Fecha, g.Valor, tg.TipoGasto, CONCAT(P.Nombre, ' ', P.Apellido) AS Persona, G.Detalle from Gastos G
	                Inner Join TiposGastos TG on tg.IdTipoGasto=G.IdTipoGasto
	                Inner Join Personas P on P.IdPersona=G.IdPersona
                    Order By Fecha desc";
                lista = conn.Query<GastosHogarDto>(selectquery).ToList();
            }
            return lista;

        }
    }
}
