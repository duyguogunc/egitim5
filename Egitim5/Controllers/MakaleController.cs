using Business;
using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Utility;

namespace Egitim5.Controllers
{
    public class MakaleController : Controller
    {
        // GET: Makale

        public ActionResult Index()
        {
            MakaleRep eRep = new MakaleRep();
            return View(eRep.GetAll().OrderByDescending(x => x.MakaleID).Take(20));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, MakaleModerator")]
        public ActionResult MakaleEkle()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, MakaleModerator")]
        [ValidateAntiForgeryToken]
        public ActionResult MakaleEkle(Makale k, List<int> SecilenKonular, HttpPostedFileBase resim)
        {
            var klasor = Server.MapPath("/Content/Upload/");
            if (resim != null && resim.ContentLength != 0)
            {
                if (resim.ContentLength > 2 * 1024 * 1024)
                    ModelState.AddModelError(null, "Resim boyutu max 2MB olabilir.");
                else
                {
                    try
                    {
                        FileInfo fi = new FileInfo(resim.FileName);
                        var rastgele = Guid.NewGuid().ToString().Substring(0, 5);
                        var dosyaAdi = fi.Name + rastgele + fi.Extension;

                        resim.SaveAs(klasor + dosyaAdi);
                        k.ResimURL = dosyaAdi;
                    }
                    catch { }
                }
            }
            if (SecilenKonular != null && SecilenKonular.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir konu seciniz.");
            try
            {
                KonuRep kr = new KonuRep();
                k.Konular = kr.GetAll().Where(x => SecilenKonular.Any(a => a == x.KonuID)).ToList();
            }
            catch { }
            if (ModelState.IsValid)
            {
                new MakaleRep().Insert(k);
                ViewBag.EklendiMi = true;
            }
            return View();
        }

        [Authorize(Roles = "Admin, MakaleModerator")]
        [HttpPost]
        public JsonResult MakaleSil(int id)
        {
            try
            {
                new MakaleRep().Delete(id);
                return Json(new { success = true, message = "Silindi" });
            }
            catch
            {
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }
        public ActionResult Detay(int id)
        {
            Makale k = new MakaleRep().GetById(id);
            return View(k);
        }

        public ActionResult IlgiliMakaleler(int id)
        {

            Makale simdiki = new MakaleRep().GetById(id);
            List<int> konular = simdiki.Konular.Select(a => a.KonuID).ToList();
            if (konular != null)
            {
                List<Makale> liste = new MakaleRep().GetAll().Where(x => konular.Any(a => x.Konular.Select(t => t.KonuID).Contains(a) && x.MakaleID != id)).ToList();
                return View(liste);
            }
            else return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, MakaleModerator")]
        public ActionResult Duzenle(int id)
        {
            MakaleRep rep = new MakaleRep();
            return View(rep.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, MakaleModerator")]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Makale k, HttpPostedFileBase MakaleURL, List<int> SecilenKonular)
        {
            if (SecilenKonular == null || SecilenKonular.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir konu seciniz.");

            if (ModelState.IsValid)
            {
                MakaleRep er = new MakaleRep();

                Makale kitap = er.GetById(k.MakaleID);

                kitap.Baslik = k.Baslik;
                kitap.Description = k.Description;
                kitap.MakaleIcerik = k.MakaleIcerik;
                kitap.Keywords = k.Keywords;
                kitap.KisaAciklama = k.KisaAciklama;
                KonuRep kr = new KonuRep();
                kitap.Konular = new List<Konu>();
                kitap.Konular.AddRange(kr.GetAll().Where(x => SecilenKonular.Any(a => a == x.KonuID)).ToList());
                kitap.Title = k.Title;
                er.Update(kitap);
                return RedirectToAction("Index");
            }
            return View();
        }
    }


}