using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Sikayet
    {
        public Sikayet()
        {
            SikayetTarihi = DateTime.Now;
        }
        [Key]
        public int SikayetID { get; set; }
        public string SikayetEdenKullaniciID { get; set; }
        public string SikayetSebep { get; set; }
        public string SikayetMesaj { get; set; }
        public int? IlgiliMakaleID { get; set; }
        public int? IlgiliKitapID { get; set; }
        public int? IlgiliVideoID { get; set; }
        public DateTime SikayetTarihi { get; set; }
    }
}
