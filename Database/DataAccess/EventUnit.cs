using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class EventUnit : Repository<Event>
    {
        public EventUnit(SchoolContext context) : base(context) {}

        public override void Insert(Event e)
        {
            context.Events.Add(e);
            context.Entry(e.Resource).State = EntityState.Unchanged;
            context.Entry(e.User).State = EntityState.Unchanged;
            e.Resource.Status = ReservationStatus.Reserved;
            context.SaveChanges();
        }

        public override void Update(Event entity, int id)
        {
            Event oldEvent = Get(id);
            oldEvent.Resource.Status = ReservationStatus.Available;
            if (oldEvent != null)
            {
                context.Entry(oldEvent).CurrentValues.SetValues(entity);
                oldEvent.User = entity.User;
                oldEvent.Resource = entity.Resource;
                oldEvent.Resource.Status = ReservationStatus.Reserved;
                context.SaveChanges();
            }
        }
    }
}
