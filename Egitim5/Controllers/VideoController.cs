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
            return View();
        }
        
        public ActionResult VideoEkle()
        {
            return View();
        }
        public ActionResult VideoDetay(string id)
        {
            // var video = (from a in EntityId.Video where a.VideoID == GelenID select a).FirstOrDefault();
            var video = new Video();
            if (video != null)
            {
                ViewBag.Baslik = video.Baslik;
                //ViewBag.Icerik = video.Video1;
            }
            return View();
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


