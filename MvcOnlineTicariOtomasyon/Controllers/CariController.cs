using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari() {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p) { 
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}