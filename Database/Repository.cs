using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Repository<Entity> where Entity : class
    {
        SchoolContext context = new SchoolContext();
        DbSet<Entity> dbSet;

        public Repository()
        {
            dbSet = context.Set<Entity>();
        }

        public IQueryable<Entity> Get()
        {
            return dbSet.AsQueryable();
        }

        public Entity Get (int id)
        {
            return dbSet.Find(id);
        }

        public void Insert (Entity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(Entity entity, int id)
        {
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                dbSet.Remove(oldEntity);
                context.SaveChanges();
            }
        }
    }
}
