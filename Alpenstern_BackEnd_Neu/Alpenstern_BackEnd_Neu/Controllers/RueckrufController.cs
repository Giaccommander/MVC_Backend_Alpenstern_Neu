using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class RueckrufController : Controller
    {
        // GET: Rueckruf
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RueckrufNeu()
        {
            return View();
        }
    }
}