﻿using System.Data.Entity;

namespace Database
{
    class SchoolContext: DbContext
    {
        public SchoolContext(): base()
        { }

        public DbSet<Assets> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Events> Events{ get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams{ get; set; }
    }
}