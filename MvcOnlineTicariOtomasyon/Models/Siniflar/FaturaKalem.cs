using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID{ get; set; }
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BİrimFiyat{ get; set; }
        public decimal Tutar { get; set; }
    }
}