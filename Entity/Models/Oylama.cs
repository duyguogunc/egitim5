using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Oylama
    {
        [Key]
        public int OylamaID { get; set; }
        public int? Oy { get; set; }
        public string KullaniciAdi { get; set; }

        public string MakaleAdi { get; set; }
            
    }
}
