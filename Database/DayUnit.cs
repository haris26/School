using System.Data.Entity;

namespace Database
{
    public class DayUnit: Repository<Day>
    {
<<<<<<< HEAD
        

        public DayUnit(SchoolContext context): base(context) { }
=======
        public DayUnit(SchoolContext context) : base(context) { }
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea

        public override void Insert(Day entity)
        {
            
            context.Days.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
 
            context.SaveChanges();

        }
    }
}
