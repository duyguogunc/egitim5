namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurulum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EKitaps",
                c => new
                    {
                        EKitapID = c.Int(nullable: false, identity: true),
                        EKitapBaslik = c.String(nullable: false, maxLength: 20),
                        EKitapIcerik = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EKitapID);
            
            CreateTable(
                "dbo.Konus",
                c => new
                    {
                        KonuID = c.Int(nullable: false, identity: true),
                        KonuBaslik = c.String(nullable: false, maxLength: 30),
                        KonuIcerik = c.String(nullable: false),
                        UstKonu_KonuID = c.Int(),
                    })
                .PrimaryKey(t => t.KonuID)
                .ForeignKey("dbo.Konus", t => t.UstKonu_KonuID)
                .Index(t => t.UstKonu_KonuID);
            
            CreateTable(
                "dbo.Makales",
                c => new
                    {
                        MakaleID = c.Int(nullable: false, identity: true),
                        makaleBaslik = c.String(nullable: false),
                        makaleTur = c.String(),
                        makaleİcerik = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MakaleID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        VideoIsim = c.String(nullable: false, maxLength: 25),
                        VideoURL = c.String(),
                        Aciklama = c.String(nullable: false, maxLength: 100),
                        IzlenmeSayisi = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VideoID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdSoyad = c.String(nullable: false),
                        Meslek = c.String(),
                        WebSitesi = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        Resim = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KonuEKitaps",
                c => new
                    {
                        Konu_KonuID = c.Int(nullable: false),
                        EKitap_EKitapID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Konu_KonuID, t.EKitap_EKitapID })
                .ForeignKey("dbo.Konus", t => t.Konu_KonuID, cascadeDelete: true)
                .ForeignKey("dbo.EKitaps", t => t.EKitap_EKitapID, cascadeDelete: true)
                .Index(t => t.Konu_KonuID)
                .Index(t => t.EKitap_EKitapID);
            
            CreateTable(
                "dbo.MakaleKonus",
                c => new
                    {
                        Makale_MakaleID = c.Int(nullable: false),
                        Konu_KonuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_MakaleID, t.Konu_KonuID })
                .ForeignKey("dbo.Makales", t => t.Makale_MakaleID, cascadeDelete: true)
                .ForeignKey("dbo.Konus", t => t.Konu_KonuID, cascadeDelete: true)
                .Index(t => t.Makale_MakaleID)
                .Index(t => t.Konu_KonuID);
            
            CreateTable(
                "dbo.VideoKonus",
                c => new
                    {
                        Video_VideoID = c.Int(nullable: false),
                        Konu_KonuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_VideoID, t.Konu_KonuID })
                .ForeignKey("dbo.Videos", t => t.Video_VideoID, cascadeDelete: true)
                .ForeignKey("dbo.Konus", t => t.Konu_KonuID, cascadeDelete: true)
                .Index(t => t.Video_VideoID)
                .Index(t => t.Konu_KonuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.VideoKonus", "Konu_KonuID", "dbo.Konus");
            DropForeignKey("dbo.VideoKonus", "Video_VideoID", "dbo.Videos");
            DropForeignKey("dbo.MakaleKonus", "Konu_KonuID", "dbo.Konus");
            DropForeignKey("dbo.MakaleKonus", "Makale_MakaleID", "dbo.Makales");
            DropForeignKey("dbo.KonuEKitaps", "EKitap_EKitapID", "dbo.EKitaps");
            DropForeignKey("dbo.KonuEKitaps", "Konu_KonuID", "dbo.Konus");
            DropForeignKey("dbo.Konus", "UstKonu_KonuID", "dbo.Konus");
            DropIndex("dbo.VideoKonus", new[] { "Konu_KonuID" });
            DropIndex("dbo.VideoKonus", new[] { "Video_VideoID" });
            DropIndex("dbo.MakaleKonus", new[] { "Konu_KonuID" });
            DropIndex("dbo.MakaleKonus", new[] { "Makale_MakaleID" });
            DropIndex("dbo.KonuEKitaps", new[] { "EKitap_EKitapID" });
            DropIndex("dbo.KonuEKitaps", new[] { "Konu_KonuID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Konus", new[] { "UstKonu_KonuID" });
            DropTable("dbo.VideoKonus");
            DropTable("dbo.MakaleKonus");
            DropTable("dbo.KonuEKitaps");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Videos");
            DropTable("dbo.Makales");
            DropTable("dbo.Konus");
            DropTable("dbo.EKitaps");
        }
    }
}
