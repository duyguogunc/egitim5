using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Egitim5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SonMakaleler()
        {
            return View(new MakaleRep().GetAll().Take(1));
        }

        public ActionResult SonKitaplar()
        {
            return View(new EkitapRep().GetAll().Take(1));
        }
    }
}