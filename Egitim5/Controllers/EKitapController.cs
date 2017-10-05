using Business;
using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Utility;

namespace Egitim5.Controllers
{
    public class EKitapController : Controller
    {
        // GET: EKitap

        public ActionResult Index()
        {
            EkitapRep eRep = new EkitapRep();
            return View(eRep.GetAll().OrderByDescending(x => x.EKitapID).Take(20));
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, EKitapModerator")]
        [ValidateAntiForgeryToken]
        public ActionResult KitapEkle(EKitap k, HttpPostedFileBase EKitapURL, string konular)
        {
            var klasor = "/Content/EkitapUpload/";
            var kitapAdi = EKitapURL.FileName;
            var kaydedilecekIsim = kitapAdi;

            try
            {
                #region dosyayiKaydet
                if (System.IO.File.Exists(klasor + kitapAdi))
                {
                    //dosya.pdf  
                    //dosya-1.pdf
                    //dosya-2.pdf

                    System.IO.FileInfo bilgi = new System.IO.FileInfo(klasor + kitapAdi);

                    var sadeceDosyaAdi = bilgi.Name.Replace(bilgi.Extension, "");

                    string[] bulunanlar = System.IO.Directory.GetFiles(klasor, sadeceDosyaAdi + ".*", System.IO.SearchOption.AllDirectories);

                    var kacTane = bulunanlar.Length;

                    kaydedilecekIsim = sadeceDosyaAdi + "-" + kacTane + "." + bilgi.Extension;
                }

                var path = Server.MapPath(klasor);
                EKitapURL.SaveAs(path + kaydedilecekIsim);
                #endregion

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DosyaKayit", ex);
            }
            
            k.EKitapURL = kaydedilecekIsim;
             
            #region KonulariEkle
            string[] konuListe = konular.Split(',');
            KonuRep kRep = new KonuRep();
            foreach (string item in konuListe)
            {
                try
                {
                    var gercekKonu = kRep.GetAll().Where(x => x.KonuBaslik == item).FirstOrDefault();
                    k.EKitapinKonusu.Add(gercekKonu);
                }
                catch (Exception ex){
                    LogHelper.Log(ex, HataTuru.Ekitap);
                }
            }
            #endregion

            if (ModelState.IsValid)
            {
                new EkitapRep().Insert(k);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Admin, EKitapModerator")] 
        [HttpPost]
        public JsonResult KitapSil(int id)
        {
            try
            {
                new EkitapRep().Delete(id);
                return Json(new { success = true, message = "Silindi"});
            }
            catch {
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }


        public ActionResult Detay(int id)
        {
           EKitap k = new EkitapRep().GetById(id);
            return View(k);
        }

        public ActionResult IlgiliKitaplar(int id)
        {
            
            EKitap simdiki = new EkitapRep().GetById(id);
            List<Konu> konular = simdiki.EKitapinKonusu;
            if (konular != null)
            {
                List<EKitap> liste = new EkitapRep().GetAll().Where(x => konular.Any(a => konular.Contains(a))).ToList();
                return View(liste.Take(5));
            }
            else return View();
        }
    }

   
}