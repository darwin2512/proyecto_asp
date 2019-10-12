using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models.VentaModels;
using SistemaVentas.Models.CajaModels;
using SistemaVentas.Models.ProductoModels;
using SistemaVentas.Models;



namespace SistemaVentas.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult Index()
        {
            List<ListTablaProductoModel> lstProducto = null;
            using (dbVentasEntities db = new dbVentasEntities())
            {
                lstProducto =
                     (from d in db.producto
                      select new ListTablaProductoModel
                      {
                          Id = d.id,
                          Nombre = d.nombre,
                          Precio=d.precio
                      }).ToList();

            }

            List<SelectListItem> itemsProducto = lstProducto.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });


            ViewBag.itemsProducto = itemsProducto;

            return View();
        }

        [HttpPost]
        public ActionResult Index(TablaVentaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbVentasEntities bd = new dbVentasEntities())
                    {
                        var oVenta = new venta();
                        oVenta.id = model.Id;
                        oVenta.id_abrirCaja = model.Id_abrirCaja;
                        oVenta.total = model.Total;
                        oVenta.fecha = model.Fecha;
                        oVenta.nit = model.Nit;
                        oVenta.cliente = model.Cliente;
                        oVenta.direccion = model.Direccion;

                        bd.venta.Add(oVenta);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Venta/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Consultar(int Id)
        {
            TablaProductoModel model = new TablaProductoModel();
            using (dbVentasEntities bd = new dbVentasEntities())
            {
                var oVenta = bd.producto.Find(Id);
                model.Nombre = oVenta.nombre;
                model.Precio = oVenta.precio;
                model.Id = oVenta.id;

            }
            return View(model);
        }

    }
}