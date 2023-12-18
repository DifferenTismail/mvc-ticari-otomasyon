using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler ca)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == ca.CariMail && x.CariSifre == ca.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CarilerMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpGet]
        public ActionResult AdminLogin() { 
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p) {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null) {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}