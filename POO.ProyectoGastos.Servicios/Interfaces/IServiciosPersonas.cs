using POO.ProyectoGastos.Entidades.Dtos.ComboPersonas;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Servicios.Interfaces
{
    public interface IServiciosPersonas
    {
        void Guardar(Persona persona);
        void Borrar(int idPersona);
        bool Existe(Persona persona);
        int GetCantidad();
        List<Persona> GetPersonas();
        List<ComboPersonasDto> GetComboPersonasDtos();
        Persona GetPersonaPorId(int id);

    }
}
