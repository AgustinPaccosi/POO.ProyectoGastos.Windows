using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
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
    public class RepositorioTiposGastos : IRepositorioTiposGastos
    {
        private readonly string cadenaConexion;
        public RepositorioTiposGastos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public ComboTiposGastosDto GetComboTiposGastosPorId(int IdTipoGasto)
        {
            throw new NotImplementedException();
        }

        public List<ComboTiposGastosDto> GetTiposGastos()
        {
            List<ComboTiposGastosDto> lista = new List<ComboTiposGastosDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdTipoGasto, TipoGasto FROM TiposGastos";
                lista = conn.Query<ComboTiposGastosDto>(SelectQuery).ToList();
            }
            return lista;

        }

        public ComboTiposGastosDto GetTiposGastosPorId(int IdTipoGasto)
        {
            ComboTiposGastosDto dato = new ComboTiposGastosDto();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdTipoGasto, TipoGasto FROM TiposGastos Where IdTipoGasto=@IdTipoGasto";
                dato = conn.QuerySingleOrDefault<ComboTiposGastosDto>(SelectQuery, new { IdTipoGasto= IdTipoGasto });
            }
            return dato;

        }

    }
}
