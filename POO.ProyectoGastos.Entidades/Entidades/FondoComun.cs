﻿using System;

namespace POO.ProyectoGastos.Entidades.Entidades
{
    public class FondoComun
    {
        public int IdFondoComun { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public double RestoFinMes { get; set; }

        public string FechaTexto { get; set; }
    }
}
