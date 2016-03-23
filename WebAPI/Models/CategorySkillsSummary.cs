using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CategorySkillsSummary
    {
        public CategorySkillsSummary()
        {
            Skills = new Dictionary<int, TeamSkillSummary>();
            EmployeeSkillAverage = new Dictionary<int, double>();
            AvailableSkills = new List<AvailableSkill>();
        }

        public string CategoryName { get; set; }
        public int NumberOfSkills { get; set; }
        public double AvgSkillLevel { get; set; }
        public IList<AvailableSkill> AvailableSkills { get; set; }
        public IDictionary<int, TeamSkillSummary> Skills { get; set; }  //key is the id of a skill
        public IDictionary<int, double> EmployeeSkillAverage { get; set; } //key is the id of a team member
    }
}