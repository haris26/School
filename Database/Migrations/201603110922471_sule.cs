
namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetCategories", "Asset_Id", c => c.Int());
            AlterColumn("dbo.SkillCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Educations", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.AssetCategories", "Asset_Id");
            AddForeignKey("dbo.AssetCategories", "Asset_Id", "dbo.Assets", "Id");
            DropColumn("dbo.Assets", "Type");
            DropColumn("dbo.Assets", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "Description", c => c.String());
            AddColumn("dbo.Assets", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.AssetCategories", "Asset_Id", "dbo.Assets");
            DropIndex("dbo.AssetCategories", new[] { "Asset_Id" });
            AlterColumn("dbo.Educations", "Name", c => c.String());
            AlterColumn("dbo.SkillCategories", "Name", c => c.String());
            DropColumn("dbo.AssetCategories", "Asset_Id");
        }
    }
}
