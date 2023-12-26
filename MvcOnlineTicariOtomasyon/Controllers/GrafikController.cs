using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Index2() {
            var GrafikCiz = new Chart(600, 600);
            GrafikCiz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(GrafikCiz.ToWebImage().GetBytes(),"image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3() { 
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xValue, yValues: yValue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4() { 

            return View();
        }
        public ActionResult VisualizeUrunResult() {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List <sinif1> UrunListesi() {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1(){
                UrunAd = "Bilgisayar",
                stok = 120
            });
            snf.Add(new sinif1(){
                UrunAd = "Beyaz Eşya",
                stok = 150
            });
            snf.Add(new sinif1()
            {
                UrunAd = "Mobilya",
                stok = 70
            });
            snf.Add(new sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                stok = 180
            });
            snf.Add(new sinif1()
            {
                UrunAd = "Mobil Cihazlar",
                stok = 90
            });
            return snf;
        }
    

        public ActionResult Index5() { 
            return View();
        }
        public ActionResult VisualizeUrunResult2() {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> UrunListesi2() { 
            List<sinif2> snf = new List<sinif2>();
            using (var context = new Context()) { 
                snf = c.Uruns.Select(x => new sinif2 { 
                    UrnAd = x.UrunAd,
                    stk = x.Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6() { 
        return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }


        
}