using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EntityParser
    {
        public Resource Create(ResourceModel model, SchoolContext context)

        {
            return new Resource()
            {
                Id = model.Id,
                Name = model.Name,
                Status = model.Status,
                ResourceCategory = context.ResourceCategories.Find(model.ResourceCategory)
            };
        }
    }
}