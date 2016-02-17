namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class irma002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Vendor = c.String(),
                        Price = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CategoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Reference = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Education_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.Education_Id)
                .ForeignKey("dbo.People", t => t.Employee_Id)
                .Index(t => t.Education_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        EventStart = c.DateTime(nullable: false),
                        EventEnd = c.DateTime(nullable: false),
                        RepeatUntil = c.DateTime(nullable: false),
                        RepeatingType = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                        ParentEvent_Id = c.Int(),
                        Resource_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.ParentEvent_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.People", t => t.User_Id)
                .Index(t => t.ParentEvent_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TeamPersons",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Person_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.Person_Id);
            
            AddColumn("dbo.Engagements", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Engagements", "EndDate", c => c.DateTime());
            AddColumn("dbo.Details", "Description", c => c.String());
            AddColumn("dbo.Details", "Calendar_Id", c => c.Int());
            AddColumn("dbo.Details", "Team_Id", c => c.Int());
            AddColumn("dbo.EmployeeSkills", "Employee_Id", c => c.Int());
            AddColumn("dbo.EmployeeSkills", "Tool_Id", c => c.Int());
            AddColumn("dbo.Histories", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Histories", "Asset_Id", c => c.Int());
            AddColumn("dbo.Histories", "Person_Id", c => c.Int());
            AddColumn("dbo.ProjectSkills", "Team_Id", c => c.Int());
            AddColumn("dbo.ProjectSkills", "Tool_Id", c => c.Int());
            AddColumn("dbo.Requests", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "Asset_Id", c => c.Int());
            AddColumn("dbo.Requests", "User_Id", c => c.Int());
            AddColumn("dbo.Tools", "Category_Id", c => c.Int());
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "StartDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.EmployeeSkills", "Employee_Id");
            CreateIndex("dbo.EmployeeSkills", "Tool_Id");
            CreateIndex("dbo.Tools", "Category_Id");
            CreateIndex("dbo.ProjectSkills", "Team_Id");
            CreateIndex("dbo.ProjectSkills", "Tool_Id");
            CreateIndex("dbo.Details", "Calendar_Id");
            CreateIndex("dbo.Details", "Team_Id");
            CreateIndex("dbo.Histories", "Asset_Id");
            CreateIndex("dbo.Histories", "Person_Id");
            CreateIndex("dbo.Requests", "Asset_Id");
            CreateIndex("dbo.Requests", "User_Id");
            AddForeignKey("dbo.EmployeeSkills", "Employee_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Tools", "Category_Id", "dbo.SkillCategories", "Id");
            AddForeignKey("dbo.EmployeeSkills", "Tool_Id", "dbo.Tools", "Id");
            AddForeignKey("dbo.ProjectSkills", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.ProjectSkills", "Tool_Id", "dbo.Tools", "Id");
            AddForeignKey("dbo.Details", "Calendar_Id", "dbo.Calendars", "Id");
            AddForeignKey("dbo.Details", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Histories", "Asset_Id", "dbo.Assets", "Id");
            AddForeignKey("dbo.Histories", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Requests", "Asset_Id", "dbo.Assets", "Id");
            AddForeignKey("dbo.Requests", "User_Id", "dbo.People", "Id");
            DropColumn("dbo.Calendars", "EmployeeId");
            DropColumn("dbo.Details", "CategoryId");
            DropColumn("dbo.Details", "CalendarId");
            DropColumn("dbo.Details", "ProjectId");
            DropColumn("dbo.Details", "Status");
            DropColumn("dbo.EmployeeSkills", "ToolId");
            DropColumn("dbo.EmployeeSkills", "EmployeeId");
            DropColumn("dbo.Histories", "AssetID");
            DropColumn("dbo.ProjectSkills", "ToolId");
            DropColumn("dbo.ProjectSkills", "TeamId");
            DropColumn("dbo.Requests", "RequestStatus");
            DropColumn("dbo.Requests", "AssetId");
            DropColumn("dbo.Requests", "EmployeeId");
            DropColumn("dbo.Tools", "Category");
            DropTable("dbo.Assets");
            DropTable("dbo.Categories");
            DropTable("dbo.Events");
            DropTable("dbo.TimeCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        EventTitle = c.String(),
                        EventStart = c.DateTime(nullable: false),
                        EventEnd = c.DateTime(nullable: false),
                        RepeatUntil = c.DateTime(nullable: false),
                        RepeatingType = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Vendor = c.String(),
                        Price = c.Double(nullable: false),
                        EmployeeID = c.String(),
                    })
                .PrimaryKey(t => t.AssetId);
            
            AddColumn("dbo.Tools", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "AssetId", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "RequestStatus", c => c.String());
            AddColumn("dbo.ProjectSkills", "TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectSkills", "ToolId", c => c.Int(nullable: false));
            AddColumn("dbo.Histories", "AssetID", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeSkills", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeSkills", "ToolId", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "CalendarId", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Calendars", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Requests", "User_Id", "dbo.People");
            DropForeignKey("dbo.Requests", "Asset_Id", "dbo.Assets");
            DropForeignKey("dbo.Histories", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Histories", "Asset_Id", "dbo.Assets");
            DropForeignKey("dbo.Events", "User_Id", "dbo.People");
            DropForeignKey("dbo.Events", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Events", "ParentEvent_Id", "dbo.Events");
            DropForeignKey("dbo.EmployeeEducations", "Employee_Id", "dbo.People");
            DropForeignKey("dbo.EmployeeEducations", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.CategoryDetails", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Details", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Details", "Calendar_Id", "dbo.Calendars");
            DropForeignKey("dbo.Assets", "User_Id", "dbo.People");
            DropForeignKey("dbo.ProjectSkills", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.ProjectSkills", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.TeamPersons", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.EmployeeSkills", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.Tools", "Category_Id", "dbo.SkillCategories");
            DropForeignKey("dbo.EmployeeSkills", "Employee_Id", "dbo.People");
            DropIndex("dbo.TeamPersons", new[] { "Person_Id" });
            DropIndex("dbo.TeamPersons", new[] { "Team_Id" });
            DropIndex("dbo.Requests", new[] { "User_Id" });
            DropIndex("dbo.Requests", new[] { "Asset_Id" });
            DropIndex("dbo.Histories", new[] { "Person_Id" });
            DropIndex("dbo.Histories", new[] { "Asset_Id" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropIndex("dbo.Events", new[] { "Resource_Id" });
            DropIndex("dbo.Events", new[] { "ParentEvent_Id" });
            DropIndex("dbo.EmployeeEducations", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeEducations", new[] { "Education_Id" });
            DropIndex("dbo.CategoryDetails", new[] { "Resource_Id" });
            DropIndex("dbo.Details", new[] { "Team_Id" });
            DropIndex("dbo.Details", new[] { "Calendar_Id" });
            DropIndex("dbo.ProjectSkills", new[] { "Tool_Id" });
            DropIndex("dbo.ProjectSkills", new[] { "Team_Id" });
            DropIndex("dbo.Tools", new[] { "Category_Id" });
            DropIndex("dbo.EmployeeSkills", new[] { "Tool_Id" });
            DropIndex("dbo.EmployeeSkills", new[] { "Employee_Id" });
            DropIndex("dbo.Assets", new[] { "User_Id" });
            AlterColumn("dbo.People", "StartDate", c => c.DateTime());
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Tools", "Category_Id");
            DropColumn("dbo.Requests", "User_Id");
            DropColumn("dbo.Requests", "Asset_Id");
            DropColumn("dbo.Requests", "Status");
            DropColumn("dbo.ProjectSkills", "Tool_Id");
            DropColumn("dbo.ProjectSkills", "Team_Id");
            DropColumn("dbo.Histories", "Person_Id");
            DropColumn("dbo.Histories", "Asset_Id");
            DropColumn("dbo.Histories", "Status");
            DropColumn("dbo.EmployeeSkills", "Tool_Id");
            DropColumn("dbo.EmployeeSkills", "Employee_Id");
            DropColumn("dbo.Details", "Team_Id");
            DropColumn("dbo.Details", "Calendar_Id");
            DropColumn("dbo.Details", "Description");
            DropColumn("dbo.Engagements", "EndDate");
            DropColumn("dbo.Engagements", "StartDate");
            DropTable("dbo.TeamPersons");
            DropTable("dbo.Events");
            DropTable("dbo.EmployeeEducations");
            DropTable("dbo.Educations");
            DropTable("dbo.CategoryDetails");
            DropTable("dbo.Assets");
        }
    }
}
