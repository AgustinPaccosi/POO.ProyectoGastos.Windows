using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
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
    public class RepositorioEmpresasNegocios : IRepositorioEmpresasNegocios
    {
        private readonly string cadenaConexion;
        public RepositorioEmpresasNegocios()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(EmpresasNegocios empresa)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = "INSERT INTO EmpresasNegocios (Nombre, Direccion, Telefono) VALUES(@Nombre, @Direccion, @Telefono); SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, empresa);
                empresa.IdEmpNeg = id;
            }
        }

        public void Borrar(int IdEmpresa)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM EmpresasNegocios WHERE IdEmpNeg=@IdEmpNeg";
                conn.Execute(deleteQuery, new { IdEmpNeg = IdEmpresa });
            }
        }

        public void Editar(EmpresasNegocios empresa)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE EmpresasNegocios SET Nombre=@Nombre, Direccion=@Direccion, Telefono=@Telefono
                            WHERE IdEmpNeg=@IdEmpNeg";
                conn.Execute(updateQuery, empresa);
            }
        }

        public bool Existe(EmpresasNegocios empresa)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (empresa.IdEmpNeg == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM EmpresasNegocios
                        WHERE Nombre=@Nombre";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, empresa);
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Personas" +
                        " WHERE Nombre=@Nombre AND IdEmpNeg!=@IdEmpNeg";
                    cantidad = conn.ExecuteScalar<int>(selectQuery,
                            empresa);

                }
            }
            return cantidad > 0;
        }

        public List<EmpresasNegocios> GetEmpresasNegocios()
        {
            List<EmpresasNegocios> lista = new List<EmpresasNegocios>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"SELECT IdEmpNeg, Nombre, Direccion, Telefono
                            FROM EmpresasNegocios
                            ORDER BY Nombre";
                lista = conn.Query<EmpresasNegocios>(SelectQuery).ToList();
            }

            return lista;
        }
    }
}
