using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class ModelFactory
    {
        public TeamModel Create(Team team)
        {
            TeamModel model = new TeamModel()
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                Type = team.Type.ToString()
            };
            foreach (var person in team.Roles)
            {
                model.Members.Add(person.Person.FirstName + " " + person.Person.LastName);
            }
            return model;
        }

        public EngagementModel Create(Engagement engagement)
        {
            return new EngagementModel()
            {
                Id = engagement.Id,
                StartDate = engagement.StartDate,
                EndDate = engagement.EndDate,
                Time = engagement.Time,
                Person = engagement.Person.Id,
                PersonName = engagement.Person.FirstName + " " + engagement.Person.LastName,
                Team = engagement.Team.Id,
                TeamName = engagement.Team.Name,
                Role = engagement.Role.Id,
                RoleName = engagement.Role.Name
            };
        }

        public EmployeeSkillModel Create (EmployeeSkill empSkill)
        {
            return new EmployeeSkillModel()
            {
                Id = empSkill.Id,
                Employee = empSkill.Employee.Id,
                EmployeeName = empSkill.Employee.FirstName + " " + empSkill.Employee.LastName,
                Tool = empSkill.Tool.Id,
                ToolName = empSkill.Tool.Name,
                Level = empSkill.Level,
                Experience = empSkill.Experience
            };
        }
    }
}