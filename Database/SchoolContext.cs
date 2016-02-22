using System.Data.Entity;

namespace Database
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(): base()
        { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Day> Days { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======

        //public DbSet<CategoryDetail> Categories { get; set; }

>>>>>>> delta
=======
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
        public DbSet<Detail> Details { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Event> Events{ get; set; }
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