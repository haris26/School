using System.Data.Entity;

namespace Database
{
    public class ToolUnit : Repository<Tool>
    {
        public ToolUnit(SchoolContext context) : base (context)
        { }

        public override void Insert(Tool entity)
        {
            context.Tools.Add(entity);
            context.Entry(entity.Category).State = EntityState.Unchanged;
            context.SaveChanges();
        }

        public override void Update(Tool entity, int id)
        {
            Tool oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Category = entity.Category;
                context.SaveChanges();
            }
        }
    }
}
