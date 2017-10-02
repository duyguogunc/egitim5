﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
  public class Repository
    {
      public class VideoRep : BaseRepository<Video> { }
      public class MakaleRep : BaseRepository<Makale> { }
      public class EkitapRep : BaseRepository<EKitap> { }
    }
}