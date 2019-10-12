using SistemaVentas.Models.CajaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Models.ViewModels;

namespace SistemaVentas.Controllers.caja
{
    public class cajaController : Controller
    {
        // GET: caja
        public ActionResult Index()
        {
            List<ListUsuarioViewModel> lst = null;
            using (dbVentasEntities db = new dbVentasEntities())
            {
                lst =
                     (from d in db.usuario
                      select new ListUsuarioViewModel
                      {
                          Id = d.id,
                          Nombre = d.nombre
                      }).ToList();

            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            return View();
        }

        [HttpPost]
        public ActionResult Index(addCajaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbVentasEntities db = new dbVentasEntities())
                    {
                        var oCaja = new abrir_caja();
                        oCaja.id = model.Id;                        
                        oCaja.monto = model.Monto;
                        oCaja.fecha = model.Fecha;
                        oCaja.hora = model.Hora;

                        db.abrir_caja.Add(oCaja);
                        db.SaveChanges();
                    }
                    return Redirect("~/Home/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}