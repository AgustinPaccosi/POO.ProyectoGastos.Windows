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
        void Agregar(EmpresasNegocios empresa);
        void Borrar(int IdEmpresa);
        void Editar(EmpresasNegocios empresa);
        bool Existe(EmpresasNegocios empresa);
        List<EmpresasNegocios> GetEmpresasNegocios();

    }
}
