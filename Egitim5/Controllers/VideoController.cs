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
    }
}  
       

  

    


