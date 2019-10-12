using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.VentaModels
{
    public class TablaVentaModel
    {
        public int Id { get; set; }

        
        public int Id_abrirCaja { get; set; }

        [DataType("decimal(18,2)")]
        public decimal Total { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }


        [Display(Name ="Nit")]
        public int Nit { get; set; }

        [Display(Name = "Cliente")]
        [StringLength(50)]
        public string Cliente { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string Direccion { get; set; }
    }
}
