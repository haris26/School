using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AssetCharNamesUnit : Repository<AssetCharacteristicNames>
    {
        public AssetCharNamesUnit(SchoolContext context) : base(context)
        { }
        public override void Insert(AssetCharacteristicNames entity)

        {
            context.AssetCharNames.Add(entity);
            context.Entry(entity.AssetCategory).State = EntityState.Unchanged;
            context.SaveChanges();
        }
    }
}