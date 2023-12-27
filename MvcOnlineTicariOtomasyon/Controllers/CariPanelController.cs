using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
           // string mail = User.Identity.Name;
            string mail = HttpContext.User.Identity.Name;
            var degerler = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var MailID = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mID = MailID;
            var ToplamSatis = c.SatisHarekets.Where(x => x.CariID == MailID).Count();
            ViewBag.ToplamSatis = ToplamSatis;
            var satisHareketleri = c.SatisHarekets;
            var ToplamTutar = (satisHareketleri != null && satisHareketleri.Any(x => x.CariID == MailID)) ? satisHareketleri.Where(x => x.CariID == MailID).Sum(y => y.ToplamTutar) : 0;
            ViewBag.ToplamTutar = ToplamTutar;
            var ToplamUrunSayisi = (satisHareketleri != null && satisHareketleri.Any(x => x.CariID == MailID)) ? satisHareketleri.Where(x => x.CariID == MailID).Sum(y => y.Adet) : 0;
            ViewBag.ToplamUrunSayisi = (ToplamUrunSayisi > 0) ? ToplamUrunSayisi : 0;
            var AdSoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CardiAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.AdSoyad = AdSoyad;
            return View(degerler);

        }
        [Authorize]
        public ActionResult Siparislerim(){

            string mail = HttpContext.User.Identity.Name;
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar() {
            string mail = HttpContext.User.Identity.Name;
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail ).OrderByDescending(y => y.MesajID).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            string mail = HttpContext.User.Identity.Name;
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id) {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            string mail = HttpContext.User.Identity.Name;
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniMesaj()
        {
            string mail = HttpContext.User.Identity.Name;
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            string mail = HttpContext.User.Identity.Name;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult KargoTakip(string p) {

            var k = from x in c.KargoDetays select x;
                k = k.Where(y => y.TakipKodu.Contains(p));
                //arama butonunu daha kapsamlı yapmak istersek urun ad yazan kısmı genişletebiliriz
            return View(k.ToList());
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id) {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult LogOut() { 
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1() {
            string mail = HttpContext.User.Identity.Name;
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var CariBul = c.Carilers.Find(id);
            return PartialView("Partial1", CariBul);
        }
        public PartialViewResult Partial2() { 
            var veriler = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cariler cr) {
            var cari = c.Carilers.Find(cr.CariID);
            cari.CardiAd = cr.CardiAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSifre = cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}