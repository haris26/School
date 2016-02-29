namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Engagements", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Engagements", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "Phone", c => c.String());
            AlterColumn("dbo.People", "Email", c => c.String());
        }
    }
}
