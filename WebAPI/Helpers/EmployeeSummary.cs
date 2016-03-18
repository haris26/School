using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using Database;

namespace WebAPI.Helpers
{
    public static class EmployeeSummary
    {

       public static EmployeeSummaryModel Create (Person person)
        {
            EmployeeSummaryModel employeeSummary = new EmployeeSummaryModel()
            {
                Id = person.Id,
                FullName = person.FullName
            };

            employeeSummary.Engagements = person.Roles.Where(x => x.EndDate == null && x.Time>0).ToList()
                                                      .Select(x => CreateEngagementDetail(x)).ToList();

            employeeSummary.PastProjects = person.Roles.Where(x => x.EndDate != null).ToList()
                                                        .Select(x => CreateEngagementDetail(x)).ToList();

            employeeSummary.Qualifications = person.EmployeeEducations.ToList()
                                                    .Select(x => new EmployeeEducationDetail()
                                                    {
                                                        Qualification = x.Education.Name
                                                    }).ToList();

            employeeSummary.Skills = person.EmployeeSkills
                                           .GroupBy(x => x.Tool.Category)
                                           .Select(x => CreateEmployeeSkillsSummary(x)).ToList();

            return employeeSummary;
        }

        public static EngagementDetail CreateEngagementDetail(Engagement engagement)
        {
            return new EngagementDetail()
            {
                Team = engagement.Team.Name,
                Role = engagement.Role.Name,
                Description = engagement.Team.Description
            };
        }

        public static EmployeeSkillsSummary CreateEmployeeSkillsSummary(IGrouping<SkillCategory, EmployeeSkill> x)
        {
            return new EmployeeSkillsSummary()
            {
                CategoryName = x.Key.Name,
                Skills = x.ToList()
                          .GroupBy(y => y.Tool.Name)
                          .Select(y => y.ToList().OrderBy(z => z.Date).FirstOrDefault()).ToList()
                          .Select(y => CreateEmployeeSkillDetail(y)).ToList()
            };
        }

        public static EmployeeSkillDetail CreateEmployeeSkillDetail (EmployeeSkill skill)
        {
            return new EmployeeSkillDetail()
            {
                Skill = skill.Tool.Name,
                Level = (int)skill.Level,
                Experience = skill.Experience
            };
        }
    }
}