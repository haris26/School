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

    

        public override void Insert(AssetCharacteristicNames assetCharName)
        {
         
            context.AssetCharNames.Add(assetCharName);
            context.Entry(assetCharName.AssetCategory).State = EntityState.Unchanged;

            context.SaveChanges();

        }

    }
}







