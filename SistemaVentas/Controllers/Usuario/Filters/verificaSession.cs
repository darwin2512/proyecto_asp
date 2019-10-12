using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers.Usuario.Filters
{
    public class verificaSession : ActionFilterAttribute
    {
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {

                base.OnActionExecuting(filterContext);
                oUsuario = (usuario)HttpContext.Current.Session["user"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is UsuarioController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Usuario/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
            }
        }
    }
}