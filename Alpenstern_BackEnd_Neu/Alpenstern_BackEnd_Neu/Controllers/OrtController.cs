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
    }
}