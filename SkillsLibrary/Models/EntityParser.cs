using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsLibrary.Models
{
    public class EntityParser
    {
        private SchoolContext context;

        public EntityParser()
        { }

        public EntityParser(SchoolContext ctx)
        {
            context = ctx;
        }

        public Engagement Create(EngagementModel model)
        {
            return new Engagement()
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Time = model.Time,
                Person = context.People.Find(model.Person),
                Team = context.Teams.Find(model.Team),
                Role = context.Roles.Find(model.Role)
            };
        }

        public EmployeeSkill Create (EmployeeSkillModel model)
        {
            return new EmployeeSkill()
            {
                Id = model.Id,
                Employee = context.People.Find(model.Employee),
                Tool = context.Tools.Find(model.Tool),
                Level = model.Level,
                Experience = model.Experience
            };
        }

        public EmployeeEducation Create(EmployeeEducationModel model)
        {
            return new EmployeeEducation()
            {
                Id = model.Id,
                Employee = context.People.Find(model.Employee),
                Education = context.Educations.Find(model.Education),
                Reference = model.Reference
            };
        }

        public ProjectSkill Create(ProjectSkillModel model)
        {
            return new ProjectSkill()
            {
                Id = model.Id,
                Team = context.Teams.Find(model.Project),
                Tool = context.Tools.Find(model.Tool),
                Level = model.Level
            };
        }

        public Tool Create(ToolModel model)
        {
            return new Tool()
            {
                Id = model.Id,
                Name = model.Name,
                Category = context.SkillCategories.Find(model.Category)
            };
        }

        public Person Create (PersonModel model)
        {
            return new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Category = model.Category,
                Phone = model.Phone,
                Status = model.Status
            };
        }
    }
}