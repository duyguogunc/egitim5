using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Makale
    {
        [Key]
        public int MakaleID { get; set; }
        [Required]
        [DisplayName("Makale Adı")]
        public string makaleBaslik { get; set; }
        [DisplayName("Makale Türü")]
        public string makaleTur { get; set; }
        [DisplayName("Makale İçeriği")]
        public string makaleİcerik { get; set; }
        [DisplayName("Makale Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        public Makale()
        {
            EklenmeTarihi = DateTime.Now;
        }
    }
}
