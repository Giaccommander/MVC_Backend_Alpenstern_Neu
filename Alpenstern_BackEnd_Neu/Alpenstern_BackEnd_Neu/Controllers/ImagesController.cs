using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class ImagesController : Controller
    {
        private alpensternEntities db = new alpensternEntities();
        // GET: Images
        public ActionResult Index()
        {

            var image = db.Bilder.
            return View(image.ToList());

            //return View();
        }
        public ActionResult Galerien()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult Einstellungen()
        {
            return View();
        }
    }
}