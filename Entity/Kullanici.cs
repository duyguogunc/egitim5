using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{  [Table("TblKullanici")]
   public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        [Required]
        [DisplayName("İsim Soyisim")]
        public string AdSoyad { get; set; }
        public string Meslek { get; set; }
        public string WebSitesi { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }
        public string Resim { get; set; }
        public Kullanici()
        {
            DogumTarihi = DateTime.Today;
        }
    }
}
