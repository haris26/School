using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EntityParser
    {

        public Tool Create(ToolModel model, SchoolContext context)
        {
            return new Tool()
            {
                Id = model.Id,
                Name = model.Name,
                Category = context.SkillCategories.Find(model.Category)
            };
        }

        public ProjectSkill Create(ProjectSkillModel model, SchoolContext context)
        {
            return new ProjectSkill()
            {
                Id = model.Id,
                Team = context.Teams.Find(model.Team),
                Tool = context.Tools.Find(model.Tool),
                Level = model.Level
            };
        }

        public EmployeeSkill Create(EmployeeSkillModel model, SchoolContext context)
        {
            return new EmployeeSkill()
            {
                Id = model.Id,
                Employee = context.People.Find(model.Employee),
                Tool = context.Tools.Find(model.Tool),
                Level = model.Level,
                Experience = model.Experience,
                DateOfSelfAssessment = model.DateOfSelfAssessment,
                DateOfSupervisorAssessment = model.DateOfSupervisorAssessment,
                AssessedBy = model.AssessedBy
            };
        }

        public EmployeeEducation Create(EmployeeEducationModel model, SchoolContext context)
        {
            return new EmployeeEducation()
            {
                Id = model.Id,
                Employee = context.People.Find(model.Employee),
                Education = context.Educations.Find(model.Education),
                Reference = model.Reference
            };
        }
    }
}