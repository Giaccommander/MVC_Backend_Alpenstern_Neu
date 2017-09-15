using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using System.Net;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class ZimmerController : Controller
    {
        public alpensternEntities db = new alpensternEntities();

        // GET: Zimmer
        public ActionResult Index()
        {
            var dbkat = db.Kategorie.ToList();
            var dbkatAus = db.Kategorieausstattung.ToList();
            var dbAus = db.Ausstattung.ToList();
            var dbZim = db.Zimmer.ToList();

            var dbZimmer = new List<zimmerVM>();

            foreach (var x in dbkat)
            {
                var katZimmer = x.Zimmer;

                var katKatAusst = x.Kategorieausstattung.ToList();

                string ausstBez = "";

                foreach (var a in katKatAusst)
                {
                    ausstBez += a.Ausstattung.bezeichnung + "\n";
                }
                
                foreach (var y in katZimmer)
                {

                    zimmerVM vmzimmer = new zimmerVM();
                    vmzimmer.katid = x.id;
                    vmzimmer.id = y.id;
                    vmzimmer.zimmerBezeichnung = x.bezeichnung;
                    vmzimmer.groesse = x.groesse;
                    vmzimmer.anzPersonen = x.personenAnzahl;
                    vmzimmer.preis = x.preis;
                    vmzimmer.ausstattungsBezeichnung = ausstBez;

                    vmzimmer.zimmerNummer = y.zimmerNummer;
                    dbZimmer.Add(vmzimmer);
                }         
            }
            return View(dbZimmer);
        }

        [HttpGet]
        public ActionResult bearbeiten(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Zimmer zimmer = db.Zimmer.Find(id);           

            var vmZimmer = new ZimmerBearbeitenVM();

            vmZimmer.katId = zimmer.kategorie_id;
            vmZimmer.zimId = zimmer.id;
            vmZimmer.zimmerNummer = zimmer.zimmerNummer;

            return View(vmZimmer);
        }

        [HttpPost]
        public ActionResult bearbeiten(int id)
        {
            return View();
        }
    }
}
