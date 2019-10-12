using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers.Usuario
{
    public class ErrorController : Controller
    {

        [HttpGet]
        // GET: Error
        public ActionResult UnAuthorizedOperation(string operacion, string modulo, string msjErrorExcepcion)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msjErrorExcepcion = msjErrorExcepcion;
            return View();
        }
    }
}