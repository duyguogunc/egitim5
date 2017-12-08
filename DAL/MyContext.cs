using Entity;
using Entity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace DAL
{
    public class MyContext : IdentityDbContext<Kullanici>
    {
        public static MyContext db;
        public MyContext() : base("DefaultConnection")
        {
            
        }

        public virtual DbSet<Video> Videolar { get; set; }
        public virtual DbSet<Makale> Makaleler { get; set; }
        public virtual DbSet<EKitap> EKitaplar { get; set; }
        //public virtual DbSet<Kullanici> Kullanıcılar { get; set; }
        public virtual DbSet<Konu> Konular { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
    }
}

