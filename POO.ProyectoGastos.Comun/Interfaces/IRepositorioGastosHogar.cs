﻿using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Comun.Interfaces
{
    public interface IRepositorioGastosHogar
    {
        void Agregar(GastoHogar gastoHogar);
        void Borrar(GastoHogar gastoHogar);
        //void Editar(DetalleFondoComun fondoPersona);
        bool Existe(GastoHogar gastoHogar);
        List<GastosHogarDto> GetGastosHogar();

    }
}
