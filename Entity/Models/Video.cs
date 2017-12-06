using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Video : Icerik
    {
        [Key]
        public int VideoID { get; set; }
        public string VideoURL { get; set; }
        [Required(ErrorMessage ="Zorunlu alan!")]
        [MaxLength(100)]
        [StringLength(100,MinimumLength =10,ErrorMessage ="Aciklama 10-100 karakter arası olmalı")]
        public string Aciklama { get; set; }
        public int IzlenmeSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public Video()
        {
            IzlenmeSayisi = 0;
            EklenmeTarihi = DateTime.Today;
        }
    }
}
