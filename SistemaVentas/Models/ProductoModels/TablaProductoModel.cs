using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.ProductoModels
{
    /*ESTE MODELO  NOS PERMITE HACER VALIDACION Y LOS METODOS PARA OBTENER Y PONER VALORES EN LA BASE DE DATOS PARA LA
     TABLA PRODUCTOS*/
    public class TablaProductoModel
    {
        public int Id { get; set; }
        
       public decimal precio1 { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required]
        [Display(Name = "Costo")]
        [DataType("decimal(14,2")]
        public decimal? Costo { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DataType("decimal(14,2")]
        public decimal? Precio { get; set; }

        [Required]
        [Display(Name = "Existencia")]
        public int? Existencia { get; set; }

        //Se le asigno a fecha nacimiento un valor de tipo lista. para poder hacr la conversion
        
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }

        [Display(Name ="Direccion")]
        public string Ruta_img { get; set; }
    }
}