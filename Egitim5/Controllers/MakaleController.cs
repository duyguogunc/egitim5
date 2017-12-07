using Business;
using Entity;
using Entity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult MakaleEkle(Makale k, List<int> SecilenKonular)
        {
            if (SecilenKonular != null && SecilenKonular.Count == 0)
                ModelState.AddModelError(string.Empty, "Bir konu seciniz.");

            KonuRep kr = new KonuRep();
            k.Konular = kr.GetAll().Where(x => SecilenKonular.Any(a => a == x.KonuID)).ToList();

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
            //duruma göre içerikteki kelimeler de eklenebilir.
            Session["text"] += " " + k.Baslik;
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
        

        public ActionResult AlakaliMakaleler(int id)
        {
            IEnumerable<string> words = null;
            string text = Session["text"].ToString().Trim();
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            foreach (var item in punctuation)
            {
                //özel karakterlerden # charını çıkar. "C#"i "C" şeklinde göstermesin diye
                if (item != '#')
                {
                    words = text.Split().Select(x => x.Trim(item));
                }

            }
            if (words != null)
            {
                Dictionary<string, int> statistics = words
                                .GroupBy(word => word)
                                .ToDictionary(
                                    kvp => kvp.Key, // kelimenin kendisi key
                                    kvp => kvp.Count());
                            string enAlakali = statistics.OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();
                            IEnumerable<Makale> makaleler = new MakaleRep().GetAll().Where(x => x.Baslik.Contains(enAlakali) && x.MakaleID != id);
                return View(makaleler);
            }
            return View();
            
            
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

        
        public JsonResult MakaleOy(int oy, int id)
        {
            
            try
            {
                if (Session["HasVoted_" + id] == null || (bool)Session["HasVoted_" + id] != true)
                {
                    Oylama o = new Oylama();
                    MakaleRep mrep = new MakaleRep();
                    OylamaRep orep = new OylamaRep();
                    Makale secilen = mrep.GetById(id);
                    string isim = User.Identity.GetUserName();

                    if (secilen.ToplamOy.HasValue)
                    {
                        secilen.ToplamOy = secilen.ToplamOy.Value + oy;
                        o.MakaleAdi = secilen.Baslik;
                        o.Oy = oy;
                        o.KullaniciAdi = isim;
                        orep.Insert(o);                                                
                    }

                    else
                    {
                        secilen.ToplamOy = oy;
                        o.MakaleAdi = secilen.Baslik;
                        o.Oy = oy;
                        o.KullaniciAdi = isim;
                        orep.Insert(o);
                    }
                    mrep.Update(secilen);
                    Session["Hasvoted_" + id] = true;
                    return Json("Oy verdiğiniz için teşekkürler.");
                }
                else
                    return Json("Tekrar oy veremezsiniz.");
            }
            catch (Exception ex)
            {
                return Json("Bir hata oluştu." + ex.Message);
            }
        }
    }


}