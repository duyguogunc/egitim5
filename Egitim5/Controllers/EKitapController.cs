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
        [Authorize(Roles = "Admin, EKitapModerator")]
        public ActionResult KitapEkle()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin, EKitapModerator")]
        [ValidateAntiForgeryToken]
        public ActionResult KitapEkle(EKitap k, HttpPostedFileBase EKitapURL, List<int> SecilenKonular)
        {
            var klasor = "/Content/EkitapUpload/";
            string kaydedilecekIsim = "";

            try
            {
                #region dosyayiKaydet
                if (EKitapURL != null && EKitapURL.ContentLength > 0)
                {
                    var kitapAdi = EKitapURL.FileName;
                    kaydedilecekIsim = kitapAdi;
                    if (System.IO.File.Exists(klasor + kitapAdi))
                    {
                        System.IO.FileInfo bilgi = new System.IO.FileInfo(klasor + kitapAdi);

                        var sadeceDosyaAdi = bilgi.Name.Replace(bilgi.Extension, "");

                        string[] bulunanlar = System.IO.Directory.GetFiles(klasor, sadeceDosyaAdi + ".*", System.IO.SearchOption.AllDirectories);

                        var kacTane = bulunanlar.Length;

                        kaydedilecekIsim = sadeceDosyaAdi + "-" + kacTane + "." + bilgi.Extension;
                    }

                    var path = Server.MapPath(klasor);
                    EKitapURL.SaveAs(path + kaydedilecekIsim);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            k.EKitapURL = kaydedilecekIsim;
            /*
            if (SecilenKonular == null || SecilenKonular.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir konu seciniz.");
            else
                using (KonuRep kr = new KonuRep())
                    k.Konular = kr.GetAll().Where(x => SecilenKonular.Any(a => a == x.KonuID)).ToList();
*/
            if (ModelState.IsValid)
            {
                new EkitapRep().Insert(k);
                ViewBag.EklendiMi = true;
            }
            return View();
        }

        [Authorize(Roles = "Admin, EKitapModerator")]
        [HttpPost]
        public JsonResult KitapSil(int id)
        {
            try
            {
                new EkitapRep().Delete(id);
                return Json(new { success = true, message = "Silindi" });
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }
        public ActionResult Detay(int id)
        {
            ViewBag.gelen = "EKitap";
            EKitap k = new EkitapRep().GetById(id);
            k.EKitapGoruntulenmeSayisi++;
            new EkitapRep().Update(k);
            return View(k);
        }
        public ActionResult IlgiliKitaplar(int id)
        {

            EKitap simdiki = new EkitapRep().GetById(id);
            List<Konu> konular = simdiki.Konular;
            if (konular != null)
            {
                List<EKitap> liste = new EkitapRep().GetAll().Where(x => konular.Any(a => konular.Contains(a))).ToList();
                return View(liste.Take(5));
            }
            else return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin, EKitapModerator")]
        public ActionResult Duzenle(int id)
        {
            EkitapRep rep = new EkitapRep();
            return View(rep.GetById(id));
        }
        [HttpPost]
        [Authorize(Roles = "Admin, EKitapModerator")]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(EKitap k, HttpPostedFileBase EKitapURL, List<int> SecilenKonular)
        {
            string kaydedilecekIsim = "";
            var klasor = "/Content/EkitapUpload/";

            try
            {
                #region dosyayiKaydet
                if (k.EKitapURL != null)
                {
                    var kitapAdi = EKitapURL.FileName;
                    kaydedilecekIsim = kitapAdi;
                    if (System.IO.File.Exists(klasor + kitapAdi))
                    {
                        System.IO.FileInfo bilgi = new System.IO.FileInfo(klasor + kitapAdi);

                        var sadeceDosyaAdi = bilgi.Name.Replace(bilgi.Extension, "");

                        string[] bulunanlar = System.IO.Directory.GetFiles(klasor, sadeceDosyaAdi + ".*", System.IO.SearchOption.AllDirectories);

                        var kacTane = bulunanlar.Length;

                        kaydedilecekIsim = sadeceDosyaAdi + "-" + kacTane + "." + bilgi.Extension;
                    }

                    var path = Server.MapPath(klasor);
                    EKitapURL.SaveAs(path + kaydedilecekIsim);
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (SecilenKonular == null || SecilenKonular.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir konu seciniz.");

            if (ModelState.IsValid)
            {
                EkitapRep er = new EkitapRep();
                EKitap kitap = er.GetById(k.EKitapID);

                if (!string.IsNullOrEmpty(kaydedilecekIsim))
                {
                    try
                    {
                        if (System.IO.File.Exists(klasor + kitap.EKitapURL))
                            System.IO.File.Delete(klasor + kitap.EKitapURL);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log(ex);
                    }
                    kitap.EKitapURL = kaydedilecekIsim;
                }

                kitap.Baslik = k.Baslik;
                kitap.Description = k.Description;
                kitap.EKitapIcerik = k.EKitapIcerik;
                kitap.Keywords = k.Keywords;
                kitap.KisaAciklama = k.KisaAciklama;
                KonuRep kr = new KonuRep();
                kitap.Konular = kr.GetAll().Where(x => SecilenKonular.Any(a => a == x.KonuID)).ToList();
                kitap.Title = k.Title;
                er.Update(kitap);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}