using POO.ProyectoGastos.Comun.Interfaces;
using POO.ProyectoGastos.Datos.Repositorios;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Servicios
{
    public class ServiciosEmpresasNegocios : IServiciosEmpresasNegocios
    {
        private readonly IRepositorioEmpresasNegocios _repositorio;
        public ServiciosEmpresasNegocios()
        {
            _repositorio = new RepositorioEmpresasNegocios();
        }
        public void Borrar(int Idempresa)
        {
            try
            {
                _repositorio.Borrar(Idempresa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(EmpresaNegocio empresa)
        {
            try
            {
                return _repositorio.Existe(empresa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<EmpresaNegocio> GetEmpresasNegocios()
        {
            try
            {
                return _repositorio.GetEmpresasNegocios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(EmpresaNegocio empresa)
        {
            try
            {
                if (empresa.IdEmpNeg == 0)
                {
                    _repositorio.Agregar(empresa);
                }
                else
                {
                    _repositorio.Editar(empresa);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
