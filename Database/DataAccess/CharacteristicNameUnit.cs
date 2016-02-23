using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class CharacteristicNameUnit : Repository<CharacteristicName>
    {
        public CharacteristicNameUnit(SchoolContext context) : base(context)
        {

        }
        public override void Insert(CharacteristicName entity)
        {
            context.CharacteristicNames.Add(entity);
            context.Entry(entity.ResourceCategory).State = EntityState.Unchanged;
            context.SaveChanges();
        }
    }
}
