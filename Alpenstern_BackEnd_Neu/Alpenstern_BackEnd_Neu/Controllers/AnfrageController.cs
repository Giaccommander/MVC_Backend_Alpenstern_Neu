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
    public class AnfrageController : Controller
    {
        //Raum 508
        //private alpensternEntities db = new alpensternEntities();

        private alpensternEntitiesHeim db = new alpensternEntitiesHeim();

        // GET: Anfrage
        public ActionResult Aufenthalt(AnfrageDatumVM anfrage)
        {
            //var anfrage = db.Anfrage.Include(a => a.Gast);
            //return View(anfrage.ToList());

            //Raum 508
                //using (var db = new alpensternEntities())

            //AKT_THOR
            //using (var db = new alpensternEntities_Neu())
            {

                var dbAnfrage = db.Anfrage.ToList();
                var dbGast = db.Gast.ToList();
                var dbZimmer = db.Zimmer.ToList();

                var dbAusgabe = new List<AnfrageDatumVM>();

                foreach (var x in dbAnfrage)
                {
                    var vmAnfrage = new AnfrageDatumVM();

                    //var xxxxx = new AnfrageDatumVM();

                    vmAnfrage.id = x.id;
                    vmAnfrage.gastId = x.gast_id;
                    vmAnfrage.datumVon = x.datumVon;
                    vmAnfrage.datumBis = x.datumBis;
                    vmAnfrage.datumAnfrage = x.datumAnfrage;

                    foreach (var y in dbGast)
                    {
                        //var vmGast = new AnfrageDatumVM();

                        ////vmAnfrage.gastId = y.id;

                        //if (vmAnfrage.gastId == y.id)
                        //{
                        vmAnfrage.vorname = y.vorname;
                        vmAnfrage.nachname = y.nachname;
                    }
                    foreach (var z in dbZimmer)
                    {
                        //var vmZimmer = new AnfrageDatumVM();

                        vmAnfrage.zimmerNummer = z.zimmerNummer;

                        //break;
                    }
                    //break;
                    dbAusgabe.Add(vmAnfrage);

                }

                //dbAusgabe.Add(xxxxx);
                return View(dbAusgabe);

            }

            //}
        }


    // GET: Anfrage/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Anfrage anfrage = db.Anfrage.Find(id);
        if (anfrage == null)
        {
            return HttpNotFound();
        }
        return View(anfrage);
    }

    // GET: Anfrage/Create
    public ActionResult Create()
    {
        ViewBag.gast_id = new SelectList(db.Gast, "id", "vorname");
        return View();
    }

    // POST: Anfrage/Create
    // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
    // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "id,gast_id,datumVon,datumBis,datumAnfrage,datumBearbeitet")] Anfrage anfrage)
    {
        if (ModelState.IsValid)
        {
            db.Anfrage.Add(anfrage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.gast_id = new SelectList(db.Gast, "id", "vorname", anfrage.gast_id);
        return View(anfrage);
    }

    // GET: Anfrage/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Anfrage anfrage = db.Anfrage.Find(id);
        if (anfrage == null)
        {
            return HttpNotFound();
        }
        ViewBag.gast_id = new SelectList(db.Gast, "id", "vorname", anfrage.gast_id);
        return View(anfrage);
    }

    // POST: Anfrage/Edit/5
    // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
    // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "id,gast_id,datumVon,datumBis,datumAnfrage,datumBearbeitet")] Anfrage anfrage)
    {
        if (ModelState.IsValid)
        {
            db.Entry(anfrage).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.gast_id = new SelectList(db.Gast, "id", "vorname", anfrage.gast_id);
        return View(anfrage);
    }

    // GET: Anfrage/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Anfrage anfrage = db.Anfrage.Find(id);
        if (anfrage == null)
        {
            return HttpNotFound();
        }
        return View(anfrage);
    }

    // POST: Anfrage/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Anfrage anfrage = db.Anfrage.Find(id);
        db.Anfrage.Remove(anfrage);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
}
