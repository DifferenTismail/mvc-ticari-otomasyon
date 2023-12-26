using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);

        }
        public ActionResult Siparislerim(){
            string mail = HttpContext.User.Identity.Name;
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar() {
            string mail = HttpContext.User.Identity.Name;
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail ).OrderByDescending(y => y.MesajID).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }
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
        public ActionResult YeniMesaj(Mesajlar m)
        {
            string mail = HttpContext.User.Identity.Name;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
    }
}