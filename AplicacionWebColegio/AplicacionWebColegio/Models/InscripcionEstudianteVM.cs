using AplicacionWebColegio.Data.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AplicacionWebColegio.Models
{
    public class InscripcionEstudianteVM
    {
        public Estudiante Estudiante { get; set; }

        public List<EstudianteSeccion> Secciones { get; set; }

        public IEnumerable<SelectListItem> ListaSecciones { get; set; }

        public InscripcionEstudianteVM()
        {
            Secciones = new List<EstudianteSeccion>();
        }
    }
}