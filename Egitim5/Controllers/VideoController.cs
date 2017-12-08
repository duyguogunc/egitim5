using Business;
using Entity;
using Entity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Egitim5.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            VideoRep br = new VideoRep();
            var liste = br.GetAll();
            return View(liste);
        }
        [HttpGet]
        public ActionResult VideoEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VideoEkle(Video yeni)
        {
            VideoRep br = new VideoRep();
            br.Insert(yeni);
            return View();
        }
        // GET: Video
        public ActionResult Detail(int id)
        {
            var vRep = new VideoRep();
            Video v = vRep.GetById(id);
            v.VideoGoruntulenmeSayisi++;
            new VideoRep().Update(v);
            return View(v);
        }

        public JsonResult VoteVideo(int id, int points)
        {
            try
            {//id için tanımlı olan Article kaydına points kadar puan ekleyelim  (TotalPoints)
                if (Session["HasVoted_" + id] == null || (bool)Session["HasVoted_" + id] != true)
                {
                    OyRep rep = new OyRep();
                    Oylama o = new Oylama();
                    VideoRep vRep = new VideoRep();
                    Video selected = vRep.GetById(id);
                    string isim = User.Identity.GetUserName();
                    if (selected.TotalRate.HasValue)
                    {
                        selected.TotalRate = selected.TotalRate.Value + points;
                        o.Oy = points;
                        o.KullaniciAdi = isim;
                        o.HangiVideo = selected.Baslik;
                        rep.Insert(o);
                    }



                    else
                    {
                        selected.TotalRate = points;
                        o.Oy = points;
                        o.KullaniciAdi = isim;
                        o.HangiVideo = selected.Baslik;
                        rep.Insert(o);
                    }
                        vRep.Update(selected);
                    Session["HasVoted_" + id] = true;

                    return Json("Thank you for voting");
                }
                else
                {
                    return Json("you can't vote again!");
                }
            }
            catch (Exception ex)
            {

                return Json("A problem has occured - " + ex.Message);
            }
        }
        
        [HttpGet]

        public ActionResult Duzenle(int? id)
        {
            Video duzenlenecek = new VideoRep().GetById((int)id);

            
            return View(duzenlenecek);
        }

        [HttpPost]

        public ActionResult Duzenle(Video duzenlenenvideo)
        {
          var vRep=  new VideoRep();
            var eski = vRep.GetById(duzenlenenvideo.VideoID);
            eski.VideoURL = duzenlenenvideo.VideoURL;
            eski.Aciklama = duzenlenenvideo.Aciklama;
            eski.IzlenmeSayisi = duzenlenenvideo.IzlenmeSayisi;
            eski.EklenmeTarihi = duzenlenenvideo.EklenmeTarihi;
            eski.Baslik = duzenlenenvideo.Baslik;
            eski.KisaAciklama = duzenlenenvideo.KisaAciklama;
            if(ModelState.IsValid)
            vRep.Update(eski);

            return View(duzenlenenvideo);
        }

    }
}