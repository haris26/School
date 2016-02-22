using System.Data.Entity;

namespace Database
{
<<<<<<< HEAD
    public class EngagementUnit : Repository<Engagement>
    {

<<<<<<< HEAD
        public SchoolContext context = new SchoolContext();
>>>>>>> delta
=======
    public class EngagementUnit: Repository<Engagement>
    {

        public EngagementUnit(SchoolContext context) : base(context) { }
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
=======
        public EngagementUnit(SchoolContext context) : base(context) { }
>>>>>>> dev

        public override void Insert(Engagement entity)
        {
            context.Engagements.Add(entity);
            context.Entry(entity.Person).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;
            context.Entry(entity.Role).State = EntityState.Unchanged;
            context.SaveChanges();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> delta
=======
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
=======
>>>>>>> dev
        }
    }
}