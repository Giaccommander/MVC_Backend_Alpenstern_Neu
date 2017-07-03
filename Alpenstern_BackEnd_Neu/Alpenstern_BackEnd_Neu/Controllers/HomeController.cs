using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ankunft()
        {
            ViewBag.Message = "Ankunft Übersicht";

            return View();
        }

        public ActionResult Rueckruf()
        {
            ViewBag.Message = "Rückruf Service";

            return View();
        }
    }
}