using Business;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Utility;

namespace Egitim5.Controllers
{

    public class KonuController : Controller
    {
        public ActionResult Index()
        {
            KonuRep kr = new KonuRep();
            var konular = kr.GetAll();
            var ustKonular = konular.Where(x => x.UstKonuID == null).ToList();
            ustKonular.ForEach(x => x.AltKonular = konular.Where(a => a.UstKonuID == x.KonuID).ToList());
            return View(ustKonular);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult KonuEkle(Konu konu)
        {
            KonuRep kr = new KonuRep();
            if (ModelState.IsValid)
            {
                if (konu.UstKonuID == 0) konu.UstKonuID = null;
                kr.Insert(konu);
                ViewBag.EklendiMi = true;
            }
            return View();
        }
        public ActionResult KonuEkle()
        {
            KonuRep kr = new KonuRep();
            List<Konu> liste = kr.GetAll();
            liste.Insert(0, new Konu { KonuID = 0, KonuBaslik = "Seçiniz" });
            ViewBag.Konular = liste;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public JsonResult KonuSil(int? id)
        {
            if (id != null)
            {
                try
                {
                    new KonuRep().Delete((int)id);
                    return Json(new { success = true, message = "Silindi" });
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex);
                    return Json(new { success = false, message = "Bir hata oluştu." });
                }
            }
            else
                return Json(new { success = false, message = "Silinecek konuyu seciniz." });
        }



    }
}
