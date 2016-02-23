using System.Collections.Generic;
using System.Collections.ObjectModel;

// WORKFORCE ROSTER
namespace Database
{
//  list of project (teams)
    public class Team
    {
        public Team()
        {
            Roles = new Collection<Engagement>();
            Members = new Collection<Person>();
            ProjectSkills = new Collection<ProjectSkill>();
        }

        public int Id { get; set; }                         // Identity[1]
        public string Name { get; set; }                    // Team (project) name
        public string Description { get; set; }             // Description
        public ProjectType Type { get; set; }               // Type (absence, internal, external)

        public ICollection<Engagement> Roles { get; set; }
        public ICollection<Person> Members { get; set; }
        public ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}
