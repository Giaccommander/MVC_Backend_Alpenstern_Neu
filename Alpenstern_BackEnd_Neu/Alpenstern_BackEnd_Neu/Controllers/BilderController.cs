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
using System.IO;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class BilderController : Controller
    {
        private alpensternEntities db = new alpensternEntities();
        

        // GET: Bilder
        public ActionResult Index()
        {
            var vmListe = new List<BilderVM>();
            var dbBilderListe = db.Bilder.ToList();

            foreach (var b in dbBilderListe)
            {
                var vmbild = new BilderVM();

                vmbild.id = b.id;
                vmbild.bilderart = b.bilderart;
                vmbild.pfad = b.pfad;

                vmListe.Add(vmbild);
            }


            return View(vmListe);
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
        public ActionResult Create(BilderVM img, HttpPostedFileBase file)
        {
            var dbbilder = new Bilder();
            if (ModelState.IsValid && file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var destinationFullPath = Path.Combine(Server.MapPath("~/Content/images/Upload/"), fileName);

                file.SaveAs(destinationFullPath);

                
                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                dbbilder.bilderart = img.bilderart;
                dbbilder.pfad = "/Content/images/Upload/" + fileName;
                dbbilder.dbimage = data;


                db.Bilder.Add(dbbilder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(img);
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
        public ActionResult Edit([Bind(Include = "id,bilderart,pfad,dbimage")] Bilder bilder)
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
