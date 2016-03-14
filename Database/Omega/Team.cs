
﻿using Database.Omega;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;



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


        [NameControl]
        public string Name { get; set; }                    // Team (project) name
        public string Description { get; set; }             // Description
        public ProjectType Type { get; set; }               // Type (absence, internal, external)

        public virtual ICollection<Engagement> Roles { get; set; }
        public virtual ICollection<Person> Members { get; set; }
        public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}
