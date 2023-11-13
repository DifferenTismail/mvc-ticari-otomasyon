using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler =c.Kategoris.ToList();
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
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //veri tabanından kategori silmek için gereken kodlar
        public ActionResult KategoriSil(int id) {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}