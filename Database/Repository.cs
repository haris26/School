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
        public SchoolContext context;
        public DbSet<Entity> dbSet;

        public Repository(SchoolContext _context)
        {
            context = _context;
            dbSet = _context.Set<Entity>();
        } 


        public IQueryable<Entity> Get()
        {
            return dbSet.AsQueryable();
        }

        //find entity by id
        public Entity Get(int Id)
        {
            return dbSet.Find(Id);
        }

        //insert entity in database 
        public virtual void Insert(Entity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(Entity entity, int Id)
        {
            Entity oldEntity = Get(Id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }

        }

        public void Delete(int Id)
        {
            Entity oldEntity = Get(Id);
            if (oldEntity != null)
            {
                dbSet.Remove(oldEntity);
                context.SaveChanges();
            }

        }
    }
}