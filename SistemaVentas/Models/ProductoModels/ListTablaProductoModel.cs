using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.ProductoModels
{
    /*ESTA CLASE NOS PERMITE OBTNER LOS DATOS DE LA TABLA PRODUCTOS Y TRAERLOS A NUESTRA TABLA DE PRODUCTOS*/
    public class ListTablaProductoModel
    {
        
            public int Id { get; set; }
            
            public string Codigo { get; set; }

            public string Nombre { get; set; }

            public decimal? Costo { get; set; }

            public decimal? Precio { get; set; }

            public int? Existencia { get; set; }

        //Se le asigno a fecha nacimiento un valor de tipo lista. para poder hacr la conversion
        
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha { get; set; }
        
            public string Ruta_img { get; set; }       
    }
}