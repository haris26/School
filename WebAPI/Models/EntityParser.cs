using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EntityParser
    {
        private SchoolContext context;

        public EntityParser(SchoolContext _context)
        {
            context = _context;
        }
       
        public Resource Create(ResourceModel model)

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