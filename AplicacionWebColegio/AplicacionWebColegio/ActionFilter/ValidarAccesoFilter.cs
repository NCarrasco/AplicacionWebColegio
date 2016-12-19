using AplicacionWebColegio.DataAccess;
using AplicacionWebColegio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWebColegio.ActionFilter
{
    public class ValidarAccesoFilter : ActionFilterAttribute
    {
        private readonly UsuarioNivel nivelMinimo;

        public ValidarAccesoFilter(UsuarioNivel nivel)
        {
            nivelMinimo = nivel;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var dbContext = new AplicacionWebColegioDbContext())
            {
                string usrConectado = filterContext.HttpContext.User.Identity.Name;

                var usuario = dbContext.Usuarios
                    .FirstOrDefault(u => u.NombreUsuario == usrConectado);

                if (usuario == null || usuario.Nivel > nivelMinimo)
                    filterContext.Result = new RedirectResult("http://www.google.com.do");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}