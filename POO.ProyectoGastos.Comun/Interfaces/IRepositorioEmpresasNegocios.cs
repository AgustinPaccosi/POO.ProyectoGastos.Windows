using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioEmpresasNegocios
    {
        void Agregar(EmpresaNegocio empresa);
        void Borrar(int IdEmpresa);
        void Editar(EmpresaNegocio empresa);
        bool Existe(EmpresaNegocio empresa);
        List<EmpresaNegocio> GetEmpresasNegocios();

    }
}
