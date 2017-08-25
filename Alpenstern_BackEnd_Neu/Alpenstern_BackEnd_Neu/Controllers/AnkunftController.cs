using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class AnkunftController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new alpensternEntities())
            {

                var VMKundenListe = new List<AnkunftVM>();
                var dbKundenListe = db.Gast.ToList();
                var dbZimmerNummer = db.Zimmer.ToList();

                foreach (var k in dbKundenListe)
                {
                    var ankunftsListe = new AnkunftVM();
                    ankunftsListe.id = k.id;
                    ankunftsListe.nachname = k.nachname;
                    ankunftsListe.vorname = k.vorname;
                    ankunftsListe.geburtsdatum = k.geburtsdatum;
                    ankunftsListe.email = k.email;
                    foreach (var z in dbZimmerNummer)
                    {
                        ankunftsListe.zimmernummer = z.zimmerNummer;
                    }
                    VMKundenListe.Add(ankunftsListe);
                }


                return View(VMKundenListe);
            }


        }
    }
}