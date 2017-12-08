using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
 public   class Yorum
    {
        public int YorumID { get; set; }
        public string KullaniciAd { get; set; }
        public string ResimURL { get; set; }
        public string YorumBaslik { get; set; }
        public string YorumIcerik { get; set; }
        public int YorumPuan { get; set; }
        public int DiscriptionID { get; set; }
        public string Discription { get; set; }


    }
}
