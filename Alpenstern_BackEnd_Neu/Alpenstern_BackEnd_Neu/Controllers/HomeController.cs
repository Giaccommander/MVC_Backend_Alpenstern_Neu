using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class HomeController : Controller
    {
        private alpensternEntities db = new alpensternEntities();

        public ActionResult Index(Mitarbeiter vorname,Mitarbeiter passwort )
        {
            List<Mitarbeiter> mitarbeiter = new List<Mitarbeiter>();

            return View(db.Login.ToList());
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