using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class BuchungController : Controller
    {
        [HttpGet]
        public ActionResult Index(buchungIndexVM vm)
        {
            var kundeDaten = (buchungIndexVM)TempData["filter"];
            // neue ViewModel variable 
            var vmKundenListe = new buchungIndexVM();
            ViewBag.kD = kundeDaten;
            if (kundeDaten == null)
            {

                using (var db = new alpensternEntities())
                //using (var db = new alpenstern_finalEntities())
                //using (var db = new alpenstern_HeimEntities())
                {
                    //Daten aus der Datenbank holen
                    var dbKundenListe = db.Gast.ToList();

                    // Daten aus der DB in den ViewModel eintragen und in die vmKundenListe speichern
                    foreach (var e in dbKundenListe)
                    {
                        var buchungIndexVM = new buchungIndexVM();
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
        public ActionResult Index(string vorname, string nachname, DateTime? gebdatum, buchungIndexVM vm)
        {

            using (var db = new alpensternEntities())
            //using (var db = new alpenstern_finalEntities())
            //using (var db = new alpenstern_HeimEntities())
            {
                var vmKundenListe = new buchungIndexVM();
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
                    var buchungIndexVM = new buchungIndexVM();
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
        public ActionResult Persoenlichdaten(buchungIndexVM vm)
        {
            var Kunde = new PersonDatenVM();
            using (var db = new alpensternEntities())
            //using (var db = new alpenstern_finalEntities())
            //using (var db = new alpenstern_HeimEntities())
            {
                var dbkundedaten = db.Gast;
                var dbLand = db.Land;
                var dbOrt = db.Stadt;
                var dbZimmer = db.Zimmer;
                var dbkategorie = db.Kategorie;
                foreach (var k in dbkundedaten)
                {
                    if (k.id == vm.radioAuswahl)
                    {
                        var kundeMV = new PersonDatenVM();
                        kundeMV.id = vm.radioAuswahl;
                        kundeMV.vorname = k.vorname;
                        kundeMV.nachname = k.nachname;
                        kundeMV.reisePassNr = k.reisepassnummer;
                        kundeMV.strasse = k.straße;
                        kundeMV.gebDatum = k.geburtsdatum;
                        kundeMV.email = k.email;
                        kundeMV.telefonNr = k.telefonnummer;

                        foreach (var l in dbLand)
                        {
                            kundeMV.land = l.bezeichnung;
                        }
                        foreach (var s in dbOrt)
                        {
                            kundeMV.ort = s.bezeichnung;
                            kundeMV.plz = s.plz;
                        }
                        foreach (var ku in dbkategorie)
                        {
                            kundeMV.kategorieID = ku.id;
                            kundeMV.bezeichnung = ku.bezeichnung;
                            kundeMV.preis = ku.preis;
                            kundeMV.personenAnzahl = ku.personenAnzahl;
                            kundeMV.groesse = ku.groesse;
                        }
                        foreach (var z in dbZimmer)
                        {
                            kundeMV.zimmerID = z.id;
                            kundeMV.kategorieID = z.kategorie_id;
                            kundeMV.zimmerNummer = z.zimmerNummer;
                        }
                        Kunde = kundeMV;
                        break;
                    }
                }
            }
            return View(Kunde);
        }

        [HttpPost]
        public ActionResult Persoenlichdaten(PersonDatenVM vm, buchungIndexVM bVm)
        {
            using (var db = new alpensternEntities())
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
                return View();
            }
        }
    }
}