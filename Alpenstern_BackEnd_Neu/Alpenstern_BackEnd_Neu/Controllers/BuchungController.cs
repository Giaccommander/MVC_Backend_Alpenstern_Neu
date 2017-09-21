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
                var dbZimmerbuchung = db.Zimmerbuchung;
                var dbAnfrage = db.Anfrage;
                var dbKatAnfrage = db.Kategorieanfrage;
                var dbKategorie = db.Kategorie;
                foreach (var k in dbkundedaten)
                {
                    if (k.id == vm.radioAuswahl)
                    {
                        var kundeMV = new PersonDatenVM();
                        var daten = (

                            from g in dbkundedaten
                            join s in dbOrt on g.stadt_id equals s.id
                            join l in dbLand on s.land_id equals l.id
                            join a in dbAnfrage on g.id equals a.gast_id
                            join kate in dbKatAnfrage on a.id equals kate.anfrage_id
                            join zb in dbZimmerbuchung on kate.id equals zb.kategorieanfrage_id
                            join zim in dbZimmer on zb.zimmer_id equals zim.id
                            join kat in db.Kategorie on zim.kategorie_id equals kat.id
                            where g.id == vm.radioAuswahl
                            select new {
                                g.id,
                                zim.zimmerNummer,
                                kat.bezeichnung,
                                kat.preis,
                                kat.personenAnzahl,
                                kat.groesse,
                                g.vorname,
                                g.nachname,
                                g.reisepassnummer,
                                g.straße,
                                g.geburtsdatum,
                                g.email,
                                g.telefonnummer
                            });

                        foreach (var ka in daten)
                        {
                            kundeMV.groesse = ka.groesse;
                            kundeMV.bezeichnung = ka.bezeichnung;
                            kundeMV.preis = ka.preis;
                            kundeMV.personenAnzahl = ka.personenAnzahl;
                            kundeMV.zimmerNummer = ka.zimmerNummer;
                            kundeMV.vorname = ka.vorname;
                            kundeMV.nachname = ka.nachname;
                            kundeMV.reisePassNr = ka.reisepassnummer;
                            kundeMV.strasse = ka.straße;
                            kundeMV.gebDatum = ka.geburtsdatum;
                            kundeMV.email = ka.email;
                            kundeMV.telefonNr = ka.telefonnummer;
                            foreach (var s in dbOrt)
                            {
                                if (k.stadt_id == s.id)
                                {
                                    kundeMV.ort = s.bezeichnung;
                                    kundeMV.plz = s.plz;

                                    foreach (var l in dbLand)
                                    {
                                        if (s.land_id == l.id)
                                        {
                                            kundeMV.land = l.bezeichnung;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }

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