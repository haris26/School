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
<<<<<<< HEAD
}
=======
}
>>>>>>> af0afc48dfe75ce3413c01c03aad5c284773faf2
