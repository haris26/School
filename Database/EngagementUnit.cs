using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class EngagementUnit : Repository<Engagement>
    {

        public EngagementUnit(SchoolContext context) : base(context) { }

        public override void Insert(Engagement entity)
        {
            context.Engagements.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;
            context.Entry(entity.Role).State = EntityState.Unchanged;
            context.SaveChanges();
        }
    }
}
