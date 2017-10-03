using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class MyContext :IdentityDbContext<Kullanici>
    {
        public virtual DbSet<Video> Videolar { get; set; }
        public virtual DbSet<Makale> Makaleler { get; set; }
        public virtual DbSet<EKitap> EKitaplar { get; set; }
        public virtual DbSet<Kullanici> Kullanıcılar { get; set; }
    }
}
