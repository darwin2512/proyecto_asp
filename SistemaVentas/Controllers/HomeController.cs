using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Models.ViewModels;
using SistemaVentas.Models.UsuarioModels;
using SistemaVentas.Models.CajaModels;

namespace SistemaVentas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                          return View();
        }
    }
}