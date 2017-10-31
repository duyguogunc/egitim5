using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Makale : Icerik
    {
        [Key]
        public int MakaleID { get; set; }

        [DisplayName("Makale İçeriği")]
        public string MakaleIcerik { get; set; }
        [DisplayName("Makale Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }
        public Makale()
        {
            EklenmeTarihi = DateTime.Now;
        }
    }
}
