using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Models.ProductoModels;



namespace SistemaVentas.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaProductoModel> lst;
            using (dbVentasEntities bd = new dbVentasEntities())
            {
                lst = (from p in bd.producto
                       select new ListTablaProductoModel
                       {                           
                           Id = p.id,
                           Codigo = p.codigo,
                           Nombre = p.nombre,
                           Costo = p.costo,
                           Precio = p.precio,
                           Existencia = p.existencia,
                           Fecha = p.fecha
                       }).ToList();
            }
            return View(lst);
        }

        
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaProductoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbVentasEntities bd = new dbVentasEntities())
                    {
                        var oProducto = new producto();
                        oProducto.codigo = model.Codigo;
                        oProducto.nombre = model.Nombre;
                        oProducto.costo = model.Costo;
                        oProducto.precio = model.Precio;
                        oProducto.existencia = model.Existencia;
                        oProducto.fecha = model.Fecha;

                        /*AGREGAR UNA IMAGEN*/
                        
                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            string pictureName = Path.GetFileName(file.FileName);
                            if(pictureName != "")
                            {
                                string serverPath = Path.Combine(HttpContext.Server.MapPath("~/Content/img/productos"), pictureName);
                                string[] paths = serverPath.Split('.');
                                string time = DateTime.UtcNow.ToString();
                                time = time.Replace(" ", "_").Replace(":", "_").Replace(".", "").Replace("/", "_");
                                string url = paths[0] +"-" + time + Path.GetExtension(pictureName);
                                file.SaveAs(url);
                                oProducto.ruta_img = "~\\Content\\img\\productos\\" + Path.GetFileNameWithoutExtension(file.FileName) + "-" + time + Path.GetExtension(pictureName);
                            }
                        }

                        bd.producto.Add(oProducto);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaProductoModel model = new TablaProductoModel();
                using (dbVentasEntities bd = new dbVentasEntities())
            {
                var oProducto = bd.producto.Find(Id);

                model.Codigo = oProducto.codigo;
                model.Nombre = oProducto.nombre; 
                model.Costo = oProducto.costo;
                model.Precio = oProducto.precio;
                model.Existencia = oProducto.existencia;
                model.Fecha = oProducto.fecha;
                model.Id = oProducto.id;
                model.Ruta_img = oProducto.ruta_img;

            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(TablaProductoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbVentasEntities bd = new dbVentasEntities())
                    {
                        var oProducto = bd.producto.Find(model.Id);
                        oProducto.codigo = model.Codigo;
                        oProducto.nombre = model.Nombre;
                        oProducto.costo = model.Costo;
                        oProducto.precio = model.Precio;
                        oProducto.existencia = model.Existencia;
                        oProducto.fecha = model.Fecha;

                        /*AGREGAR UNA IMAGEN*/

                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[0];
                            string pictureName = Path.GetFileName(file.FileName);
                            if (pictureName != "")
                            {
                                string serverPath = Path.Combine(HttpContext.Server.MapPath("~/Content/img/productos"), pictureName);
                                string[] paths = serverPath.Split('.');
                                string time = DateTime.UtcNow.ToString();
                                time = time.Replace(" ", "_").Replace(":", "_").Replace(".", "").Replace("/", "_");
                                string url = paths[0] + "-" + time + Path.GetExtension(pictureName);
                                file.SaveAs(url);
                                oProducto.ruta_img = "~\\Content\\img\\productos\\" + Path.GetFileNameWithoutExtension(file.FileName) + "-" + time + Path.GetExtension(pictureName);
                            }
                        }

                        //actualizamos en la BD
                        bd.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (dbVentasEntities bd = new dbVentasEntities())
            {
                var oProducto = bd.producto.Find(Id);
                bd.producto.Remove(oProducto);
                bd.SaveChanges();
            }
            return Redirect("~/Tabla/");
        }
    }
} 