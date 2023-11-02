using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //ürün  
        //cari 
        //personel
        public DateTime Tarih{ get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar{ get; set; }
        public Urun Urun { get; set; }
        public Cariler Cariler { get; set; }
        public Personel Peronel { get; set; }
    }
}