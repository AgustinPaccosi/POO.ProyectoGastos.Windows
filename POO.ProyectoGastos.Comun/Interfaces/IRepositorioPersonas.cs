using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioPersonas
    {
        void Agregar(Persona persona);
        void Borrar(int idPersona);
        void Editar(Persona presona);
        bool Existe(Persona persona);
        List<Persona> GetPersonas();
        Persona GetPersonaPorId(int idPersona);
        List<ComboPersonasDto> GetComboPersonasDtos();


    }
}
