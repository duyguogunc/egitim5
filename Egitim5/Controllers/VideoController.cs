using Business;
using Entity;
using System;
using System.Collections.Generic;
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
            var video = (from a in entity.Video where a.VideoID == GelenID select a).FirstOrDefault();
            if (video != null)
            {
                ViewBag.Baslik = video.Baslik;
                ViewBag.Icerik = video.Video1;
            }
            return View();
        }

    }

    }


