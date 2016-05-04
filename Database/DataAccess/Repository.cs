﻿using System.Data.Entity;
using System.Linq;

namespace Database
{
    public class Repository<Entity> : Interface<Entity> where Entity : class
    {
        protected SchoolContext context;
        protected DbSet<Entity> dbSet;

        public Repository(SchoolContext _context)
        {
            context = _context;
            dbSet = context.Set<Entity>();
        }

        public SchoolContext BaseContext()
        {
            return context;
        }

        public IQueryable<Entity> Get()
        {
            return dbSet.AsQueryable();
        }

        public Entity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(Entity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(Entity entity, int id)
        {
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                if (entity.GetType() == typeof(Asset)) ChangeUser(oldEntity as Asset, entity as Asset);
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

        static void ChangeUser(Asset old, Asset newe)
        {
            old.User = newe.User;
        }
    }
}