using System.Data.Entity;

namespace Database
{
    public class SchoolContext: DbContext
    {
<<<<<<< HEAD
        public SchoolContext(): base(/*"name=School"*/)
=======
        public SchoolContext(): base()
>>>>>>> d91397fbf5ea5f54e285b8f436de6ec4907ef9c7
        { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Event> Events{ get; set; }
        public DbSet<ExtendedEvent> ExtendedEvents { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams{ get; set; }
        public DbSet<AssetCategory> AssetCategory { get; set; }
        public DbSet<AssetCharacteristicNames> AssetCharNames { get; set; }
        public DbSet<AssetChar> AssetCharacteristics  { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<Characteristic> CategoryCharacteristics { get; set; }
        public DbSet<ResourceCategory> ResourceCategories { get; set; }
        public DbSet<CharacteristicName> CharacteristicNames { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
    }
}