namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurulum : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Konus", name: "UstKonu_KonuID", newName: "UstKonuID");
            RenameIndex(table: "dbo.Konus", name: "IX_UstKonu_KonuID", newName: "IX_UstKonuID");
            AddColumn("dbo.EKitaps", "Baslik", c => c.String());
            AddColumn("dbo.EKitaps", "KisaAciklama", c => c.String());
            AddColumn("dbo.EKitaps", "Title", c => c.String());
            AddColumn("dbo.EKitaps", "Description", c => c.String());
            AddColumn("dbo.EKitaps", "Keywords", c => c.String());
            AddColumn("dbo.Makales", "MakaleIcerik", c => c.String());
            AddColumn("dbo.Makales", "Baslik", c => c.String());
            AddColumn("dbo.Makales", "KisaAciklama", c => c.String());
            AddColumn("dbo.Makales", "Title", c => c.String());
            AddColumn("dbo.Makales", "Description", c => c.String());
            AddColumn("dbo.Makales", "Keywords", c => c.String());
            AddColumn("dbo.Videos", "Baslik", c => c.String());
            AddColumn("dbo.Videos", "KisaAciklama", c => c.String());
            AddColumn("dbo.Videos", "Title", c => c.String());
            AddColumn("dbo.Videos", "Description", c => c.String());
            AddColumn("dbo.Videos", "Keywords", c => c.String());
            AlterColumn("dbo.Konus", "KonuBaslik", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "DogumTarihi", c => c.DateTime());
            DropColumn("dbo.EKitaps", "EKitapBaslik");
            DropColumn("dbo.Makales", "makaleBaslik");
            DropColumn("dbo.Makales", "makaleTur");
            DropColumn("dbo.Makales", "makaleİcerik");
            DropColumn("dbo.Videos", "VideoIsim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "VideoIsim", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Makales", "makaleİcerik", c => c.String());
            AddColumn("dbo.Makales", "makaleTur", c => c.String());
            AddColumn("dbo.Makales", "makaleBaslik", c => c.String(nullable: false));
            AddColumn("dbo.EKitaps", "EKitapBaslik", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "DogumTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Konus", "KonuBaslik", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Videos", "Keywords");
            DropColumn("dbo.Videos", "Description");
            DropColumn("dbo.Videos", "Title");
            DropColumn("dbo.Videos", "KisaAciklama");
            DropColumn("dbo.Videos", "Baslik");
            DropColumn("dbo.Makales", "Keywords");
            DropColumn("dbo.Makales", "Description");
            DropColumn("dbo.Makales", "Title");
            DropColumn("dbo.Makales", "KisaAciklama");
            DropColumn("dbo.Makales", "Baslik");
            DropColumn("dbo.Makales", "MakaleIcerik");
            DropColumn("dbo.EKitaps", "Keywords");
            DropColumn("dbo.EKitaps", "Description");
            DropColumn("dbo.EKitaps", "Title");
            DropColumn("dbo.EKitaps", "KisaAciklama");
            DropColumn("dbo.EKitaps", "Baslik");
            RenameIndex(table: "dbo.Konus", name: "IX_UstKonuID", newName: "IX_UstKonu_KonuID");
            RenameColumn(table: "dbo.Konus", name: "UstKonuID", newName: "UstKonu_KonuID");
        }
    }
}
