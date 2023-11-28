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
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum==true).ToList();
            return View(urunler);
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
    }
}