using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        //Form yüklendiğinde çalışır
        [HttpGet]
        public ActionResult FaturaEkle() { 
            return View();
        }
        //form gönderildiğinde çalışıcak
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f) { 
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}