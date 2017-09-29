using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class BuchungController : Controller
    {
        [HttpGet]
        public ActionResult Index(BuchungsIndexVM vm)
        {
            var kundeDaten = (BuchungsIndexVM)TempData["filter"];
            // neue ViewModel variable 
            var vmKundenListe = new BuchungsIndexVM();
            if (kundeDaten == null)
            {

                using (var db = new alpensternEntities2())
                {
                    //Daten aus der Datenbank holen
                    var dbKundenListe = db.Gast.ToList();

                    // Daten aus der DB in den ViewModel eintragen und in die vmKundenListe speichern
                    foreach (var e in dbKundenListe)
                    {
                        var buchungIndexVM = new BuchungsIndexVM();
                        buchungIndexVM.id = e.id;
                        buchungIndexVM.nachname = e.nachname;
                        buchungIndexVM.vorname = e.vorname;
                        buchungIndexVM.gebdatum = e.geburtsdatum;
                        vmKundenListe.Liste.Add(buchungIndexVM);
                    }
                    return View(vmKundenListe);
                }
            }
            else
            {
                return View(@kundeDaten);
            }
        }

        [HttpPost]
        public ActionResult Index(string vorname, string nachname, DateTime? gebdatum, Models.BuchungsIndexVM vm)
        {

            using (var db = new alpensternEntities2())
            //using (var db = new alpenstern_finalEntities())
            //using (var db = new alpenstern_HeimEntities())
            {
                var vmKundenListe = new BuchungsIndexVM();
                var dbKundenListe = db.Gast.ToList();


                // Abfragen ob Vorname/Nachname/gebdatum leer ist
                if (vorname != null && vorname != "")
                {
                    dbKundenListe = dbKundenListe.Where(v => v.vorname == vorname).ToList();
                }
                else if (nachname != null && nachname != "")
                {
                    dbKundenListe = dbKundenListe.Where(v => v.nachname == nachname).ToList();
                }
                else if (gebdatum != null)
                {
                    dbKundenListe = dbKundenListe.Where(v => v.geburtsdatum == gebdatum).ToList();
                }

                foreach (var e in dbKundenListe)
                {
                    var buchungIndexVM = new BuchungsIndexVM();
                    buchungIndexVM.nachname = e.nachname;
                    buchungIndexVM.vorname = e.vorname;
                    buchungIndexVM.gebdatum = e.geburtsdatum;
                    buchungIndexVM.id = e.id;
                    vmKundenListe.Liste.Add(buchungIndexVM);
                }

                var kundeDaten = vmKundenListe;

                TempData["filter"] = kundeDaten;
                if (vm.radioAuswahl == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Persoenlichdaten", "Buchung", vm);
                }
            }
        }

        [HttpGet]
        public ActionResult Persoenlichdaten(BuchungsIndexVM vm, GastAnfrageDetailsVM gad)
        {
            var kundeMV = new PersoenDatenVM();
            using (var db = new alpensternEntities2())
            {    
                kundeMV.stadt = gad.Stadt;
                kundeMV.land = gad.Land;
                kundeMV.groesse = gad.groeZimm;
                kundeMV.bezeichnung = gad.KategorieBez;
                kundeMV.preis = gad.preisProNacht;
                kundeMV.personenAnzahl =gad.personenAnzahl;
                kundeMV.zimmerNummer = gad.zimmerNummer;
                kundeMV.vorname = gad.vorname;
                kundeMV.nachname = gad.nachname;
                kundeMV.reisePassNr = gad.reisepassnummer;
                kundeMV.strasse = gad.straße;
                kundeMV.gebDatum = gad.geburtsdatum;
                kundeMV.email = gad.email;
                kundeMV.plz =gad.plz;
                kundeMV.telefonNr = gad.telefonnummer;
               
                return View(kundeMV);
            }
        }

        [HttpPost]
        public ActionResult Persoenlichdaten(PersoenDatenVM vm, BuchungsIndexVM bVm)
        {
            using (var db = new alpensternEntities2())
            {
                vm.id = bVm.radioAuswahl;
                foreach (var user in db.Gast)
                {
                    if (user.id == vm.id)
                    {
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        var editUser = db.Entry(user).Entity;
                        editUser.vorname = vm.vorname;
                        editUser.nachname = vm.nachname;
                        editUser.reisepassnummer = vm.reisePassNr;
                        editUser.straße = vm.strasse;
                        editUser.geburtsdatum = vm.gebDatum;
                        editUser.email = vm.email;
                        editUser.telefonnummer = vm.telefonNr;
                        user.stadt_id = user.stadt_id;
                    }
                }
                db.SaveChanges();
                TempData["filter"] = null;
                return View();
            }
        }
    }
   }