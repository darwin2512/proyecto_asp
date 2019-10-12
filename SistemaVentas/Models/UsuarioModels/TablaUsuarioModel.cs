using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.UsuarioModels
{
    public class TablaUsuarioModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Pass")]
        public string Pass { get; set; }

 
        [Display(Name = "Id_rol")]
        public int Id_rol { get; set; }

    }
}