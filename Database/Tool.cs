using System.Collections.Generic;
using System.Collections.ObjectModel;

// SKILLS LIBRARY
namespace Database
{
//  Set of tools
    public class Tool
    {
        public Tool()
        {
            EmployeeSkills = new Collection<EmployeeSkill>();
            ProjectSkills = new Collection<ProjectSkill>();
        }

        public int Id { get; set; }                                 // Identity[1]
        public string Name { get; set; }                            // Name

        public virtual SkillCategory Category { get; set; }         // Category [programming language, project management, version control...]

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}
