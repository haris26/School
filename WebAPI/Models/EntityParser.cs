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

        public EmployeeSkill Create(EmployeeSkillModel model, SchoolContext context)
        {
            return new EmployeeSkill()
            {
                Id = model.Id,
                Employee = context.People.Find(model.Employee),
                Tool = context.Tools.Find(model.Tool),
                Level = model.Level,
                Experience = model.Experience,
                Date = model.Date,
                AssessedBy = model.AssessedBy
            };
        }
    }
}