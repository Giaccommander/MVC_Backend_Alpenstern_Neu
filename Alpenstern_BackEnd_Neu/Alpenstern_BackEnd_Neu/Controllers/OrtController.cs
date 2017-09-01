using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class OrtController : Controller
    {
        [HttpGet]
        public ActionResult LandListe()
        {
            var landListe = new LandListeVM();

            using(var db = new alpensternEntities())
            {
                var dbListe = db.Land.ToList();

                foreach(var l in dbListe)
                {
                    var vmLand = new LandDetailsVM();

                    vmLand.Bezeichnung = l.bezeichnung;
                    vmLand.LandId = l.id;

                    foreach (var s in l.Stadt.ToList())
                    {
                        var vmStadt = new StadtVM();

                        vmStadt.Bezeichnung = s.bezeichnung;
                        vmStadt.StadtId = s.id;
                        vmStadt.PLZ = s.plz;

                        vmLand.StadtListe.Add(vmStadt);
                    }
                landListe.Liste.Add(vmLand);
                }     
            }

            return View(landListe);
        }

        [HttpGet]
        public ActionResult LandDetails(int id)
        {
            //View Model erzeugen
            var vmLandDetails = new LandDetailsVM();

            using(var db = new alpensternEntities())
            {
                //Entität aus DB laden
                var dbLand = db.Land.Find(id);

                //Properties der DB-Entität in das VM Mappen
                vmLandDetails.Bezeichnung = dbLand.bezeichnung;
                vmLandDetails.LandId = dbLand.id;

                //Da wir die Städteliste aus der DB (da sie eine DB-Entität ist)
                //nicht in unser ViewModel abspeichern können...
                var dbStadtListe = dbLand.Stadt.ToList();

                foreach(var stadt in dbStadtListe)
                {   //...erzeugen wir für jede DB Stadt
                    // eine VM Stadt und fügen diese
                    // unserem View Model (Land Details) hinzu.
                    var vmStadt = new StadtVM();
                    vmStadt.Bezeichnung = stadt.bezeichnung;
                    vmStadt.PLZ = stadt.plz;
                    vmStadt.StadtId = stadt.id;

                    vmLandDetails.StadtListe.Add(vmStadt);
                }
            }
            return View(vmLandDetails);
        }
    }
}