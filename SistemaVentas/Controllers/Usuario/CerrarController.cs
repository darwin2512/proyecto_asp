using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers.Usuario
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult logoOff()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Usuario");
        }
    }
}