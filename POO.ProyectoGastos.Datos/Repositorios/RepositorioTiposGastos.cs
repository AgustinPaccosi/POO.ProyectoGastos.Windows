using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Entidades.Dtos.TipoGastos;
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
        public List<ComboTiposGastosDto> GetTiposGastos()
        {
            List<ComboTiposGastosDto> lista = new List<ComboTiposGastosDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdTiposGastos, TipoGasto FROM TiposGastos";
                lista = conn.Query<ComboTiposGastosDto>(SelectQuery).ToList();
            }
            return lista;

        }
    }
}
