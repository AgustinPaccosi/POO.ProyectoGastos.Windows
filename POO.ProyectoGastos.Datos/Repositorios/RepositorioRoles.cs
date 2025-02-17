using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioRoles : IRepositorioRoles
    {
        private readonly string cadenaConexion;

        public RepositorioRoles()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public List<ComboRolDto> GetRoles()
        {
            List<ComboRolDto> lista = new List<ComboRolDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdRol, Rol FROM Roles";
                lista = conn.Query<ComboRolDto>(SelectQuery).ToList();
            }
            return lista;

        }
        public ComboRolDto GetRolPorId(int IdRol)
        {
            ComboRolDto dato = new ComboRolDto();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdRol, Rol FROM Roles where IdRol=@IdRol";
                dato = conn.QuerySingleOrDefault<ComboRolDto>(SelectQuery, new {IdRol=IdRol });
            }
            return dato;

        }

    }
}
