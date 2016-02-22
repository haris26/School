using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ExtendedEventUnit : Repository<ExtendedEvent>
    {
        public ExtendedEventUnit(SchoolContext context) : base(context)
        {

        }

        public void Insert(ExtendedEvent exEvent)
        {
            context.ExtendedEvents.Add(exEvent);
            context.Entry(exEvent.ParentEvent).State = EntityState.Unchanged;
            context.SaveChanges();
        }
    }
}
