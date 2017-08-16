using Alpenstern_BackEnd_Neu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel lvm)
        {

            using (var datenbank = new alpensternEntities())
            {
                if( datenbank.Login.Any(a => a.benutzername == lvm.Login))
                {
                    var dbLogin = datenbank.Login.Where(w => w.benutzername == lvm.Login).FirstOrDefault();
                    if (dbLogin.passwort == lvm.Passwort)
                    {
                        return RedirectToAction("Buchungen");
                    }
                }
            }
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