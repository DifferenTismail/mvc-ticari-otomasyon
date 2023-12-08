using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.Uruns.Count(x => x.Stok<=20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault(); //en yüksek fiyatlı ürün
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();//en düşük fiyatlı ürün
            ViewBag.d9 = deger9;

            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();//ürünleri markaya göre gruplandırır ve en fazla kullanılan markayı ekrana yazdırır
            ViewBag.d12 = deger12;

            var deger13 = c.Uruns.Where(u => u.UrunID == ( c.SatisHarekets.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var bugunkuSatislar = c.SatisHarekets.Where(x => x.Tarih == bugun);

            // Bugünkü satışların sayısını kontrol et
            int satisAdeti = bugunkuSatislar.Count();
            ViewBag.d15 = satisAdeti.ToString();

            // Eğer bugün satış yapılmışsa ToplamTutar'ı topla, aksi halde 0 olarak ata
            decimal bugunkuToplamTutar = satisAdeti > 0 ? bugunkuSatislar.Sum(y => y.ToplamTutar) : 0;
            ViewBag.d16 = bugunkuToplamTutar.ToString();
            return View();
        }
    }
}