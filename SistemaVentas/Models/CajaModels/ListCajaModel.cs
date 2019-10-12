using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.CajaModels
{
    public class ListCajaModel
    {
        public int Id { get; set; }

        public decimal? Monto { get; set; }

        public DateTime? Fecha { get; set; }

        public TimeSpan Hora { get; set; }
    }
}