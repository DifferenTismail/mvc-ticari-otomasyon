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
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        //yeni cari kayıt etmede çalışır
        public ActionResult YeniCari() {
            return View();
        }
        [HttpPost]
        //yeni cari kayıt etmede çalışır
        public ActionResult YeniCari(Cariler p) {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //cari silme kodu
        public ActionResult CariSil(int id) {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //carileri güncelleme ekranına yazdırmaya yarar
        public ActionResult CariGetir(int id) {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        //cari güncelleme kodları
        public ActionResult CariGuncelle(Cariler p) {
            if (!ModelState.IsValid) {
                return View("CariGetir"); 
            }
            var cari = c.Carilers.Find(p.CariID);
            cari.CardiAd = p.CardiAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //Müsterilerin yapdığı satışı ekrana yazdırır
        public ActionResult MusteriSatis(int id) {
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CardiAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}