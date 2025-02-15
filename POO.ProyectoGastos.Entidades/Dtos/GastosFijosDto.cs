﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Dtos
{
    public class GastosFijosDto
    {
        public int IdGastoFijo { get; set; }
        public string Nombre { get; set; }
        public DateTime Vencimiento { get; set; }
        public double MontoPagar { get; set; }
        public string TipoGasto { get; set; }
        public String TipoDeVencimiento { get; set; }

    }
}
