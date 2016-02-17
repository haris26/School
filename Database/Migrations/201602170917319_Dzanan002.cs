namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dzanan002 : DbMigration
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
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Category = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Image = c.String(),
                        Phone = c.String(),
                        Address_ZipCode = c.String(),
                        Address_Town = c.String(),
                        Address_Road = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Tool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Employee_Id)
                .ForeignKey("dbo.Tools", t => t.Tool_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Tool_Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkillCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.SkillCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Team_Id = c.Int(),
                        Tool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .ForeignKey("dbo.Tools", t => t.Tool_Id)
                .Index(t => t.Team_Id)
                .Index(t => t.Tool_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Engagements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Time = c.Int(nullable: false),
                        Person_Id = c.Int(),
                        Role_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team = c.Boolean(nullable: false),
                        System = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        EntryStatus = c.Int(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkTime = c.Double(nullable: false),
                        BillTime = c.Double(nullable: false),
                        Description = c.String(),
                        Day_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Day_Id)
                .Index(t => t.Team_Id);
            
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
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventBegin = c.DateTime(nullable: false),
                        EventEnd = c.DateTime(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        Asset_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.Asset_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Asset_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        requestType = c.Int(nullable: false),
                        RequestMessage = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Asset_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.Asset_Id)
                .ForeignKey("dbo.People", t => t.User_Id)
                .Index(t => t.Asset_Id)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "User_Id", "dbo.People");
            DropForeignKey("dbo.Requests", "Asset_Id", "dbo.Assets");
            DropForeignKey("dbo.Histories", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Histories", "Asset_Id", "dbo.Assets");
            DropForeignKey("dbo.Events", "User_Id", "dbo.People");
            DropForeignKey("dbo.Events", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Events", "ParentEvent_Id", "dbo.Events");
            DropForeignKey("dbo.EmployeeEducations", "Employee_Id", "dbo.People");
            DropForeignKey("dbo.EmployeeEducations", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.Days", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Details", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Details", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.CategoryDetails", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Assets", "User_Id", "dbo.People");
            DropForeignKey("dbo.ProjectSkills", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.Engagements", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Engagements", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Engagements", "Person_Id", "dbo.People");
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
            DropIndex("dbo.Details", new[] { "Team_Id" });
            DropIndex("dbo.Details", new[] { "Day_Id" });
            DropIndex("dbo.Days", new[] { "Person_Id" });
            DropIndex("dbo.CategoryDetails", new[] { "Resource_Id" });
            DropIndex("dbo.Engagements", new[] { "Team_Id" });
            DropIndex("dbo.Engagements", new[] { "Role_Id" });
            DropIndex("dbo.Engagements", new[] { "Person_Id" });
            DropIndex("dbo.ProjectSkills", new[] { "Tool_Id" });
            DropIndex("dbo.ProjectSkills", new[] { "Team_Id" });
            DropIndex("dbo.Tools", new[] { "Category_Id" });
            DropIndex("dbo.EmployeeSkills", new[] { "Tool_Id" });
            DropIndex("dbo.EmployeeSkills", new[] { "Employee_Id" });
            DropIndex("dbo.Assets", new[] { "User_Id" });
            DropTable("dbo.TeamPersons");
            DropTable("dbo.Requests");
            DropTable("dbo.Histories");
            DropTable("dbo.Events");
            DropTable("dbo.EmployeeEducations");
            DropTable("dbo.Educations");
            DropTable("dbo.Details");
            DropTable("dbo.Days");
            DropTable("dbo.Resources");
            DropTable("dbo.CategoryDetails");
            DropTable("dbo.Roles");
            DropTable("dbo.Engagements");
            DropTable("dbo.Teams");
            DropTable("dbo.ProjectSkills");
            DropTable("dbo.SkillCategories");
            DropTable("dbo.Tools");
            DropTable("dbo.EmployeeSkills");
            DropTable("dbo.People");
            DropTable("dbo.Assets");
        }
    }
}
