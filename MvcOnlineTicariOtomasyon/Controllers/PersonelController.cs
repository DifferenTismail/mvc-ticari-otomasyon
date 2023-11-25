using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonControllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context(); 
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
    }
}