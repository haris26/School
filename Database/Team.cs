using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Database
{
    public class Team
    {
        public Team()
        {
            Roles = new Collection<Engagement>();
            Members = new Collection<Person>();
            ProjectSkills = new Collection<ProjectSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Type { get; set; }

        public ICollection<Engagement> Roles { get; set; }
        public ICollection<Person> Members { get; set; }
        public ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}
