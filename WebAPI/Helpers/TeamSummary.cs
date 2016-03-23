using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using Database;

namespace WebAPI.Helpers
{
    public class TeamSummary
    {
        public static TeamSummaryModel Create(Team team)
        {
            TeamSummaryModel teamSummary = new TeamSummaryModel()
            {
                Name = team.Name,
                PeopleInTeam = team.Members.Count()
            };

            teamSummary.RequiredSkills = team.ProjectSkills.ToList().Select(x => CreateRequiredSkill(x)).ToList();

            //teamSummary.Skills = 

            return teamSummary;
        }

        public static RequiredSkill CreateRequiredSkill(ProjectSkill projectSkill)
        {
            return new RequiredSkill()
            {
                Skill = projectSkill.Tool.Name,
                Level = (int)projectSkill.Level
            };
        }

        public static TeamSkillSummary CreateTeamSkillSummary(IGrouping<int, ProjectSkill> x)
        {
            return new TeamSkillSummary()
            {
                //AverageLevel = 
            };
        }

    }
}