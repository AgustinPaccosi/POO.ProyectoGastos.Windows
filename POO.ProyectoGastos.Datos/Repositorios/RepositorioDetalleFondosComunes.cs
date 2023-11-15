using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioDetalleFondosComunes : IRepositorioDetalleFondosComunes
    {
        private readonly string cadenaConexion;

        public RepositorioDetalleFondosComunes()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(DetalleFondoComun fondoPersona)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int idFondoPersona)
        {
            throw new NotImplementedException();
        }

        public void Editar(DetalleFondoComun fondoPersona)
        {
            throw new NotImplementedException();
        }

        public bool Existe(DetalleFondoComun fondoPersona)
        {
            throw new NotImplementedException();
        }

        public List<DetalleFondoComunDto> GetFondoComunDtos()
        {
            List<DetalleFondoComunDto> lista = new List<DetalleFondoComunDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = @"Select Pf.IdFondoComun, Pf.IdPersona, 
                            CONCAT(p.Apellido, ', ', p.Nombre) As NombreCompleto, Pf.Monto, pf.Fecha 
                            from [Personas/FondosComunes] pf
                            Inner Join Personas P ON P.IdPersona=pf.IdPersona";
                lista = conn.Query<DetalleFondoComunDto>(SelectQuery).ToList();
            }
            return lista;
        }
    }
}
