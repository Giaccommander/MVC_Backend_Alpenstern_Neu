using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class RueckrufController : Controller
    {
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
    }
}