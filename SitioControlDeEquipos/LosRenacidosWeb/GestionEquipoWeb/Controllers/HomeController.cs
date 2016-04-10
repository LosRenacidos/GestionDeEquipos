using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionEquipoWeb.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Gestión de Equipos de Cómputo";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
