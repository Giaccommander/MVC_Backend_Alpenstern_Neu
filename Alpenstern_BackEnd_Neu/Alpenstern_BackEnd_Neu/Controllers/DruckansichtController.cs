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
        public ActionResult Index(PersonDatenVM vm,buchungIndexVM bi, AnfrageDatumVM anfrage, RechnungVM re)
        {
            // Datenbank verbindung
            using(var db = new masterEntities())
            {
                // neue variable vom ViewModel
                var vmd = new DruckansichtVM();
                // ViewModel befüllen vom PersonenDaten
                vmd.vorname = vm.vorname;
                vmd.nachname = vm.nachname;
                vmd.strasse = vm.strasse;
                vmd.plz = vm.plz;
                vmd.ort = vm.ort;
                vmd.id = vm.id;
                vmd.zimmerNummer = vm.zimmerNummer;
                vmd.datumVon=anfrage.datumVon;
                vmd.datumVon = anfrage.datumBis;
                
                return View(vmd);


            }

         
        }
    }
}