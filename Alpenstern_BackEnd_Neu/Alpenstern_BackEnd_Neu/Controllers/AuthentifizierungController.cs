using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using Alpenstern_BackEnd_Neu.Helper;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class AuthentifizierungController : Controller
    {
        [HttpGet]
        public ActionResult MitarbeiterAnlegen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MitarbeiterAnlegen(MitarbeiterAnlegenVM maVM)
        {
            //Von ViewModel auf EntityModel mappen
            var dbMitarbeiter = new Mitarbeiter();

            dbMitarbeiter.nachname = maVM.Nachname;
            dbMitarbeiter.vorname = maVM.Vorname;
            dbMitarbeiter.passwort = maVM.Passwort;

            //Zusaetzliche Daten ins EntityModel hineinladen, Daten Aufbereiten, ...

            //Salt erzeugen
            var salt = Hashes.SaltErzeugen();

            //Salt in das EntiyModel speichern
            dbMitarbeiter.salt = salt;

            //Salt an das Klartextpasswort anhaengen
            dbMitarbeiter.passwort += salt;

            //PW Hashen
            dbMitarbeiter.passwort = Hashes.HashBerechnen(dbMitarbeiter.passwort);

            //Entitaet in der DB abspeichern
            using (var db = new alpensternEntities_Neu())
            {
                db.Mitarbeiter.Add(dbMitarbeiter);
                db.SaveChanges();
            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}