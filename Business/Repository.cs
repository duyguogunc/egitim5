using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class VideoRep : BaseRepository<Video> { }
    public class MakaleRep : BaseRepository<Makale> { }
    public class EkitapRep : BaseRepository<EKitap> { }
    public class KonuRep : BaseRepository<Konu> { }

    public class YorumRep : BaseRepository<Yorum> { }

}
