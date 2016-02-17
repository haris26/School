namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sule20160216 : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        EntryStatus = c.Int(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
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
                        BirthDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Engagements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        CalendarId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        WorkTime = c.Double(nullable: false),
                        BillTime = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
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
                "dbo.Histories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssetID = c.Int(nullable: false),
                        EventBegin = c.DateTime(nullable: false),
                        EventEnd = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        requestType = c.Int(nullable: false),
                        RequestMessage = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                        RequestStatus = c.String(),
                        AssetId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.SkillCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Engagements", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Engagements", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Engagements", "Person_Id", "dbo.People");
            DropIndex("dbo.Engagements", new[] { "Team_Id" });
            DropIndex("dbo.Engagements", new[] { "Role_Id" });
            DropIndex("dbo.Engagements", new[] { "Person_Id" });
            DropIndex("dbo.Calendars", new[] { "Person_Id" });
            DropTable("dbo.Tools");
            DropTable("dbo.TimeCategories");
            DropTable("dbo.SkillCategories");
            DropTable("dbo.Resources");
            DropTable("dbo.Requests");
            DropTable("dbo.ProjectSkills");
            DropTable("dbo.Histories");
            DropTable("dbo.Events");
            DropTable("dbo.EmployeeSkills");
            DropTable("dbo.Details");
            DropTable("dbo.Categories");
            DropTable("dbo.Teams");
            DropTable("dbo.Roles");
            DropTable("dbo.Engagements");
            DropTable("dbo.People");
            DropTable("dbo.Calendars");
            DropTable("dbo.Assets");
        }
    }
}
