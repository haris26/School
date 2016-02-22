using System.Data.Entity;

namespace Database
{
    public class DayUnit : Repository<Day>
    {
        public SchoolContext context = new SchoolContext();

        public override void Insert(Day entity)
        {
            context.Days.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
 
            context.SaveChanges();

        }
    }
}
