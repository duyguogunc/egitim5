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
    [Table("EKitaplar")]
   public class EKitap
    {
        [Key]
        public int EKitapID { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage ="Makale adı en fazla 20 karakter uzunluğunda olabilir.")]
        [DisplayName("E-Kitap Adı")]
        public string EKitapAdi { get; set; }
        [Required]
        [DisplayName("E-Kitap İçeriği")]
        public string EKitapIcerik { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }
        public EKitap()
        {
            EklenmeTarihi = DateTime.Now;
        }
    }
}
