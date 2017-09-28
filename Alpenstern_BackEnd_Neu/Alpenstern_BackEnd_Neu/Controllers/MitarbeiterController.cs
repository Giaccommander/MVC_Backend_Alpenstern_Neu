using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using Alpenstern_BackEnd_Neu.Helper;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class MitarbeiterController : Controller
    {

        //AKT-THOR
        private masterEntities db = new masterEntities();

        // GET: Mitarbeiter
        public ActionResult Index()
        {
            return View(db.Mitarbeiter.ToList());
        }

        // GET: Mitarbeiter/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MitarbeiterAnlegenVM mitarbeiter)
        {
            //Von ViewModel auf EntityModel mappen
            var dbMitarbeiter = new Mitarbeiter();

            dbMitarbeiter.nachname = mitarbeiter.Nachname;
            dbMitarbeiter.vorname = mitarbeiter.Vorname;
            dbMitarbeiter.passwort = mitarbeiter.Passwort;

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

            //Raum 508
            //using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            using (var db = new masterEntities())
            {
                db.Mitarbeiter.Add(dbMitarbeiter);
                db.SaveChanges();
            }

            return RedirectToAction("Index",mitarbeiter);
        }

        // GET: Mitarbeiter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mitarbeiter mitarbeiter = db.Mitarbeiter.Find(id);
            if (mitarbeiter == null)
            {
                return HttpNotFound();
            }
            return View(mitarbeiter);
        }

        // POST: Mitarbeiter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mitarbeiter mitarbeiter = db.Mitarbeiter.Find(id);
            db.Mitarbeiter.Remove(mitarbeiter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
