using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class KonuViewModel
    {
        public int KonuID { get; set; }
        public bool SeciliMi { get; set; }
        public string KonuBaslik { get; set; }
    }
}
