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
    public class EstudiantesController : BaseController
    {

        // GET: Estudiantes
        public ActionResult Index()
        {
            var estudiante = dbContext.Estudiantes;
            return View(estudiante);
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = dbContext.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            var estudiante = new Estudiante();

            // Datos por defecto de la vista.
            estudiante.FechaNacimiento = DateTime.Now.AddYears(-18);
            estudiante.FechaMatriculacion = DateTime.Now;
            return View(estudiante);
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante estudiante)
        {

            bool estudianteExistente = dbContext.Estudiantes
                .Any(e => e.Matricula == estudiante.Matricula);

            if (estudianteExistente)
                ModelState.AddModelError("Matricula", "Ya existe un estudiante con esta matricula...");
            
            if (ModelState.IsValid)
            {
                estudiante.FechaMatriculacion = DateTime.Now;


                dbContext.Estudiantes.Add(estudiante);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = dbContext.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricula,Observaciones,FechaMatriculacion,Nombres,Apellidos,FechaNacimiento")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(estudiante).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = dbContext.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiante estudiante = dbContext.Estudiantes.Find(id);
            dbContext.Estudiantes.Remove(estudiante);
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
