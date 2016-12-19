using AplicacionWebColegio.ActionFilter;
using AplicacionWebColegio.Models;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWebColegio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
