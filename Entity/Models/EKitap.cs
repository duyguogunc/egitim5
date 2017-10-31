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
    public class EKitap : Icerik
    {
        [Key]
        public int EKitapID { get; set; }
        [Required]
        public string EKitapIcerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string EKitapURL { get; set; }
        public EKitap()
        {
            EklenmeTarihi = DateTime.Now;
        }
    }
}
