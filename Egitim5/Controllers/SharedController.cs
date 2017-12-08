using Business;
using Entity.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Egitim5.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult KonuSelect(IEnumerable<int> secilenler = null)
        {
            KonuRep kr = new KonuRep();
                return View(kr.GetAll().Select(x => new KonuViewModel()
                {
                    KonuBaslik = x.KonuBaslik,
                    KonuID = x.KonuID,
                    SeciliMi = secilenler==null ? false :secilenler.Any(a => a == x.KonuID)
                }).ToList());
            
        }
    }
}