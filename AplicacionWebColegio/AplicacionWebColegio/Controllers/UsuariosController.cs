using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionWebColegio.Data.Models;
using AplicacionWebColegio.DataAccess;
using AplicacionWebColegio.ActionFilter;
using AplicacionWebColegio.Models;

namespace AplicacionWebColegio.Controllers
{
   [ValidarAccesoFilter(UsuarioNivel.Usuario)]
    public class UsuariosController : BaseController
    {
        //private AplicacionWebColegioDbContext dbContext = new AplicacionWebColegioDbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = dbContext.Usuarios.ToList();
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = dbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var usuario = new Usuario();
            usuario.Activo = true;
            return View(usuario);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreUsuario,Nivel,Activo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                dbContext.Usuarios.Add(usuario);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = dbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreUsuario,Nivel,Activo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(usuario).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = dbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = dbContext.Usuarios.Find(id);
            dbContext.Usuarios.Remove(usuario);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        dbContext.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
