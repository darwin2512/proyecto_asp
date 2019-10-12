using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.CajaModels
{
    public class addCajaModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Monto")]
        [DataType("decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha{ get; set; }



        [Required]
        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Hora { get; set; }
    }
}