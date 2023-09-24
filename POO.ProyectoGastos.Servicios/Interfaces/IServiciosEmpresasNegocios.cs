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
        void Guardar(EmpresasNegocios empresa);
        void Borrar(int Idempresa);
        bool Existe(EmpresasNegocios empresa);
        int GetCantidad();
        List<EmpresasNegocios> GetEmpresasNegocios();


    }
}
