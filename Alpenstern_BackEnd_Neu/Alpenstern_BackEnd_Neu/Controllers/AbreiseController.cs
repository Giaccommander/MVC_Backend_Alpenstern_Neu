using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Controllers
{
    public class AbreiseController : Controller
    {
        // GET: Abreise
        public ActionResult Index()
        {
            List<AbreiseViewModel> abreisen = new List<AbreiseViewModel>();




            return View(abreisen);
        }
    }
}