﻿using Dapper;
using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Entidades.Dtos.Roles;
using POO.ProyectoGastos.Entidades.Dtos.TiposDeVencimiento;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Datos.Repositorios
{
    public class RepositorioTiposDeVencimientos: IRepositorioTiposDeVencimientos
    {
        private readonly string cadenaConexion;

        public RepositorioTiposDeVencimientos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public List<ComboTiposDeVencimientosDto> GetTiposDeVencimientos()
        {
            List<ComboTiposDeVencimientosDto> lista = new List<ComboTiposDeVencimientosDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdTipoDeVencimiento, TipoDeVencimiento FROM TiposDeVencimientos";
                lista = conn.Query<ComboTiposDeVencimientosDto>(SelectQuery).ToList();
            }
            return lista;
        }

        public ComboTiposDeVencimientosDto GetTiposDeVencimientosPorId(int IdTipoDeVencimiento)
        {
            ComboTiposDeVencimientosDto dato = new ComboTiposDeVencimientosDto();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string SelectQuery = "SELECT IdTipoDeVencimiento, TipoDeVencimiento FROM TiposDeVencimientos Where IdTipoDeVencimiento=@IdTipoDeVencimiento";
                dato = conn.QuerySingleOrDefault<ComboTiposDeVencimientosDto>(SelectQuery, new { IdTipoDeVencimiento = IdTipoDeVencimiento });
            }
            return dato;
        }

    }
}
