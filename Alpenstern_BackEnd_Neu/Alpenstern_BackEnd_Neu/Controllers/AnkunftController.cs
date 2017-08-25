using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class AnkunftController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new alpensternEntities())
            {
               
                
               


                //ankunft.nachname = kunde.nachname;
                //ankunft.vorname = kunde.vorname;
                //ankunft.email = kunde.email;
                //ankunft.geburtsdatum = kunde.geburtsdatum;
                //ankunft.zimmernummer = zimmernummer.zimmerNummer;


                return View();
            }


        }
    }
}