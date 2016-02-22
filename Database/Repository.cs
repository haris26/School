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
<<<<<<< HEAD
<<<<<<< HEAD
        public SchoolContext context = new SchoolContext();
        public DbSet<Entity> dbSet;

        public Repository(SchoolContext _context) {
            context = _context;
=======
<<<<<<< HEAD
        public SchoolContext context;
        public DbSet<Entity> dbSet;

        public Repository(SchoolContext _context)
        {
            context = _context;
=======
        SchoolContext context = new SchoolContext();
        public DbSet<Entity> dbSet;

        public Repository() {
>>>>>>> delta
>>>>>>> 5b9a0b4eebc14ef3dad363b1fae91bd1ec1f84d9
            dbSet = context.Set<Entity>();
=======
        public SchoolContext context = new SchoolContext();
        public DbSet<Entity> dbSet;

        public Repository(SchoolContext _context)
        {
            context = _context;
            dbSet = _context.Set<Entity>();
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
        }

        public Repository()
        {
        }

        public IQueryable<Entity> Get()
        {
            return dbSet.AsQueryable();
        }
<<<<<<< HEAD
<<<<<<< HEAD
      
=======

>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
        public Entity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(Entity entity)
        {
<<<<<<< HEAD
=======

        public Entity Get(int id) {
            return dbSet.Find(id); //find po prim keyu return context.Teams.Where(x => x.Id == id).FirstOrDefault();
                                     
        }
       public virtual void Insert(Entity entity) {
>>>>>>> delta
=======
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
            dbSet.Add(entity);
            context.SaveChanges();
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public void Update(Entity entity, int id)
        {
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
=======
        public void Update(Entity entity, int id) {
=======
        public void Update(Entity entity, int id)
        {
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
            Entity oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
>>>>>>> delta
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
<<<<<<< HEAD
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                dbSet.Remove(oldEntity);
                context.SaveChanges();
            }
        }
=======
            Entity oldEnt = Get(id);
            if (oldEnt != null)
            {
                dbSet.Remove(oldEnt);
                context.SaveChanges();
            }
<<<<<<< HEAD

        }


>>>>>>> delta
=======
        }
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
    }
}