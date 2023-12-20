using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKodu{ get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama{ get; set; }
        public DateTime TarihZaman{ get; set; }
    }
}