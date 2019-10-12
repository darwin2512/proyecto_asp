using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.VentaModels
{
    public class ListVentaModel
    {
        public int Id { get; set; }


        public int Id_abrirCaja { get; set; }


        public decimal Total { get; set; }


        public DateTime Fecha { get; set; }


        public int Nit { get; set; }


        public string Cliente { get; set; }

        public string Direccion { get; set; }
    }
}