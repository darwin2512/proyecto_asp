using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models;

namespace SistemaVentas.Controllers.Usuario.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class authorizeUser : AuthorizeAttribute
    {
        private usuario oUsuario;
        private dbVentasEntities db = new dbVentasEntities();
        private int idOperacion;

        public authorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                oUsuario = (usuario)HttpContext.Current.Session["user"];
                var lstMisOperaciones = from m in db.rol_operacion
                                        where m.id_rol == oUsuario.id_rol
                                        && m.id_operacion == idOperacion
                                        select m;

                if (lstMisOperaciones.ToList().Count() < 1)
                {
                    var oOperacion = db.operacion.Find(idOperacion);
                    int? idModulo = oOperacion.id_modulo;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreDelModulo(idModulo);
                    //nombremodulo = nombremodulo.replace("", "+");
                    //nombreoperacion = nombreoperacion.replace(" ", "+");
                    filterContext.Result = new RedirectResult("~/Error/UnAuthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnAuthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=" + ex.Message);
            }

        }
        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.operacion
                      where op.id == idOperacion
                      select op.nombre;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }
        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.modulo
                         where m.id == idModulo
                         select m.nombre;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
    }
}