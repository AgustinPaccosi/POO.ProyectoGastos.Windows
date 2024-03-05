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
            throw new NotImplementedException();
        }

        public void Borrar(GastoHogar gastoHogar)
        {
            throw new NotImplementedException();
        }

        public bool Existe(GastoHogar gastoHogar)
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
	                Inner Join  Personas P on P.IdPersona=G.IdPersona
                    Order By Fecha desc";
                lista = conn.Query<GastosHogarDto>(selectquery).ToList();
            }
            return lista;

        }
    }
}
