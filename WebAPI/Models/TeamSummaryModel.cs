using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TeamSkillsSummary
    {
        public string CategoryName { get; set; }
        public int NumberOfSkills { get; set; }
        public double AvgSkillLevel { get; set; }
        public int MyProperty { get; set; }
    }

    public class TeamSummaryModel
    {
        public TeamSummaryModel()
        {
            Skills = new List<TeamSkillsSummary>();
        }
        public string Name { get; set; }
        public int PeopleInTeam { get; set; }
        public IList<TeamSkillsSummary> Skills { get; set; }
    }
}