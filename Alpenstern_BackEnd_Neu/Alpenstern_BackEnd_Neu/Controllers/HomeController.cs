using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            //Gast gast = new Gast();

            //gast.nachname = "Mustermann";
            //gast.vorname = "Max";

            //using (var datenbank = new alpensternEntities())
            //{
            //    var gast = datenbank.Gast.Find(1);

            //    //var zinr = gast.Anfrage.ToList()[0].Kategorieanfrage.ToList()[0]
            //    //    .Zimmerbuchung.ToList()[0].Zimmer.zimmerNummer;

            //    var gastVM = new GastVM();

            //    gastVM.Nachname = gast.nachname;
            //    gastVM.Vorname = gast.vorname;

            //    return View(gastVM);
            //}

            return View();
                
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginVM lvm)
        {

            //1. Existiert der Login? Wenn nicht, "return", wenn ja: 2
            //2. Mitarbeiter aus der DB holen
            //3. Salt an das eingegebene PW anhaengen
            //4. PW+Salt hashen 
            //5. Hashes vergleichen, Wenn gleich: 6, wenn ungleich: "return"
            
            //6. Authorisierung vornehmen


            using (var datenbank = new alpensternEntities())
            {
                var loginStrings = lvm.Login.Split('.');
                var vmVorname = loginStrings[0];
                var vmNachname = loginStrings[1];

                //1
                if (datenbank.Mitarbeiter.Any(n => n.nachname == vmNachname && n.vorname == vmVorname))
                {   //2
                    var dbMitarbeiter = datenbank.Mitarbeiter.Where((n => n.nachname == vmNachname && n.vorname == vmVorname)).FirstOrDefault();
                    //3
                    lvm.Passwort += dbMitarbeiter.salt;
                    //4
                    var eingegPWHash = Helper.Hashes.HashBerechnen(lvm.Passwort);
                    //5
                    if(eingegPWHash == dbMitarbeiter.passwort)
                    {
                        //6
                        var authTicket = new FormsAuthenticationTicket(
                            1,  //Ticketversion
                            lvm.Login, //Useridentifizierung
                            DateTime.Now, //Zeitpunkt der Erstellung
                            DateTime.Now.AddMinutes(30), //Wann das Ticket ablaeuft
                            false, //Persistentes Ticket?
                            "" //Userdata
                            );

                        var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                        System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                        return RedirectToAction("Ankunft");
                    }
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Ankunft()
        {
            ViewBag.Message = "Ankunft Übersicht";

            return View();
        }
        [Authorize]
        public ActionResult Rueckruf()
        {
            ViewBag.Message = "Rückruf Service";

            return View();
        }
    }
}