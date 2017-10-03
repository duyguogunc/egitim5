using Business;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;


namespace Egitim5.Controllers
{
    
    public class KonuController : Controller
    {
        [HttpGet]
        public ActionResult Konular ()
        {
            KonuRep kr = new KonuRep();
            return View(kr.GetAll());

        }

       [Authorize(Roles = "Admin")]             
        public ActionResult KonuEkle(Konu konu)
        {
            KonuRep kr = new KonuRep();
            kr.Insert(konu);
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult KonuSil(int? id)
        {
            if (id != null)
            {
                KonuRep kr = new KonuRep();
                kr.Delete((int)id);
            }
            else
            {
                Response.Redirect("" + id);
            }
            return View();
        }



    }
}
