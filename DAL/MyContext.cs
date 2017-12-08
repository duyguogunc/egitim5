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
        public virtual DbSet<Oylama> Oylamalar { get; set; }
        public virtual DbSet<Konu> Konular { get; set; }
<<<<<<< HEAD
        public virtual DbSet<Yorum> Yorumlar { get; set; }
=======
        public virtual DbSet<Sikayet> Sikayetler { get; set; }
>>>>>>> 364cedb898becf01efb4579e8ca09ab8e803274f
    }
}

