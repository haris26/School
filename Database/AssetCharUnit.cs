using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AssetCharUnit : Repository<AssetChar>
    {
        public AssetCharUnit(SchoolContext context) : base(context)
        {

        }
        public override void Insert(AssetChar assetChar)
        {
            context.AssetCharacteristics.Add(assetChar);
            context.Entry(assetChar.Asset).State = EntityState.Unchanged;

            context.SaveChanges();

        }

    }
}







