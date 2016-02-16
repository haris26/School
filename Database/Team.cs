using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Database
{
    public class Team
    {
        public Team()
        {
            Roles = new List<Engagement>();
            ProjectSkills = new Collection<ProjectSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Type { get; set; }

        public IList<Engagement> Roles { get; set; }
<<<<<<< HEAD
        public IList<Person> Members { get; set; }
=======
        public ICollection<ProjectSkill> ProjectSkills { get; set; }

>>>>>>> d0bb89dd3fc3a3487c01103da40786699bf28379
    }
}
