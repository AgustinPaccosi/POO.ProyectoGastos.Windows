﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class DatosTarjetas
    {
        public int IdTarjeta { get; set; }
        public string Numero { get; set; }
        public Persona Persona { get; set; }

    }
}