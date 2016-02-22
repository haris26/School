<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System.Data.Entity;
>>>>>>> delta

namespace Database
{
    public class EngagementUnit : Repository<Engagement>
    {
<<<<<<< HEAD
        public EngagementUnit(SchoolContext context) : base(context)
        { }
=======

        public SchoolContext context = new SchoolContext();
>>>>>>> delta

        public override void Insert(Engagement entity)
        {
            context.Engagements.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;
            context.Entry(entity.Role).State = EntityState.Unchanged;
            context.SaveChanges();
<<<<<<< HEAD
=======

>>>>>>> delta
        }
    }
}
