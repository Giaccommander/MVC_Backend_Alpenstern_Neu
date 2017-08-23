using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class ZimmerController : Controller
    {
        // GET: Zimmer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult zimmerListe()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AusstattungAnlegen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AusstattungAnlegen(AusstattungAnlegenVM vm)
        {
            //DB-Entitaet erstellen (Tabelle)
            var dbAusstattung = new Ausstattung();

            //DB-Entitaet befuellen (mit Daten vom VM)
            dbAusstattung.bezeichnung = vm.Beschreibung;

            //Verbindung zur DB herstellen
            using (var db = new alpensternEntities())
            {
                db.Ausstattung.Add(dbAusstattung);
                db.SaveChanges();
            }

            return RedirectToAction("AusstattungListe");
        }

        [HttpGet]
        public ActionResult AusstattungListe()
        {
            //View Model Erzeugen
            var vm = new AusstattungListeAnzeigenVM();
            
            using(var db = new alpensternEntities())
            {   //Datensaetze aus DB holen
                var dbListe = db.Ausstattung.ToList();

                foreach(var e in dbListe) //Fuer jeden Datensatz
                {   //View Model Objekt anlegen
                    var ausstattung = new AusstattungVM();
                    //Werte mappen
                    ausstattung.Beschreibung = e.bezeichnung;
                    //View Model Objekt der View Model Liste hinzufuegen
                    vm.Liste.Add(ausstattung);
                }
            }
            //Nicht vergessen: Der View die Daten (=das Viewmodel) übergeben!
            return View(vm);
        }
    }
}