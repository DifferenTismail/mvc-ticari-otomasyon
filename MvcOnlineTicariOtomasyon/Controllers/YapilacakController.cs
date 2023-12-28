using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Yapilacaks.Where(x => x.Durum == true).ToList();
            
            //var deger1 = c.Carilers.Count().ToString();
            //ViewBag.d1 = deger1;

            //var deger2 = c.Uruns.Count().ToString();
            //ViewBag.d2 = deger2;

            //var deger3 = c.Kategoris.Count().ToString();
            //ViewBag.d3 = deger3;

            //var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            //ViewBag.d4 = deger4;

            //var yapilacaklar = c.Yapilacaks.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YapilacakEkle()
        {
            return View();
        }
        [HttpPost]
        //Yapılacak ekleme kodları
        public ActionResult YapilacakEkle(Yapilacak y)
        {
            y.Durum = true;
            c.Yapilacaks.Add(y);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YapilacakSil(int id)
        {
            var yap = c.Yapilacaks.Find(id);
            yap.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}