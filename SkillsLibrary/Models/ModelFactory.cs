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

        public EmployeeEducationModel Create(EmployeeEducation empEdu)
        {
            return new EmployeeEducationModel()
            {
                Id = empEdu.Id,
                Employee = empEdu.Employee.Id,
                EmployeeName = empEdu.Employee.FirstName + " " + empEdu.Employee.LastName,
                Education = empEdu.Education.Id,
                EducationName = empEdu.Education.Name,
                Reference = empEdu.Reference
            };
        }

        public ProjectSkillModel Create(ProjectSkill projSkill)
        {
            return new ProjectSkillModel()
            {
                Id = projSkill.Id,
                Project = projSkill.Team.Id,
                TeamName = projSkill.Team.Name,
                ProjectName = projSkill.Team.Description,
                Tool = projSkill.Tool.Id,
                ToolName = projSkill.Tool.Name,
                Level = projSkill.Level
            };
        }

        public ToolModel Create(Tool tool)
        {
            return new ToolModel()
            {
                Id = tool.Id,
                Name = tool.Name,
                Category = tool.Category.Id,
                CategoryName = tool.Category.Name
            };
        }
    }
}