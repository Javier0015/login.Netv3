using Crud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            using (dbModels context = new dbModels())
            {
				return View(context.Usuarios.ToList());
			}   
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            using (dbModels context = new dbModels())
            {
				return View(context.Usuarios.Where(x=>x.ID == id).FirstOrDefault());
			}
            
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuarios usuarios)
        {
            try
            {
                // TODO: Add insert logic here
                using(dbModels context = new dbModels())
                {
                    context.Usuarios.Add(usuarios);
                    context.SaveChanges();
				}
				return RedirectToAction("Index");
			}
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
			using (dbModels context = new dbModels())
			{
				return View(context.Usuarios.Where(x => x.ID == id).FirstOrDefault());
			}
		}

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuarios usuarios)
        {
            try
            {
				// TODO: Add update logic here
				using (dbModels context = new dbModels())
				{
					context.Entry(usuarios).State=EntityState.Modified;
                    context.SaveChanges();
				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
			using (dbModels context = new dbModels())
			{
				return View(context.Usuarios.Where(x => x.ID == id).FirstOrDefault());
			}
		}

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using(dbModels context = new dbModels())
                {
                    Usuarios usuario = context.Usuarios.Where(x => x.ID == id).FirstOrDefault();
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
