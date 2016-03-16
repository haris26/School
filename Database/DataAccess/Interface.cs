using System.Linq;

namespace Database
{
    public interface Interface<Entity>
    {
        SchoolContext BaseContext();
        IQueryable<Entity> Get();
        Entity Get(int id);
        void Insert(Entity entity);
        void Update(Entity entity, int id);
        void Delete(int id);
    }
}
