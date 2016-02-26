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
    }
}
