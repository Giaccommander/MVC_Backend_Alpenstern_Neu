using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using System.Globalization;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class RueckrufController : Controller
    {
        //Raum 508
        private alpenstern_finalEntities db = new alpenstern_finalEntities();

        //AKT-THOR
        //private alpensternEntities_Neu db = new alpensternEntities_Neu();

        // GET: Rueckruf
        public ActionResult Index()
        {
            //Raum 508
            using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            //using (var db = new alpensternEntities_Neu())
            {
                var dbRueckruf = db.Rueckruf.ToList();
                var rrVM = new List<RueckrufVM>();

                foreach (var x in dbRueckruf)
                {
                    var vmRueckruf = new RueckrufVM();

                    vmRueckruf.id = x.id;
                    vmRueckruf.name = x.name;
                    vmRueckruf.telefon = x.telefon;
                    vmRueckruf.grund = x.grund;
                    vmRueckruf.datumWann = x.datum_erhalten;
                    vmRueckruf.datumErledigt = x.datum_erledigt;

                    rrVM.Add(vmRueckruf);
                }
                return View(rrVM);
            }
        }

        [HttpGet]   
        public ActionResult RueckrufNeu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RueckrufNeu(RueckrufVM rrVM)
        {                       
            var dbRueckruf = new Rueckruf();
           
            dbRueckruf.id = rrVM.id;
            dbRueckruf.name = rrVM.name;
            dbRueckruf.grund = rrVM.grund;
            dbRueckruf.datum_erhalten = DateTime.Now;
            dbRueckruf.telefon = rrVM.telefon;
            dbRueckruf.datum_erledigt = null;

            //Raum 508
            using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            //using (var db = new alpensternEntities_Neu())
            {
                db.Rueckruf.Add(dbRueckruf);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult rueckrufBearbeiten(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rueckruf rueckruf = db.Rueckruf.Find(id);
            if (rueckruf == null)
            {
                return HttpNotFound();
            }
            return View(rueckruf);
        }

        [HttpPost]
        public ActionResult rueckrufBearbeitet(Rueckruf rr)
        {

            //Raum 508
            using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            //using (var db = new alpensternEntities_Neu())
            {
                //erstellen einer Variable ... speichert den wert der gesuchten id 
                var rueckruf = db.Rueckruf.Find(rr.id);

                //erstelle ein neues Datum 
                rueckruf.datum_erledigt = DateTime.Now;

                //in der Datenbank besteht ein eintrag mit einen status
                //EntityState.Modified = Modifizier den Status mit der mitgegebenen Variable
                db.Entry(rueckruf).State = EntityState.Modified;

                //Datenbank änderungen abspeichern
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult rueckrufBearbeitetListe()
        {
            //Raum 508
            using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            //using (var db = new alpensternEntities_Neu())
            {
                var dbRueckruf = db.Rueckruf.ToList();
                var rrVM = new List<RueckrufVM>();

                foreach (var x in dbRueckruf)
                {
                    var vmRueckruf = new RueckrufVM();

                    vmRueckruf.id = x.id;
                    vmRueckruf.name = x.name;
                    vmRueckruf.telefon = x.telefon;
                    vmRueckruf.grund = x.grund;
                    vmRueckruf.datumWann = x.datum_erhalten;
                    vmRueckruf.datumErledigt = x.datum_erledigt;                    

                    rrVM.Add(vmRueckruf);
                }
                return View(rrVM);
            }
        }
    }
}