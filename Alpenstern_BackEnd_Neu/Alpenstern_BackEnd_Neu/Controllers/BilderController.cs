using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class BilderController : Controller
    {
        private alpensternEntities db = new alpensternEntities();

        // GET: Bilder
        public ActionResult Index()
        {


            return View(db.Bilder.ToList());
        }

        // GET: Bilder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilder bilder = db.Bilder.Find(id);
            if (bilder == null)
            {
                return HttpNotFound();
            }
            return View(bilder);
        }

        // GET: Bilder/Create
        public ActionResult Create()
        {
            var bildHinzufuegen = new BilderVM();


            return View();
        }

        // POST: Bilder/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bilderart,pfad")] Bilder bilder, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/Images/upload") + file.FileName);
                    bilder.pfad = file.FileName;
                    bilder.bilderart = bilder.bilderart;
                }
                db.Bilder.Add(bilder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilder);
        }

        // GET: Bilder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilder bilder = db.Bilder.Find(id);
            if (bilder == null)
            {
                return HttpNotFound();
            }
            return View(bilder);
        }

        // POST: Bilder/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bilderart,pfad")] Bilder bilder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilder);
        }

        // GET: Bilder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilder bilder = db.Bilder.Find(id);
            if (bilder == null)
            {
                return HttpNotFound();
            }
            return View(bilder);
        }

        // POST: Bilder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilder bilder = db.Bilder.Find(id);
            db.Bilder.Remove(bilder);
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
