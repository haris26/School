using System.Data.Entity;

namespace Database
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(): base()
        { }
        // ALPHA
        public DbSet<Education> Educations { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        // BETA
        public DbSet<Characteristic> CategoryCharacteristics { get; set; }
        public DbSet<CharacteristicName> CharacteristicNames { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ExtendedEvent> ExtendedEvents { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceCategory> ResourceCategories { get; set; }
        // CHARLIE
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetCategory> AssetCategory { get; set; }
        public DbSet<AssetChar> AssetCharacteristics { get; set; }
        public DbSet<AssetCharacteristicNames> AssetCharNames { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Request> Requests { get; set; }
        // DELTA
        public DbSet<Day> Days { get; set; }
        public DbSet<Detail> Details { get; set; }
        // OMEGA
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams{ get; set; }

        //TOKEN
        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }
    }
}