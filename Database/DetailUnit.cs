using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Database
{
    public class DetailUnit : Repository<Detail>
    {
<<<<<<< HEAD
        public DetailUnit(SchoolContext context): base(context) { }
        

        public override void Insert(Detail entity) 
=======
        public DetailUnit(SchoolContext context) : base(context) { }


        public override void Insert(Detail entity)
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
        {
            context.Details.Add(entity);
            context.Entry(entity.Day).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;

            context.SaveChanges();

        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> e1cd4b7cd8f69542dd1ae3ce1cd6cc30dd0605ea
