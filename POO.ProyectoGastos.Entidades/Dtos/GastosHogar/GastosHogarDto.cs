﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.ProyectoGastos.Entidades.Dtos.GastosHogar
{
    public class GastosHogarDto:ICloneable
    {
        public int IdGasto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public string TipoGasto { get; set; }
        public string Persona { get; set; }
        public string Detalle { get; set; }
        public int IdGastoFijo { get; set; }
        public bool Pagado { get; set; }
        public string FormaPago { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
