using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacak
    {
        [Key]
        public int YapicalakID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Baslik{ get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }


    }
}