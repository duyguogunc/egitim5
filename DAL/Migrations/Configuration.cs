namespace DAL.Migrations
{
    using Egitim5.Models;
    using Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.MyContext context)
        {
            //veritabanýnda kullanýcý yoksa
            if (context.Users.Count() == 0)
            {
                #region kullaniciEkle
                UserStore<Kullanici> str = new UserStore<Kullanici>(context);

                UserManager<Kullanici> mng = new UserManager<Kullanici>(str);

                var admin = new Kullanici() { Email = "admin@yaz5.com", UserName = "admin@yaz5.com" };
                var videomoderator = new Kullanici() { Email = "videomoderator@yaz5.com", UserName = "videomoderator@yaz5.com" };
                var makalemoderator = new Kullanici() { Email = "makalemoderator@yaz5.com", UserName = "makalemoderator@yaz5.com" };
                var ekitapmoderator = new Kullanici() { Email = "ekitapmoderator@yaz5.com", UserName = "ekitapmoderator@yaz5.com" };


                mng.Create(admin, "Aa123456!"); //2. parametre þifresi
                mng.Create(videomoderator, "Aa123456!"); 
                mng.Create(makalemoderator, "Aa123456!"); 
                mng.Create(ekitapmoderator, "Aa123456!"); 
                #endregion

                #region rolleriOlustur
                context.Roles.Add(new IdentityRole() { Name = "Admin" });
                context.Roles.Add(new IdentityRole() { Name = "VideoModerator" });
                context.Roles.Add(new IdentityRole() { Name = "MakaleModerator" });
                context.Roles.Add(new IdentityRole() { Name = "EKitapModerator" });
                context.SaveChanges();
                #endregion

                #region kullanicilariRollereEkle
                mng.AddToRole(admin.Id, "Admin");
                mng.AddToRole(videomoderator.Id, "VideoModerator");
                mng.AddToRole(makalemoderator.Id, "MakaleModerator");
                mng.AddToRole(ekitapmoderator.Id, "EKitapModerator");
                #endregion
            }
        }
    }
}
