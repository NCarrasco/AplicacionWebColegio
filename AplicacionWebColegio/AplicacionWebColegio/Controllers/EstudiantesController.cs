using AplicacionWebColegio.ActionFilter;
using AplicacionWebColegio.Data.Models;
using AplicacionWebColegio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWebColegio.Controllers
{
    public class EstudiantesController : BaseController
    {
        //Esto se genera de forma automatica si no definimos un constructor -
        public EstudiantesController()
            : base()
        {

        }

        // GET: Estudiantes
        public ActionResult Index(string q = null)
        {
            IEnumerable<Estudiante> estudiantes;

            if (String.IsNullOrEmpty(q))
                estudiantes = dbContext.Estudiantes;
            else
                estudiantes = dbContext.Estudiantes.Where(e =>
                    e.Nombres.Contains(q) ||
                    e.Apellidos.Contains(q) ||
                    e.Matricula == q);


            return View(estudiantes);
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
            estudiante.FechaMatriculacion = DateTime.Today;
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
                estudiante.FechaMatriculacion = DateTime.Today;


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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var estudiante = dbContext.Estudiantes
                .FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
                return HttpNotFound();

            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.Id = id;

                dbContext.Estudiantes.Attach(estudiante);
                dbContext.Entry(estudiante).State = EntityState.Modified;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            var estudiante = dbContext.Estudiantes
                .FirstOrDefault(e => e.Id == id);

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (estudiante == null)
                return HttpNotFound();

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var estudiante = dbContext.Estudiantes
                .FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
                return HttpNotFound();

            dbContext.Estudiantes.Remove(estudiante);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Inscribir(int id)
        {
            var estudiante = dbContext.Estudiantes
                .FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
                return HttpNotFound();

            var model = new InscripcionEstudianteVM();

            model.Estudiante = estudiante;

            CompletarDatosModeloInscripcion(model);

            model.Secciones = new List<EstudianteSeccion>()
            {
                new EstudianteSeccion(),
                new EstudianteSeccion(),
                new EstudianteSeccion()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Inscribir(int id, InscripcionEstudianteVM model)
        {
            if (ModelState.IsValid)
            {
                foreach (var estudianteSeccion in model.Secciones)
                {
                    estudianteSeccion.EstudianteId = id;
                    estudianteSeccion.Calificacion = 0;
                    estudianteSeccion.Estado = EstadoEstudiante.Activo;
                    estudianteSeccion.FechaInscripcion = DateTime.Now;

                    dbContext.EstudiantesSeccion.Add(estudianteSeccion);
                }

                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            CompletarDatosModeloInscripcion(model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Inscripcion(int id)
        {
            var estudiante = dbContext.Estudiantes.Find(id);

            var secciones = dbContext.EstudiantesSeccion
                .Where(e => e.EstudianteId == id)
                .Include("Seccion.Materia")
                .Include("Seccion.Profesor")
                .ToList();

            if (secciones.Count == 0)
                return RedirectToAction("Inscribir", new { id = id });

            var model = new InscripcionEstudianteVM();

            model.Estudiante = estudiante;
            model.Secciones = secciones.ToList();

            return View(model);
        }

        private void CompletarDatosModeloInscripcion(InscripcionEstudianteVM model)
        {
            var secciones = dbContext.Secciones
                .Include("Profesor")
                .Where(s => s.Activa);

            model.ListaSecciones = secciones
                .ToList()
                .Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = string.Concat(
                        s.Nombre,
                        " - ",
                        s.Ubicacion,
                        " con el prof. ",
                        s.Profesor.Nombres,
                        " ",
                        s.Profesor.Apellidos)
                });
        }
    }
}