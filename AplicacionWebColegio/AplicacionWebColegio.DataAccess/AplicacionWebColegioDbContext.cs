using AplicacionWebColegio.Data.Models;
using AplicacionWebColegio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebColegio.DataAccess
{
    public class AplicacionWebColegioDbContext : DbContext
    {
        public AplicacionWebColegioDbContext() 
            : base("AplicacionWebColegio") {

                this.Configuration.LazyLoadingEnabled = false;
        
        }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Seccion> Secciones { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<EstudianteSeccion> EstudiantesSeccion { get; set; }
    }
}
