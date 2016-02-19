using System.Data.Entity;

namespace Database
{
    public class EngagementUnit : Repository<Engagement>
    {

        public SchoolContext context = new SchoolContext();

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
