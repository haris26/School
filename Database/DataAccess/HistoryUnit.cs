using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Database
{
    public class HistoryUnit : Repository<History>
    {
        public HistoryUnit(SchoolContext context) : base(context)
        {

        }

        public override void Insert(History entity)
        {
            context.Histories.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.Entry(entity.Asset).State = EntityState.Unchanged;
            context.SaveChanges();
        }
        public override void Update(History entity, int id)
        {
            History oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Person = entity.Person;
                oldEnt.Asset = entity.Asset;
                context.SaveChanges();
            }
        }
    }
}
