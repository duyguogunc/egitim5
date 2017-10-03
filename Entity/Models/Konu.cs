using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entity.Models
{
  public  class Konu
    {
        [Key]
        public int KonuID { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = ("En fazla 30 karakter yazılabilir."))]
        [DisplayName("Konu Baslik")]
        public string KonuBaslik { get; set; }
        [Required]
        [DisplayName("Konu İçerik")]
        public string KonuIcerik { get; set; }
        public virtual List<Konu> AltKonular { get; set; }
        public Konu UstKonu { get; set; }
        public List<EKitap> KonununEkitaplari { get; set; }
        public List<Video> KonununVideolari{ get; set; }
        public List<Makale> KonununMakaleleri { get; set; }
    }
}
