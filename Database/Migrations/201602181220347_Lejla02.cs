namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lejla02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetCharacteristicNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AssetCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetCategories", t => t.AssetCategory_Id)
                .Index(t => t.AssetCategory_Id);
            
            AddColumn("dbo.Assets", "AssetCategory_Id", c => c.Int());
            CreateIndex("dbo.Assets", "AssetCategory_Id");
            AddForeignKey("dbo.Assets", "AssetCategory_Id", "dbo.AssetCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "AssetCategory_Id", "dbo.AssetCategories");
            DropForeignKey("dbo.AssetCharacteristicNames", "AssetCategory_Id", "dbo.AssetCategories");
            DropIndex("dbo.AssetCharacteristicNames", new[] { "AssetCategory_Id" });
            DropIndex("dbo.Assets", new[] { "AssetCategory_Id" });
            DropColumn("dbo.Assets", "AssetCategory_Id");
            DropTable("dbo.AssetCharacteristicNames");
            DropTable("dbo.AssetCategories");
        }
    }
}
