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
        //form yüklendiğinde çalışır
        [HttpGet]
        public ActionResult PersonelEkle() { 
            List<SelectListItem> deger1 =(from x in c.Departmans.ToList() select  new SelectListItem { 
                Text = x.DepartmanAd,
                Value = x.DepartmanID.ToString()
            }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        //personel ekleme kodları
        [HttpPost]
        public ActionResult PersonelEkle(Personel p) {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //güncelleme sayfasına personelleri getirme kodları
        public ActionResult PersonelGetir(int id) {
            List<SelectListItem> deger1 =(from x in c.Departmans.ToList() select  new SelectListItem { 
                Text = x.DepartmanAd,
                Value = x.DepartmanID.ToString()
            }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        //personel güncelleme kodları
        public ActionResult PersonelGuncelle(Personel p) {
            var prsn = c.Personels.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe() { 
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}