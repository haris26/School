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
                Name = team.Name
            };

            var distinctMembers = team.Roles.Where(x => x.EndDate == null)
                                            .GroupBy(x => x.Person)
                                            .Select(x => x.Key)
                                            .ToList();

            teamSummary.Members = distinctMembers.Select(x => new PersonModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();

            teamSummary.PeopleInTeam = teamSummary.Members.Count();

            var memberSkills = distinctMembers.Select(x => x.EmployeeSkills.GroupBy(y => y.Tool.Name)
                                                                           .Select(y => y.ToList().Where(z => z.AssessedBy == AssessmentType.Supervisor)
                                                                           .OrderByDescending(z => z.DateOfSupervisorAssessment)
                                                                           .FirstOrDefault()).ToList()).ToList();

            IList<EmployeeSkill> allSkills = new List<EmployeeSkill>();

            foreach(var memberSkill in memberSkills)
            {
                foreach (var skill in memberSkill)
                    allSkills.Add(skill);
            }


            teamSummary.Skills = allSkills.GroupBy(x => x.Tool.Category)
                                          .Select(x => CreateCategorySkillSummary(x)).ToList();

            teamSummary.RequiredSkills = team.ProjectSkills.ToList().Select(x => CreateRequiredSkill(x)).ToList();

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

        public static CategorySkillsSummary CreateCategorySkillSummary(IGrouping<SkillCategory, EmployeeSkill> categorySkills)
        {
            CategorySkillsSummary categorySkillSummary = new CategorySkillsSummary()
            {
                CategoryName = categorySkills.Key.Name,
                AvgSkillLevel = categorySkills.Average(x => (int)x.Level),
                NumberOfSkills = categorySkills.GroupBy(x => x.Tool.Id).ToList().Count()
            };

            categorySkillSummary.AvailableSkills = categorySkills.GroupBy(x => x.Tool)
                                       .Select(x => new AvailableSkill() { Id = x.Key.Id, Name = x.Key.Name })
                                       .ToList();

            //group skills per employee, in order to calculate average per employee
            var skillsPerEmployee = categorySkills.GroupBy(x => x.Employee.Id).ToList();

            //for each employee, calculate the average
            foreach (var employeeSkillsList in skillsPerEmployee)
            {
                categorySkillSummary.EmployeeSkillAverage.Add(employeeSkillsList.Key, employeeSkillsList.Average(x => (int)x.Level));
            }

            //group skills per tool
            var skillsPerTool = categorySkills.GroupBy(x => x.Tool.Id).ToList();

            foreach (var skills in skillsPerTool)
            {
                categorySkillSummary.Skills.Add(skills.Key, CreateTeamSkillSummary(skills.ToList()));
            }

            return categorySkillSummary;
        }

        public static TeamSkillSummary CreateTeamSkillSummary(List<EmployeeSkill> skills)
        {
            TeamSkillSummary teamSkillSummary = new TeamSkillSummary()
            {
                AverageLevel = skills.Average(x => (int)x.Level)
            };

            //group skills per employee
            var skillsPerEmployee = skills.GroupBy(x => x.Employee.Id).ToList();

            foreach(var skill in skillsPerEmployee)
            {
                var employeeSkill = skill.FirstOrDefault();
                teamSkillSummary.MemberSkills.Add(skill.Key, new EmployeeSkillDetail() { Skill = employeeSkill.Tool.Name,
                                                                                         Level = (int)employeeSkill.Level,
                                                                                         Experience = employeeSkill.Experience });
            }

            return teamSkillSummary;
        }

    }
}