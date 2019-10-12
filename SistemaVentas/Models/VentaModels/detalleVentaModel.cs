using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.VentaModels
{
    public class detalleVentaModel
    {
        public int Id { get; set; }

        public int Id_venta { get; set; }


        [DataType("decimal(18,2)")]
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public int Id_producto { get; set; }

    }
}