using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public abstract class Icerik : SEOIcerik
    {
        [DisplayName("Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Kısa Açıklama")]
        public string KisaAciklama { get; set; }
        public virtual List<Konu> Konular { get; set; }
    }

    public abstract class SEOIcerik
    {
        [DisplayName("SEO Title")]
        public string Title { get; set; }
        [DisplayName("SEO Description")]
        public string Description { get; set; }
        [DisplayName("SEO Keywords")]
        public string Keywords { get; set; }
    }
}
