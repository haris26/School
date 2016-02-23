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

        public DetailUnit(SchoolContext context) : base(context) { }


        public override void Insert(Detail entity)

        {
            context.Details.Add(entity);
            context.Entry(entity.Day).State = EntityState.Unchanged;
            context.Entry(entity.Team).State = EntityState.Unchanged;

            context.SaveChanges();

        }
    }
}
