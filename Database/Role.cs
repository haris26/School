using System.Collections.Generic;

namespace Database
{
    public class Role
    {
        public Role()
        {
            Roles = new List<Engagement>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Team { get; set; }
        public bool System { get; set; }

        public IList<Engagement> Roles { get; set; }
    }
}
