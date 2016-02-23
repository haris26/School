namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dzanan : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Details", "Flag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "Flag", c => c.Boolean(nullable: false));
        }
    }
}
