using Business;
using DAL;
using Entity.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Egitim5.Controllers
{
    public class SikayetController : Controller
    {
        // GET: Sikayet
        public ActionResult Index(int? MakaleID,int? KitapID, int? VideoID,Sikayet yeniSikayet)
        {
            MyContext db = new MyContext();
            if (yeniSikayet.SikayetMesaj!=null&&MakaleID != null)
            {
                yeniSikayet.IlgiliMakaleID = MakaleID;
                yeniSikayet.SikayetEdenKullaniciID = User.Identity.GetUserId();
                db.Sikayetler.Add(yeniSikayet);
                db.SaveChanges();
            }
            else if (yeniSikayet.SikayetMesaj != null && KitapID != null)
            {
                yeniSikayet.IlgiliKitapID = KitapID;
                yeniSikayet.SikayetEdenKullaniciID = User.Identity.GetUserId();
                db.Sikayetler.Add(yeniSikayet);
                db.SaveChanges();
            }
            return View();
        }
        [Authorize(Roles = "Admin,Author")]
        public ActionResult SikayetAdminPanel()
        {
            return View(new SikayetRep().GetAll());
        }
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Detay(int id)
        {
            Sikayet s = new SikayetRep().GetById(id);
            return View(s);
        }
    }
}