using Business;
using Entity;
using Entity.Models;
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
            KonuRep k = new KonuRep();
            List<Konu> liste = k.GetAll();
            return View(liste);
        }

        public ActionResult SonMakaleler()
        {
            return View(new MakaleRep().GetAll().Take(2));
        }

        public ActionResult SonKitaplar()
        {
            return View(new EkitapRep().GetAll().Take(2));
        }
    }
}