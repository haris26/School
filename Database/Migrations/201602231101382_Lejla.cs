namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lejla : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ParentEvent_Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "ParentEvent_Id" });
            CreateTable(
                "dbo.ExtendedEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RepeatUntil = c.DateTime(nullable: false),
                        RepeatingType = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                        ParentEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.ParentEvent_Id)
                .Index(t => t.ParentEvent_Id);
            
            AddColumn("dbo.Assets", "Model", c => c.String());
            AddColumn("dbo.Assets", "DateOfTrade", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeEducations", "Reference", c => c.String());
            AddColumn("dbo.Requests", "RequestDescription", c => c.String());
            AlterColumn("dbo.EmployeeSkills", "Experience", c => c.Int());
            DropColumn("dbo.Educations", "Reference");
            DropColumn("dbo.Events", "RepeatUntil");
            DropColumn("dbo.Events", "RepeatingType");
            DropColumn("dbo.Events", "Frequency");
            DropColumn("dbo.Events", "ParentEvent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ParentEvent_Id", c => c.Int());
            AddColumn("dbo.Events", "Frequency", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "RepeatingType", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "RepeatUntil", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "Reference", c => c.String());
            DropForeignKey("dbo.ExtendedEvents", "ParentEvent_Id", "dbo.Events");
            DropIndex("dbo.ExtendedEvents", new[] { "ParentEvent_Id" });
            AlterColumn("dbo.EmployeeSkills", "Experience", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "RequestDescription");
            DropColumn("dbo.EmployeeEducations", "Reference");
            DropColumn("dbo.Assets", "DateOfTrade");
            DropColumn("dbo.Assets", "Model");
            DropTable("dbo.ExtendedEvents");
            CreateIndex("dbo.Events", "ParentEvent_Id");
            AddForeignKey("dbo.Events", "ParentEvent_Id", "dbo.Events", "Id");
        }
    }
}
