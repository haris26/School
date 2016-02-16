using System.Collections.Generic;

namespace Database
{
    public class Team
    {
        public Team()
        {
            Roles = new List<Engagement>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Type { get; set; }

        public IList<Engagement> Roles { get; set; }
        public IList<Person> Members { get; set; }
    }
}
