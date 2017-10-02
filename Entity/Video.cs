using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [Required(ErrorMessage ="Zorunlu alan!")]
        [MaxLength(25)]
        public string VideoIsim { get; set; }
        public string VideoURL { get; set; }
        [Required(ErrorMessage ="Zorunlu alan!")]
        [MaxLength(100)]
        [StringLength(100,MinimumLength =10,ErrorMessage ="Aciklama 10-100 karakter arası olmalı")]
        public string Aciklama { get; set; }
        public int IzlenmeSayisi { get; set; }

        public DateTime EklenmeTarihi { get; set; }
        public Video()
        {
            EklenmeTarihi = DateTime.Today;
        }
    }
}
