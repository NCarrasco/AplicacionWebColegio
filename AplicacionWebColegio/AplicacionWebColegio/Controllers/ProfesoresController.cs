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
    public class ProfesoresController : BaseController
    {
        //private AplicacionWebColegioDbContext dbContext = new AplicacionWebColegioDbContext();

        // GET: Profesores
        public ActionResult Index()
        {
            var estudiante = dbContext.Profesores.ToList();
            return View(estudiante);
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = dbContext.Profesores.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            var profesor = new Profesor();
            profesor.FechaNacimiento = DateTime.Now.AddYears(-18);
            profesor.FechaRegistro = DateTime.Now;

            profesor.Activo = true;
            return View(profesor);
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Observaciones,Activo,FechaRegistro,Nombres,Apellidos,FechaNacimiento")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                profesor.FechaRegistro = DateTime.Now;

                dbContext.Profesores.Add(profesor);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesor);
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = dbContext.Profesores.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Observaciones,Activo,FechaRegistro,Nombres,Apellidos,FechaNacimiento")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(profesor).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesor);
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = dbContext.Profesores.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesor profesor = dbContext.Profesores.Find(id);
            dbContext.Profesores.Remove(profesor);
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
