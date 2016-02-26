using System.Data.Entity;

namespace Database
{
    public class DayUnit: Repository<Day>
    {
        public DayUnit(SchoolContext context) : base(context) { }

        public override void Insert(Day entity)
        {
            context.Days.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.SaveChanges();
        }

        public override void Update(Day entity, int id)
        {
            Day oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Person = entity.Person;
                context.SaveChanges();
            }
        }
    }
}
