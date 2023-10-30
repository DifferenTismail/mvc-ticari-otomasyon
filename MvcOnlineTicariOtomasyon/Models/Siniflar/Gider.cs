using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string  Aciklama{ get; set; }
        public DateTime Tarih {  get; set; }
        public decimal Tutar { get; set; }
    }
}