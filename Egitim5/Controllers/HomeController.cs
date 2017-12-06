using Business;
using Entity;
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
        public ActionResult Ara(string aranan)
        {
            Session["aranacak"] = aranan.ToLower();
            return View();
        }
        public ActionResult MakaleSonuclar()
        {
            MakaleRep rep = new MakaleRep();
            var sonuclar = rep.GetAll().Where(x=>x.Baslik.ToLower().Contains(Session["aranacak"].ToString()));
            return View(sonuclar);
        }
        public ActionResult EkitapSonuclar()
        {
            EkitapRep rep = new EkitapRep();
            var sonuclar = rep.GetAll().Where(x => x.Baslik.ToLower().Contains(Session["aranacak"].ToString()));
            return View(sonuclar);
        }
        public ActionResult VideoSonuclar()
        {
            VideoRep rep = new VideoRep();
            var sonuclar = rep.GetAll().Where(x => x.Baslik.ToLower().Contains(Session["aranacak"].ToString()));
            return View(sonuclar);
        }
        [HttpGet]

        

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