using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class DruckansichtController : Controller
    {
        // GET: Druckansicht
        public ActionResult Index(PersonDatenVM vm,buchungIndexVM bi)
        {
            // Datenbank verbindung
            using(var db = new alpensternEntities())
            {
                // neue variable vom ViewModel
                var vmd = new DruckansichtVM();
                // ViewModel befüllen vom PersonenDaten
                vmd.vorname = vm.vorname;



            }

            return View();
        }
    }
}