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
    }
}