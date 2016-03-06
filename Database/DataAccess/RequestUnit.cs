using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Database
{
    public class RequestUnit : Repository<Request>
    {
        public RequestUnit(SchoolContext context) : base(context)
        {

        }

        public override void Insert(Request entity)
        {

            context.Requests.Add(entity);
            context.Entry(entity.User).State = EntityState.Unchanged;
            context.Entry(entity.Asset).State = EntityState.Unchanged;

            context.SaveChanges();
        }
        public override void Update(Request entity, int id)
        {
            Request oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.User = entity.User;
                oldEnt.Asset = entity.Asset;
                context.SaveChanges();
            }
        }
    }
}
