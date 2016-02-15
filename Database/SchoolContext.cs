using System.Data.Entity;

namespace Database
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(): base("School")
        { }

        public DbSet<Assets> Assets { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<TimeCategory> TimeCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Events> Events{ get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams{ get; set; }
    }
}