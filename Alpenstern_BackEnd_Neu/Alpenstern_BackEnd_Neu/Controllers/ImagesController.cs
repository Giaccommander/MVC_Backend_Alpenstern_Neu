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
    public class ImagesController : Controller
    {
        private alpensternEntities db = new alpensternEntities();

        // GET: Images
        public ActionResult Index()
        {
            return View(db.Bilder.ToList());
        }

        // GET: Images/Details/5
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

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bilderart,pfad")] Bilder bilder)
        {
            if (ModelState.IsValid)
            {
                db.Bilder.Add(bilder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilder);
        }

        // GET: Images/Edit/5
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

        // POST: Images/Edit/5
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

        // GET: Images/Delete/5
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

        // POST: Images/Delete/5
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
