using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataAccess
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
