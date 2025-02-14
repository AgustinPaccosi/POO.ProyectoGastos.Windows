using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioFormasPago : IRepositorioFormasPagos
    {
        private readonly string cadenaConexion;
        public RepositorioFormasPago()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public List<FormasPagos> GetFormasPagos()
        {
            List<FormasPagos> lista = new List<FormasPagos>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdFormaPago, FormaPago FROM FormasPagos";
                lista = conn.Query<FormasPagos>(SelectQuery).ToList();
            }
            return lista;

        }
    }
}
