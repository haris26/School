namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lejla150 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetCategories", "Asset_Id", c => c.Int());
            CreateIndex("dbo.AssetCategories", "Asset_Id");
            AddForeignKey("dbo.AssetCategories", "Asset_Id", "dbo.Assets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetCategories", "Asset_Id", "dbo.Assets");
            DropIndex("dbo.AssetCategories", new[] { "Asset_Id" });
            DropColumn("dbo.AssetCategories", "Asset_Id");
        }
    }
}
