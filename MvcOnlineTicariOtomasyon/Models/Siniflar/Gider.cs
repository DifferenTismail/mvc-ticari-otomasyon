using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID{ get; set; }
        public string  Aciklama{ get; set; }
        public DateTime Tarih {  get; set; }
        public decimal Tutar { get; set; }
    }
}