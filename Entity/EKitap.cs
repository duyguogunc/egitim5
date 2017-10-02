using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class EKitap
    {
        [Key]
        public int EKitapID { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage =("En fazla 20 karakter yazılabilir."))]
        public string EKitapBaslik { get; set; }
        [Required]
        public string EKitapIcerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public EKitap()
        {
            EklenmeTarihi = DateTime.Now;
        }
    }
}
