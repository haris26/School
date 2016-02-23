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
    }
}
