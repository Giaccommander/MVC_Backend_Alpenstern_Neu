using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class RechnungController : Controller
    {
      
        // GET: Rechnung
        public ActionResult Index(DruckansichtVM vmd)
        {
            using (var db=new alpensternEntities())
            {
                var re = new RechnungVM();

                re.anzahlNaechte = vmd.anzahlNaechte;
                re.anzahlPersonen = vmd.anzahlPersonen;


            }
            return View(re);
        }
    }
}