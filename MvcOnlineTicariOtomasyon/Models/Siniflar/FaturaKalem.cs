using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BİrimFiyat{ get; set; }
        public decimal Tutar { get; set; }
        public Faturalar Faturalar { get; set; }
    }
}