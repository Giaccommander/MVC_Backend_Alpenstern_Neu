using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;


namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class RueckrufController : Controller
    {
        private alpensternEntities_Neu db = new alpensternEntities_Neu();
        // GET: Rueckruf
        public ActionResult Index()
        {
            using (var db = new alpensternEntities_Neu())
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

        public ActionResult RueckrufNeu()
        {
            return View();
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
        public ActionResult rueckrufBearbeitet(RueckrufVM rr)
        {
            var dbrueckruf = new Rueckruf();

            dbrueckruf.name = rr.name;
            dbrueckruf.grund = rr.grund;
            dbrueckruf.telefon = rr.telefon;
            dbrueckruf.datum_erhalten = rr.datumWann;
            dbrueckruf.datum_erledigt = rr.datumErledigt;

            using (var db = new alpensternEntities_Neu())
            {
                db.Rueckruf.Add(dbrueckruf);
                db.SaveChanges();
            }

            return View();
        }
    }
}