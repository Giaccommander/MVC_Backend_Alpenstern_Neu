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

                    vmRueckruf.name = x.name;
                    vmRueckruf.telefon = x.telefon;
                    vmRueckruf.grund = x.grund;
                    vmRueckruf.datumWann = x.datum_erhalten;

                    rrVM.Add(vmRueckruf);
                }
                        
            return View(rrVM);
            }

        }

        public ActionResult RueckrufNeu()
        {
            return View();
        }

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
            return View();
        }
    }
}