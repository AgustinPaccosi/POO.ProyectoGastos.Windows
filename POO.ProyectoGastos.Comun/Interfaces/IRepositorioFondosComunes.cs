using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Entidades;
using System.Collections.Generic;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioFondosComunes
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
