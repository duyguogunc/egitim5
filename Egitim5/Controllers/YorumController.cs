using Business;
using Entity;
using Entity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Egitim5.Controllers
{
    public class YorumController : Controller
    {
        // GET: Yorum
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YorumEkle()
        {

            return View();
        }
        YorumRep yrep = new YorumRep();
        [HttpPost]
        public JsonResult YorumYap(Yorum y, string tur, int ID)
        {

            try
            {
                //    if (Session["HasVoted_" + id] == null || (bool)Session["HasVoted_" + id] != true)
                //    {
                //Oylama o = new Oylama();
                //OylamaRep orep = new OylamaRep();
                //Yorum y = new Yorum();
                y.DiscriptionID = ID;
                y.Discription = tur;
                string isim = User.Identity.GetUserName();
                y.KullaniciAd = isim;
                yrep.Insert(y);


                return Json("Yorum bildirdiğiniz için teşekkürler.");
            }
            catch (Exception ex)
            {
                return Json("Bir hata oluştu." + ex.Message);
            }
        }
    [HttpPost]
        public ActionResult YorumEkle(Yorum y, string tur, int ID)
        {
            y.DiscriptionID = ID;
            y.Discription = tur;
            string isim = User.Identity.GetUserName();
            y.KullaniciAd = isim;

            yrep.Insert(y);

            return View(y);
        }
        [HttpGet]
        public ActionResult YorumGoruntule(Yorum y)
        {
            List<Yorum> liste = yrep.GetAll();
            return View(liste);
        }

    }
}