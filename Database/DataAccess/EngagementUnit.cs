using System.Data.Entity;

namespace Database
{
    public class EngagementUnit : Repository<Engagement>
    {
        public EngagementUnit(SchoolContext context): base(context)
        { }

        public override void Insert(Engagement entity)
        {
            dbSet.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;
            context.Entry(entity.Role).State = EntityState.Unchanged;
            context.SaveChanges();
        }

        public override void Update(Engagement entity, int id)
        {
            Engagement oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Person = entity.Person;
                oldEnt.Team = entity.Team;
                oldEnt.Role = entity.Role;
                context.SaveChanges();
            }
        }
    }
}
