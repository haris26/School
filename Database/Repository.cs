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
<<<<<<< HEAD
=======
>>>>>>> dev
        public SchoolContext context = new SchoolContext();
        public DbSet<Entity> dbSet;

        public Repository(SchoolContext _context)
        {
            context = _context;
<<<<<<< HEAD
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
=======
            dbSet = _context.Set<Entity>();
>>>>>>> dev
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
<<<<<<< HEAD
      
=======

>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
=======

>>>>>>> dev
        public Entity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(Entity entity)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======

        public Entity Get(int id) {
            return dbSet.Find(id); //find po prim keyu return context.Teams.Where(x => x.Id == id).FirstOrDefault();
                                     
        }
       public virtual void Insert(Entity entity) {
>>>>>>> delta
=======
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
=======
>>>>>>> dev
            dbSet.Add(entity);
            context.SaveChanges();
        }

<<<<<<< HEAD
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
=======
        public void Update(Entity entity, int id)
        {
>>>>>>> dev
            Entity oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Entity oldEnt = Get(id);
            if (oldEnt != null)
            {
                dbSet.Remove(oldEnt);
                context.SaveChanges();
            }
<<<<<<< HEAD
<<<<<<< HEAD

        }


>>>>>>> delta
=======
        }
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
=======
        }
>>>>>>> dev
    }
}