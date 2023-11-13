using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosEmpresasNegocios
    {
        void Guardar(EmpresaNegocio empresa);
        void Borrar(int Idempresa);
        bool Existe(EmpresaNegocio empresa);
        int GetCantidad();
        List<EmpresaNegocio> GetEmpresasNegocios();


    }
}
