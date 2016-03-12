using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioControlDeEquipos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GesAveria()
        {
                       return View();
        }

        public ActionResult ActAveria()
        {
            return View();
        }

        public ActionResult GesEquipo()
        {
            return View();
        }

        public ActionResult ConEquipo()
        {
            return View();
        }

    }
}
