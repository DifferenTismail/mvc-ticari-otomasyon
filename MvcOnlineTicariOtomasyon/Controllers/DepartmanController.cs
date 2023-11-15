using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        //departman ekleme kodları
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //departman silme kodları
        public ActionResult DepartmanSil(int id) {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //departman sayfasına veri tabanındaki verileri yazdırmaya yarar
        public ActionResult DepartmanGetir (int id) {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir", dpt);
        }
        //Departman güncelleme kodları
        public ActionResult DepartmanGuncelle(Departman p) {
            var dept = c.Departmans.Find(p.DepartmanID);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //departmanla ilgili olan detayları ekrana yazdıran kodlar
        public ActionResult DepartmanDetay(int id) {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID==id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        //departmandaki personelin satışlarını ekrana yazdırtan kodlar
        public ActionResult DepartmanPersonelSatis (int id) {
            return View();
        }
    }
}