using System.Collections.Generic;

// WORKFORCE ROSTER
namespace Database
{
//  List of roles performed by people on projects
    public class Role
    {
        public Role()
        {
            Roles = new List<Engagement>();
        }

        public int Id { get; set; }                 // Identity[1]
        public string Name { get; set; }            // Name of the role
        public bool Team { get; set; }              // Is it team role? [like developer, qa, team lead...]
        public bool System { get; set; }            // Is it system role? [like admin, user, team lead...]

        public IList<Engagement> Roles { get; set; }
    }
}
