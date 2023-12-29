using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Gonderici{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Icerik { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}