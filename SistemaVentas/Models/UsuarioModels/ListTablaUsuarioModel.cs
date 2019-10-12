using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.UsuarioModels
{
    public class ListTablaUsuarioModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Pass { get; set; }

        public int? Id_rol { get; set; }

        public string Nombre_rol { get; set; }
    }
}