using Business;
using DAL;
using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Egitim5.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            BaseRepository<Video> br = new BaseRepository<Video>();
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
            BaseRepository<Video> br = new BaseRepository<Video>();
            br.Insert(yeni);
            return View();
        }
        // GET: Video
        public ActionResult Detail(int id)
        {
            Video v = new VideoRep().GetById(id);
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
                    VideoRep vRep = new VideoRep();
                    Video selected = vRep.GetById(id);
                    if (selected.TotalRate.HasValue)
                        selected.TotalRate = selected.TotalRate.Value + points;
                    else
                        selected.TotalRate = points;
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
            // var video = (from a in EntityId.Video where a.VideoID == GelenID select a).FirstOrDefault();
            //Video video = new Video();
            //if (video != null)
            //{
            //    ViewBag.Baslik = video.Baslik;
            //    //ViewBag.Icerik = video.Video1;
            //}
            //return View();
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
            MyContext db = new MyContext();
            var eski = db.Videolar.Find(duzenlenenvideo.VideoID);
            eski.VideoURL = duzenlenenvideo.VideoURL;
            eski.Aciklama = duzenlenenvideo.Aciklama;
            eski.IzlenmeSayisi = duzenlenenvideo.IzlenmeSayisi;
            eski.EklenmeTarihi = duzenlenenvideo.EklenmeTarihi;
            eski.Baslik = duzenlenenvideo.Baslik;
            eski.KisaAciklama = duzenlenenvideo.KisaAciklama;
            db.Entry(eski).State = System.Data.Entity.EntityState.Modified;
            if(ModelState.IsValid)
            db.SaveChanges();

            return View(duzenlenenvideo);
        }

    }




    }
}