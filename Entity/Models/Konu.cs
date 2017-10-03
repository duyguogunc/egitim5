using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
  public  class Konu
    {
        [Key]
        public int KonuID { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = ("En fazla 30 karakter yazılabilir."))]
        public string KonuBaslik { get; set; }
        [Required]
        public string KonuIcerik { get; set; }
    }
}
