using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class Konu
    {
        [Key]
        public int KonuID { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = ("En fazla 100 karakter yazılabilir."))]
        [DisplayName("Konu Baslik")]
        public string KonuBaslik { get; set; }
        [Required]
        [DisplayName("Konu İçerik")]
        public string KonuIcerik { get; set; }
        [ForeignKey("UstKonu")]
        public int? UstKonuID { get; set; }
        public virtual List<Konu> AltKonular { get; set; }
        public virtual Konu UstKonu { get; set; }
        public virtual List<EKitap> KonununEkitaplari { get; set; }
        public virtual List<Video> KonununVideolari { get; set; }
        public virtual List<Makale> KonununMakaleleri { get; set; }
    }
}
