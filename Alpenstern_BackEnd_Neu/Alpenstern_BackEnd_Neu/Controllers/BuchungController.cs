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
        // GET: Buchung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Persoenlichdaten()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DatumEingabe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DatumEingabe(BuchungVM buchung)
        {
            //buchung.gastEmail = User.Identity.Name; //Eigentlich so

            //Das funktioniert nur im Frontend
            //using (var db = new alpensternEntities())
            //{
            //    var dbGast = db.Gast.Where(g => g.email == buchung.gastEmail).FirstOrDefault();
            //    buchung.gastId = dbGast.id;
            //}

            buchung.gastEmail = "test@test.com"; //Zum Testen
            buchung.gastId = 0; //Zum Testen

            //TempData["Buchung"] = buchung;

            Session["Buchung"] = buchung;

            Session["DatumBuchung"] = DateTime.Now;

            Session["randomZahl"] = 42;

            return RedirectToAction("KategorieWahl");
        }

        [HttpGet]
        public ActionResult KategorieWahl()
        {
            // 1. Ausgewaehltes Datum mittels Prozedur pruefen
            // 2. Verfuegbare Kategorien laden
            // 3. Neue Seite anzeigen

            //BuchungVM buchung = (BuchungVM) TempData["Buchung"];

            BuchungVM buchung = (BuchungVM) Session["Buchung"];

            //Verfuegbare Kategorien aus DB holen
            buchung.verfuegbareKategorien = new Dictionary<int, int>();
            buchung.verfuegbareKategorien[1] = 5; //normalerweise kommt der Wert aus der DB!
            buchung.verfuegbareKategorien[2] = 3; //normalerweise kommt der Wert aus der DB!
            buchung.verfuegbareKategorien[4] = 1; //normalerweise kommt der Wert aus der DB!

            return View(buchung);
        }
    }
}