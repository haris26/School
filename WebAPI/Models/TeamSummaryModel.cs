using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class RequiredSkill
    {
        public string Skill { get; set; }
        public int Level { get; set; }
    }

    public class TeamSummaryModel
    {
        public TeamSummaryModel()
        {
            Skills = new List<CategorySkillsSummary>();
            RequiredSkills = new List<RequiredSkill>();
            Members = new List<PersonModel>();
        }

        public string Name { get; set; }
        public int PeopleInTeam { get; set; }
        public IList<PersonModel> Members { get; set; }
        public IList<RequiredSkill> RequiredSkills { get; set; }
        public IList<CategorySkillsSummary> Skills { get; set; }
    }
}