using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p)) {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
                //arama butonunu daha kapsamlı yapmak istersek urun ad yazan kısmı genişletebiliriz
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun() { 
            List<SelectListItem> deger1 =(from x in c.Kategoris.ToList() select  new SelectListItem { 
                Text = x.KategoriAd,
                Value = x.KategoriID.ToString()
            }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id) { 
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id) {

            List<SelectListItem> deger1 =(from x in c.Kategoris.ToList() select  new SelectListItem { 
                Text = x.KategoriAd,
                Value = x.KategoriID.ToString()
            }).ToList();
            ViewBag.dgr1 = deger1;
        
            var UrunDeger  = c.Uruns.Find(id);
            return View("UrunGetir", UrunDeger);
        }
        public ActionResult UrunGuncelle(Urun p) { 
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyati = p.AlisFiyati;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyati =  p.SatisFiyati;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        //pdf excel sayfasına verileri yazdırır
        public ActionResult UrunListesi() { 
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public  ActionResult SatisYap(int id) {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger3;
            var deger2 = c.Uruns.Find(id);
            ViewBag.dgr2 = deger2.UrunID;
            ViewBag.dgr3 = deger2.SatisFiyati;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p) {

            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }

    }
}