﻿using POO.ProyectoGastos.Entidades.Dtos;
using POO.ProyectoGastos.Entidades.Dtos.DatosTrjetasDto;
using POO.ProyectoGastos.Entidades.Dtos.FondoComunDto;
using POO.ProyectoGastos.Entidades.Dtos.FondosComunesPersonasDto;
using POO.ProyectoGastos.Entidades.Dtos.GastosHogar;
using POO.ProyectoGastos.Entidades.Entidades;
using POO.ProyectoGastos.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.ProyectoGastos.Windows.Helpers.GridHelper
{
    public static class GridHelper
    {
        //private ServiciosFondosComunes fondo= new ServiciosFondosComunes();
        static decimal valor;
        public static void MontoDeFondoComun(decimal Monto)
        {
            //var monto = Monto;
            //return monto;
            valor = Monto;
            
        }
        internal static void MostrarDatosEnGrilla<T>(DataGridView dgv, List<T> lista)
        {
            GridHelper.LimpiarGrilla(dgv);
            foreach (var obj in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgv);
                GridHelper.SetearFila(r, obj);
                GridHelper.AgregarFila(dgv, r);
            }
        }
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Persona persona:
                    r.Cells[0].Value=persona.Nombre;
                    r.Cells[1].Value = persona.Apellido;
                    r.Cells[2].Value = persona.Rol;
                    break;
                case EmpresaNegocio empresa:
                    r.Cells[0].Value = empresa.Nombre;
                    r.Cells[1].Value = $"{empresa.Direccion}, {empresa.Telefono}";
                    break;
                case DatosTarjetasDto datos:
                    r.Cells[0].Value = datos.NombreCompleto;
                    r.Cells[1].Value = datos.Numero;
                    break;
                case FondoComunDto fondo:
                    r.Cells[0].Value = fondo.Fecha.ToShortDateString();
                    r.Cells[1].Value = fondo.Fecha.ToString("MMMM").ToUpper();
                    r.Cells[2].Value = $" $ {valor}";
                    //r.Cells[2].Value = $" $ {fondo.RestoFinMes}";

                    break;
                case DetalleFondoComunDto detalle:
                    r.Cells[0].Value = detalle.FechaDeCreacion.ToString("MMMM").ToUpper();
                    r.Cells[1].Value = detalle.FechaDeAporte.ToShortDateString();
                    r.Cells[2].Value = detalle.NombreCompleto;
                    r.Cells[3].Value = $"$ {detalle.Monto}";
                    break;
                case GastosHogarDto gastosHogar:
                    r.Cells[0].Value = gastosHogar.TipoGasto;
                    r.Cells[1].Value = gastosHogar.Persona;
                    r.Cells[2].Value = gastosHogar.Fecha.ToShortDateString();
                    r.Cells[3].Value = $" $ {gastosHogar.Valor}";
                    r.Cells[4].Value = gastosHogar.Detalle != null ? gastosHogar.Detalle : "S/D";
                    r.Cells[5].Value = gastosHogar.IdGastoFijo == 0 ? "No" : "Si";
                    r.Cells[6].Value = gastosHogar.Pagado == false ? "No" : "Si";
                    r.Cells[7].Value = gastosHogar.FormaPago;
                    break;
                case GastosFijosDto gastoFijo:
                    r.Cells[0].Value = gastoFijo.Nombre;
                    r.Cells[1].Value = gastoFijo.TipoGasto;
                    //r.Cells[2].Value = $"El {gastoFijo.Vencimiento.Day} de cada mes";
                    //r.Cells[2].Value = gastoFijo.Vencimiento.ToShortDateString();
                    r.Cells[2].Value = $" $ {gastoFijo.MontoPagar}";
                    r.Cells[3].Value = gastoFijo.TipoDeVencimiento;
                    break;

            }
            r.Tag = obj;

        }
    }
}
