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
<<<<<<< HEAD
    public class EngagementUnit : Repository<Engagement>
    {
<<<<<<< HEAD
        public EngagementUnit(SchoolContext context) : base(context)
        { }
=======

        public SchoolContext context = new SchoolContext();
>>>>>>> delta
=======
    public class EngagementUnit: Repository<Engagement>
    {

        public EngagementUnit(SchoolContext context) : base(context) { }
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea

        public override void Insert(Engagement entity)
        {
            context.Engagements.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;
            context.Entry(entity.Role).State = EntityState.Unchanged;
            context.SaveChanges();
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> delta
=======
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
        }
    }
}
