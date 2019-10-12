using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Controllers.Usuario.Filters;
using SistemaVentas.Models;
using SistemaVentas.Models.UsuarioModels;

namespace SistemaVentas.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            try
            {
                using ( dbVentasEntities db = new dbVentasEntities())
                {
                    var oUser = (from d in db.usuario
                                 where d.email == user.Trim() && d.pass == pass.Trim()
                                 select d).FirstOrDefault();

                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrectos";
                        return View();
                    }

                    Session["user"] = oUser;
                }


                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }            
        }

        [authorizeUser(idOperacion: 1)]
        public ActionResult ListaUsuario()
        {
            List<ListTablaUsuarioModel> lst;

            using (dbVentasEntities bd = new dbVentasEntities())
            {

                lst = (from p in bd.usuario
                       select new ListTablaUsuarioModel
                       {
                           Id = p.id,
                           Nombre = p.nombre,
                           Email = p.email,
                           Pass = p.pass,
                           Id_rol = p.id_rol,
                          // Nombre_rol = bd.rol
                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult NuevoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(TablaUsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbVentasEntities bd = new dbVentasEntities())
                    {
                        var oUsuario = new usuario();
                        oUsuario.nombre = model.Nombre;
                        oUsuario.email= model.Email;
                        oUsuario.pass = model.Pass;
                        oUsuario.id_rol = model.Id_rol;
                        bd.usuario.Add(oUsuario);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Usuario/ListaUsuario");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult EliminarUsuario(int Id)
        {
            using (dbVentasEntities bd = new dbVentasEntities())
            {
                var oUsuario = bd.usuario.Find(Id);
                bd.usuario.Remove(oUsuario);
                bd.SaveChanges();
            }
            return Redirect("~/Usuario/ListaUsuario");
        }
    }
}