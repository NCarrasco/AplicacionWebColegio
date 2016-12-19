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

namespace AplicacionWebColegio.Controllers
{
    public class SeccionesController : BaseController
    {
        //private AplicacionWebColegioDbContext dbContext = new AplicacionWebColegioDbContext();

        // GET: Secciones
        public ActionResult Index()
        {
            var seccions = dbContext.Secciones.Include(s => s.Materia).Include(s => s.Profesor);
            return View(seccions.ToList());
        }

        // GET: Secciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = dbContext.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // GET: Secciones/Create
        public ActionResult Create()
        {

            ViewBag.MateriaId = new SelectList(dbContext.Materias, "Id", "Nombre");
            ViewBag.ProfesorId = new SelectList(dbContext.Profesores, "Id", "Nombres");

            var seccion = new Seccion();
            seccion.FechaRegistro = DateTime.Now;
            seccion.Activa = true;
            return View(seccion);
        }

        // POST: Secciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfesorId,MateriaId,Nombre,Ubicacion,MaximoEstudiantes,Activa,FechaRegistro,Observaciones")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                seccion.FechaRegistro = DateTime.Now;

                dbContext.Secciones.Add(seccion);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(dbContext.Materias, "Id", "Nombre", seccion.MateriaId);
            ViewBag.ProfesorId = new SelectList(dbContext.Profesores, "Id", "Nombres", seccion.ProfesorId);
            return View(seccion);
        }

        // GET: Secciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = dbContext.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(dbContext.Materias, "Id", "Nombre", seccion.MateriaId);
            ViewBag.ProfesorId = new SelectList(dbContext.Profesores, "Id", "Nombres", seccion.ProfesorId);
            return View(seccion);
        }

        // POST: Secciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfesorId,MateriaId,Nombre,Ubicacion,MaximoEstudiantes,Activa,FechaRegistro,Observaciones")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(seccion).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(dbContext.Materias, "Id", "Nombre", seccion.MateriaId);
            ViewBag.ProfesorId = new SelectList(dbContext.Profesores, "Id", "Nombres", seccion.ProfesorId);
            return View(seccion);
        }

        // GET: Secciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = dbContext.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // POST: Secciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seccion seccion = dbContext.Secciones.Find(id);
            dbContext.Secciones.Remove(seccion);
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
