using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler =c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        //form yüklendiğinde bura çalışıcak
        public ActionResult KategoriEkle() {
            return View();
        }
        [HttpPost]
        //butona basıldığında bura çalışıcak
        public ActionResult KategoriEkle(Kategori k) {
            if (ModelState.IsValid)
            {
                c.Kategoris.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //veri tabanından kategori silmek için gereken kodlar
        public ActionResult KategoriSil(int id) {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //kategorileri güncelleme sayfasına getirir
        public ActionResult KategoriGetir(int id) {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        //kategorileri güncelleme kodları
        public ActionResult KategoriGuncelle(Kategori k) { 
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme() { 
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriID", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "UrunID", "UrunAd");
            return View(cs);
        }
        public JsonResult UrunGetir(int p) { 
            var UrunListesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.KategoriID equals y.KategoriID
                               where x.Kategori.KategoriID == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   Value = x.UrunID.ToString()
                               }).ToList();
            return Json(UrunListesi, JsonRequestBehavior.AllowGet);
        }

    }
}