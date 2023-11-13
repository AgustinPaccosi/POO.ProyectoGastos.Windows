using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosDatosTarjetas : IServiciosDatosTarjetas
    {
        private readonly IRepositorioDatosTarjetas _repositorioDatos;
        public ServiciosDatosTarjetas()
        {
            _repositorioDatos = new RepositorioDatosTarjetas();
        }
        public void Borrar(int IdTarjeta)
        {
            try
            {
                _repositorioDatos.Borrar(IdTarjeta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(DatoTarjeta datos)
        {
            try
            {
                return _repositorioDatos.Existe(datos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DatosTarjetasDto> GetDatos()
        {
            return _repositorioDatos.GetDatosTarjetas();
        }

        public void Guardar(DatoTarjeta datos)
        {
            try
            {
                _repositorioDatos.Agregar(datos);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
