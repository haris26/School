using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace SkillsLibrary.Models
{
    public class ProjectSkills
    {
        public ProjectSkills()
        {
            Skills = new List<ProjectSkillModel>();
        }

        public Team Team { get; set; }
        public IList<ProjectSkillModel> Skills { get; set; }
    }
}