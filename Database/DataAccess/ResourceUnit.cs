﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ResourceUnit : Repository<Resource>
    {

        public ResourceUnit(SchoolContext context) : base(context)
        { }

        public override void Insert(Resource resource)
        {
            context.Resources.Add(resource);
            context.Entry(resource.ResourceCategory).State = EntityState.Unchanged;
            context.SaveChanges();
        }
        public override void Update(Resource entity, int id)
        {
            Resource oldResource = Get(id);
            if (oldResource != null)
            {
                context.Entry(oldResource).CurrentValues.SetValues(entity);
                oldResource.ResourceCategory = entity.ResourceCategory;
                context.SaveChanges();
            }
        }
    }
}
