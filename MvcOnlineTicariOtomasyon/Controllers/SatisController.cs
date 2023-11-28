using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        //form yüklendiğinde çalışıcak olan kısım
        [HttpGet]
        public ActionResult YeniSatis() {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                select new SelectListItem {
                    Text = x.UrunAd,
                    Value = x.UrunID.ToString()
                }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                select new SelectListItem {
                    Text = x.CardiAd + " " + x.CariSoyad,
                    Value = x.CariID.ToString()
                }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                select new SelectListItem {
                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                    Value = x.PersonelID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        //Satış yapma sayfası kodları
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s) {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //yapılan satışları güncelleme sayfasına götürür
        public ActionResult SatisGetir(int id) {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                select new SelectListItem {
                    Text = x.UrunAd,
                    Value = x.UrunID.ToString()
                }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                select new SelectListItem {
                    Text = x.CardiAd + " " + x.CariSoyad,
                    Value = x.CariID.ToString()
                }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                select new SelectListItem {
                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                    Value = x.PersonelID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        //yapılan satışları güncelleme kodları
        public ActionResult SatisGuncelle(SatisHareket p) {
            var deger = c.SatisHarekets.Find(p.SatisID);
            deger.CariID = p.CariID;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.PersonelID = p.PersonelID;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.UrunID = p.UrunID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //satış detay sayfasında gerekli olan verileri getirir
        public ActionResult SatisDetay(int id) {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}