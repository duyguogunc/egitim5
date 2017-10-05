namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EKitaps", "EKitapURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EKitaps", "EKitapURL");
        }
    }
}
