using AplicacionWebColegio.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWebColegio.Controllers
{
    /// <summary>
    /// En esta clase manejaremos los controller
    /// ademas sera de tipo abstracta para que el motor de MVC no lo vea como un Controlador
    /// si no que solo vamos a heredar desde aqui.
    /// </summary>
    public abstract class BaseController : Controller
    {

        //Creamos una instancia de nuestro contexto de datos, que sera de solo lectura.
        protected readonly AplicacionWebColegioDbContext dbContext;

        //Creamos un constructor de la clase
        public BaseController()
        {
            dbContext = new AplicacionWebColegioDbContext();
        }

        //Agregamos un metodo de tipo Disponse para poder liberar nuestra conexion.

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }

    }
}