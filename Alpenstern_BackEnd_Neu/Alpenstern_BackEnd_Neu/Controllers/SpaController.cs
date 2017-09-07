using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using System.Net;
using System.Data.Entity;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class SpaController : Controller
    {
        //Raum 508
        private alpenstern_finalEntities db = new alpenstern_finalEntities();

        //AKT-THOR
        //private alpensternEntities_Neu db = new alpensternEntities_Neu();


        // GET: Spa
        public ActionResult Index()
        {
            using (var db = new alpenstern_finalEntities())
            {
                var dbSpa = db.Spa.ToList();

                var spa = new List<Spa>();

                foreach (var x in dbSpa)
                {
                    var vmSpa = new Spa();

                    vmSpa.id = x.id;
                    vmSpa.bezeichnung = x.bezeichnung;
                    vmSpa.preis = x.preis;
                    vmSpa.einheit = x.einheit;

                    spa.Add(vmSpa);
                }
                return View(spa);
            }            
        }

        [HttpGet]
        public ActionResult spaNeu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult spaNeu(Spa spa)
        {
            var dbSpa = new Spa();
            //dbSpa.id = spa.id;
            dbSpa.bezeichnung = spa.bezeichnung;
            dbSpa.einheit = spa.einheit;
            dbSpa.preis = spa.preis;

            //Raum 508
            //using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            using (var db = new alpenstern_finalEntities())
            {
                db.Spa.Add(dbSpa);
                db.SaveChanges();
            }
            return RedirectToAction("Index", spa);
        }


        [HttpGet]
        public ActionResult spaBearbeiten(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spa spa = db.Spa.Find(id);
            if (spa == null)
            {
                return HttpNotFound();
            }
            return View(spa);
        }

        [HttpPost]
        public ActionResult spaBearbeiten(Spa x)
        {
            //Raum 508
            using (var db = new alpenstern_finalEntities())

            //AKT_THOR
            //using (var db = new alpensternEntities_Neu())
            {                
                var rueckruf = db.Rueckruf.Find(x.id);               
              
                db.Entry(x).State = EntityState.Modified;
               
                db.SaveChanges();
            }
            return RedirectToAction("Index");            
        }

        public ActionResult spaLoeschen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spa spa = db.Spa.Find(id);
            if (spa == null)
            {
                return HttpNotFound();
            }
            return View(spa);         
        }
       
        [HttpPost, ActionName("spaLoeschen")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spa spa = db.Spa.Find(id);
            db.Spa.Remove(spa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}