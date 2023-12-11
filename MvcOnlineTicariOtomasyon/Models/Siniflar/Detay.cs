using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }

        [Column (TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string UrunBilgi{ get; set; }
    }
}