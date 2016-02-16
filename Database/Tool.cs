using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Tool
    {
        public Tool()
        {
            EmployeeSkills = new Collection<EmployeeSkill>();
            ProjectSkills = new Collection<ProjectSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual SkillCategory Category { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}
